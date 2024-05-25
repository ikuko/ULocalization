using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoshinoLabs.Localization.Udon {
    public abstract class LocalizationSignal {
        public virtual void OnSelectedLocaleChanged(string locale) { }
    }
}
