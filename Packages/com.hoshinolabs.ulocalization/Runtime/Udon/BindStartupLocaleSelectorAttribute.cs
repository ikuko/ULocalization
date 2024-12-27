using System;

namespace HoshinoLabs.ULocalization.Udon {
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public sealed class BindStartupLocaleSelectorAttribute : Attribute {
        public Type BindTo { get; }

        public BindStartupLocaleSelectorAttribute(Type bindTo) {
            BindTo = bindTo;
        }
    }
}
