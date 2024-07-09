using HoshinoLabs.ULocalization.Udon;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UdonSharp.Serialization;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.SceneManagement;

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
            //switch (sourceObject) {
            //    case AssetId<LocalizedString> localizedString: {
            //            AssetIdExtensions._listString.Add(localizedString);// TODO
            //            break;
            //        }
            //    case AssetId<LocalizedAsset<AudioClip>> localizedAsset: {
            //            AssetIdExtensions._listAsset.Add(new AssetId<LocalizedAssetBase>(localizedAsset.LocalizedReference));// TODO
            //            break;
            //        }
            //    case AssetId<LocalizedAsset<Texture>> localizedAsset: {
            //            AssetIdExtensions._listAsset.Add(new AssetId<LocalizedAssetBase>(localizedAsset.LocalizedReference));// TODO
            //            break;
            //        }
            //    case AssetId<LocalizedAsset<Sprite>> localizedAsset: {
            //            AssetIdExtensions._listAsset.Add(new AssetId<LocalizedAssetBase>(localizedAsset.LocalizedReference));// TODO
            //            break;
            //        }
            //}
            return sourceObject.Pack();
        }

        public override AssetId<T> Deserialize(object sourceObject) {
            return AssetIdExtensions.UnPack<T>(sourceObject);
        }
    }
    internal sealed class AssetIdArrayBuilder : IProcessSceneWithReport {
        public int callbackOrder => -5001;

        public void OnProcessScene(Scene scene, BuildReport report) {
            var _serializer = typeof(Serializer);
            var _typeCheckSerializers = _serializer.GetField("_typeCheckSerializers", BindingFlags.Static | BindingFlags.NonPublic);
            var typeCheckSerializers = (List<Serializer>)_typeCheckSerializers.GetValue(_serializer);
            typeCheckSerializers.RemoveAll(x => x.GetType() == typeof(AssetIdArraySerializer<LocalizedReference>));
            //typeCheckSerializers.RemoveAll(x => x.GetType() == typeof(GroupIdArraySerializer));
            typeCheckSerializers.Insert(0, new AssetIdArraySerializer<LocalizedReference>(null));
            //typeCheckSerializers.Insert(0, new GroupIdArraySerializer(null));
        }
    }
}
