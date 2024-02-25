using System;
using System.Collections;
using System.Collections.Generic;
using UdonSharp;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.SmartFormat.PersistentVariables;

namespace HoshinoLabs.Localization {
    [Serializable]
    [DisplayName("Udon")]
    public sealed class UdonVariable : Variable<UdonSharpBehaviour> { }
}
