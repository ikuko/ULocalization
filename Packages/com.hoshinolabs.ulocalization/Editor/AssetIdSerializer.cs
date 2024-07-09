using HoshinoLabs.ULocalization.Udon;
using System;
using System.Collections;
using System.Collections.Generic;
using UdonSharp.Serialization;
using UnityEngine;
using UnityEngine.Localization;

namespace HoshinoLabs.ULocalization {
    internal sealed class AssetIdSerializer<T> : Serializer<AssetId<T>> where T : LocalizedReference {
        public AssetIdSerializer(TypeSerializationMetadata typeMetadata)
            : base(typeMetadata) {

        }

        protected override Serializer MakeSerializer(TypeSerializationMetadata typeMetadata) {
            VerifyTypeCheckSanity();
            var typeArgument = typeMetadata.cSharpType.GenericTypeArguments[0];
            return (Serializer)Activator.CreateInstance(typeof(AssetIdSerializer<>).MakeGenericType(typeArgument), typeMetadata);
        }

        protected override bool HandlesTypeSerialization(TypeSerializationMetadata typeMetadata) {
            VerifyTypeCheckSanity();
            return typeMetadata.cSharpType.IsGenericType && typeMetadata.cSharpType.GetGenericTypeDefinition() == typeof(AssetId<>);
        }

        public override object Serialize(in AssetId<T> sourceObject) {
            return sourceObject.Pack();
        }

        public override AssetId<T> Deserialize(object sourceObject) {
            return AssetIdExtensions.UnPack<T>(sourceObject);
        }
    }
}
