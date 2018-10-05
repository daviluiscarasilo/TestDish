using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CommonModels;
using System.Linq;

namespace UnitTestDishes
{
    [TestClass]
    public class UnitTest1
    {
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }
		private string Output { get; set; }


        [TestMethod]
        public void Case1()
        {
			Output = Method("morning, 1, 2, 3");

			TestContext.WriteLine($"Expected:eggs, toast, coffee\n obtain:{Output}");

			Assert.AreEqual("eggs,toast,coffee", Output.Replace(" ",string.Empty));
        }
        [TestMethod]
        public void Case2()
        {
			Output = Method("morning, 2, 1, 3");

			TestContext.WriteLine($"Expected:eggs, toast, coffee\n obtain:{Output}");

			Assert.AreEqual("eggs,toast,coffee", Output.Replace(" ", string.Empty));
		}
        [TestMethod]
        public void Case3()
        {
			Output = Method("morning, 1, 2, 3, 4");

			TestContext.WriteLine($"Expected:eggs, toast, coffee, error\n obtain:{Output}");

			Assert.AreEqual("eggs,toast,coffee,error", Output.Replace(" ", string.Empty));
		}
        [TestMethod]
        public void Case4()
        {
			Output = Method("morning, 1, 2, 3, 3, 3");

			TestContext.WriteLine($"Expected:eggs, toast, coffee(x3)\n obtain:{Output}");

			Assert.AreEqual("eggs,toast,coffee(x3)", Output.Replace(" ", string.Empty));
		}
        [TestMethod]
        public void Case5()
        {
			Output = Method("night, 1, 2, 3, 4");

			TestContext.WriteLine($"Expected:steak, potato, wine, cake\n obtain:{Output}");

			Assert.AreEqual("steak,potato,wine,cake", Output.Replace(" ", string.Empty));
		}
        [TestMethod]
        public void Case6()
		{
			Output = Method("night, 1, 2, 2, 4");

			TestContext.WriteLine($"Expected:steak, potato(x2), cake\n obtain:{Output}");

			Assert.AreEqual("steak,potato(x2),cake", Output.Replace(" ", string.Empty));
		}
        [TestMethod]
        public void Case7()
        {
			Output = Method("night, 1, 2, 3, 5");

			TestContext.WriteLine($"Expected:steak, potato, wine, error\n obtain:{Output}");

			Assert.AreEqual("steak,potato,wine,error", Output.Replace(" ", string.Empty));
		}
        [TestMethod]
        public void Case8()
        {
			Output = Method("night, 1, 1, 2, 3, 5");

			TestContext.WriteLine($"Expected:steak, error\n obtain:{Output}");

			Assert.AreEqual("steak,error", Output.Replace(" ", string.Empty));
		}


        private string Method(string input)
        {
            Dish dish;
            dish = input.Contains("morning") && !input.Contains("night") ? new Dish(true)
                        : !input.Contains("morning") && input.Contains("night") ? new Dish(false)
                        : null;

            if (dish != null)
            {
                //Remove white spaces
                input = input.Replace(" ", string.Empty);

                //Remove the time of the day from the input
                input = input.Replace("morning,", string.Empty).Replace("night,", string.Empty);

                //Parse a input and set de InputDish property from Dish object
                dish.InputDish = input.Split(',')?.ToList();

                return dish.OutputDishes();
            }

            return String.Empty;
        }
    }
}
