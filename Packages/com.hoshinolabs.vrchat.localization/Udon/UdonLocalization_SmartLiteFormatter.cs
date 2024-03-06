using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRC.SDK3.Data;
using VRC.Udon;

namespace HoshinoLabs.Localization.Udon {
    internal partial class UdonLocalization {
        void SmartLiteFormat(DataDictionary args) {
            var i = 0;
            while (true) {
                var l = listenerString.IndexOf('{', i);
                var r = listenerString.IndexOf('}', i);
                if (l < 0 || r < 0) {
                    break;
                }

                var v = listenerString.Substring(l + 1, r - l - 1);
                var c = v.IndexOf(':');
                var f = c < 0 ? "" : v.Substring(c + 1);
                var s = c < 0 ? v : v.Substring(0, c);
                var d = v.IndexOf('.');
                var o = d < 0 ? s : s.Substring(0, d);
                var m = d < 0 ? null : s.Substring(d + 1);

                if (!args.TryGetValue(o, out var _variableId)) {
                    // Displays a warning when a formatting error occurs
                    Debug.LogWarning($"[<color=#47F1FF>UdonLocalization</color>] Error parsing format string: Could not evaluate the selector \"{v}\" at {i}");
                    i = r + 1;
                    continue;
                }
                var variableId = _variableId.Int;

                switch (variables_0[variableId]) {
                    case VariableType.Bool: {
                            var value = (bool)variables_1[variableId];
                            listenerString = listenerString.Replace($"{{{v}}}", value.ToString());
                            break;
                        }
                    case VariableType.SByte: {
                            var value = (sbyte)variables_1[variableId];
                            listenerString = listenerString.Replace($"{{{v}}}", value.ToString(f));
                            break;
                        }
                    case VariableType.Byte: {
                            var value = (byte)variables_1[variableId];
                            listenerString = listenerString.Replace($"{{{v}}}", value.ToString(f));
                            break;
                        }
                    case VariableType.Short: {
                            var value = (short)variables_1[variableId];
                            listenerString = listenerString.Replace($"{{{v}}}", value.ToString(f));
                            break;
                        }
                    case VariableType.UShort: {
                            var value = (ushort)variables_1[variableId];
                            listenerString = listenerString.Replace($"{{{v}}}", value.ToString(f));
                            break;
                        }
                    case VariableType.Int: {
                            var value = (int)variables_1[variableId];
                            listenerString = listenerString.Replace($"{{{v}}}", value.ToString(f));
                            break;
                        }
                    case VariableType.UInt: {
                            var value = (uint)variables_1[variableId];
                            listenerString = listenerString.Replace($"{{{v}}}", value.ToString(f));
                            break;
                        }
                    case VariableType.Long: {
                            var value = (long)variables_1[variableId];
                            listenerString = listenerString.Replace($"{{{v}}}", value.ToString(f));
                            break;
                        }
                    case VariableType.ULong: {
                            var value = (ulong)variables_1[variableId];
                            listenerString = listenerString.Replace($"{{{v}}}", value.ToString(f));
                            break;
                        }
                    case VariableType.String: {
                            var value = (string)variables_1[variableId];
                            listenerString = listenerString.Replace($"{{{v}}}", value.ToString());
                            break;
                        }
                    case VariableType.Float: {
                            var value = (float)variables_1[variableId];
                            listenerString = listenerString.Replace($"{{{v}}}", value.ToString(f));
                            break;
                        }
                    case VariableType.Double: {
                            var value = (double)variables_1[variableId];
                            listenerString = listenerString.Replace($"{{{v}}}", value.ToString(f));
                            break;
                        }
                    case VariableType.Object: {
                            var value = (object)variables_1[variableId];
                            listenerString = listenerString.Replace($"{{{v}}}", value.ToString());
                            break;
                        }
                    case VariableType.LocalizedString: {
                            var value = (int)variables_1[variableId];
                            listenerString = listenerString.Replace($"{{{v}}}", currentStringDatabase[value]);
                            break;
                        }
                    //case VariableType.CurrentTime: {
                    //        var value = DateTime.Now;
                    //        listenerString = listenerString.Replace($"{{{v}}}", value.ToString(f));
                    //        break;
                    //    }
                    //case VariableType.DateTime: {
                    //        var value = (DateTime)variables_1[variableId];
                    //        listenerString = listenerString.Replace($"{{{v}}}", value.ToString(f));
                    //        break;
                    //    }
                    case VariableType.Udon: {
                            var udon = (UdonBehaviour)variables_1[variableId];
                            if (string.IsNullOrEmpty(m)) {
                                listenerString = listenerString.Replace($"{{{v}}}", udon.ToString());
                                break;
                            }
                            else {
                                var value = udon.GetProgramVariable(m);
                                listenerString = listenerString.Replace($"{{{v}}}", value.ToString());
                            }
                            break;
                        }
                    default: {
                            break;
                        }
                }
            }
        }
    }
}
