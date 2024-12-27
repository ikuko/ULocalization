using HoshinoLabs.Sardinject;

namespace HoshinoLabs.ULocalization.Udon {
    internal static class ComponentContainerBuilderExtensions {
        public static ComponentBindingBuilder OverrideLocalizationInjection(this ContainerBuilder self) {
            var destination = new ComponentDestination();
            var resolverBuilder = new LocalizationResolverBuilder(destination).OverrideScopeIfNeeded(self, Lifetime.Cached);
            var builder = new ComponentBindingBuilder(typeof(Localization), resolverBuilder, destination);
            self.Register(builder);
            return builder;
        }
    }
}
