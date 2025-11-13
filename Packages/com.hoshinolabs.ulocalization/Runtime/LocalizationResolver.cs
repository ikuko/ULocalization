using HoshinoLabs.Sardinject;
using System;

namespace HoshinoLabs.ULocalization {
    internal sealed class LocalizationResolver : IBindingResolver {
        public object Resolve(Type type, Container container) {
            return new Localization();
        }
    }
}
