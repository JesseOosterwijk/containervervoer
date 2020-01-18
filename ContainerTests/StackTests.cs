using ContainerVervoer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContainerTests
{
    [TestClass]
    public class StackTests
    {
        [TestMethod]
        public void StackWeightOnTopOfBottomContainer()
        {
            Stack stack = new Stack(1, new Row(1, 1, 1));
            int expected = -20000;

            for (int i = 0; i < 4; i++)
            {
                Container container = new Container(20000, ContainerType.Normal);
                stack.AddContainer(container, i);
                expected += container.Weight;
            }

            Assert.AreEqual(expected, stack.WeightOnTopOfBottomContainer());
        }
    }
}
