using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Localization.Components;

namespace HoshinoLabs.Localization {
    public static class LocalizeComponentExtensions {
        public static bool TryGetRuntimeGroupId(this LocalizeAudioClipEvent self, out int groupId) {
            return LocalizationHelper.ReferenceGroupIds.TryGetValue(GlobalObjectId.GetGlobalObjectIdSlow(self), out groupId);
        }

        public static int GetRuntimeGroupId(this LocalizeAudioClipEvent self, out int groupId) {
            if (self.TryGetRuntimeGroupId(out groupId)) {
                return groupId;
            }
            throw new Exception("Group ID could not be found.");
        }

        public static bool TryGetRuntimeGroupId(this LocalizeStringEvent self, out int groupId) {
            return LocalizationHelper.ReferenceGroupIds.TryGetValue(GlobalObjectId.GetGlobalObjectIdSlow(self), out groupId);
        }

        public static int GetRuntimeGroupId(this LocalizeStringEvent self, out int groupId) {
            if (self.TryGetRuntimeGroupId(out groupId)) {
                return groupId;
            }
            throw new Exception("Group ID could not be found.");
        }

        public static bool TryGetRuntimeGroupId(this LocalizeTextureEvent self, out int groupId) {
            return LocalizationHelper.ReferenceGroupIds.TryGetValue(GlobalObjectId.GetGlobalObjectIdSlow(self), out groupId);
        }

        public static int GetRuntimeGroupId(this LocalizeTextureEvent self, out int groupId) {
            if (self.TryGetRuntimeGroupId(out groupId)) {
                return groupId;
            }
            throw new Exception("Group ID could not be found.");
        }

        public static bool TryGetRuntimeGroupId(this LocalizeSpriteEvent self, out int groupId) {
            return LocalizationHelper.ReferenceGroupIds.TryGetValue(GlobalObjectId.GetGlobalObjectIdSlow(self), out groupId);
        }

        public static int GetRuntimeGroupId(this LocalizeSpriteEvent self, out int groupId) {
            if (self.TryGetRuntimeGroupId(out groupId)) {
                return groupId;
            }
            throw new Exception("Group ID could not be found.");
        }
    }
}
