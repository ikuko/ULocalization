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
using UnityEngine.Localization.Components;
using UnityEngine.SceneManagement;
using VRC.Udon;
using VRC.Udon.Common.Interfaces;

namespace HoshinoLabs.Localization {
    internal sealed class LocalizationPostBuilder : IProcessSceneWithReport {
        public int callbackOrder => 100;

        public void OnProcessScene(Scene scene, BuildReport report) {
            foreach(var usharp in GameObject.FindObjectsOfType<UdonSharpBehaviour>()) {
                var type = usharp.GetType();
                var fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                    .ToArray();
                foreach (var field in fields) {
                    RewriteRuntimeId(usharp, field);
                }
            }

            foreach (var x in LocalizationHelper.ReferenceGroupIds.Keys) {
                GameObject.DestroyImmediate(x);
            }
        }

        void RewriteRuntimeId(UdonSharpBehaviour usharp, FieldInfo field) {
            var attributes = field.GetCustomAttributes().ToArray();
            foreach (var x in attributes) {
                switch (x) {
                    case GroupIdAttribute: {
                            var value = (string)field.GetValue(usharp);
                            var id = GetRuntimeGroupId(value);
                            var udon = UdonSharpEditorUtility.GetBackingUdonBehaviour(usharp);
                            udon.publicVariables.RemoveVariable(field.Name);
                            SetUdonVariable(udon, (object)id, field.Name);
                            return;
                        }
                    case VariableIdAttribute: {
                            var value = (string)field.GetValue(usharp);
                            var id = GetRuntimeVariableId(value);
                            var udon = UdonSharpEditorUtility.GetBackingUdonBehaviour(usharp);
                            udon.publicVariables.RemoveVariable(field.Name);
                            SetUdonVariable(udon, (object)id, field.Name);
                            return;
                        }
                }
            }
        }

        int GetRuntimeGroupId(string value) {
            if (!GlobalObjectId.TryParse(value, out var id)) {
                return -1;
            }
            var component = GlobalObjectId.GlobalObjectIdentifierToObjectSlow(id) as LocalizedMonoBehaviour;
            return component.GetRuntimeGroupId();
        }

        int GetRuntimeVariableId(string value) {
            var idx = value.IndexOf('#');
            if (idx < 0 || !GlobalObjectId.TryParse(value.Substring(0, idx), out var id)) {
                return -1;
            }
            var component = (LocalizeStringEvent)GlobalObjectId.GlobalObjectIdentifierToObjectSlow(id);
            var variable = value.Substring(idx + 1);
            return component.GetRuntimeVariableId(variable);
        }

        void SetUdonVariable<T>(UdonBehaviour udon, T param, string symbol) {
            var programAsset = (UdonSharpProgramAsset)udon.programSource;
            var variables = udon.publicVariables;
            if (!variables.TryGetVariableValue(symbol, out object variableValue)) {
                variableValue = programAsset.GetPublicVariableDefaultValue(symbol);
            }
            variableValue = param;
            if (!variables.TrySetVariableValue(symbol, variableValue)) {
                var variableType = typeof(VRC.Udon.Common.UdonVariable<>).MakeGenericType(typeof(T));
                var variable = (IUdonVariable)Activator.CreateInstance(variableType, symbol, variableValue);
                variables.TryAddVariable(variable);
            }
        }
    }
}
