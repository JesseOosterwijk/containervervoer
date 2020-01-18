using System.Collections.Generic;
using System.Linq;
using ContainerVervoer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Container = ContainerVervoer.Container;

namespace ContainerTests
{
    [TestClass]
    public class ContainerTests
    {
        [TestMethod]
        public void PlaceCooledContainersOnOneStack()
        {
            Ship ship = new Ship(1, 2);

            List<Container> containerList = new List<Container>();

            for (int i = 1; i <= 6; i++)
            {
                Container container = new Container(30000, ContainerType.Cooled);
                containerList.Add(container);
            }

            ContainerDistribution cDistribution = new ContainerDistribution(ship, containerList);

            Assert.AreEqual(false, cDistribution.PlaceAllContainers());
        }

        [TestMethod]
        public void PlaceNormalContainersOnOneStack()
        {
            Ship ship = new Ship(1, 1);

            List<Container> containerList = new List<Container>();

            for (int i = 1; i <= 10; i++)
            {
                Container container = new Container(20000, ContainerType.Normal);
                containerList.Add(container);
            }

            ContainerDistribution cDistributor = new ContainerDistribution(ship, containerList);

            Assert.AreEqual(false, cDistributor.PlaceAllContainers());
        }

        [TestMethod]
        public void PlaceNormalContainersOnMultipleStacks()
        {
            Ship ship = new Ship(3, 2);

            List<Container> containerList = new List<Container>();

            for (int i = 1; i <= 30; i++)
            {
                Container container = new Container(25000, ContainerType.Normal);
                containerList.Add(container);
            }

            ContainerDistribution cDistributor = new ContainerDistribution(ship, containerList);

            Assert.AreEqual(true, cDistributor.PlaceAllContainers());
        }

        [TestMethod]
        public void PlaceNormalContainersOnThreeStacks()
        {
            Ship ship = new Ship(3, 1);

            List<Container> containerList = new List<Container>();

            for (int i = 1; i <= 15; i++)
            {
                Container container = new Container(29000, ContainerType.Normal);
                containerList.Add(container);
            }

            ContainerDistribution cDistributor = new ContainerDistribution(ship, containerList);

            Assert.AreEqual(true, cDistributor.PlaceAllContainers());
        }

        [TestMethod]
        public void PlaceNormalAndCooledContainers()
        {
            Ship ship = new Ship(3, 2);

            List<Container> containerList = new List<Container>();

            for (int i = 1; i <= 25; i++)
            {
                Container container = new Container(20000, ContainerType.Normal);
                containerList.Add(container);
            }

            for (int i = 1; i <= 10; i++)
            {
                Container container = new Container(20000, ContainerType.Cooled);
                containerList.Add(container);
            }

            ContainerDistribution cDistributor = new ContainerDistribution(ship, containerList);

            Assert.AreEqual(true, cDistributor.PlaceAllContainers());
        }

        [TestMethod]
        public void PlaceNormalCooledAndValuableContainers()
        {
            Ship ship = new Ship(3, 4);

            List<Container> containerList = new List<Container>();

            for (int i = 1; i <= 30; i++)
            {
                Container container = new Container(30000, ContainerType.Normal);
                containerList.Add(container);
            }

            for (int i = 1; i <= 10; i++)
            {
                Container container = new Container(19999, ContainerType.Cooled);
                containerList.Add(container);
            }

            for (int i = 1; i <= 6; i++)
            {
                Container container = new Container(20000, ContainerType.Valuable);
                containerList.Add(container);
            }

            ContainerDistribution cDistributor = new ContainerDistribution(ship, containerList);

            Assert.AreEqual(true, cDistributor.PlaceAllContainers());
        }

        [TestMethod]
        public void Place6ValueableContainers()
        {
            Ship ship = new Ship(3, 4);

            List<Container> containerList = new List<Container>();

            for (int i = 1; i <= 36; i++)
            {
                Container container = new Container(25000, ContainerType.Normal);
                containerList.Add(container);
            }

            for (int i = 1; i <= 6; i++)
            {
                Container container = new Container(20000, ContainerType.Valuable);
                containerList.Add(container);
            }

            ContainerDistribution cDistributor = new ContainerDistribution(ship, containerList);

            Assert.AreEqual(true, cDistributor.PlaceAllContainers());
        }

        [TestMethod]
        public void PlaceTooManyValueableContainers2()
        {
            Ship ship = new Ship(4, 4);

            List<Container> containerList = new List<Container>();

            for (int i = 1; i <= 42; i++)
            {
                Container container = new Container(25000, ContainerType.Normal);
                containerList.Add(container);
            }

            for (int i = 1; i <= 12; i++)
            {
                Container container = new Container(20000, ContainerType.Valuable);
                containerList.Add(container);
            }

            ContainerDistribution cDistributor = new ContainerDistribution(ship, containerList);

            Assert.AreEqual(false, cDistributor.PlaceAllContainers());
        }

        [TestMethod]
        public void Place7ValueableContainers()
        {
            Ship ship = new Ship(3, 4);

            List<Container> containerList = new List<Container>();

            for (int i = 1; i <= 7; i++)
            {
                Container container = new Container(20000, ContainerType.Valuable);
                containerList.Add(container);
            }

            ContainerDistribution cDistributor = new ContainerDistribution(ship, containerList);

            Assert.AreEqual(false, cDistributor.PlaceAllContainers());
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

        [TestMethod]
        public void PlaceTooManyValueableContainers()
        {
            Ship ship = new Ship(4, 4);

            List<Container> containerList = new List<Container>();

            for (int i = 1; i <= 30; i++)
            {
                Container container = new Container(25000, ContainerType.Normal);
                containerList.Add(container);
            }

            for (int i = 1; i <= 20; i++)
            {
                Container container = new Container(25000, ContainerType.Valuable);
                containerList.Add(container);
            }

            ContainerDistribution cDistributor = new ContainerDistribution(ship, containerList);

            Assert.AreEqual(false, cDistributor.PlaceAllContainers());
        }

        [TestMethod]
        public void PlaceValueableContainersWithOnly1Row()
        {
            Ship ship = new Ship(1, 1);

            List<Container> containerList = new List<Container>();

            for (int i = 1; i <= 3; i++)
            {
                Container container = new Container(25000, ContainerType.Valuable);
                containerList.Add(container);
            }

            ContainerDistribution cDistributor = new ContainerDistribution(ship, containerList);

            Assert.AreEqual(false, cDistributor.PlaceAllContainers());
        }

        [TestMethod]
        public void IsOdd()
        {
            Ship ship = new Ship(1, 1);
            Ship ship2 = new Ship(4, 1);

            var result = ship.IsOdd();
            var result2 = ship2.IsOdd();

            Assert.AreEqual(true, result);
            Assert.AreEqual(false, result2);
        }
    }
}