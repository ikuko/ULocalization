using HoshinoLabs.ULocalization.Udon;
using System;
using System.Collections;
using System.Collections.Generic;
using UdonSharp.Serialization;
using UnityEngine;
using UnityEngine.Localization;

namespace HoshinoLabs.ULocalization {
    internal sealed class AssetIdArraySerializer<T> : ArraySerializer<AssetId<T>> where T : LocalizedReference {
        public AssetIdArraySerializer(TypeSerializationMetadata typeMetadata)
            : base(typeMetadata) {

        }

        protected override Serializer MakeSerializer(TypeSerializationMetadata typeMetadata) {
            VerifyTypeCheckSanity();
            var elementType = typeMetadata.cSharpType.GetElementType();
            var typeArgument = elementType.GenericTypeArguments[0];
            return (Serializer)Activator.CreateInstance(typeof(AssetIdArraySerializer<>).MakeGenericType(typeArgument), typeMetadata);
        }

        protected override bool HandlesTypeSerialization(TypeSerializationMetadata typeMetadata) {
            VerifyTypeCheckSanity();
            if (!typeMetadata.cSharpType.IsArray) {
                return false;
            }
            var elementType = typeMetadata.cSharpType.GetElementType();
            return !elementType.IsArray && elementType.IsGenericType && elementType.GetGenericTypeDefinition() == typeof(AssetId<>);
        }

        public override object Serialize(in AssetId<T> sourceObject) {
            return sourceObject.Pack();
        }

        public override AssetId<T> Deserialize(object sourceObject) {
            return AssetIdExtensions.UnPack<T>(sourceObject);
        }
    }

    internal sealed class AssetIdArraySerializer : ArraySerializer<AssetId> {
        public AssetIdArraySerializer(TypeSerializationMetadata typeMetadata)
            : base(typeMetadata) {

        }

        protected override Serializer MakeSerializer(TypeSerializationMetadata typeMetadata) {
            VerifyTypeCheckSanity();
            return new AssetIdArraySerializer(typeMetadata);
        }

        public override object Serialize(in AssetId sourceObject) {
            return sourceObject.Pack();
        }

        public override AssetId Deserialize(object sourceObject) {
            return AssetIdExtensions.UnPack(sourceObject);
        }
    }
}
