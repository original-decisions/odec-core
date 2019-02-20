using System;
using System.Collections.Generic;
using NUnit.Framework;
using odec.Framework.Extensions;

namespace odec.Framework.CP.Tests
{
    class DictionaryExtTester:Tester
    {
        private Dictionary<string, string> _testCollection = new Dictionary<string, string>
        {
            {"1", "q"},
            {"2", "w"},
            {"3", "e"},
            {"4", "r"},
            {"5", "t"},
            {"6", "y"},
        };
        [Test]
        public void DictToStrDefault()
        {
            var result = String.Empty;
            var compareWith = "1=q&2=w&3=e&4=r&5=t&6=y";
            Assert.DoesNotThrow(()=> result= _testCollection.ToKeyValuePairsString());
            Assert.AreEqual(result, compareWith);
        }
        [Test]
        public void DictToStrChangeSeparator()
        {
            var result = String.Empty;
            var compareWith = "1=q;2=w;3=e;4=r;5=t;6=y";
            Assert.DoesNotThrow(() => result = _testCollection.ToKeyValuePairsString(separator:';'));
            Assert.AreEqual(result, compareWith);
        }

        [Test]
        public void DictToStrChangeFormat()
        {
            var result = String.Empty;
            var compareWith = "1>q&2>w&3>e&4>r&5>t&6>y";
            Assert.DoesNotThrow(() => result = _testCollection.ToKeyValuePairsString(format: "{0}>{1}"));
            Assert.AreEqual(result, compareWith);
        }
        [Test]
        public void DictToStrChangeFormatAndSeparator()
        {
            var result = String.Empty;
            var compareWith = "1>q;2>w;3>e;4>r;5>t;6>y";
            Assert.DoesNotThrow(() => result = _testCollection.ToKeyValuePairsString(separator: ';',format:"{0}>{1}"));
            Assert.AreEqual(result, compareWith);
        }

    }
}
