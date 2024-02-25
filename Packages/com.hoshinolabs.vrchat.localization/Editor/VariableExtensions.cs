using HoshinoLabs.Localization.Udon;
using System.Collections;
using System.Collections.Generic;
using UdonSharp;
using UdonSharpEditor;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.SmartFormat.PersistentVariables;
using VRC.Udon;

namespace HoshinoLabs.Localization {
    internal static class VariableExtensions {
        public static Variable ToVariable(this BoolVariable self) {
            return new Variable(VariableType.Bool, self.Value);
        }

        public static Variable ToVariable(this SByteVariable self) {
            return new Variable(VariableType.SByte, self.Value);
        }

        public static Variable ToVariable(this ByteVariable self) {
            return new Variable(VariableType.Byte, self.Value);
        }

        public static Variable ToVariable(this ShortVariable self) {
            return new Variable(VariableType.Short, self.Value);
        }

        public static Variable ToVariable(this UShortVariable self) {
            return new Variable(VariableType.UShort, self.Value);
        }

        public static Variable ToVariable(this IntVariable self) {
            return new Variable(VariableType.Int, self.Value);
        }

        public static Variable ToVariable(this UIntVariable self) {
            return new Variable(VariableType.UInt, self.Value);
        }

        public static Variable ToVariable(this LongVariable self) {
            return new Variable(VariableType.Long, self.Value);
        }

        public static Variable ToVariable(this ULongVariable self) {
            return new Variable(VariableType.ULong, self.Value);
        }

        public static Variable ToVariable(this StringVariable self) {
            return new Variable(VariableType.String, self.Value);
        }

        public static Variable ToVariable(this FloatVariable self) {
            return new Variable(VariableType.Float, self.Value);
        }

        public static Variable ToVariable(this DoubleVariable self) {
            return new Variable(VariableType.Double, self.Value);
        }

        public static Variable ToVariable(this ObjectVariable self) {
            if (typeof(UdonSharpBehaviour).IsAssignableFrom(self.Value.GetType())) {
                var usharp = (UdonSharpBehaviour)self.Value;
                var udon = UdonSharpEditorUtility.GetBackingUdonBehaviour(usharp);
                return new Variable(VariableType.Udon, udon);
            }
            if (self.Value.GetType() == typeof(UdonBehaviour)) {
                return new Variable(VariableType.Udon, self.Value);
            }
            return new Variable(VariableType.Object, self.Value);
        }

        public static Variable ToVariable(this LocalizedString self) {
            var tableId = self.TableReference.TableCollectionName;
            var entryId = self.TableEntryReference.KeyId.ToString();
            var assetId = LocalizationHelper.ReferenceStringIds[(tableId, entryId)];
            // TODO: Nested local variables are not supported
            return new Variable(VariableType.LocalizedString, assetId);
        }

        public static Variable ToVariable(this CurrentTime self) {
            return new Variable(VariableType.CurrentTime, null);
        }

        public static Variable ToVariable(this DateTimeVariable self) {
            return new Variable(VariableType.DateTime, self.GetSourceValue(null));
        }

        public static Variable ToVariable(this UdonVariable self) {
            var udon = UdonSharpEditorUtility.GetBackingUdonBehaviour(self.Value);
            return new Variable(VariableType.Udon, udon);
        }

        public static Variable ToVariable(this IVariable self) {
            switch (self) {
                case BoolVariable boolVariable: {
                        return boolVariable.ToVariable();
                    }
                case SByteVariable sbyteVariable: {
                        return sbyteVariable.ToVariable();
                    }
                case ByteVariable byteVariable: {
                        return byteVariable.ToVariable();
                    }
                case ShortVariable shortVariable: {
                        return shortVariable.ToVariable();
                    }
                case UShortVariable ushortVariable: {
                        return ushortVariable.ToVariable();
                    }
                case IntVariable intVariable: {
                        return intVariable.ToVariable();
                    }
                case UIntVariable uintVariable: {
                        return uintVariable.ToVariable();
                    }
                case LongVariable longVariable: {
                        return longVariable.ToVariable();
                    }
                case ULongVariable ulongVariable: {
                        return ulongVariable.ToVariable();
                    }
                case StringVariable stringVariable: {
                        return stringVariable.ToVariable();
                    }
                case FloatVariable floatVariable: {
                        return floatVariable.ToVariable();
                    }
                case DoubleVariable doubleVariable: {
                        return doubleVariable.ToVariable();
                    }
                case ObjectVariable objectVariable: {
                        return objectVariable.ToVariable();
                    }
                case LocalizedString localizedString: {
                        return localizedString.ToVariable();
                    }
                case CurrentTime currentTime: {
                        return currentTime.ToVariable();
                    }
                case DateTimeVariable dateTimeVariable: {
                        return dateTimeVariable.ToVariable();
                    }
                case UdonVariable udonVariable: {
                        return udonVariable.ToVariable();
                    }
                default: {
                        return new Variable(VariableType.Unknown, null);
                    }
            }
        }
    }
}
