using HoshinoLabs.Sardinject;
using System.Collections.Generic;

namespace HoshinoLabs.ULocalization.Udon {
    internal sealed class LocalizationResolverBuilder : IResolverBuilder {
        public Dictionary<object, IResolver> Parameters { get; } = null;

        readonly ComponentDestination destination;

        public LocalizationResolverBuilder(ComponentDestination destination) {
            this.destination = destination;
        }

        public IBindingResolver Build() {
            return new LocalizationResolver(destination);
        }
    }
}
