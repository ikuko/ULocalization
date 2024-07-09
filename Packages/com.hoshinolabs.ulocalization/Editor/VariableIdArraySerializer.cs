using HoshinoLabs.ULocalization.Udon;
using System;
using System.Collections;
using System.Collections.Generic;
using UdonSharp.Serialization;
using UnityEngine;
using UnityEngine.Localization.Components;

namespace HoshinoLabs.ULocalization {
    internal sealed class VariableIdArraySerializer<T> : ArraySerializer<VariableId<T>> where T : LocalizedMonoBehaviour {
        public VariableIdArraySerializer(TypeSerializationMetadata typeMetadata)
            : base(typeMetadata) {

        }

        protected override Serializer MakeSerializer(TypeSerializationMetadata typeMetadata) {
            VerifyTypeCheckSanity();
            var elementType = typeMetadata.cSharpType.GetElementType();
            var typeArgument = elementType.GenericTypeArguments[0];
            return (Serializer)Activator.CreateInstance(typeof(VariableIdArraySerializer<>).MakeGenericType(typeArgument), typeMetadata);
        }

        protected override bool HandlesTypeSerialization(TypeSerializationMetadata typeMetadata) {
            VerifyTypeCheckSanity();
            if (!typeMetadata.cSharpType.IsArray) {
                return false;
            }
            var elementType = typeMetadata.cSharpType.GetElementType();
            return !elementType.IsArray && elementType.IsGenericType && elementType.GetGenericTypeDefinition() == typeof(VariableId<>);
        }

        public override object Serialize(in VariableId<T> sourceObject) {
            return sourceObject.Pack();
        }

        public override VariableId<T> Deserialize(object sourceObject) {
            return VariableIdExtensions.UnPack<T>(sourceObject);
        }
    }
}
