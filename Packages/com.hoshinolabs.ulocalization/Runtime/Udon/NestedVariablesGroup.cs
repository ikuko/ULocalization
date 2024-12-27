using HoshinoLabs.Sardinject.Udon;
using System;
using UnityEngine;

namespace HoshinoLabs.ULocalization.Udon {
    [Serializable]
    public sealed class NestedVariablesGroup : IVariable, ISerializable {
        [Inject, SerializeReference]
        UnityEngine.Localization.SmartFormat.PersistentVariables.NestedVariablesGroup variablesGroup = new UnityEngine.Localization.SmartFormat.PersistentVariables.NestedVariablesGroup();

        public NestedVariablesGroup() {

        }

        public NestedVariablesGroup(UnityEngine.Localization.SmartFormat.PersistentVariables.NestedVariablesGroup variablesGroup) {
            this.variablesGroup = variablesGroup;
        }

        public void Serialize(IDataWriter writer) {
#if !COMPILER_UDONSHARP && UNITY_EDITOR
            writer.WriteReference("", LocalizationResolver.Resolve());
            writer.WriteInt32("", VariableCache.AddOrGet(variablesGroup));
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
