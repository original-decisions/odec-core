using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace odec.Framework.Extensions.Configuration
{
    /// <summary>
    /// Provides the logic how to parse the string as the configuration.
    /// </summary>
    public class JsonStringProvider : ConfigurationProvider, IConfigurationProvider
    {
        /// <summary>
        /// Constructor accepting the string <see cref="JsonStringSource"/>
        /// </summary>
        /// <param name="source"></param>
        public JsonStringProvider(JsonStringSource source)
        {
            Source = source ?? throw new ArgumentNullException(nameof(source));
        }

        /// <inheritdoc />
        public override void Load()
        {
            var str = Source.SourceString;
            if (string.IsNullOrEmpty(str))
            {
                if (Source.Optional) // Always optional on reload
                {
                    Data = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                }
                else
                {
                    var error = new StringBuilder($"The configuration string '{Source.SourceString}' was not found and is not optional.");
                    throw new Exception(error.ToString());
                }
            }
            else
            {
                Data = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                using (var sr = new StringReader(str))
                {
                    try
                    {

                        Data = JsonConfigurationStringParser.Parse(sr);
                    }
                    catch (JsonReaderException ex)
                    {
                        throw ex;
                        //string errorLine = string.Empty;
                        //if (sr.CanSeek)
                        //{
                        //    stream.Seek(0, SeekOrigin.Begin);

                        //    IEnumerable<string> fileContent;
                        //    using (var streamReader = new StreamReader(stream))
                        //    {
                        //        fileContent = ReadLines(streamReader);
                        //        errorLine = RetrieveErrorContext(e, fileContent);
                        //    }
                        //}

                        //throw new FormatException(Resources.FormatError_JSONParseError(e.LineNumber, errorLine), e);
                    }
                }
            }

        }

        /// <summary>
        /// The source settings for this provider.
        /// </summary>
        public JsonStringSource Source { get; }

        /// <summary>
        /// Reads the line from a stream.
        /// </summary>
        /// <param name="streamReader">stream reader object. <see cref="StreamReader"/></param>
        /// <returns>Returns the text strings.</returns>
        private static IEnumerable<string> ReadLines(StreamReader streamReader)
        {
            string line;
            do
            {
                line = streamReader.ReadLine();
                yield return line;
            } while (line != null);
        }
    }
}
