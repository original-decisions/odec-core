﻿using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace odec.Framework.Extensions.Configuration
{
    /// <summary>
    /// The class is used internally to parse the Json from a string.
    /// </summary>
    internal class JsonConfigurationStringParser
    {

        private JsonConfigurationStringParser() { }



        private readonly IDictionary<string, string> _data = new SortedDictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        private readonly Stack<string> _context = new Stack<string>();
        private string _currentPath;

        private JsonTextReader _reader;

        /// <summary>
        /// Parses the Json configuration from a <see cref="StringReader"/>.
        /// </summary>
        /// <param name="input"><see cref="StringReader"/> object to be parsed</param>
        /// <returns>Key value dictionary for the result. <see cref="IDictionary{String,String}"/></returns>
        public static IDictionary<string, string> Parse(StringReader input)
            => new JsonConfigurationStringParser().ParseStream(input);

        /// <summary>
        /// The real Method which is doing the Job. It basically takes the stream and 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private IDictionary<string, string> ParseStream(StringReader input)
        {
            _data.Clear();
            _reader = new JsonTextReader(input) { DateParseHandling = DateParseHandling.None };
            var jsonConfig = JObject.Load(_reader);
            VisitJObject(jsonConfig);

            return _data;
        }

        private void VisitJObject(JObject jObject)
        {
            foreach (var property in jObject.Properties())
            {
                EnterContext(property.Name);
                VisitProperty(property);
                ExitContext();
            }
        }

        private void VisitProperty(JProperty property)
        {
            VisitToken(property.Value);
        }

        private void VisitToken(JToken token)
        {
            switch (token.Type)
            {
                case JTokenType.Object:
                    VisitJObject(token.Value<JObject>());
                    break;

                case JTokenType.Array:
                    VisitArray(token.Value<JArray>());
                    break;

                case JTokenType.Integer:
                case JTokenType.Float:
                case JTokenType.String:
                case JTokenType.Boolean:
                case JTokenType.Bytes:
                case JTokenType.Raw:
                case JTokenType.Null:
                    VisitPrimitive(token.Value<JValue>());
                    break;

                default:
                    throw new FormatException(string.Format("Unsupported JSON token '{0}' was found. Path '{1}', line {2} position {3}.",
                        _reader.TokenType,
                        _reader.Path,
                        _reader.LineNumber,
                        _reader.LinePosition));
            }
        }

        /// <summary>
        /// Parses the <see cref="JArray" />
        /// </summary>
        /// <param name="array"></param>
        private void VisitArray(JArray array)
        {
            for (int index = 0; index < array.Count; index++)
            {
                EnterContext(index.ToString());
                VisitToken(array[index]);
                ExitContext();
            }
        }

        private void VisitPrimitive(JValue data)
        {
            var key = _currentPath;

            if (_data.ContainsKey(key))
            {
                throw new FormatException("Duplicate key found. Please check configuration.");
            }
            _data[key] = data.ToString(CultureInfo.InvariantCulture);
        }

        private void EnterContext(string context)
        {
            _context.Push(context);
            _currentPath = ConfigurationPath.Combine(_context.Reverse());
        }
        
        private void ExitContext()
        {
            _context.Pop();
            _currentPath = ConfigurationPath.Combine(_context.Reverse());
        }
    }

}
