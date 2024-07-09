using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRC.SDK3.Components;

namespace HoshinoLabs.ULocalization {
    public interface IProxyTarget {
        Object Target { get; }
    }

    public interface IProxyTarget<T> : IProxyTarget {

    }
}
