using System.Collections.Generic;
using System.Linq;
using ContainerVervoer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Container = ContainerVervoer.Container;

namespace Containerschip_TestProject
{
    [TestClass]
    public class ShipTests
    {
        [TestMethod]
        public void CreateShipRowStacks()
        {
            Ship ship = new Ship(5, 10);
            Ship ship2 = new Ship(10, 5);
            List<Row> rowList = (List<Row>)ship.GetRows();
            List<Row> rowList2 = (List<Row>)ship2.GetRows();

            for (int i = 0; i < 5; i++)
            {
                Assert.AreEqual(10, rowList[i].GetStacks().Count());
            }
            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual(5, rowList2[i].GetStacks().Count());
            }
        }

        [TestMethod]
        public void CheckWeightEvenShipWidth()
        {
            Ship ship = new Ship(6, 1);

            List<Container> containerList = new List<Container>();

            for (int i = 1; i <= 20; i++)
            {
                Container container = new Container(30000, ContainerType.Normal);
                containerList.Add(container);
            }

            ContainerDistribution cDistributor = new ContainerDistribution(ship, containerList);

            Assert.AreEqual(true, cDistributor.PlaceAllContainers());
        }

        [TestMethod]
        public void CheckWeightOddShipWidth()
        {
            Ship ship = new Ship(5, 1);

            List<Container> containerList = new List<Container>();

            for (int i = 1; i <= 20; i++)
            {
                Container container = new Container(30000, ContainerType.Normal);
                containerList.Add(container);
            }

            ContainerDistribution cDistributor = new ContainerDistribution(ship, containerList);

            Assert.AreEqual(true, cDistributor.PlaceAllContainers());
        }

    }
}