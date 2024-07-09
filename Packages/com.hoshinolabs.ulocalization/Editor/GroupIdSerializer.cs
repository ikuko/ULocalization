using HoshinoLabs.ULocalization.Udon;
using System;
using System.Collections;
using System.Collections.Generic;
using UdonSharp.Serialization;
using UnityEngine;
using UnityEngine.Localization.Components;

namespace HoshinoLabs.ULocalization {
    internal sealed class GroupIdSerializer<T> : Serializer<GroupId<T>> where T : LocalizedMonoBehaviour {
        public GroupIdSerializer(TypeSerializationMetadata typeMetadata)
            : base(typeMetadata) {

        }

        protected override Serializer MakeSerializer(TypeSerializationMetadata typeMetadata) {
            VerifyTypeCheckSanity();
            var typeArgument = typeMetadata.cSharpType.GenericTypeArguments[0];
            return (Serializer)Activator.CreateInstance(typeof(GroupIdSerializer<>).MakeGenericType(typeArgument), typeMetadata);
        }

        protected override bool HandlesTypeSerialization(TypeSerializationMetadata typeMetadata) {
            VerifyTypeCheckSanity();
            return typeMetadata.cSharpType.IsGenericType && typeMetadata.cSharpType.GetGenericTypeDefinition() == typeof(GroupId<>);
        }

        public override object Serialize(in GroupId<T> sourceObject) {
            return sourceObject.Pack();
        }

        public override GroupId<T> Deserialize(object sourceObject) {
            return GroupIdExtensions.UnPack<T>(sourceObject);
        }
    }

    internal sealed class GroupIdSerializer : Serializer<GroupId> {
        public GroupIdSerializer(TypeSerializationMetadata typeMetadata)
            : base(typeMetadata) {

        }

        protected override Serializer MakeSerializer(TypeSerializationMetadata typeMetadata) {
            VerifyTypeCheckSanity();
            return new GroupIdSerializer(typeMetadata);
        }

        public override object Serialize(in GroupId sourceObject) {
            return sourceObject.Pack();
        }

        public override GroupId Deserialize(object sourceObject) {
            return GroupIdExtensions.UnPack(sourceObject);
        }
    }
}
