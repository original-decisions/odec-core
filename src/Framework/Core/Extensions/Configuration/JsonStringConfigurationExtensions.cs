using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;

namespace odec.Framework.Extensions.Configuration
{

    /// <summary>
    /// Extension class which extends the configuration builder with additional configuration source,
    /// which is coming from simple string. For more <see cref="JsonStringSource"/>
    /// </summary>
    public static class JsonStringConfigurationExtensions
    {
        /// <summary>
        /// Unique key for the string provider.
        /// </summary>
        private static readonly string StringProviderKey = "SourceString";
        /// <summary>
        /// Adds a JSON string configuration source to <paramref name="builder"/>.
        /// </summary>
        /// <param name="builder">The <see cref="IConfigurationBuilder"/> to add to.</param>
        /// <param name="stringProvider">The default string provider instance.</param>
        /// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
        public static IConfigurationBuilder AddJsonFromString(this IConfigurationBuilder builder, string stringProvider)
        {
            return AddJsonFromString(builder, stringProvider: stringProvider, optional: false);
        }

        /// <summary>
        /// Adds a JSON string configuration source to <paramref name="builder"/>.
        /// </summary>
        /// <param name="builder">The <see cref="IConfigurationBuilder"/> to add to.</param>
        /// <param name="stringProvider">The default string provider instance.</param>
        /// <param name="optional"></param>
        /// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
        public static IConfigurationBuilder AddJsonFromString(this IConfigurationBuilder builder, string stringProvider, bool optional)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            return builder.AddJsonFromString(new JsonStringSource
            {
                SourceString = stringProvider,
                Optional = optional
            });
        }

        /// <summary>
        /// Adds a JSON string configuration source to <paramref name="builder"/>.
        /// </summary>
        /// <param name="builder">The <see cref="IConfigurationBuilder"/> to add to.</param>
        /// <param name="configureSource">Configures the source.</param>
        /// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
        public static IConfigurationBuilder AddJsonFromString(this IConfigurationBuilder builder, JsonStringSource configureSource)
        {
            return builder.Add(configureSource);
        }

        /// <summary>
        /// Sets the default <see cref="String"/> to be used for file-based providers.
        /// </summary>
        /// <param name="builder">The <see cref="IConfigurationBuilder"/> to add to.</param>
        /// <param name="stringProvider">The default string provider instance.</param>
        /// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
        public static IConfigurationBuilder SetStringProvider(this IConfigurationBuilder builder, string stringProvider)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.Properties[StringProviderKey] = stringProvider ?? throw new ArgumentNullException(nameof(stringProvider));
            return builder;
        }

        /// <summary>
        /// Gets the default string provider name. (actually it is a useless method i probably should delete)
        /// </summary>
        /// <param name="builder">The <see cref="IConfigurationBuilder"/>.</param>
        /// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
        [Obsolete]
        public static string GetStringProvider(this IConfigurationBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (builder.Properties.TryGetValue(StringProviderKey, out object provider))
            {
                return builder.Properties[StringProviderKey] as string;
            }

            return null;
        }
    }
}
