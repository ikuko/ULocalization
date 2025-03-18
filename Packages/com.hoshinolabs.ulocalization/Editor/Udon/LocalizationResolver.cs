using HoshinoLabs.Sardinject;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using UdonSharp;
using UdonSharpEditor;
using UnityEditor;
using UnityEditor.Localization;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;
using VRC.SDK3.Data;

namespace HoshinoLabs.ULocalization.Udon {
    internal sealed class LocalizationResolver : IBindingResolver {
        public readonly ComponentDestination Destination;

        static GameObject rootGo;
        static Localization localization;

        public LocalizationResolver(ComponentDestination destination) {
            Destination = destination;
        }

        [InitializeOnLoadMethod]
        static void OnLoad() {
            UnityInjector.OnSceneContainerBuilt -= SceneContainerBuilt;
            UnityInjector.OnSceneContainerBuilt += SceneContainerBuilt;
        }

        static void SceneContainerBuilt(Scene scene, Container container) {
            if (localization == null || !LocalizationSettings.HasSettings) {
                return;
            }

            var availableLocales = LocalizationSettings.AvailableLocales.Locales;
            var projectLocale = LocalizationSettings.ProjectLocale;

            var _0 = availableLocales
                .Select(x => x.Identifier.Code)
                .ToArray();
            var _1 = availableLocales
                .Select(x => x.Identifier.CultureInfo)
                .ToArray();
            var _2 = projectLocale?.Identifier.Code;
            var _3 = projectLocale?.Identifier.CultureInfo;

            var _4 = BuildStartupLocaleSelectors();

            var localizeEvents = BuildLocalizeEvents(scene);
            var localizeEventPersistentCalls = BuildLocalizeEventPersistentCalls(localizeEvents);

            var _localizeds = BuildLocalizeds();
            var localizeds = _localizeds
                .Select(x => x.Key)
                .ToList();
            var localizedRefs = _localizeds
                .Select(x => x.Value)
                .ToList();

            var _entries = BuildEntries(localizeds);
            var entryKeys = _entries
                .Select(x => x.Key)
                .ToList();
            var entryValues = _entries
                .Select(x => x.Value)
                .ToList();

            var _5 = availableLocales
                .Select(x => BuildEntryValues(entryValues, x))
                .ToArray();
            var _6 = availableLocales
                .Select(x => BuildEntryIsSmarts(entryValues, x))
                .ToArray();

            var _7 = localizeEvents.Count;
            var _8 = localizeEvents
                .Select(x => BuildLocalizeEventLocalized(x, localizedRefs))
                .ToArray();
            var _9 = localizeEventPersistentCalls
                .Select(x => BuildEventListenerCount(x))
                .ToArray();
            var _10 = localizeEventPersistentCalls
                .Select(x => BuildEventListenerMethods(x))
                .ToArray();
            var _11 = localizeEventPersistentCalls
                .Select(x => BuildEventListenerTargets(x))
                .ToArray();
            var _12 = localizeEventPersistentCalls
                .Select(x => BuildEventListenerArguments(x))
                .ToArray();

            var _13 = localizedRefs
                .Select(x => BuildLocalizedRefs(x, localizeEvents))
                .ToArray();
            var _14 = localizeds
                .Select(x => BuildLocalizedEntry(x, entryKeys))
                .ToArray();

            var _variables = BuildVariables();
            var variables = _variables
                .Select(x => x.Key)
                .ToList();
            var variableRefs = _variables
                .Select(x => x.Value)
                .ToList();

            var _15 = variables
                .Select(x => BuildVariableId(x))
                .ToArray();
            var _16 = variableRefs
                .Select(x => BuildVariableRefs(x, variables))
                .ToArray();
            var _17 = variables
                .Select(x => BuildVariableValue(x, localizeds, variables))
                .ToArray();

            var builder = new ContainerBuilder();
            builder.RegisterComponentInstance(localization)
                .As<Localization>()
                .WithParameter("_0", _0)
                .WithParameter("_1", _1)
                .WithParameter("_2", _2)
                .WithParameter("_3", _3)
                .WithParameter("_4", _4)
                .WithParameter("_5", _5)
                .WithParameter("_6", _6)
                .WithParameter("_7", _7)
                .WithParameter("_8", _8)
                .WithParameter("_9", _9)
                .WithParameter("_10", _10)
                .WithParameter("_11", _11)
                .WithParameter("_12", _12)
                .WithParameter("_13", _13)
                .WithParameter("_14", _14)
                .WithParameter("_15", _15)
                .WithParameter("_16", _16)
                .WithParameter("_17", _17);
            builder.Build()
                .Resolve<Localization>();
        }

        public object Resolve(Type type, Container container) {
            var _0 = Array.Empty<string>();
            var _1 = Array.Empty<CultureInfo>();
            var _2 = default(string);
            var _3 = default(CultureInfo);
            var _4 = Array.Empty<IStartupLocaleSelector>();
            var _5 = Array.Empty<object[]>();
            var _6 = Array.Empty<bool[]>();
            var _7 = 0;
            var _8 = Array.Empty<int>();
            var _9 = Array.Empty<int>();
            var _10 = Array.Empty<string[]>();
            var _11 = Array.Empty<object[]>();
            var _12 = Array.Empty<object[]>();
            var _13 = Array.Empty<DataList>();
            var _14 = Array.Empty<int>();
            var _15 = Array.Empty<string>();
            var _16 = Array.Empty<DataList>();
            var _17 = Array.Empty<object>();

            var builder = new ContainerBuilder();
            builder.RegisterComponentOnNewGameObject(
                typeof(Localization).GetCustomAttribute<Sardinject.Udon.ImplementationTypeAttribute>().ImplementationType,
                Lifetime.Transient,
                $"{typeof(Localization).Name}"
            )
                .As<Localization>()
                .UnderTransform(() => {
                    rootGo = Destination.Transform.Resolve<Transform>(container).gameObject;
                    return rootGo.transform;
                })
                .WithParameter("_0", _0)
                .WithParameter("_1", _1)
                .WithParameter("_2", _2)
                .WithParameter("_3", _3)
                .WithParameter("_4", _4)
                .WithParameter("_5", _5)
                .WithParameter("_6", _6)
                .WithParameter("_7", _7)
                .WithParameter("_8", _8)
                .WithParameter("_9", _9)
                .WithParameter("_10", _10)
                .WithParameter("_11", _11)
                .WithParameter("_12", _12)
                .WithParameter("_13", _13)
                .WithParameter("_14", _14)
                .WithParameter("_15", _15)
                .WithParameter("_16", _16)
                .WithParameter("_17", _17);
            localization = builder.Build()
                .Resolve<Localization>();
            return localization;
        }

        static IStartupLocaleSelector[] BuildStartupLocaleSelectors() {
            return LocalizationSettings.StartupLocaleSelectors
                .Select(startupLocaleSelector => {
                    var binder = TypeCache.GetTypesWithAttribute<BindStartupLocaleSelectorAttribute>()
                        .Where(x => x.GetCustomAttribute<BindStartupLocaleSelectorAttribute>().BindTo == startupLocaleSelector.GetType())
                        .FirstOrDefault();
                    return binder == null ? null : BuildStartupLocaleSelector(binder, startupLocaleSelector);
                })
                .Where(x => x != null)
                .ToArray();
        }

        static IStartupLocaleSelector BuildStartupLocaleSelector(Type binder, UnityEngine.Localization.Settings.IStartupLocaleSelector startupLocaleSelector) {
            var builder = new ContainerBuilder();
            builder.RegisterComponentOnNewGameObject(
                binder,
                Lifetime.Transient,
                $"{binder.Name}"
            )
                .As<IStartupLocaleSelector>()
                .UnderTransform(rootGo.transform)
                .WithParameter(startupLocaleSelector.GetType(), startupLocaleSelector);
            return builder.Build()
                .Resolve<IStartupLocaleSelector>();
        }

        static List<LocalizedMonoBehaviour> BuildLocalizeEvents(Scene scene) {
            var localizeEvents = scene.GetRootGameObjects()
                .SelectMany(x => x.GetComponentsInChildren<UnityEngine.Localization.Components.LocalizedMonoBehaviour>(true));
            foreach (var localizeEvent in localizeEvents) {
                switch (localizeEvent) {
                    case UnityEngine.Localization.Components.LocalizeStringEvent localizeStringEvent: {
                            LocalizeEventCache.AddOrGet(localizeStringEvent);
                            break;
                        }
                    case UnityEngine.Localization.Components.LocalizeAudioClipEvent localizeAudioClipEvent: {
                            LocalizeEventCache.AddOrGet(localizeAudioClipEvent);
                            break;
                        }
                    case UnityEngine.Localization.Components.LocalizeTextureEvent localizeTextureEvent: {
                            LocalizeEventCache.AddOrGet(localizeTextureEvent);
                            break;
                        }
                    case UnityEngine.Localization.Components.LocalizeSpriteEvent localizeSpriteEvent: {
                            LocalizeEventCache.AddOrGet(localizeSpriteEvent);
                            break;
                        }
                    case ULocalization.LocalizeDropdownEvent localizeDropdownEvent: {
                            LocalizeEventCache.AddOrGet(localizeDropdownEvent);
                            break;
                        }
                }
            }
            return LocalizeEventCache.GetAll()
                .Select(x => {
                    if (x.IsSupported()) {
                        return x;
                    }
                    Logger.LogWarning($"LocalizeEvent type {x.GetType()} is not supported.");
                    return default;
                })
                .ToList();
        }

        static List<KeyValuePair<LocalizedReference, HashSet<LocalizedMonoBehaviour>>> BuildLocalizeds() {
            var localizeds = new KeyValuePair<LocalizedReference, HashSet<LocalizedMonoBehaviour>>[IID.GetAll().Count()];
            LocalizedCache.GetAll()
                .ToList()
                .ForEach(x => {
                    if (x.Key.IsSupported()) {
                        localizeds[IID.GenerateId(x.Key)] = new(x.Key, x.Value.Where(x => x.IsSupported()).ToHashSet());
                    }
                    else {
                        Logger.LogWarning($"Localized type {x.GetType()} is not supported.");
                    }
                });
            return localizeds.ToList();
        }

        static List<KeyValuePair<long, ITableEntry>> BuildEntries(List<LocalizedReference> localizeds) {
            var stringEntries = LocalizationEditorSettings.GetStringTableCollections()
                .SelectMany(x => x.SharedData.Entries.Select(entry => new StringTableEntry(x.TableCollectionNameReference, entry.Id)))
                .ToDictionary(x => x.Id, x => x);
            var assetEntries = LocalizationEditorSettings.GetAssetTableCollections()
                .SelectMany(x => x.SharedData.Entries.Select(entry => new AssetTableEntry(x.TableCollectionNameReference, entry.Id)))
                .ToDictionary(x => x.Id, x => x);
            foreach (var localized in localizeds) {
                switch (localized) {
                    case UnityEngine.Localization.LocalizedString localizedString: {
                            if (!stringEntries.TryGetValue(localized.TableEntryReference.KeyId, out var entry)) {
                                var tableReference = localized.TableReference;
                                var tableEntryReference = localized.TableEntryReference;
                                var tableEntry = new StringTableEntry(tableReference, tableEntryReference);
                                stringEntries.Add(localized.TableEntryReference.KeyId, tableEntry);
                            }
                            break;
                        }
                    case LocalizedAssetBase localizedAsset: {
                            if (!assetEntries.TryGetValue(localized.TableEntryReference.KeyId, out var entry)) {
                                var tableReference = localized.TableReference;
                                var tableEntryReference = localized.TableEntryReference;
                                var tableEntry = new AssetTableEntry(tableReference, tableEntryReference);
                                assetEntries.Add(localized.TableEntryReference.KeyId, tableEntry);
                            }
                            break;
                        }
                }
            }
            var entries = new List<KeyValuePair<long, ITableEntry>>();
            foreach (var entry in stringEntries) {
                entries.Add(new(entry.Value.Id, entry.Value));
            }
            foreach (var entry in assetEntries) {
                entries.Add(new(entry.Value.Id, entry.Value));
            }
            return entries;
        }

        static object[] BuildEntryValues(List<ITableEntry> entryValues, Locale locale) {
            return entryValues
                .Select(x => x.GetValue(locale))
                .ToArray();
        }

        static bool[] BuildEntryIsSmarts(List<ITableEntry> entryValues, Locale locale) {
            return entryValues
                .Select(x => x.GetIsSmart(locale))
                .ToArray();
        }

        static List<KeyValuePair<UnityEngine.Localization.SmartFormat.PersistentVariables.IVariable, HashSet<UnityEngine.Localization.SmartFormat.PersistentVariables.IVariable>>> BuildVariables() {
            var variables = new KeyValuePair<UnityEngine.Localization.SmartFormat.PersistentVariables.IVariable, HashSet<UnityEngine.Localization.SmartFormat.PersistentVariables.IVariable>>[IID.GetAll().Count()];
            VariableCache.GetAll()
                .ToList()
                .ForEach(x => {
                    if (x.Key.IsSupported()) {
                        variables[IID.GenerateId(x.Key)] = new(x.Key, x.Value.Where(x => x.IsSupported()).ToHashSet());
                    }
                    else {
                        Logger.LogWarning($"Variable type {x.GetType()} is not supported.");
                    }
                });
            return variables.ToList();
        }

        static List<PersistentCallGroup> BuildLocalizeEventPersistentCalls(List<LocalizedMonoBehaviour> localizeEvents) {
            return localizeEvents
                .Select(x => {
                    switch (x) {
                        case UnityEngine.Localization.Components.LocalizeStringEvent localizeStringEvent: {
                                return BuildLocalizeEventPersistentCall(localizeStringEvent, "m_UpdateString");
                            }
                        case UnityEngine.Localization.Components.LocalizeAudioClipEvent localizeAudioClipEvent: {
                                return BuildLocalizeEventPersistentCall(localizeAudioClipEvent, "m_UpdateAsset");
                            }
                        case UnityEngine.Localization.Components.LocalizeTextureEvent localizeTextureEvent: {
                                return BuildLocalizeEventPersistentCall(localizeTextureEvent, "m_UpdateAsset");
                            }
                        case UnityEngine.Localization.Components.LocalizeSpriteEvent localizeSpriteEvent: {
                                return BuildLocalizeEventPersistentCall(localizeSpriteEvent, "m_UpdateAsset");
                            }
                        case ULocalization.LocalizeDropdownEvent localizeDropdownEvent: {
                                return BuildLocalizeEventPersistentCall(localizeDropdownEvent, "updateOptions");
                            }
                    }
                    return null;
                })
                .ToList();
        }

        static int BuildLocalizeEventLocalized(LocalizedMonoBehaviour localizeEvent, List<HashSet<LocalizedMonoBehaviour>> localizedRefs) {
            return localizedRefs
                .FindIndex(x => x?.Contains(localizeEvent) ?? false);
        }

        static PersistentCallGroup BuildLocalizeEventPersistentCall<T>(T localizeEvent, string propertyPath) where T : LocalizedMonoBehaviour {
            var serializedProperty = new SerializedObject(localizeEvent).FindProperty(propertyPath);
            return new PersistentCallGroup(serializedProperty);
        }

        static int BuildEventListenerCount(PersistentCallGroup localizeEventPersistentCall) {
            return localizeEventPersistentCall?.GetListeners()
                .Where(x => x.Target && !string.IsNullOrEmpty(x.MethodName))
                .Where(x => UnityEventFilter.IsTargetPermitted(x.Target, x.MethodName))
                .Count() ?? 0;
        }

        static string[] BuildEventListenerMethods(PersistentCallGroup localizeEventPersistentCall) {
            return localizeEventPersistentCall?.GetListeners()
                .Where(x => x.Target && !string.IsNullOrEmpty(x.MethodName))
                .Where(x => UnityEventFilter.IsTargetPermitted(x.Target, x.MethodName))
                .Select(x => {
                    var target = typeof(UdonSharpBehaviour).IsAssignableFrom(x.Target.GetType())
                        ? UdonSharpEditorUtility.GetBackingUdonBehaviour((UdonSharpBehaviour)x.Target)
                        : x.Target;
                    if (x.Mode == PersistentListenerMode.EventDefined) {
                        return $"{UnityEventFilter.GetSignature(target.GetType(), x.MethodName)}.__{x.Mode}";
                    }
                    return UnityEventFilter.GetSignature(target.GetType(), x.MethodName);
                })
                .Select(x => $"__{x.ComputeHashMD5()}")
                .ToArray();
        }

        static object[] BuildEventListenerTargets(PersistentCallGroup localizeEventPersistentCall) {
            return localizeEventPersistentCall?.GetListeners()
                .Where(x => x.Target && !string.IsNullOrEmpty(x.MethodName))
                .Where(x => UnityEventFilter.IsTargetPermitted(x.Target, x.MethodName))
                .Select(x => {
                    if (typeof(UdonSharpBehaviour).IsAssignableFrom(x.Target.GetType())) {
                        return UdonSharpEditorUtility.GetBackingUdonBehaviour((UdonSharpBehaviour)x.Target);
                    }
                    if (x.Target.GetType().IsAssignableToGenericType(typeof(IBehaviourExtension<>))) {
                        return ((IBehaviourExtension)x.Target).Target;
                    }
                    return x.Target;
                })
                .Cast<object>()
                .ToArray();
        }

        static object[] BuildEventListenerArguments(PersistentCallGroup localizeEventPersistentCall) {
            return localizeEventPersistentCall?.GetListeners()
                .Where(x => x.Target && !string.IsNullOrEmpty(x.MethodName))
                .Where(x => UnityEventFilter.IsTargetPermitted(x.Target, x.MethodName))
                .Select(x => BuildEventListenerArgument(x))
                .ToArray();
        }

        static object BuildEventListenerArgument(PersistentCall localizeEventPersistentCall) {
            switch (localizeEventPersistentCall.Mode) {
                case PersistentListenerMode.Object: {
                        return localizeEventPersistentCall.Arguments.UnityObjectArgument;
                    }
                case PersistentListenerMode.Int: {
                        return localizeEventPersistentCall.Arguments.IntArgument;
                    }
                case PersistentListenerMode.Float: {
                        return localizeEventPersistentCall.Arguments.FloatArgument;
                    }
                case PersistentListenerMode.String: {
                        return localizeEventPersistentCall.Arguments.StringArgument;
                    }
                case PersistentListenerMode.Bool: {
                        return localizeEventPersistentCall.Arguments.BoolArgument;
                    }
            }
            return default;
        }

        static DataList BuildLocalizedRefs(HashSet<LocalizedMonoBehaviour> localizedRefs, List<LocalizedMonoBehaviour> localizeEvents) {
            return localizedRefs?
                .Select(x => localizeEvents.IndexOf(x))
                .ToDataList();
        }

        static int BuildLocalizedEntry(LocalizedReference localized, List<long> entryKeys) {
            switch (localized) {
                case ULocalization.LocalizeDropdownEvent.LocalizedOptionDataList localizedOptionDataList: {
                        return -1;
                    }
                case LocalizedReference localizedReference: {
                        return entryKeys.IndexOf(localized.TableEntryReference.KeyId);
                    }
            }
            return -1;
        }

        static string BuildVariableId(UnityEngine.Localization.SmartFormat.PersistentVariables.IVariable variable) {
            if (variable == null) {
                return null;
            }
            return $"__{variable.GetType().FullName.Replace(".", "").ComputeHashMD5()}";
        }

        static DataList BuildVariableRefs(HashSet<UnityEngine.Localization.SmartFormat.PersistentVariables.IVariable> variableRefs, List<UnityEngine.Localization.SmartFormat.PersistentVariables.IVariable> variables) {
            return variableRefs?
                .Select(x => variables.IndexOf(x))
                .ToDataList();
        }

        static object BuildVariableValue(UnityEngine.Localization.SmartFormat.PersistentVariables.IVariable variable, List<LocalizedReference> localizeds, List<UnityEngine.Localization.SmartFormat.PersistentVariables.IVariable> variables) {
            switch (variable) {
                case UnityEngine.Localization.SmartFormat.PersistentVariables.BoolVariable boolVariable: {
                        return boolVariable.Value;
                    }
                case UnityEngine.Localization.SmartFormat.PersistentVariables.SByteVariable sbyteVariable: {
                        return sbyteVariable.Value;
                    }
                case UnityEngine.Localization.SmartFormat.PersistentVariables.ByteVariable byteVariable: {
                        return byteVariable.Value;
                    }
                case UnityEngine.Localization.SmartFormat.PersistentVariables.ShortVariable shortVariable: {
                        return shortVariable.Value;
                    }
                case UnityEngine.Localization.SmartFormat.PersistentVariables.UShortVariable ushortVariable: {
                        return ushortVariable.Value;
                    }
                case UnityEngine.Localization.SmartFormat.PersistentVariables.IntVariable intVariable: {
                        return intVariable.Value;
                    }
                case UnityEngine.Localization.SmartFormat.PersistentVariables.UIntVariable uintVariable: {
                        return uintVariable.Value;
                    }
                case UnityEngine.Localization.SmartFormat.PersistentVariables.LongVariable longVariable: {
                        return longVariable.Value;
                    }
                case UnityEngine.Localization.SmartFormat.PersistentVariables.ULongVariable ulongVariable: {
                        return ulongVariable.Value;
                    }
                case UnityEngine.Localization.SmartFormat.PersistentVariables.StringVariable stringVariable: {
                        return stringVariable.Value;
                    }
                case UnityEngine.Localization.SmartFormat.PersistentVariables.FloatVariable floatVariable: {
                        return floatVariable.Value;
                    }
                case UnityEngine.Localization.SmartFormat.PersistentVariables.DoubleVariable doubleVariable: {
                        return doubleVariable.Value;
                    }
                case UnityEngine.Localization.SmartFormat.PersistentVariables.ObjectVariable objectVariable: {
                        if (typeof(UdonSharpBehaviour).IsAssignableFrom(objectVariable.Value.GetType())) {
                            return UdonSharpEditorUtility.GetBackingUdonBehaviour((UdonSharpBehaviour)objectVariable.Value);
                        }
                        return objectVariable.Value;
                    }
                case UnityEngine.Localization.SmartFormat.PersistentVariables.NestedVariablesGroup nestedVariableGroup: {
                        return variables.IndexOf(nestedVariableGroup.Value);
                    }
                case UnityEngine.Localization.SmartFormat.PersistentVariables.VariablesGroupAsset variablesGroup: {
                        return variablesGroup
                            .ToDataDictionary(x => x.Key, x => variables.IndexOf(x.Value));
                    }
                case UnityEngine.Localization.LocalizedString localizedString: {
                        return localizedString
                            .ToDataDictionary(x => x.Key, x => variables.IndexOf(x.Value));
                    }
                case ULocalization.LocalizeDropdownEvent.LocalizedOptionDataList localizedOptionDataList: {
                        return localizedOptionDataList
                            .Select(x => new[] { localizeds.IndexOf(x.Text), localizeds.IndexOf(x.Image) })
                            .ToDataList();
                    }
            }
            return default;
        }
    }
}
