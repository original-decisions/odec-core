using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;

namespace odec.Framework.Extensions.Configuration
{
    public static class JsonStringConfiguraitonExtensions
    {
        private static readonly string StringProviderKey = "SourceString";

        public static IConfigurationBuilder AddJsonFromString(this IConfigurationBuilder builder, string stringProvider)
        {
            return AddJsonFromString(builder, stringProvider: stringProvider, optional: false);
        }

        /// <summary>
        /// Adds a JSON configuration source to <paramref name="builder"/>.
        /// </summary>
        /// <param name="builder">The <see cref="IConfigurationBuilder"/> to add to.</param>
        /// <param name="provider">The <see cref="IFileProvider"/> to use to access the file.</param>
        /// <param name="path">Path relative to the base path stored in 
        /// <see cref="IConfigurationBuilder.Properties"/> of <paramref name="builder"/>.</param>
        /// <param name="optional">Whether the file is optional.</param>
        /// <param name="reloadOnChange">Whether the configuration should be reloaded if the file changes.</param>
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
        /// Adds a JSON configuration source to <paramref name="builder"/>.
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
        /// Gets the default <see cref="IFileProvider"/> to be used for file-based providers.
        /// </summary>
        /// <param name="builder">The <see cref="IConfigurationBuilder"/>.</param>
        /// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
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
