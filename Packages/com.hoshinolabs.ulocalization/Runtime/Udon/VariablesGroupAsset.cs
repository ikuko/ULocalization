using HoshinoLabs.Sardinject.Udon;
using System;
using UnityEngine;

namespace HoshinoLabs.ULocalization.Udon {
    [Serializable]
    public sealed class VariablesGroupAsset : ISerializable {
        [Inject, SerializeField]
        UnityEngine.Localization.SmartFormat.PersistentVariables.VariablesGroupAsset variablesGroup;

        public VariablesGroupAsset() {

        }

        public VariablesGroupAsset(UnityEngine.Localization.SmartFormat.PersistentVariables.VariablesGroupAsset variablesGroup) {
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
