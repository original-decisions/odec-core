using NUnit.Framework;
using odec.Framework.Attributes;
using odec.Framework.Extensions;
using Assert = NUnit.Framework.Assert;

namespace odec.Framework.CP.Tests
{

    public class EnumExtTester : Tester
    {
        enum MyEnum
        {
            [UniqueCode(Code = "1")]
            First = 1,
            [UniqueCode(Code = "2", Description = "description 2")]
            Second = 2,
            [System.ComponentModel.Description("ololo")]
            Third,
            Forth
        }


        [Test]
        public void GetCodeEnum()
        {
            var firstcode2 = MyEnum.First.GetCodeInfo();
            var secondcode2 = MyEnum.Second.GetCodeInfo();
            var thirdcode2 = MyEnum.Third.GetCodeInfo();
            Assert.True(!string.IsNullOrEmpty(firstcode2.Code) && string.IsNullOrEmpty(firstcode2.Description));
            Assert.True(!string.IsNullOrEmpty(secondcode2.Code) && !string.IsNullOrEmpty(secondcode2.Description));
            Assert.True(string.IsNullOrEmpty(thirdcode2.Code) && string.IsNullOrEmpty(thirdcode2.Description));
        }

        [Test]
        public void GetCodeInfoEnum()
        {
            var firstcode2 = MyEnum.First.GetCodeInfo();
            var secondcode2 = MyEnum.Second.GetCodeInfo();
            var thirdcode2 = MyEnum.Third.GetCodeInfo();
            Assert.True(!string.IsNullOrEmpty(firstcode2.Code) && string.IsNullOrEmpty(firstcode2.Description));
            Assert.True(!string.IsNullOrEmpty(secondcode2.Code) && !string.IsNullOrEmpty(secondcode2.Description));
            Assert.True(string.IsNullOrEmpty(thirdcode2.Code) && string.IsNullOrEmpty(thirdcode2.Description));
        }


        [Test]
        public void GetDescriptionEnum()
        {
            var firstDescription = MyEnum.First.GetDescription();
            var secondDescription = MyEnum.Second.GetDescription();
            var thirdDescription = MyEnum.Third.GetDescription();
            var forthDescription = MyEnum.Forth.GetDescription();
            Assert.True(string.IsNullOrEmpty(forthDescription));
            Assert.True(string.IsNullOrEmpty(firstDescription));
            Assert.False(string.IsNullOrEmpty(secondDescription));
            Assert.False(string.IsNullOrEmpty(thirdDescription));
        }
    }
}
