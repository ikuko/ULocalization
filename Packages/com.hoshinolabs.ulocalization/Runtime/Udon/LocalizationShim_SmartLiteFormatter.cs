using System.Text.RegularExpressions;
using UdonSharp;
using VRC.SDK3.Data;
using VRC.Udon;

namespace HoshinoLabs.ULocalization.Udon {
    internal sealed partial class LocalizationShim {
        [RecursiveMethod]
        string SmartLiteFormat(string format, DataDictionary args) {
            var r = format;
            var ms = Regex.Matches(r, @"\{([^{}:]+)\:?([^{}]+)?\}");
            var ml = ms.Count;
            for (var i = 0; i < ml; i++) {
                var m = ms[i];
                var gs = m.Groups;
                var g = gs[1];
                var ks = g.Value.Split('.');
                var kl = ks.Length;
                var f = gs[2].Value;
                var d = args;
                var s = string.Empty;
                for (var j = 0; j < kl; j++) {
                    var k = ks[j].Trim();
                    if (d == null || !d.TryGetValue(k, out var _v)) {
                        Logger.LogError($"Error parsing format string. Could not evaluate the variable \"{k}\" at {g.Index - 2}");
                        return format;
                    }
                    var v = _v.Int;
                    switch (_17[v]) {
                        case "__f8cfba77af0119c086592e79c73223e5": {
                                d = null;
                                s = ((bool)_19[v]).ToString(culture);
                                break;
                            }
                        case "__6bac394d6972c8d339cc1ce54df77912": {
                                d = null;
                                s = ((sbyte)_19[v]).ToString(f, culture);
                                break;
                            }
                        case "__7e161907af17a8f682d768188abd5951": {
                                d = null;
                                s = ((byte)_19[v]).ToString(f, culture);
                                break;
                            }
                        case "__87ef78382d22f90afacdd86d7c2c3e65": {
                                d = null;
                                s = ((short)_19[v]).ToString(f, culture);
                                break;
                            }
                        case "__e2c64e0a94ccfc78d9209d4d9aaffce7": {
                                d = null;
                                s = ((ushort)_19[v]).ToString(f, culture);
                                break;
                            }
                        case "__8417c01a3ee51184c42f97c8f6e41b4a": {
                                d = null;
                                s = ((int)_19[v]).ToString(f, culture);
                                break;
                            }
                        case "__9843bf736c4a3f95db46565832dc7167": {
                                d = null;
                                s = ((uint)_19[v]).ToString(f, culture);
                                break;
                            }
                        case "__261e9c8a98d5bc34284778a40dbcf076": {
                                d = null;
                                s = ((long)_19[v]).ToString(f, culture);
                                break;
                            }
                        case "__012ee6846df47c4946e18c2d71a61ca1": {
                                d = null;
                                s = ((ulong)_19[v]).ToString(f, culture);
                                break;
                            }
                        case "__2e798db3630c1fd3c89877775b600ffe": {
                                d = null;
                                s = ((string)_19[v]).ToString(culture);
                                break;
                            }
                        case "__73eb38c4d216f0260fa5dd939499ea3b": {
                                d = null;
                                s = ((float)_19[v]).ToString(f, culture);
                                break;
                            }
                        case "__7a160556cb5c2de9039d3b53bdde58a7": {
                                d = null;
                                s = ((double)_19[v]).ToString(f, culture);
                                break;
                            }
                        case "__d3be8ac28dfa83b00c677fa0937010c8": {
                                d = null;
                                var o = _19[v];
                                if (o == null) {
                                    s = "null";
                                }
                                else {
                                    s = o.ToString();
                                    for (j++; j < kl; j++) {
                                        var t = o.GetType().FullName;
                                        if (t == "VRC.Udon.UdonBehaviour") {
                                            k = ks[j].Trim();
                                            var u = (UdonBehaviour)o;
                                            o = u.GetProgramVariableType(k);
                                            if (o == null) {
                                                j--;
                                                break;
                                            }
                                            o = u.GetProgramVariable(k);
                                            switch (o.GetType().FullName) {
                                                case "System.Boolean": {
                                                        s = ((bool)o).ToString(culture);
                                                        break;
                                                    }
                                                case "System.SByte": {
                                                        s = ((sbyte)o).ToString(f, culture);
                                                        break;
                                                    }
                                                case "System.Byte": {
                                                        s = ((byte)o).ToString(f, culture);
                                                        break;
                                                    }
                                                case "System.Int16": {
                                                        s = ((short)o).ToString(f, culture);
                                                        break;
                                                    }
                                                case "System.UInt16": {
                                                        s = ((ushort)o).ToString(f, culture);
                                                        break;
                                                    }
                                                case "System.Int32": {
                                                        s = ((int)o).ToString(f, culture);
                                                        break;
                                                    }
                                                case "System.UInt32": {
                                                        s = ((uint)o).ToString(f, culture);
                                                        break;
                                                    }
                                                case "System.Int64": {
                                                        s = ((long)o).ToString(f, culture);
                                                        break;
                                                    }
                                                case "System.UInt64": {
                                                        s = ((ulong)o).ToString(f, culture);
                                                        break;
                                                    }
                                                case "System.String": {
                                                        s = ((string)o).ToString(culture);
                                                        break;
                                                    }
                                                case "System.Single": {
                                                        s = ((float)o).ToString(f, culture);
                                                        break;
                                                    }
                                                case "System.Double": {
                                                        s = ((double)o).ToString(f, culture);
                                                        break;
                                                    }
                                                case "System.Object": {
                                                        s = o.ToString();
                                                        break;
                                                    }
                                                default: {
                                                        s = o.ToString();
                                                        break;
                                                    }
                                            }
                                            continue;
                                        }
                                        j--;
                                        break;
                                    }
                                }
                                break;
                            }
                        case "__6c640a4ed53d954835db21cc931dc34e": {
                                d = (DataDictionary)_19[(int)_19[v]];
                                break;
                            }
                        case "__8a40d06f0f1ef4f691875d86a3c4c58c": {
                                d = null;
                                s = (string)GetLocalizedValue(v);
                                break;
                            }
                    }
                }
                r = r.Replace(m.Value, s);
            }
            return r;
        }
    }
}
