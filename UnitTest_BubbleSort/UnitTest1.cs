using NUnit.Framework;
using System.Collections.Generic;
using System;
using System.IO;
namespace UnitTest_BubbleSort
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void Test_BubbleSort_Many_Item_WorstCaseScenario()
        {
            Assert.AreEqual(new List<int> { -3, -2, -1, 0, 1, 2, 3 }, BubbleSortDemo.Program.BubbleSort(new List<int> { 3, 2, 1, 0, -1, -2, -3 }));

        }
        [Test]
        public void Test_BubbleSort_Many_Item_Mixed_Scenario()
        {
            Assert.AreEqual(new List<int> { -3, -3, -1, -1,0,  2, 20}, BubbleSortDemo.Program.BubbleSort(new List<int> { -3, 2, -1, 0, -1, 20, -3 }));

        }
        [Test]
        public void Test_BubbleSort_Single_Item()
        {
            Assert.AreEqual(new List<int> { -1 },
                BubbleSortDemo.Program.BubbleSort(new List<int> { -1 }));
        }
        [Test]
        public void Test_BubbleSort_Empty_List()
        {
            Assert.AreEqual(new List<int> { },
                BubbleSortDemo.Program.BubbleSort(new List<int> { }));
        }

    }
}