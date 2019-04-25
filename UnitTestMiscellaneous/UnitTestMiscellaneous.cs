using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestMiscellaneous
{

    public interface ITypeTest
    {
        String hello { get; set; }
    }

    public class typeTest1 : ITypeTest
    {

        public String hello { get; set; } = "HelloWorld 1";                
        

    }

    public class typeTest2 : ITypeTest
    {
        public String hello { get; set; } = "HelloWorld 2";


    }



    [TestClass]
    public class UnitTestMiscellaneous
    {
        [TestMethod]
        public void TestMethod1()
        {
  
            Type objectType1 = Type.GetType(typeof(typeTest1).AssemblyQualifiedName);
            Type objectType2 = Type.GetType(typeof(typeTest2).AssemblyQualifiedName);

            ITypeTest instantiatedObject1 = (ITypeTest) Activator.CreateInstance(objectType1);
            ITypeTest instantiatedObject2 = (ITypeTest)Activator.CreateInstance(objectType2);

            Assert.IsTrue(instantiatedObject1.hello == "HelloWorld 1");
            Assert.IsTrue(instantiatedObject2.hello == "HelloWorld 2");

        }
    }
}
