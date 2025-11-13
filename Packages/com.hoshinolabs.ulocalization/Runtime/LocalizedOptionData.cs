using System;
using UnityEngine;
using UnityEngine.Localization;

namespace HoshinoLabs.ULocalization {
    [Serializable]
    public sealed class LocalizedOptionData {
        event ChangeHandler changeHandler;

        public delegate void ChangeHandler();

        public event ChangeHandler OptionChanged {
            add {
                if (value == null) {
                    throw new ArgumentNullException();
                }
                changeHandler += value;
            }
            remove {
                changeHandler -= value;
            }
        }

        [SerializeField]
        LocalizedString text = new();
        [SerializeField]
        LocalizedSprite image = new();

        public LocalizedString Text {
            get => text;
            set {
                ClearChangeHandler();
                text = value;
                RegisterChangeHandler();
            }
        }

        public LocalizedSprite Image {
            get => image;
            set {
                ClearChangeHandler();
                image = value;
                RegisterChangeHandler();
            }
        }

        public LocalizedOptionData() {

        }

        public LocalizedOptionData(LocalizedString text) {
            this.text = text;
        }

        public LocalizedOptionData(LocalizedSprite image) {
            this.image = image;
        }

        public LocalizedOptionData(LocalizedString text, LocalizedSprite image) {
            this.text = text;
            this.image = image;
        }

        void UpdateString(string value) {
            changeHandler?.Invoke();
        }

        void UpdateAsset(Sprite value) {
            changeHandler?.Invoke();
        }

        void RegisterChangeHandler() {
            if (text != null) {
                text.StringChanged += UpdateString;
            }
            if (image != null) {
                image.AssetChanged += UpdateAsset;
            }
        }

        void ClearChangeHandler() {
            if (text != null) {
                text.StringChanged -= UpdateString;
            }
            if (image != null) {
                image.AssetChanged -= UpdateAsset;
            }
        }
    }
}
