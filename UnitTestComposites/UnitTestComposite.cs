using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RSIComposite;

namespace UnitTestComposites
{

    [TestClass]
    public class UnitTestComposite
    {

        class DerivedComposite : Composite
        {
            public DerivedComposite() : base() { }

            public DerivedComposite(string type) : base(type) { }

            public DerivedComposite(string type, string name) : base(type, name) { }

            public DerivedComposite(string type, string name, string value) : base(type, name, value) { }
        }


        #region ObjectId
        [TestMethod]
        public void TestObjectId ()
        {
            Composite.resetObjectId();

            for(int i = 1; i < 101; i++)
            {
                Composite com = new Composite();

                Assert.IsTrue(com.ObjectID == i );
            }
        }

        #endregion

        #region Constructors 

        [TestMethod]
        public void TestCompositeConstructor()
        {
            Composite.resetObjectId();

            Composite com = new Composite();

            Assert.IsTrue(com.ObjectID == 1);
            Assert.IsTrue(com.Type == "Composite");
            Assert.IsTrue(String.IsNullOrEmpty(com.Name));
            Assert.IsTrue(String.IsNullOrEmpty(com.Value));
            Assert.IsNotNull(com.Parents);
            Assert.IsNotNull(com.Children);

        }

 

        [TestMethod]
        public void TestDerivedCompositeConstructor()
        {
            Composite.resetObjectId();

            Composite com = new DerivedComposite();

            Assert.IsTrue(com.ObjectID == 1);
            Assert.IsTrue(com.Type == "DerivedComposite");
            Assert.IsTrue(String.IsNullOrEmpty(com.Name));
            Assert.IsTrue(String.IsNullOrEmpty(com.Value));
            Assert.IsNotNull(com.Parents);
            Assert.IsNotNull(com.Children);

        }

        [TestMethod]

        public void TestConstructorType()
        {
            Composite.resetObjectId();

            Composite com1 = new Composite("DerivedComposite");
            DerivedComposite com2 = new DerivedComposite();

            Assert.IsTrue(com1.Type == "DerivedComposite" && com2.Type == "DerivedComposite");
            Assert.IsTrue(String.IsNullOrEmpty(com1.Name) && String.IsNullOrEmpty (com2.Name));
            Assert.IsTrue(String.IsNullOrEmpty(com1.Value) && String.IsNullOrEmpty(com2.Value));
            Assert.IsNotNull(com1.Parents);
            Assert.IsNotNull(com2.Parents);
            Assert.IsNotNull(com1.Children);
            Assert.IsNotNull(com2.Children);
        }

        [TestMethod]

        public void TestConstructorTypeName()
        {
            Composite.resetObjectId();

            Composite com1 = new Composite("Book", "C# Programming");

            Assert.IsTrue(com1.Type == "Book" && com1.Name == "C# Programming");
        }

        [TestMethod]

        public void TestConstructorTypeNameValue()
        {
            Composite.resetObjectId();

            Composite com1 = new Composite("Book", "C# Programming", "Release 1");

            Assert.IsTrue(com1.Type == "Book" && com1.Name == "C# Programming" && com1.Value == "Release 1");
        }


        [TestMethod]
        public void TestDerivedConstructorTypeName()
        {
            Composite.resetObjectId();

            DerivedComposite com1 = new DerivedComposite("Book", "C# Programming");

            Assert.IsTrue(com1.Type == "Book" && com1.Name == "C# Programming");
        }

        [TestMethod]

        public void TestDerivedConstructorTypeNameValue()
        {
            Composite.resetObjectId();

            DerivedComposite com1 = new DerivedComposite("Book", "C# Programming", "Chapter 1");

            Assert.IsTrue(com1.Type == "Book" && com1.Name == "C# Programming" && com1.Value == "Chapter 1");
        }

        #endregion

        #region Types

        #region Constructors
        [TestMethod]
        public void TestTypeAssignedByEmptyConstructor()
        {
            Composite com1 = new Composite();
            DerivedComposite com2 = new DerivedComposite();

            Assert.IsTrue(com1.Type == "Composite");

            Assert.IsTrue(com1.GetType().Name == "Composite");

            Assert.IsTrue(com2.Type == "DerivedComposite");

            Assert.IsTrue(com2.GetType().Name == "DerivedComposite");

        }

        [TestMethod]
        public void TestTypeAssignedByTypeConstructor()
        {
            Composite parent = new Composite("Parent");
            DerivedComposite son = new DerivedComposite("Son");

            Assert.IsTrue(parent.Type == "Parent");

            Assert.IsTrue(parent.GetType().Name == "Composite");

            Assert.IsTrue(son.Type == "Son");

            Assert.IsTrue(son.GetType().Name == "DerivedComposite");


        }

        [TestMethod]
        public void TestTypeAssignedByTypeNameConstructor()
        {
            Composite parent = new Composite("Parent", "Father");
            DerivedComposite child = new DerivedComposite("Child", "Son");

            Assert.IsTrue(parent.Type == "Parent");

            Assert.IsTrue(parent.GetType().Name == "Composite");
            Assert.IsTrue(child.Type == "Child");
            Assert.IsFalse(child.Type == "child");

            Assert.IsTrue(child.GetType().Name == "DerivedComposite");


        }

        [TestMethod]
        public void TestTypeAssignedByTypeNameValueConstructor()
        {
            Composite parent = new Composite("Parent", "Father", "Mark");
            DerivedComposite child = new DerivedComposite("Child", "Son", "Fred");

            Assert.IsTrue(parent.Type == "Parent");
            Assert.IsFalse(parent.Type == "parent");

            Assert.IsTrue(parent.GetType().Name == "Composite");

            Assert.IsTrue(child.Type == "Child");
            Assert.IsFalse(child.Type == "child");

            Assert.IsTrue(child.GetType().Name == "DerivedComposite");


        }
        #endregion
        
        #region getType

        [TestMethod]
        public void TestGetTypeByType()
        {
            Composite com = new Composite();

            for(int i = 0;  i < 10; i++)
            { com.addChild(new Composite()); }

            for (int i = 0; i < 10; i++)
            { com.addChild(new DerivedComposite()); }

            Assert.IsTrue(com.Children.Count == 20);
            Assert.IsTrue(com.getType<Composite>().Count == 10);
            Assert.IsTrue(com.getType<DerivedComposite>().Count == 10);

        }

        [TestMethod]
        public void TestGetTypeByTypeName()
        {
            Composite com = new Composite();

            for (int i = 0; i < 10; i++)
            { com.addChild(new Composite("COM1")); }

            for (int i = 0; i < 10; i++)
            { com.addChild(new DerivedComposite("COM2")); }

            Assert.IsTrue(com.Children.Count == 20);
            Assert.IsTrue(com.getType("COM1").Count == 10);
            Assert.IsTrue(com.getType("COM2").Count == 10);

        }

        #endregion
        #endregion

        #region Child

        [TestMethod]
        public void TestAddChild()
        {

            Composite grandFather = new Composite();
            Composite grandMother = new Composite();

            Composite father = new Composite();
            Composite mother = new Composite();

            Composite son = new Composite();
            Composite daughter = new Composite();
            DerivedComposite stepDaughter = new DerivedComposite();

            grandFather.addChild(father);
            grandMother.addChild(mother);

            father.addChild(son);
            father.addChild(daughter);
            father.addChild(stepDaughter);

            mother.addChild(son);
            mother.addChild(daughter);

            Assert.IsTrue(grandFather.Children.Count == 1);
            Assert.IsTrue(grandMother.Children.Count == 1);

            Assert.IsTrue(father.Children.Count == 3);
            Assert.IsTrue(mother.Children.Count == 2);

            Assert.IsTrue(son.Parents.Count == 2);
            Assert.IsTrue(daughter.Parents.Count == 2);
            Assert.IsTrue(stepDaughter.Parents.Count == 1);
                      
            Assert.IsTrue(son.Children.Count == 0);
            Assert.IsTrue(daughter.Children.Count == 0);
            Assert.IsTrue(stepDaughter.Children.Count == 0);
        }

        [TestMethod]
        public void TestRemoveChildFromParentAndParentFromChild()
        {
            Composite parent = new Composite();
            Composite son = new Composite();
            Composite daughter = new Composite();

            parent.addChild(son);
            parent.addChild(daughter);

            Assert.IsTrue(parent.Children.Count == 2);
            Assert.IsTrue(son.Parents.Count == 1);

            parent.removeChild(son);

            Assert.IsTrue(parent.Children.Count == 1);
            Assert.IsTrue(son.Parents.Count == 0);

        }

        [TestMethod]
        public void TestRemoveChildFromParentAndDoNotRemoveParentFromChild()
        {
            Composite parent = new Composite();
            Composite son = new Composite();
            Composite daughter = new Composite();

            parent.addChild(son);
            parent.addChild(daughter);

            Assert.IsTrue(parent.Children.Count == 2);
            Assert.IsTrue(son.Parents.Count == 1);

            parent.removeChild(son, false);

            Assert.IsTrue(parent.Children.Count == 1);
            Assert.IsTrue(son.Parents.Count == 1);

        }


        #endregion

        #region Parent

        [TestMethod]
        public void TestRemoveParentFromChild()
        {
            Composite father = new Composite();
            Composite mother = new Composite();
            Composite daughter = new Composite();

            father.addChild(daughter);
            mother.addChild(daughter);

            Assert.IsTrue(father.Children.Count == 1);
            Assert.IsTrue(mother.Children.Count == 1);
            Assert.IsTrue(daughter.Parents.Count == 2);

            daughter.removeParent(mother);

            Assert.IsTrue(mother.Children.Count == 0);
            Assert.IsTrue(daughter.Parents.Count == 1);

        }

        [TestMethod]
        public void TestRemoveParentFromChildAndDoNotRemoveChildFromParent()
        {
            Composite father = new Composite();
            Composite mother = new Composite();
            Composite daughter = new Composite();

            father.addChild(daughter);
            mother.addChild(daughter);

            Assert.IsTrue(father.Children.Count == 1);
            Assert.IsTrue(mother.Children.Count == 1);
            Assert.IsTrue(daughter.Parents.Count == 2);

            daughter.removeParent(mother, false);

            Assert.IsTrue(mother.Children.Count == 1);
            Assert.IsTrue(daughter.Parents.Count == 1);

        }


        #endregion

        
        

    
        
    }
}
