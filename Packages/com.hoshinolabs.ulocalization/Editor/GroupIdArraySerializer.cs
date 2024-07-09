using HoshinoLabs.ULocalization.Udon;
using System;
using System.Collections;
using System.Collections.Generic;
using UdonSharp.Serialization;
using UnityEngine;
using UnityEngine.Localization.Components;

namespace HoshinoLabs.ULocalization {
    internal sealed class GroupIdArraySerializer<T> : ArraySerializer<GroupId<T>> where T : LocalizedMonoBehaviour {
        public GroupIdArraySerializer(TypeSerializationMetadata typeMetadata)
            : base(typeMetadata) {

        }

        protected override Serializer MakeSerializer(TypeSerializationMetadata typeMetadata) {
            VerifyTypeCheckSanity();
            var elementType = typeMetadata.cSharpType.GetElementType();
            var typeArgument = elementType.GenericTypeArguments[0];
            return (Serializer)Activator.CreateInstance(typeof(GroupIdArraySerializer<>).MakeGenericType(typeArgument), typeMetadata);
        }

        protected override bool HandlesTypeSerialization(TypeSerializationMetadata typeMetadata) {
            VerifyTypeCheckSanity();
            if (!typeMetadata.cSharpType.IsArray) {
                return false;
            }
            var elementType = typeMetadata.cSharpType.GetElementType();
            return !elementType.IsArray && elementType.IsGenericType && elementType.GetGenericTypeDefinition() == typeof(GroupId<>);
        }

        public override object Serialize(in GroupId<T> sourceObject) {
            return sourceObject.Pack();
        }

        public override GroupId<T> Deserialize(object sourceObject) {
            return GroupIdExtensions.UnPack<T>(sourceObject);
        }
    }

    internal sealed class GroupIdArraySerializer : ArraySerializer<GroupId> {
        public GroupIdArraySerializer(TypeSerializationMetadata typeMetadata)
            : base(typeMetadata) {

        }

        protected override Serializer MakeSerializer(TypeSerializationMetadata typeMetadata) {
            VerifyTypeCheckSanity();
            return new GroupIdArraySerializer(typeMetadata);
        }

        public override object Serialize(in GroupId sourceObject) {
            return sourceObject.Pack();
        }

        public override GroupId Deserialize(object sourceObject) {
            return GroupIdExtensions.UnPack(sourceObject);
        }
    }
}
