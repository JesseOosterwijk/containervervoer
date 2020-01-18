using ContainerVervoer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace ContainerTests
{
    [TestClass]
    public class RowTests
    {
        [TestMethod]
        public void CreateShipRows()
        {
            Ship ship = new Ship(5, 10);
            Ship ship2 = new Ship(10, 5);
            Assert.AreEqual(5, ship.GetRows().Count());
            Assert.AreEqual(10, ship2.GetRows().Count());
        }

        [TestMethod]
        public void RowWeight()
        {
            Ship ship = new Ship(5, 10);
            List<Row> rowList = (List<Row>)ship.GetRows();
            List<Stack> stackList = rowList[0].GetStacks();
            int expected = 0;
            for (int i = 1; i < 4; i++)
            {
                for (int y = 1; y < 4; y++)
                {
                    Container container = new Container(20000, ContainerType.Normal);
                    stackList[i].AddContainer(container, y);
                    expected += container.Weight;
                }
           }
            Assert.AreEqual(expected, rowList[0].CalculateWeightInRow());
        }
    }
}
