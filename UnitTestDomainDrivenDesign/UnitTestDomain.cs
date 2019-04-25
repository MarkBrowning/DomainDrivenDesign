using System;
using DomainDrivenDesign;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RSIComposite;

namespace UnitTestDomainDrivenDesign
{

 
    [TestClass]
    public class UnitTestDomainDrivenDesign
    {


        #region Domain

        [TestMethod]
        public void NewDomainConstructorsTest()
        {
            Domain domain = new Domain();
            Domain accountingDomain = new Domain("Accounting");
            Domain accountingDomainAlabama = new Domain("Accounting", "Alabama");

            Assert.IsTrue(domain.Type == "Domain");
            Assert.IsTrue(accountingDomain.Type == "Domain" && accountingDomain.Name == "Accounting");

            Assert.IsTrue(accountingDomainAlabama.Type == "Domain" 
                && accountingDomainAlabama.Name == "Accounting"
                && accountingDomainAlabama.Value == "Alabama");
        }

        #region DomainAggregates


        [TestMethod]

        public void DomainAggregatesTest()
        {
            Domain accounting = new Domain();

            for(int i = 0; i < 100; i++)
            {
                accounting.addChild(new Composite("Child " +i.ToString()));
                accounting.addAggregate(i.ToString());
            }

            Assert.IsTrue(accounting.Children.Count == 200);
            Assert.IsTrue(accounting.Aggregates.Count == 100);

        }
        [TestMethod]

        public void DomainAddAggregateByNameTest()
        {
            Domain accountDomain = new Domain();

            for(int i =0;i < 5; i++)
                accountDomain.addAggregate("Budget");

            for(int i =0; i < 5;i++)
                accountDomain.addAggregate("AdjustedBudget");

            Assert.IsTrue(accountDomain.Aggregates.Count == 2);

        }

        [TestMethod]

        public void DomainAddAggregateByAggregateTypeTest()
        {
            Domain accountDomain = new Domain();

            for (int i = 0; i < 5; i++)
                accountDomain.addAggregate(new Aggregate("Budget"));

            for (int i = 0; i < 5; i++)
                accountDomain.addAggregate(new Aggregate("AdjustedBudget"));

            Assert.IsTrue(accountDomain.Aggregates.Count == 2);

        }


        [TestMethod]

        public void DomainGetAggregateTest()
        {
            Domain accountingDomain = new Domain();

           for(int i= 0; i < 100; i++)
            {
                if (i == 85)
                    accountingDomain.addAggregate(new Aggregate(i.ToString(), "test aggregate"));
                else
                    accountingDomain.addAggregate(i.ToString());
            }

            Assert.IsTrue(accountingDomain.getAggregate("85").Value == "test aggregate");
            Assert.IsNull(accountingDomain.getAggregate("400"));

        }

        [TestMethod]

        public void DomainRemoveAggregate()
        {
            Domain accounting = new Domain();

            for (int i = 0; i < 100; i++)
                accounting.addAggregate(i.ToString());

            Assert.IsTrue(accounting.Aggregates.Count == 100);

            for (int i = 0; i < 50; i++)
                accounting.removeAggregate(i.ToString());

            accounting.removeAggregate("200");

            Assert.IsTrue(accounting.Aggregates.Count == 50);

        }

        #endregion

        #region DomainEntities


        [TestMethod]

        public void DomainEntitiesTest()
        {
            Domain accounting = new Domain();

            for (int i = 0; i < 100; i++)
            {
                accounting.addChild(new Composite("Child " + i.ToString()));
                accounting.addEntity(i.ToString());
            }

            Assert.IsTrue(accounting.Children.Count == 200);
            Assert.IsTrue(accounting.Entities.Count == 100);

        }
        [TestMethod]

        public void DomainAddEntityByNameTest()
        {
            Domain accountDomain = new Domain();

            for (int i = 0; i < 5; i++)
                accountDomain.addEntity("Budget");

            for (int i = 0; i < 5; i++)
                accountDomain.addEntity("AdjustedBudget");

            Assert.IsTrue(accountDomain.Entities.Count == 2);

        }

        [TestMethod]

        public void DomainAddEntityByEntityTypeTest()
        {
            Domain accountDomain = new Domain();

            for (int i = 0; i < 5; i++)
                accountDomain.addEntity(new Entity("Budget"));

            for (int i = 0; i < 5; i++)
                accountDomain.addEntity(new Entity("AdjustedBudget"));

            Assert.IsTrue(accountDomain.Entities.Count == 2);

        }


        [TestMethod]

        public void DomainGetEntityTest()
        {
            Domain accountingDomain = new Domain();

            for (int i = 0; i < 100; i++)
            {
                if (i == 85)
                    accountingDomain.addEntity(new Entity(i.ToString(), "test entity"));
                else
                    accountingDomain.addEntity(i.ToString());
            }

            Assert.IsTrue(accountingDomain.getEntity("85").Value == "test entity");
            Assert.IsNull(accountingDomain.getEntity("400"));

        }

        [TestMethod]

        public void DomainRemoveEntity()
        {
            Domain accounting = new Domain();

            for (int i = 0; i < 100; i++)
                accounting.addEntity(i.ToString());

            Assert.IsTrue(accounting.Entities.Count == 100);

            for (int i = 0; i < 50; i++)
                accounting.removeEntity(i.ToString());

            accounting.removeEntity("200");

            Assert.IsTrue(accounting.Entities.Count == 50);

        }

        #endregion

        #region DomainServices


        [TestMethod]

        public void DomainServicesTest()
        {
            Domain accounting = new Domain();

            for (int i = 0; i < 100; i++)
            {
                accounting.addChild(new Composite("Child " + i.ToString()));
                accounting.addService(i.ToString());
            }

            Assert.IsTrue(accounting.Children.Count == 200);
            Assert.IsTrue(accounting.Services.Count == 100);

        }
        [TestMethod]

        public void DomainAddServiceByNameTest()
        {
            Domain accountDomain = new Domain();

            for (int i = 0; i < 5; i++)
                accountDomain.addService("Budget");

            for (int i = 0; i < 5; i++)
                accountDomain.addService("AdjustedBudget");

            Assert.IsTrue(accountDomain.Services.Count == 2);

        }

        [TestMethod]

        public void DomainAddServiceByEntityTypeTest()
        {
            Domain accountDomain = new Domain();

            for (int i = 0; i < 5; i++)
                accountDomain.addService(new Service("Budget"));

            for (int i = 0; i < 5; i++)
                accountDomain.addService(new Service("AdjustedBudget"));

            Assert.IsTrue(accountDomain.Services.Count == 2);

        }


        [TestMethod]

        public void DomainGetServiceTest()
        {
            Domain accountingDomain = new Domain();

            for (int i = 0; i < 100; i++)
            {
                if (i == 85)
                    accountingDomain.addService(new Service(i.ToString(), "test service"));
                else
                    accountingDomain.addService(i.ToString());
            }

            Assert.IsTrue(accountingDomain.getService("85").Value == "test service");
            Assert.IsNull(accountingDomain.getService("400"));

        }

        [TestMethod]

        public void DomainRemoveService()
        {
            Domain accounting = new Domain();

            for (int i = 0; i < 100; i++)
                accounting.addService(i.ToString());

            Assert.IsTrue(accounting.Services.Count == 100);

            for (int i = 0; i < 50; i++)
                accounting.removeService(i.ToString());

            accounting.removeService("200");

            Assert.IsTrue(accounting.Services.Count == 50);

        }

        #endregion

        #region DomainSubDomains


        [TestMethod]

        public void DomainSubDomainsTest()
        {
            Domain accounting = new Domain();

            for (int i = 0; i < 100; i++)
            {
                accounting.addChild(new Composite("Child " + i.ToString()));
                accounting.addSubDomain(i.ToString());
            }

            Assert.IsTrue(accounting.Children.Count == 200);
            Assert.IsTrue(accounting.SubDomains.Count == 100);

        }
        [TestMethod]

        public void DomainAddSubDomainByNameTest()
        {
            Domain accountDomain = new Domain();

            for (int i = 0; i < 5; i++)
                accountDomain.addSubDomain("Budget");

            for (int i = 0; i < 5; i++)
                accountDomain.addSubDomain("AdjustedBudget");

            Assert.IsTrue(accountDomain.SubDomains.Count == 2);

        }

        [TestMethod]

        public void DomainAddSubDomainByTypeTest()
        {
            Domain accountDomain = new Domain();

            for (int i = 0; i < 5; i++)
                accountDomain.addSubDomain("Budget");

            for (int i = 0; i < 5; i++)
                accountDomain.addSubDomain(new Domain("AdjustedBudget"));

            Assert.IsTrue(accountDomain.SubDomains.Count == 2);

        }


        [TestMethod]

        public void DomainGetSubDomainTest()
        {
            Domain accountingDomain = new Domain();

            for (int i = 0; i < 100; i++)
            {
                if (i == 85)
                    accountingDomain.addSubDomain(new Domain(i.ToString(), "test SubDomain"));
                else
                    accountingDomain.addSubDomain(i.ToString());
            }

            Assert.IsTrue(accountingDomain.getSubDomain("85").Value == "test SubDomain");
            Assert.IsNull(accountingDomain.getSubDomain("400"));

        }

        [TestMethod]

        public void DomainRemoveSubDomain()
        {
            Domain accounting = new Domain();

            for (int i = 0; i < 100; i++)
                accounting.addSubDomain(i.ToString());

            Assert.IsTrue(accounting.SubDomains.Count == 100);

            for (int i = 0; i < 50; i++)
                accounting.removeSubDomain(i.ToString());

            accounting.removeSubDomain("200");

            Assert.IsTrue(accounting.SubDomains.Count == 50);

        }

        #endregion

        #region DomainValueObjects


        [TestMethod]

        public void DomainValueObjectsTest()
        {
            Domain accounting = new Domain();

            for (int i = 0; i < 100; i++)
            {
                accounting.addChild(new Composite("Child " + i.ToString()));
                accounting.addValueObject(i.ToString());
            }

            Assert.IsTrue(accounting.Children.Count == 200);
            Assert.IsTrue(accounting.ValueObjects.Count == 100);

        }
        [TestMethod]

        public void DomainAddValueObjectByNameTest()
        {
            Domain accountDomain = new Domain();

            for (int i = 0; i < 5; i++)
                accountDomain.addValueObject("Budget");

            for (int i = 0; i < 5; i++)
                accountDomain.addValueObject("AdjustedBudget");

            Assert.IsTrue(accountDomain.ValueObjects.Count == 2);

        }

        [TestMethod]

        public void DomainAddValueObjectByNameValueTest()
        {
            Domain accountDomain = new Domain();

            for (int i = 0; i < 5; i++)
                accountDomain.addValueObject("Budget", i.ToString());

            for (int i = 0; i < 5; i++)
                accountDomain.addValueObject("AdjustedBudget", i.ToString());

            Assert.IsTrue(accountDomain.ValueObjects.Count == 2);

        }


        [TestMethod]

        public void DomainAddValueObjectByTypeTest()
        {
            Domain accountDomain = new Domain();

            for (int i = 0; i < 5; i++)
                accountDomain.addValueObject("Budget");

            for (int i = 0; i < 5; i++)
                accountDomain.addValueObject(new ValueObject("AdjustedBudget"));

            Assert.IsTrue(accountDomain.ValueObjects.Count == 2);

        }


        [TestMethod]

        public void DomainGetValueObjectTest()
        {
            Domain accountingDomain = new Domain();

            for (int i = 0; i < 100; i++)
            {
                if (i == 85)
                    accountingDomain.addValueObject(new ValueObject(i.ToString(), "test ValueObject"));
                else
                    accountingDomain.addValueObject(i.ToString());
            }

            Assert.IsTrue(accountingDomain.getValueObject("85").Value == "test ValueObject");
            Assert.IsNull(accountingDomain.getValueObject("400"));

        }

        [TestMethod]

        public void DomainRemoveValueObject()
        {
            Domain accounting = new Domain();

            for (int i = 0; i < 100; i++)
                accounting.addValueObject(i.ToString());

            Assert.IsTrue(accounting.ValueObjects.Count == 100);

            for (int i = 0; i < 50; i++)
                accounting.removeValueObject(i.ToString());

            accounting.removeValueObject("200");

            Assert.IsTrue(accounting.ValueObjects.Count == 50);

        }

        #endregion



        #endregion

        #region Aggregate

        [TestMethod]
        public void AggregateConstructorsTest()
        {
            Aggregate aggregate = new Aggregate();
            Aggregate accountingAggregate = new Aggregate("Accounting");
            Aggregate accountingAggregateAlabama = new Aggregate("Accounting", "Alabama");

            Assert.IsTrue(aggregate.Type == "Aggregate");
            Assert.IsTrue(accountingAggregate.Type == "Aggregate" && accountingAggregate.Name == "Accounting");

            Assert.IsTrue(accountingAggregateAlabama.Type == "Aggregate"
                && accountingAggregateAlabama.Name == "Accounting"
                && accountingAggregateAlabama.Value == "Alabama");
        }

        #region SubAggregates


        [TestMethod]

        public void SubAggregatesAggregatesTest()
        {
            Aggregate accounting = new Aggregate();

            for (int i = 0; i < 100; i++)
            {
                accounting.addChild(new Composite("Child " + i.ToString()));
                accounting.addAggregate(i.ToString());
            }

            Assert.IsTrue(accounting.Children.Count == 200);
            Assert.IsTrue(accounting.Aggregates.Count == 100);

        }
        [TestMethod]

        public void AggregateAddSubAggregateByNameTest()
        {
            Aggregate accountDomain = new Aggregate();

            for (int i = 0; i < 5; i++)
                accountDomain.addAggregate("Budget");

            for (int i = 0; i < 5; i++)
                accountDomain.addAggregate("AdjustedBudget");

            Assert.IsTrue(accountDomain.Aggregates.Count == 2);

        }

        [TestMethod]

        public void AggregateAddSubAggregateByAggregateTypeTest()
        {
            Aggregate accountDomain = new Aggregate();

            for (int i = 0; i < 5; i++)
                accountDomain.addAggregate(new Aggregate("Budget"));

            for (int i = 0; i < 5; i++)
                accountDomain.addAggregate(new Aggregate("AdjustedBudget"));

            Assert.IsTrue(accountDomain.Aggregates.Count == 2);

        }


        [TestMethod]

        public void AggregateGetAggregateTest()
        {
            Aggregate accountingDomain = new Aggregate();

            for (int i = 0; i < 100; i++)
            {
                if (i == 85)
                    accountingDomain.addAggregate(new Aggregate(i.ToString(), "test aggregate"));
                else
                    accountingDomain.addAggregate(i.ToString());
            }

            Assert.IsTrue(accountingDomain.getAggregate("85").Value == "test aggregate");
            Assert.IsNull(accountingDomain.getAggregate("400"));

        }

        [TestMethod]

        public void AggregateRemoveAggregate()
        {
            Aggregate accounting = new Aggregate();

            for (int i = 0; i < 100; i++)
                accounting.addAggregate(i.ToString());

            Assert.IsTrue(accounting.Aggregates.Count == 100);

            for (int i = 0; i < 50; i++)
                accounting.removeAggregate(i.ToString());

            accounting.removeAggregate("200");

            Assert.IsTrue(accounting.Aggregates.Count == 50);

        }

        #endregion

        #region AggregateEntities

        [TestMethod]

        public void AggregateEntitiesTest()
        {
            Aggregate accounting = new Aggregate();

            for (int i = 0; i < 100; i++)
            {
                accounting.addChild(new Composite("Child " + i.ToString()));
                accounting.addEntity(i.ToString());
            }

            Assert.IsTrue(accounting.Children.Count == 200);
            Assert.IsTrue(accounting.Entities.Count == 100);

        }

        [TestMethod]

        public void AggregateAddEntityByNameTest()
        {
            Aggregate accountDomain = new Aggregate();

            for (int i = 0; i < 5; i++)
                accountDomain.addEntity("Budget");

            for (int i = 0; i < 5; i++)
                accountDomain.addEntity("AdjustedBudget");

            Assert.IsTrue(accountDomain.Entities.Count == 2);

        }

        [TestMethod]

        public void AggregateAddEntityByEntityTypeTest()
        {
            Aggregate accountAggregate = new Aggregate();

            for (int i = 0; i < 5; i++)
                accountAggregate.addEntity(new Entity("Budget"));

            for (int i = 0; i < 5; i++)
                accountAggregate.addEntity(new Entity("AdjustedBudget"));

            Assert.IsTrue(accountAggregate.Entities.Count == 2);

        }


        [TestMethod]

        public void AggregateGetEntityTest()
        {
            Aggregate accountingDomain = new Aggregate();

            for (int i = 0; i < 100; i++)
            {
                if (i == 85)
                    accountingDomain.addEntity(new Entity(i.ToString(), "test entity"));
                else
                    accountingDomain.addEntity(i.ToString());
            }

            Assert.IsTrue(accountingDomain.getEntity("85").Value == "test entity");
            Assert.IsNull(accountingDomain.getEntity("400"));

        }

        [TestMethod]

        public void AggregateRemoveEntity()
        {
            Domain accounting = new Domain();

            for (int i = 0; i < 100; i++)
                accounting.addEntity(i.ToString());

            Assert.IsTrue(accounting.Entities.Count == 100);

            for (int i = 0; i < 50; i++)
                accounting.removeEntity(i.ToString());

            accounting.removeEntity("200");

            Assert.IsTrue(accounting.Entities.Count == 50);

        }

        #endregion

        #region AggregateServices


        [TestMethod]

        public void AggregateServicesTest()
        {
            Aggregate accounting = new Aggregate();

            for (int i = 0; i < 100; i++)
            {
                accounting.addChild(new Composite("Child " + i.ToString()));
                accounting.addService(i.ToString());
            }

            Assert.IsTrue(accounting.Children.Count == 200);
            Assert.IsTrue(accounting.Services.Count == 100);

        }
        [TestMethod]

        public void AggregateAddServiceByNameTest()
        {
            Aggregate accountAggregate = new Aggregate();

            for (int i = 0; i < 5; i++)
                accountAggregate.addService("Budget");

            for (int i = 0; i < 5; i++)
                accountAggregate.addService("AdjustedBudget");

            Assert.IsTrue(accountAggregate.Services.Count == 2);

        }

        [TestMethod]

        public void AggregateAddServiceByEntityTypeTest()
        {
            Aggregate accountAggregate = new Aggregate();

            for (int i = 0; i < 5; i++)
                accountAggregate.addService(new Service("Budget"));

            for (int i = 0; i < 5; i++)
                accountAggregate.addService(new Service("AdjustedBudget"));

            Assert.IsTrue(accountAggregate.Services.Count == 2);

        }


        [TestMethod]

        public void AggregateGetServiceTest()
        {
            Aggregate accountingAggregate = new Aggregate();

            for (int i = 0; i < 100; i++)
            {
                if (i == 85)
                    accountingAggregate.addService(new Service(i.ToString(), "test service"));
                else
                    accountingAggregate.addService(i.ToString());
            }

            Assert.IsTrue(accountingAggregate.getService("85").Value == "test service");
            Assert.IsNull(accountingAggregate.getService("400"));

        }

        [TestMethod]

        public void AggregateRemoveService()
        {
            Aggregate accounting = new Aggregate();

            for (int i = 0; i < 100; i++)
                accounting.addService(i.ToString());

            Assert.IsTrue(accounting.Services.Count == 100);

            for (int i = 0; i < 50; i++)
                accounting.removeService(i.ToString());

            accounting.removeService("200");

            Assert.IsTrue(accounting.Services.Count == 50);

        }

        #endregion


        #region AggregateValueObjects


        [TestMethod]

        public void AggregateValueObjectsTest()
        {
            Aggregate accounting = new Aggregate();

            for (int i = 0; i < 100; i++)
            {
                accounting.addChild(new Composite("Child " + i.ToString()));
                accounting.addValueObject(i.ToString());
            }

            Assert.IsTrue(accounting.Children.Count == 200);
            Assert.IsTrue(accounting.ValueObjects.Count == 100);

        }

        [TestMethod]

        public void AggregateAddValueObjectByNameTest()
        {
            Aggregate accountAggregate = new Aggregate();

            for (int i = 0; i < 5; i++)
                accountAggregate.addValueObject("Budget");

            for (int i = 0; i < 5; i++)
                accountAggregate.addValueObject("AdjustedBudget");

            Assert.IsTrue(accountAggregate.ValueObjects.Count == 2);

        }

        [TestMethod]

        public void AggregateAddValueObjectByNameValueTest()
        {
            Domain accountDomain = new Domain();

            for (int i = 0; i < 5; i++)
                accountDomain.addValueObject("Budget", i.ToString());

            for (int i = 0; i < 5; i++)
                accountDomain.addValueObject("AdjustedBudget", i.ToString());

            Assert.IsTrue(accountDomain.ValueObjects.Count == 2);

        }


        [TestMethod]

        public void AggregateAddValueObjectByTypeTest()
        {
            Aggregate accountAggregate = new Aggregate();

            for (int i = 0; i < 5; i++)
                accountAggregate.addValueObject("Budget");

            for (int i = 0; i < 5; i++)
                accountAggregate.addValueObject(new ValueObject("AdjustedBudget"));

            Assert.IsTrue(accountAggregate.ValueObjects.Count == 2);

        }


        [TestMethod]

        public void AggregateGetValueObjectTest()
        {
            Aggregate accountingAggregate = new Aggregate();

            for (int i = 0; i < 100; i++)
            {
                if (i == 85)
                    accountingAggregate.addValueObject(new ValueObject(i.ToString(), "test ValueObject"));
                else
                    accountingAggregate.addValueObject(i.ToString());
            }

            Assert.IsTrue(accountingAggregate.getValueObject("85").Value == "test ValueObject");
            Assert.IsNull(accountingAggregate.getValueObject("400"));

        }

        [TestMethod]

        public void AggregateRemoveValueObject()
        {
            Aggregate accounting = new Aggregate();

            for (int i = 0; i < 100; i++)
                accounting.addValueObject(i.ToString());

            Assert.IsTrue(accounting.ValueObjects.Count == 100);

            for (int i = 0; i < 50; i++)
                accounting.removeValueObject(i.ToString());

            accounting.removeValueObject("200");

            Assert.IsTrue(accounting.ValueObjects.Count == 50);

        }

        #endregion



        #endregion

        #region Entity

        [TestMethod]
        public void EntityConstructorsTest()
        {
            Entity entity = new Entity();
            Entity accountingEntity = new Entity("Accounting");
            Entity accountingEntityAlabama = new Entity("Accounting", "Alabama");

            Assert.IsTrue(entity.Type == "Entity");
            Assert.IsTrue(accountingEntity.Type == "Entity" && accountingEntity.Name == "Accounting");

            Assert.IsTrue(accountingEntityAlabama.Type == "Entity"
                && accountingEntityAlabama.Name == "Accounting"
                && accountingEntityAlabama.Value == "Alabama");
        }

        #region EntityValueObjects


        [TestMethod]

        public void EntityValueObjectsTest()
        {
            Entity accounting = new Entity();

            for (int i = 0; i < 100; i++)
            {
                accounting.addChild(new Composite("Child " + i.ToString()));
                accounting.addValueObject(i.ToString());
            }

            Assert.IsTrue(accounting.Children.Count == 200);
            Assert.IsTrue(accounting.ValueObjects.Count == 100);

        }

        [TestMethod]

        public void EntityAddValueObjectByNameTest()
        {
            Entity accountEntity = new Entity();

            for (int i = 0; i < 5; i++)
                accountEntity.addValueObject("Budget");

            for (int i = 0; i < 5; i++)
                accountEntity.addValueObject("AdjustedBudget");

            Assert.IsTrue(accountEntity.ValueObjects.Count == 2);

        }

        [TestMethod]

        public void EntityAddValueObjectByTypeTest()
        {
            Entity accountEntity = new Entity();

            for (int i = 0; i < 5; i++)
                accountEntity.addValueObject("Budget");

            for (int i = 0; i < 5; i++)
                accountEntity.addValueObject(new ValueObject("AdjustedBudget"));

            Assert.IsTrue(accountEntity.ValueObjects.Count == 2);

        }


        [TestMethod]

        public void EntityGetValueObjectTest()
        {
            Entity accountingEntity = new Entity();

            for (int i = 0; i < 100; i++)
            {
                if (i == 85)
                    accountingEntity.addValueObject(new ValueObject(i.ToString(), "test ValueObject"));
                else
                    accountingEntity.addValueObject(i.ToString());
            }

            Assert.IsTrue(accountingEntity.getValueObject("85").Value == "test ValueObject");
            Assert.IsNull(accountingEntity.getValueObject("400"));

        }

        [TestMethod]

        public void EntityRemoveValueObject()
        {
            Entity accounting = new Entity();

            for (int i = 0; i < 100; i++)
                accounting.addValueObject(i.ToString());

            Assert.IsTrue(accounting.ValueObjects.Count == 100);

            for (int i = 0; i < 50; i++)
                accounting.removeValueObject(i.ToString());

            accounting.removeValueObject("200");

            Assert.IsTrue(accounting.ValueObjects.Count == 50);

        }

        #endregion


        #region EntityAttributes


        [TestMethod]

        public void EntityAttributesTest()
        {
            Entity accounting = new Entity();

            for (int i = 0; i < 100; i++)
            {
                accounting.addChild(new Composite("Child " + i.ToString()));
                accounting.addAttribute("Attribute " + i.ToString(), i.ToString());
            }

            Assert.IsTrue(accounting.Children.Count == 200);
            Assert.IsTrue(accounting.Attributes.Count == 100);

        }

        [TestMethod]
        public void EntityGetAttributeTest()
        {
            Entity accountingEntity = new Entity();

            for (int i = 0; i < 100; i++)
            {
                if (i == 85)
                    accountingEntity.addAttribute(i.ToString(), "test Attribute");
                else
                    accountingEntity.addAttribute(i.ToString(), "Test");
            }

            Assert.IsTrue(accountingEntity.getAttribute("85").Value == "test Attribute");
            Assert.IsNull(accountingEntity.getAttribute("400"));

        }


        [TestMethod]

        public void EntityAddAttributeByNameValueTest()
        {
            Entity accountEntity = new Entity();

            for (int i = 0; i < 5; i++)
                accountEntity.addAttribute("Budget", i.ToString());

            for (int i = 0; i < 5; i++)
                accountEntity.addAttribute("AdjustedBudget", i.ToString());

            Assert.IsTrue(accountEntity.Attributes.Count == 2);

        }

        [TestMethod]

        public void EntityAddAttributeByCompositeTest()
        {
            Entity accountEntity = new Entity();

            for (int i = 0; i < 5; i++)
            {
                Composite attribute = new Composite("Attribute", "Budget ", i.ToString());
                accountEntity.addAttribute(attribute);
            }

            for (int i = 0; i < 5; i++)
            {
                Composite attribute = new Composite("Attribute", "AdjustedBudget", i.ToString());
                accountEntity.addAttribute(attribute);
            }

            accountEntity.addAttribute(new Composite("NewBudget", "100"));

            Assert.IsTrue(accountEntity.Attributes.Count == 2);

        }

        [TestMethod]

        public void EntityRemoveAttribute()
        {
            Entity accounting = new Entity();

            for (int i = 0; i < 100; i++)
                accounting.addAttribute(i.ToString(), "t");

            Assert.IsTrue(accounting.Attributes.Count == 100);

            for (int i = 0; i < 50; i++)
                accounting.removeAttribute(i.ToString());

            accounting.removeAttribute("200");

            Assert.IsTrue(accounting.Attributes.Count == 50);

        }



        #endregion


        #endregion

        #region ValueObjects

        [TestMethod]
        public void ValueObjectConstructorsTest()
        {
            ValueObject valueObject = new ValueObject();
            ValueObject accountingValueObject = new ValueObject("Accounting");
            ValueObject accountingValueObjectAlabama = new ValueObject("State",  "Alabama");

            Assert.IsTrue(valueObject.Type == "ValueObject");
            Assert.IsTrue(accountingValueObject.Type == "ValueObject" && accountingValueObject.Name == "Accounting");

            Assert.IsTrue(accountingValueObjectAlabama.Type == "ValueObject"
                && accountingValueObjectAlabama.Name == "State"
                && accountingValueObjectAlabama.Value == "Alabama");
        }

        #region SubValueObjects


        [TestMethod]

        public void SubValueObjectsTest()
        {
            ValueObject accounting = new ValueObject();

            for (int i = 0; i < 100; i++)
            {
                accounting.addChild(new Composite("Child " + i.ToString()));
                accounting.addValueObject(i.ToString(), "Value");
            }

            Assert.IsTrue(accounting.Children.Count == 200);
            Assert.IsTrue(accounting.ValueObjects.Count == 100);

        }

        [TestMethod]

        public void ValueObjectAddValueObjectByNameValueTest()
        {
            ValueObject accountValueObject = new ValueObject();

            for (int i = 0; i < 5; i++)
                accountValueObject.addValueObject("Budget", i.ToString());

            for (int i = 0; i < 5; i++)
                accountValueObject.addValueObject("AdjustedBudget", i.ToString() );

            Assert.IsTrue(accountValueObject.ValueObjects.Count == 2);

        }

        [TestMethod]

        public void ValueObjectAddValueObjectByNameTest()
        {
            ValueObject accountValueObject = new ValueObject();

            for (int i = 0; i < 5; i++)
                accountValueObject.addValueObject("Budget");

            for (int i = 0; i < 5; i++)
                accountValueObject.addValueObject("AdjustedBudget");

            Assert.IsTrue(accountValueObject.ValueObjects.Count == 2);

        }


        [TestMethod]

        public void ValueObjectAddValueObjectByTypeTest()
        {
            ValueObject accountValueObject = new ValueObject();

            for (int i = 0; i < 5; i++)
                accountValueObject.addValueObject(new ValueObject("Budget"));

            for (int i = 0; i < 5; i++)
                accountValueObject.addValueObject(new ValueObject("AdjustedBudget"));

            Assert.IsTrue(accountValueObject.ValueObjects.Count == 2);

        }


        [TestMethod]

        public void ValueObjectGetValueObjectTest()
        {
            ValueObject accountingValueObject = new ValueObject();

            for (int i = 0; i < 100; i++)
            {
                if (i == 85)
                    accountingValueObject.addValueObject(new ValueObject(i.ToString(), "test ValueObject"));
                else
                    accountingValueObject.addValueObject(i.ToString());
            }

            Assert.IsTrue(accountingValueObject.getValueObject("85").Value == "test ValueObject");
            Assert.IsNull(accountingValueObject.getValueObject("400"));

        }

        [TestMethod]

        public void ValueObjectRemoveValueObject()
        {
            ValueObject accounting = new ValueObject();

            for (int i = 0; i < 100; i++)
                accounting.addValueObject(i.ToString());

            Assert.IsTrue(accounting.ValueObjects.Count == 100);

            for (int i = 0; i < 50; i++)
                accounting.removeValueObject(i.ToString());

            accounting.removeValueObject("200");

            Assert.IsTrue(accounting.ValueObjects.Count == 50);

        }

        #endregion


        #region EntityAttributes


        [TestMethod]

        public void ValueObjectAttributesTest()
        {
            ValueObject accounting = new ValueObject();

            for (int i = 0; i < 100; i++)
            {
                accounting.addChild(new Composite("Child " + i.ToString()));
                accounting.addAttribute("Attribute " + i.ToString(), i.ToString());
            }

            Assert.IsTrue(accounting.Children.Count == 200);
            Assert.IsTrue(accounting.Attributes.Count == 100);

        }

        [TestMethod]
        public void ValueObjectGetAttributeTest()
        {
            ValueObject accountingValueObject = new ValueObject();

            for (int i = 0; i < 100; i++)
            {
                if (i == 85)
                    accountingValueObject.addAttribute(i.ToString(), "test Attribute");
                else
                    accountingValueObject.addAttribute(i.ToString(), "Test");
            }

            Assert.IsTrue(accountingValueObject.getAttribute("85").Value == "test Attribute");
            Assert.IsNull(accountingValueObject.getAttribute("400"));

        }


        [TestMethod]

        public void ValueObjectAddAttributeByNameValueTest()
        {
            ValueObject accountValueObject = new ValueObject();

            for (int i = 0; i < 5; i++)
                accountValueObject.addAttribute("Budget", i.ToString());

            for (int i = 0; i < 5; i++)
                accountValueObject.addAttribute("AdjustedBudget", i.ToString());

            Assert.IsTrue(accountValueObject.Attributes.Count == 2);

        }

        [TestMethod]

        public void ValueObjectAddAttributeByCompositeTest()
        {
            ValueObject accountValueObject = new ValueObject();

            for (int i = 0; i < 5; i++)
            {
                Composite attribute = new Composite("Attribute", "Budget ", i.ToString());
                accountValueObject.addAttribute(attribute);
            }

            for (int i = 0; i < 5; i++)
            {
                Composite attribute = new Composite("Attribute", "AdjustedBudget", i.ToString());
                accountValueObject.addAttribute(attribute);
            }

            accountValueObject.addAttribute(new Composite("NewBudget", "100"));

            Assert.IsTrue(accountValueObject.Attributes.Count == 2);

        }

        [TestMethod]

        public void ValueObjectRemoveAttribute()
        {
            ValueObject accounting = new ValueObject();

            for (int i = 0; i < 100; i++)
                accounting.addAttribute(i.ToString(), "t");

            Assert.IsTrue(accounting.Attributes.Count == 100);

            for (int i = 0; i < 50; i++)
                accounting.removeAttribute(i.ToString());

            accounting.removeAttribute("200");

            Assert.IsTrue(accounting.Attributes.Count == 50);

        }



        #endregion


        #endregion

        #region Services

        [TestMethod]
        public void NewServiceConstructorsTest()
        {
            Service service = new Service();
            Service accountingService = new Service("Accounting");
            Service accountingServiceAlabama = new Service("Accounting", "Alabama");

            Assert.IsTrue(service.Type == "Service");
            Assert.IsTrue(accountingService.Type == "Service" && accountingService.Name == "Accounting");

            Assert.IsTrue(accountingServiceAlabama.Type == "Service"
                && accountingServiceAlabama.Name == "Accounting"
                && accountingServiceAlabama.Value == "Alabama");
        }

        #region ServiceAggregates


        [TestMethod]

        public void ServiceAggregatesTest()
        {
            Service accounting = new Service();

            for (int i = 0; i < 100; i++)
            {
                accounting.addChild(new Composite("Child " + i.ToString()));
                accounting.addAggregate(i.ToString());
            }

            Assert.IsTrue(accounting.Children.Count == 200);
            Assert.IsTrue(accounting.Aggregates.Count == 100);

        }

        [TestMethod]

        public void ServiceAddAggregateByNameTest()
        {
            Service accountDomain = new Service();

            for (int i = 0; i < 5; i++)
                accountDomain.addAggregate("Budget");

            for (int i = 0; i < 5; i++)
                accountDomain.addAggregate("AdjustedBudget");

            Assert.IsTrue(accountDomain.Aggregates.Count == 2);

        }

        [TestMethod]

        public void ServiceAddAggregateByAggregateTypeTest()
        {
            Service accountService = new Service();

            for (int i = 0; i < 5; i++)
                accountService.addAggregate(new Aggregate("Budget"));

            for (int i = 0; i < 5; i++)
                accountService.addAggregate(new Aggregate("AdjustedBudget"));

            Assert.IsTrue(accountService.Aggregates.Count == 2);

        }


        [TestMethod]

        public void ServiceGetAggregateTest()
        {
            Service accountingService = new Service();

            for (int i = 0; i < 100; i++)
            {
                if (i == 85)
                    accountingService.addAggregate(new Aggregate(i.ToString(), "test Service"));
                else
                    accountingService.addAggregate(i.ToString());
            }

            Assert.IsTrue(accountingService.getAggregate("85").Value == "test Service");
            Assert.IsNull(accountingService.getAggregate("400"));

        }

        [TestMethod]

        public void ServiceRemoveAggregate()
        {
            Service accounting = new Service();

            for (int i = 0; i < 100; i++)
                accounting.addAggregate(i.ToString());

            Assert.IsTrue(accounting.Aggregates.Count == 100);

            for (int i = 0; i < 50; i++)
                accounting.removeAggregate(i.ToString());

            accounting.removeAggregate("200");

            Assert.IsTrue(accounting.Aggregates.Count == 50);

        }

        #endregion

        #region ServiceEntities


        [TestMethod]

        public void ServiceEntitiesTest()
        {
            Service accounting = new Service();

            for (int i = 0; i < 100; i++)
            {
                accounting.addChild(new Composite("Child " + i.ToString()));
                accounting.addEntity(i.ToString());
            }

            Assert.IsTrue(accounting.Children.Count == 200);
            Assert.IsTrue(accounting.Entities.Count == 100);

        }
        [TestMethod]

        public void ServiceAddEntityByNameTest()
        {
            Service accountDomain = new Service();

            for (int i = 0; i < 5; i++)
                accountDomain.addEntity("Budget");

            for (int i = 0; i < 5; i++)
                accountDomain.addEntity("AdjustedBudget");

            Assert.IsTrue(accountDomain.Entities.Count == 2);

        }

        [TestMethod]

        public void ServiceAddEntityByEntityTypeTest()
        {
            Service accountDomain = new Service();

            for (int i = 0; i < 5; i++)
                accountDomain.addEntity(new Entity("Budget"));

            for (int i = 0; i < 5; i++)
                accountDomain.addEntity(new Entity("AdjustedBudget"));

            Assert.IsTrue(accountDomain.Entities.Count == 2);

        }


        [TestMethod]

        public void ServiceGetEntityTest()
        {
            Service accountingService = new Service();

            for (int i = 0; i < 100; i++)
            {
                if (i == 85)
                    accountingService.addEntity(new Entity(i.ToString(), "test Service"));
                else
                    accountingService.addEntity(i.ToString());
            }

            Assert.IsTrue(accountingService.getEntity("85").Value == "test Service");
            Assert.IsNull(accountingService.getEntity("400"));

        }

        [TestMethod]

        public void ServiceRemoveEntity()
        {
            Service accounting = new Service();

            for (int i = 0; i < 100; i++)
                accounting.addEntity(i.ToString());

            Assert.IsTrue(accounting.Entities.Count == 100);

            for (int i = 0; i < 50; i++)
                accounting.removeEntity(i.ToString());

            accounting.removeEntity("200");

            Assert.IsTrue(accounting.Entities.Count == 50);

        }

        #endregion

        #region ServiceValueObjects


        [TestMethod]

        public void ServiceValueObjectsTest()
        {
            Service accounting = new Service();

            for (int i = 0; i < 100; i++)
            {
                accounting.addChild(new Composite("Child " + i.ToString()));
                accounting.addValueObject(i.ToString());
            }

            Assert.IsTrue(accounting.Children.Count == 200);
            Assert.IsTrue(accounting.ValueObjects.Count == 100);

        }

        [TestMethod]

        public void ServiceAddValueObjectByNameTest()
        {
            Service accountDomain = new Service();

            for (int i = 0; i < 5; i++)
                accountDomain.addValueObject("Budget");

            for (int i = 0; i < 5; i++)
                accountDomain.addValueObject("AdjustedBudget");

            Assert.IsTrue(accountDomain.ValueObjects.Count == 2);

        }


        [TestMethod]

        public void ServiceAddValueObjectByNameValueTest()
        {
            Service accountService = new Service();

            for (int i = 0; i < 5; i++)
                accountService.addValueObject("Budget", i.ToString());

            for (int i = 0; i < 5; i++)
                accountService.addValueObject("AdjustedBudget", i.ToString());

            Assert.IsTrue(accountService.ValueObjects.Count == 2);

        }


        [TestMethod]

        public void ServiceAddValueObjectByTypeTest()
        {
            Service accountDomain = new Service();

            for (int i = 0; i < 5; i++)
                accountDomain.addValueObject("Budget");

            for (int i = 0; i < 5; i++)
                accountDomain.addValueObject(new ValueObject("AdjustedBudget"));

            Assert.IsTrue(accountDomain.ValueObjects.Count == 2);

        }


        [TestMethod]

        public void ServiceGetValueObjectTest()
        {
            Service accountingService = new Service();

            for (int i = 0; i < 100; i++)
            {
                if (i == 85)
                    accountingService.addValueObject(new ValueObject(i.ToString(), "test ValueObject"));
                else
                    accountingService.addValueObject(i.ToString());
            }

            Assert.IsTrue(accountingService.getValueObject("85").Value == "test ValueObject");
            Assert.IsNull(accountingService.getValueObject("400"));

        }

        [TestMethod]

        public void ServiceRemoveValueObject()
        {
            Service accounting = new Service();

            for (int i = 0; i < 100; i++)
                accounting.addValueObject(i.ToString());

            Assert.IsTrue(accounting.ValueObjects.Count == 100);

            for (int i = 0; i < 50; i++)
                accounting.removeValueObject(i.ToString());

            accounting.removeValueObject("200");

            Assert.IsTrue(accounting.ValueObjects.Count == 50);

        }

        #endregion



        #endregion



    }
}
