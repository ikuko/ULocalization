using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace HoshinoLabs.Localization {
    internal static class UnityEventExtensions {
        internal class PersistentCall {
            internal class ArgumentCache {
                PersistentListenerMode mode;
                Object objectArgument;
                int intArgument;
                float floatArgument;
                string stringArgument;
                bool boolArgument;

                public Object ObjectArgument => objectArgument;
                public int IntArgument => intArgument;
                public float FloatArgument => floatArgument;
                public string StringArgument => stringArgument;
                public bool BoolArgument => boolArgument;

                public ArgumentCache(PersistentListenerMode mode, SerializedProperty arguments) {
                    this.mode = mode;
                    switch (mode) {
                        case PersistentListenerMode.EventDefined: {
                                break;
                            }
                        case PersistentListenerMode.Void: {
                                break;
                            }
                        case PersistentListenerMode.Object: {
                                objectArgument = arguments.FindPropertyRelative("m_ObjectArgument").objectReferenceValue;
                                break;
                            }
                        case PersistentListenerMode.Int: {
                                intArgument = arguments.FindPropertyRelative("m_IntArgument").intValue;
                                break;
                            }
                        case PersistentListenerMode.Float: {
                                floatArgument = arguments.FindPropertyRelative("m_FloatArgument").floatValue;
                                break;
                            }
                        case PersistentListenerMode.String: {
                                stringArgument = arguments.FindPropertyRelative("m_StringArgument").stringValue;
                                break;
                            }
                        case PersistentListenerMode.Bool: {
                                boolArgument = arguments.FindPropertyRelative("m_BoolArgument").boolValue;
                                break;
                            }
                    }
                }

                public object Value {
                    get {
                        switch (mode) {
                            case PersistentListenerMode.EventDefined: {
                                    return null;
                                }
                            case PersistentListenerMode.Void: {
                                    return null;
                                }
                            case PersistentListenerMode.Object: {
                                    return objectArgument;
                                }
                            case PersistentListenerMode.Int: {
                                    return intArgument;
                                }
                            case PersistentListenerMode.Float: {
                                    return floatArgument;
                                }
                            case PersistentListenerMode.String: {
                                    return stringArgument;
                                }
                            case PersistentListenerMode.Bool: {
                                    return boolArgument;
                                }
                        }
                        return null;
                    }
                }
            }

            Object target;
            string methodName;
            PersistentListenerMode mode;
            ArgumentCache arguments;
            UnityEventCallState callState;

            public Object Target => target;
            public string MethodName => methodName;
            public PersistentListenerMode Mode => mode;
            public ArgumentCache Arguments => arguments;
            public UnityEventCallState CallState => callState;

            public PersistentCall(SerializedProperty persistentCall) {
                target = persistentCall.FindPropertyRelative("m_Target").objectReferenceValue;
                methodName = persistentCall.FindPropertyRelative("m_MethodName").stringValue;
                mode = (PersistentListenerMode)persistentCall.FindPropertyRelative("m_Mode").enumValueIndex;
                arguments = new ArgumentCache(mode, persistentCall.FindPropertyRelative("m_Arguments"));
                callState = (UnityEventCallState)persistentCall.FindPropertyRelative("m_CallState").enumValueIndex;
            }
        }

        internal class PersistentCallGroup {
            PersistentCall[] calls;

            public PersistentCallGroup(SerializedProperty calls) {
                this.calls = Enumerable.Range(0, calls.arraySize)
                    .Select(x => new PersistentCall(calls.GetArrayElementAtIndex(x)))
                    .ToArray();
            }

            public int Count => calls.Length;

            public PersistentCall GetListener(int index) {
                return calls[index];
            }

            public IEnumerable<PersistentCall> GetListeners() {
                return calls;
            }
        }

        internal static PersistentCallGroup GetPersistentCallGroup(Object self, string property) {
            return new PersistentCallGroup(new SerializedObject(self).FindProperty(property).FindPropertyRelative("m_PersistentCalls").FindPropertyRelative("m_Calls"));
        }
    }
}
