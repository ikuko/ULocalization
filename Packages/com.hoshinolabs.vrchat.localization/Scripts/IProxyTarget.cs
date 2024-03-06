using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRC.SDK3.Components;

namespace HoshinoLabs.Localization {
    public interface IProxyTarget {
        Object Target { get; }
    }

    public interface IProxyTarget<T> : IProxyTarget {

    }
}
