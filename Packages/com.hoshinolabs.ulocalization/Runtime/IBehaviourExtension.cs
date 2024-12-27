using UnityEngine;

namespace HoshinoLabs.ULocalization {
    public interface IBehaviourExtension {
        Object Target { get; }
    }

    public interface IBehaviourExtension<T> : IBehaviourExtension {

    }
}
