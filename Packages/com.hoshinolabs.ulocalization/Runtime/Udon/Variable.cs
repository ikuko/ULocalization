using HoshinoLabs.Sardinject.Udon;
using System;
using UnityEngine;

namespace HoshinoLabs.ULocalization.Udon {
    [Serializable]
    public class Variable<T> : IVariable, ISerializable where T : UnityEngine.Localization.SmartFormat.PersistentVariables.IVariable {
        [Inject, SerializeField]
        T variable;

        public Variable() {

        }

        public Variable(T variable) {
            this.variable = variable;
        }

        public void Serialize(IDataWriter writer) {
#if !COMPILER_UDONSHARP && UNITY_EDITOR
            writer.WriteReference("", LocalizationResolver.Resolve());
            writer.WriteInt32("", VariableCache.AddOrGet(variable));
#endif
        }

        public void Deserialize(IDataReader reader) {
#if !COMPILER_UDONSHARP && UNITY_EDITOR
            reader.SkipEntry();
            reader.SkipEntry();
#endif
        }
    }
}
