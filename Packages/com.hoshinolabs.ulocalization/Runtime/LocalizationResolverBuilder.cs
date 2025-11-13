using HoshinoLabs.Sardinject;
using System.Collections.Generic;

namespace HoshinoLabs.ULocalization {
    internal sealed class LocalizationResolverBuilder : IResolverBuilder {
        public Dictionary<object, IResolver> Parameters { get; } = new();

        public LocalizationResolverBuilder() {

        }

        public IBindingResolver Build() {
            return new LocalizationResolver();
        }
    }
}
