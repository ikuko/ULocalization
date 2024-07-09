using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UdonSharp.Serialization;
using UnityEngine;

namespace HoshinoLabs.ULocalization {
    internal class ArraySerializer<T> : UdonSharp.Serialization.Serializer<T[]> {
        public ArraySerializer(TypeSerializationMetadata typeMetadata)
            : base(typeMetadata) {

        }

        protected override Serializer MakeSerializer(TypeSerializationMetadata typeMetadata) {
            VerifyTypeCheckSanity();
            return new ArraySerializer<T>(typeMetadata);
        }

        protected override bool HandlesTypeSerialization(TypeSerializationMetadata typeMetadata) {
            VerifyTypeCheckSanity();
            if (!typeMetadata.cSharpType.IsArray) {
                return false;
            }
            var elementType = typeMetadata.cSharpType.GetElementType();
            return !elementType.IsArray && elementType == typeof(T);
        }

        public override void Write(IValueStorage targetObject, in T[] sourceObject) {
            VerifySerializationSanity();
            if (targetObject == null) {
                Debug.LogError($"[<color=#47F1FF>ULocalization</color>] Field for {typeof(T)} does not exist");
                return;
            }

            if (targetObject.Value != null && targetObject.Value.GetType() == typeof(object[])) {
                return;
            }

            if (sourceObject == null) {
                targetObject.Value = null;
                return;
            }

            var targetArray = (Array)targetObject.Value;
            if (targetArray == null || targetArray.Length != sourceObject.Length) {
                targetObject.Value = Activator.CreateInstance(GetUdonStorageType(), sourceObject.Length);
            }

            var _sourceObject = sourceObject.Select(x => Serialize(x)).ToArray();
            var behaviourSerializer = CreatePooled(_sourceObject.GetType());
            behaviourSerializer.WriteWeak(targetObject, _sourceObject);
        }

        public override void Read(ref T[] targetObject, IValueStorage sourceObject) {
            VerifySerializationSanity();
        }

        public override Type GetUdonStorageType() {
            return typeof(object[]);
        }

        public virtual object Serialize(in T sourceObject) {
            return new object[] { sourceObject };
        }

        public virtual T Deserialize(object sourceObject) {
            return (T)sourceObject;
        }
    }
}
