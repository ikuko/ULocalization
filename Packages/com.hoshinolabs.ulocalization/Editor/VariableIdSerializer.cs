using HoshinoLabs.ULocalization.Udon;
using System;
using System.Collections;
using System.Collections.Generic;
using UdonSharp.Serialization;
using UnityEngine;
using UnityEngine.Localization.Components;

namespace HoshinoLabs.ULocalization {
    internal sealed class VariableIdSerializer<T> : Serializer<VariableId<T>> where T : LocalizedMonoBehaviour {
        public VariableIdSerializer(TypeSerializationMetadata typeMetadata)
            : base(typeMetadata) {

        }

        protected override Serializer MakeSerializer(TypeSerializationMetadata typeMetadata) {
            VerifyTypeCheckSanity();
            var typeArgument = typeMetadata.cSharpType.GenericTypeArguments[0];
            return (Serializer)Activator.CreateInstance(typeof(VariableIdSerializer<>).MakeGenericType(typeArgument), typeMetadata);
        }

        protected override bool HandlesTypeSerialization(TypeSerializationMetadata typeMetadata) {
            VerifyTypeCheckSanity();
            return typeMetadata.cSharpType.IsGenericType && typeMetadata.cSharpType.GetGenericTypeDefinition() == typeof(VariableId<>);
        }

        public override object Serialize(in VariableId<T> sourceObject) {
            return sourceObject.Pack();
        }

        public override VariableId<T> Deserialize(object sourceObject) {
            return VariableIdExtensions.UnPack<T>(sourceObject);
        }
    }

    internal sealed class VariableIdSerializer : Serializer<VariableId> {
        public VariableIdSerializer(TypeSerializationMetadata typeMetadata)
            : base(typeMetadata) {

        }

        protected override Serializer MakeSerializer(TypeSerializationMetadata typeMetadata) {
            VerifyTypeCheckSanity();
            return new VariableIdSerializer(typeMetadata);
        }

        public override object Serialize(in VariableId sourceObject) {
            return sourceObject.Pack();
        }

        public override VariableId Deserialize(object sourceObject) {
            return VariableIdExtensions.UnPack(sourceObject);
        }
    }
}
