using System;
using DomainDrivenDesign;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RSIComposite;

namespace UnitTestBudgetDomain
{
    public class BudgetDomain : Domain
        {
        public BudgetDomain()
        {
            this.addService("BudgetManager");
            this.addService("CalculateBudget");

            for(int i = 0; i < 10; i++)
            {
                Entity budget = new Entity(i.ToString());

                budget.addValueObject("Provider");
              
                budget.addValueObject("OriginalBudget");

                for (int j = 0; j < 10; j++)
                    budget.addValueObject("Transaction");

                this.addEntity(budget);
            }

        }
        }


    [TestClass]
    public class UnitTestBudgetDomain
    {
        [TestMethod]
        public void TestMethod1()
        {
            BudgetDomain domain = new BudgetDomain();
            Assert.IsTrue(domain.Services.Count == 2);
            Assert.IsTrue(domain.Entities.Count == 10);
        }
    }
}
