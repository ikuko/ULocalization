using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Localization.Components;

namespace HoshinoLabs.Localization {
    public static class LocalizeComponentExtensions {
        public static bool TryGetRuntimeGroupId(this LocalizeAudioClipEvent self, out int groupId) {
            return LocalizationHelper.ReferenceGroupIds.TryGetValue(self, out groupId);
        }

        public static int GetRuntimeGroupId(this LocalizeAudioClipEvent self) {
            if (self.TryGetRuntimeGroupId(out var groupId)) {
                return groupId;
            }
            throw new Exception("Group ID could not be found.");
        }

        public static bool TryGetRuntimeGroupId(this LocalizeStringEvent self, out int groupId) {
            return LocalizationHelper.ReferenceGroupIds.TryGetValue(self, out groupId);
        }

        public static int GetRuntimeGroupId(this LocalizeStringEvent self) {
            if (self.TryGetRuntimeGroupId(out var groupId)) {
                return groupId;
            }
            throw new Exception("Group ID could not be found.");
        }

        public static bool TryGetRuntimeGroupId(this LocalizeTextureEvent self, out int groupId) {
            return LocalizationHelper.ReferenceGroupIds.TryGetValue(self, out groupId);
        }

        public static int GetRuntimeGroupId(this LocalizeTextureEvent self) {
            if (self.TryGetRuntimeGroupId(out var groupId)) {
                return groupId;
            }
            throw new Exception("Group ID could not be found.");
        }

        public static bool TryGetRuntimeGroupId(this LocalizeSpriteEvent self, out int groupId) {
            return LocalizationHelper.ReferenceGroupIds.TryGetValue(self, out groupId);
        }

        public static int GetRuntimeGroupId(this LocalizeSpriteEvent self) {
            if (self.TryGetRuntimeGroupId(out var groupId)) {
                return groupId;
            }
            throw new Exception("Group ID could not be found.");
        }

        public static bool TryGetRuntimeGroupId(this LocalizedMonoBehaviour self, out int groupId) {
            return LocalizationHelper.ReferenceGroupIds.TryGetValue(self, out groupId);
        }

        public static int GetRuntimeGroupId(this LocalizedMonoBehaviour self) {
            if (self.TryGetRuntimeGroupId(out var groupId)) {
                return groupId;
            }
            throw new Exception("Group ID could not be found.");
        }
    }
}
