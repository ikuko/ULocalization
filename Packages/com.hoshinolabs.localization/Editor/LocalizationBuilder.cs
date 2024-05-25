using HoshinoLabs.Localization.Udon;
using HoshinoLabs.Sardinject;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UdonSharp;
using UdonSharpEditor;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Tables;
using UnityEngine.SceneManagement;
using VRC.SDK3.Data;

namespace HoshinoLabs.Localization {
    internal sealed class LocalizationBuilder : IProcessSceneWithReport {
        public int callbackOrder => -100;

        GameObject go;
        GameObject startupSelectorGo;

        GameObject GetOrBuildGO() {
            if (go == null) {
                go = new GameObject($"__{GetType().Namespace.Replace('.', '_')}__");
                go.hideFlags = HideFlags.HideInHierarchy;
            }

            return go;
        }

        GameObject GetOrBuildStartupSelectorGO() {
            if (startupSelectorGo == null) {
                var go = GetOrBuildGO();

                startupSelectorGo = new GameObject($"__StartupLocaleSelectors__");
                startupSelectorGo.transform.SetParent(go.transform);
            }

            return startupSelectorGo;
        }

        Udon.IStartupLocaleSelector GetOrBuildStartupLocaleSelectorUdon(Type binder, object startupLocaleSelector) {
            var go = GetOrBuildStartupSelectorGO();

            var startupSelectorGo = new GameObject($"{binder.Name}");
            startupSelectorGo.transform.SetParent(go.transform);

            var udon = (Udon.IStartupLocaleSelector)startupSelectorGo.AddUdonSharpComponentEx(binder, false);

            var initializer = binder.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
                .Where(x => x.IsDefined(typeof(BindStartupLocaleSelectorInitializer)))
                .Where(x => x.GetParameters().Length == 2)
                .FirstOrDefault();
            if (initializer != null) {
                initializer.Invoke(null, new object[] { udon, startupLocaleSelector });
            }

            return udon;
        }

        public void OnProcessScene(Scene scene, BuildReport report) {
            if (!LocalizationSettings.HasSettings) {
                return;
            }

            var variableData = BuildVariableData();
            var groupData = BuildGroupData();

            ProjectContext.Enqueue(builder => {
                builder.AddOnNewGameObject(
                    LocalizationTypeResolver.ImplementationType,
                    Lifetime.Cached,
                    $"{LocalizationTypeResolver.ImplementationType.Name}"
                )
                    .As<ILocalization>()
                    .UnderTransform(GetOrBuildGO().transform)
                    .WithParameter("startupSelectors", BuildStartupSelectors())
                    .WithParameter("availableLocales", BuildAvailableLocales())
                    .WithParameter("stringDatabase", BuildStringDatabase())
                    .WithParameter("assetDatabase", BuildAssetDatabase())
                    .WithParameter("projectLocale", LocalizationSettings.ProjectLocale?.Identifier.Code)
                    .WithParameter("variables_0", variableData._0)
                    .WithParameter("variables_1", variableData._1)
                    .WithParameter("groups_0", groupData._0)
                    .WithParameter("groups_1", groupData._1)
                    .WithParameter("groups_2", groupData._2)
                    .WithParameter("groups_3", groupData._3)
                    .WithParameter("groups_4_0", groupData._4._0)
                    .WithParameter("groups_4_1", groupData._4._1)
                    .WithParameter("groups_4_2", groupData._4._2)
                    .WithParameter("groups_4_3", groupData._4._3);
                builder.AddEntryPoint<ILocalization>();
            });
        }

        Udon.IStartupLocaleSelector[] BuildStartupSelectors() {
            return LocalizationSettings.StartupLocaleSelectors
                .Select(startupLocaleSelector => (
                    startupLocaleSelector,
                    binder: AppDomain.CurrentDomain.GetAssemblies()
                        .Select(assembly => {
                            return assembly.GetTypes()
                                .Where(x => x.IsSubclassOf(typeof(Udon.IStartupLocaleSelector)))
                                .Where(x => x.IsSubclassOf(typeof(UdonSharpBehaviour)))
                                .Where(x => UdonSharpEditorUtility.GetUdonSharpProgramAsset(x) != null)
                                .Where(x => x.IsDefined(typeof(BindStartupLocaleSelectorAttribute)))
                                .Where(x => x.GetCustomAttribute<BindStartupLocaleSelectorAttribute>().BindTo == startupLocaleSelector.GetType());
                        })
                        .SelectMany(x => x)
                        .FirstOrDefault()
                ))
                .Where(x => x.binder != null)
                .Select(x => GetOrBuildStartupLocaleSelectorUdon(x.binder, x.startupLocaleSelector))
                .ToArray();
        }

        string[] BuildAvailableLocales() {
            return LocalizationHelper.AvailableLocales
                .Select(x => x.Code)
                .ToArray();
        }

        string[][] BuildStringDatabase() {
            return LocalizationHelper.StringDatabase
                .Select(x => x.Select(x => x?.Value).ToArray())
                .ToArray();
        }

        object[][] BuildAssetDatabase() {
            return LocalizationHelper.AssetDatabase
                .Select(x => x.Select(x => x?.Value).ToArray())
                .ToArray();
        }

        (VariableType[] _0, object[] _1) BuildVariableData() {
            var variableData = LocalizationHelper.ReferenceVariableIds
                .Keys
                .Select(x => (
                    group: x.group as LocalizeStringEvent,
                    x.index
                ))
                .Select(x => x.group.StringReference.Values.ElementAt(x.index).ToVariable())
                .ToArray();
            return (
                variableData.Select(x => x.Type).ToArray(),
                variableData.Select(x => x.Value).ToArray()
            );
        }

        DataDictionary BuildGroupValues(LocalizeStringEvent localizeString) {
            var values = new DataDictionary();
            foreach (var (x, i) in localizeString.StringReference.Keys.Select((v, i) => (v, i))) {
                if (LocalizationHelper.ReferenceVariableIds.TryGetValue((localizeString, i), out var variableId)) {
                    values.Add(x, variableId);
                }
            }
            return values.Count == 0 ? null : values;
        }

        ListenerData BuildGroupListener(UnityEventExtensions.PersistentCall listener) {
            var target = listener.Target;
            if (typeof(UdonSharpBehaviour).IsAssignableFrom(target.GetType())) {
                target = UdonSharpEditorUtility.GetBackingUdonBehaviour((UdonSharpBehaviour)target);
            }
            var signature = default(string);
            var argument = default(object);
            switch (listener.Mode) {
                case PersistentListenerMode.EventDefined: {
                        signature = $"{MethodSignature.GetSignature(target.GetType(), listener.MethodName)}.0";
                        argument = null;
                        break;
                    }
                case PersistentListenerMode.Void: {
                        signature = MethodSignature.GetSignature(target.GetType(), listener.MethodName);
                        argument = null;
                        break;
                    }
                default: {
                        signature = $"{MethodSignature.GetSignature(target.GetType(), listener.MethodName)}.1";
                        argument = listener.Arguments.Value;
                        break;
                    }
            }
            if (target.GetType().IsAssignableToGenericType(typeof(IProxyTarget<>))) {
                target = (target as IProxyTarget).Target;
            }
            return new ListenerData(
                $"__{signature.ComputeHashMD5()}",
                target,
                argument
            );
        }

        ListenerData[] BuildGroupListeners(LocalizedMonoBehaviour behaviour, string property) {
            return UnityEventExtensions.GetPersistentCallGroup(behaviour, property)
                .GetListeners()
                .Where(x => x.Target && !string.IsNullOrEmpty(x.MethodName))
                .Where(x => UnityEventFilter.IsTargetPermitted(x.Target, x.MethodName))
                .Select(x => BuildGroupListener(x))
                .ToArray();
        }

        GroupData BuildInvalidGroupData() {
            return new GroupData(default, -1, default, new ListenerData[0]);
        }

        GroupData BuildGroupData(LocalizeStringEvent localizeString) {
            var localized = localizeString.StringReference;
            if (localized.TableReference.ReferenceType != TableReference.Type.Guid) {
                return BuildInvalidGroupData();
            }
            if (localized.TableEntryReference.ReferenceType != TableEntryReference.Type.Id) {
                return BuildInvalidGroupData();
            }
            var tableId = localized.TableReference.TableCollectionName;
            var entryId = localized.TableEntryReference.KeyId.ToString();
            LocalizationHelper.ReferenceStringIds.TryGetValue((tableId, entryId), out var assetId);
            var values = BuildGroupValues(localizeString);
            var listeners = BuildGroupListeners(localizeString, "m_UpdateString");
            return new GroupData(false, assetId, values, listeners);
        }

        GroupData BuildGroupData<T, U, V>(LocalizedAssetEvent<T, U, V> localizeAsset)
            where T : UnityEngine.Object
            where U : LocalizedAsset<T>, new()
            where V : UnityEvent<T>, new() {
            var localized = localizeAsset.AssetReference;
            if (localized.TableReference.ReferenceType != TableReference.Type.Guid) {
                return BuildInvalidGroupData();
            }
            if (localized.TableEntryReference.ReferenceType != TableEntryReference.Type.Id) {
                return BuildInvalidGroupData();
            }
            var tableId = localized.TableReference.TableCollectionName;
            var entryId = localized.TableEntryReference.KeyId.ToString();
            LocalizationHelper.ReferenceAssetIds.TryGetValue((tableId, entryId), out var assetId);
            var listeners = BuildGroupListeners(localizeAsset, "m_UpdateAsset");
            return new GroupData(true, assetId, null, listeners);
        }

        (int _0, bool[] _1, int[] _2, DataDictionary[] _3, (int[] _0, string[][] _1, object[][] _2, object[][] _3) _4) BuildGroupData() {
            var groupData = LocalizationHelper.ReferenceGroupIds
                .Keys
                .Select(x => {
                    switch (x) {
                        case LocalizeStringEvent localizeString: {
                                return BuildGroupData(localizeString);
                            }
                        case LocalizeAudioClipEvent localizeAudioClip: {
                                return BuildGroupData(localizeAudioClip);
                            }
                        case LocalizeTextureEvent localizeTexture: {
                                return BuildGroupData(localizeTexture);
                            }
                        case LocalizeSpriteEvent localizeSprite: {
                                return BuildGroupData(localizeSprite);
                            }
                        default: {
                                return BuildInvalidGroupData();
                            }
                    }
                })
                .ToArray();
            return (
                _0: groupData.Length,
                _1: groupData.Select(x => x.Mode).ToArray(),
                _2: groupData.Select(x => x.AssetId).ToArray(),
                _3: groupData.Select(x => x.Values).ToArray(),
                _4: (
                    _0: groupData.Select(x => x.Listeners).Select(x => x.Length).ToArray(),
                    _1: groupData.Select(x => x.Listeners).Select(x => x.Select(x => x.Hash).ToArray()).ToArray(),
                    _2: groupData.Select(x => x.Listeners).Select(x => x.Select(x => x.Target).ToArray()).ToArray(),
                    _3: groupData.Select(x => x.Listeners).Select(x => x.Select(x => x.Argument).ToArray()).ToArray()
                )
            );
        }
    }
}
