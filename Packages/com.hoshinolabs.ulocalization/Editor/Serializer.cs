using System;
using System.Collections;
using System.Collections.Generic;
using UdonSharp.Serialization;
using UnityEngine;

namespace HoshinoLabs.ULocalization {
    internal class Serializer<T> : UdonSharp.Serialization.Serializer<T> {
        public Serializer(TypeSerializationMetadata typeMetadata)
            : base(typeMetadata) {

        }

        protected override Serializer MakeSerializer(TypeSerializationMetadata typeMetadata) {
            VerifyTypeCheckSanity();
            return new Serializer<T>(typeMetadata);
        }

        protected override bool HandlesTypeSerialization(TypeSerializationMetadata typeMetadata) {
            VerifyTypeCheckSanity();
            return typeMetadata.cSharpType == typeof(T);
        }

        public override void Write(IValueStorage targetObject, in T sourceObject) {
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

            var _sourceObject = Serialize(sourceObject);
            if (_sourceObject == null) {
                targetObject.Value = null;
                return;
            }
            var behaviourSerializer = CreatePooled(_sourceObject.GetType());
            behaviourSerializer.WriteWeak(targetObject, _sourceObject);
        }

        public override void Read(ref T targetObject, IValueStorage sourceObject) {
            VerifySerializationSanity();
        }

        public override Type GetUdonStorageType() {
            return typeof(object);
        }

        public virtual object Serialize(in T sourceObject) {
            return new object[] { sourceObject };
        }

        public virtual T Deserialize(object sourceObject) {
            return (T)sourceObject;
        }
    }
}
