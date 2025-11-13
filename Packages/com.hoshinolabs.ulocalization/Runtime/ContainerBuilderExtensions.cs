using HoshinoLabs.Sardinject;

namespace HoshinoLabs.ULocalization {
    internal static class ContainerBuilderExtensions {
        public static BindingBuilder OverrideLocalizationInjection(this ContainerBuilder self) {
            var resolverBuilder = new LocalizationResolverBuilder().OverrideScopeIfNeeded(self, Lifetime.Cached);
            var builder = new BindingBuilder(typeof(Localization), resolverBuilder);
            self.Register(builder);
            return builder;
        }
    }
}
