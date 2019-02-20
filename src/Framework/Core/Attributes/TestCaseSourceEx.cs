using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using NUnit.Framework;

namespace odec.Framework.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class TestCaseSourceEx : TestCaseSourceAttribute
    {
        public TestCaseSourceEx(Type sourceType, string sourceName, [CallerMemberName] string methodName = null)
            : base(sourceType, sourceName)
        {

        }
        public TestCaseSourceEx(string sourceName, [CallerMemberName] string methodName = null)
            : base(sourceName)
        {

        }
    }
}
