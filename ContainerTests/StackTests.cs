using ContainerVervoer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContainerTests
{
    [TestClass]
    public class StackTests
    {
        [TestMethod]
        public void StackWeightOnTopOfBottomContainer()
        {
            Stack stack = new Stack(1, new Row(1, 1, 1));

            for (int i = 0; i < 4; i++)
            {
                Container container = new Container(20000, ContainerType.Normal);
                stack.AddContainer(container, i);
            }

            Assert.AreEqual(60000, stack.WeightOnTopOfBottomContainer());
        }
    }
}
