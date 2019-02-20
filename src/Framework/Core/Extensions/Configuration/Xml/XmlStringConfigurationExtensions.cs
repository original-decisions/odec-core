using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace odec.Framework.Extensions.Configuration.Xml
{
    public static class XmlStringConfigurationExtensions
    {
        private static readonly string StringProviderKey = "SourceString";


        public static IConfigurationBuilder AddXmlFromString(this IConfigurationBuilder builder, string stringProvider)
        {
            return AddXmlFromString(builder, stringProvider: stringProvider, optional: false);
        }


        /// <summary>
        /// Adds a JSON configuration source to <paramref name="builder"/>.
        /// </summary>
        /// <param name="builder">The <see cref="IConfigurationBuilder"/> to add to.</param>
        /// <param name="stringProvider"> string to be parsed to config</param>
        /// <param name="optional">Whether the file is optional.</param>
        /// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
        public static IConfigurationBuilder AddXmlFromString(this IConfigurationBuilder builder, string stringProvider, bool optional)
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
        public static IConfigurationBuilder AddXmlFromString(this IConfigurationBuilder builder, XmlStringSource configureSource)
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
