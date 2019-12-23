using System.Collections.Generic;
using System.Linq;
using ContainerVervoer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Container = ContainerVervoer.Container;

namespace Containerschip_TestProject
{
    [TestClass]
    public class ContainerTests
    {
        [TestMethod]
        public void CreateShipColumns()
        {
            Ship ship = new Ship(5, 10);
            Ship ship2 = new Ship(10, 5);
            Assert.AreEqual(5, ship.GetColumns().Count());
            Assert.AreEqual(10, ship2.GetColumns().Count());
        }

        [TestMethod]
        public void CreateShipColumnPiles()
        {
            Ship ship = new Ship(5, 10);
            Ship ship2 = new Ship(10, 5);
            List<Column> columnList = (List<Column>)ship.GetColumns();
            List<Column> columnList2 = (List<Column>)ship2.GetColumns();

            for (int i = 0; i < 5; i++)
            {
                Assert.AreEqual(10, columnList[i].GetPiles().Count());
            }
            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual(5, columnList2[i].GetPiles().Count());
            }
        }

        [TestMethod]
        public void PileWeightOnTopOfBottomContainer()
        {
            Ship ship = new Ship(5, 10);
            List<Column> columnList = (List<Column>)ship.GetColumns();
            List<Pile> pileList = columnList[0].GetPiles();

            for (int i = 0; i < 4; i++)
            {
                Container container = new Container(20000, ContainerType.Normal);
                pileList[0].AddContainer(container, i);
            }

            Assert.AreEqual(60000, pileList[0].WeightOnTopOfBottomContainer());
        }

        [TestMethod]
        public void ColumnWeight()
        {
            Ship ship = new Ship(5, 10);
            List<Column> columnList = (List<Column>)ship.GetColumns();
            List<Pile> pileList = columnList[0].GetPiles();

            for (int i = 1; i < 4; i++)
            {
                for (int y = 1; y < 4; y++)
                {
                    Container container = new Container(20000, ContainerType.Normal);
                    pileList[i].AddContainer(container, y);
                }
            }

            Assert.AreEqual(60000 * 3, columnList[0].CalculateWeightInColumn());
        }

        [TestMethod]
        public void PlaceCooledContainersOnOnePile()
        {
            List<Ship> shipList = new List<Ship>();
            Ship ship = new Ship(1, 2);
            shipList.Add(ship);

            List<Container> containerList = new List<Container>();

            for (int i = 1; i <= 6; i++)
            {
                Container container = new Container(30000, ContainerType.Cooled);
                containerList.Add(container);
            }

            ContainerDistribution cDistribution = new ContainerDistribution(shipList, containerList);

            Assert.AreEqual(false, cDistribution.PlaceAllContainers());
        }

        [TestMethod]
        public void PlaceNormalContainersOnOnePile()
        {
            List<Ship> shipList = new List<Ship>();
            Ship ship = new Ship(1, 1);
            shipList.Add(ship);

            List<Container> containerList = new List<Container>();

            for (int i = 1; i <= 10; i++)
            {
                Container container = new Container(20000, ContainerType.Normal);
                containerList.Add(container);
            }

            ContainerDistribution cDistributor = new ContainerDistribution(shipList, containerList);

            Assert.AreEqual(false, cDistributor.PlaceAllContainers());
        }

        [TestMethod]
        public void PlaceNormalContainersOnMultiplePiles()
        {
            List<Ship> shipList = new List<Ship>();
            Ship ship = new Ship(3, 2);
            shipList.Add(ship);

            List<Container> containerList = new List<Container>();

            for (int i = 1; i <= 30; i++)
            {
                Container container = new Container(25000, ContainerType.Normal);
                containerList.Add(container);
            }

            ContainerDistribution cDistributor = new ContainerDistribution(shipList, containerList);

            Assert.AreEqual(true, cDistributor.PlaceAllContainers());
        }

        [TestMethod]
        public void PlaceNormalContainersOnThreePiles()
        {
            List<Ship> shipList = new List<Ship>();
            Ship ship = new Ship(3, 1);
            shipList.Add(ship);

            List<Container> containerList = new List<Container>();

            for (int i = 1; i <= 15; i++)
            {
                Container container = new Container(29000, ContainerType.Normal);
                containerList.Add(container);
            }

            ContainerDistribution cDistributor = new ContainerDistribution(shipList, containerList);

            Assert.AreEqual(true, cDistributor.PlaceAllContainers());
        }

        [TestMethod]
        public void PlaceNormalAndCooledContainers()
        {
            List<Ship> shipList = new List<Ship>();
            Ship ship = new Ship(3, 2);
            shipList.Add(ship);

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

            ContainerDistribution cDistributor = new ContainerDistribution(shipList, containerList);

            Assert.AreEqual(true, cDistributor.PlaceAllContainers());
        }

        [TestMethod]
        public void PlaceNormalCooledAndValuableContainers()
        {
            List<Ship> shipList = new List<Ship>();
            Ship ship = new Ship(3, 4);
            shipList.Add(ship);

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

            ContainerDistribution cDistributor = new ContainerDistribution(shipList, containerList);

            Assert.AreEqual(true, cDistributor.PlaceAllContainers());
        }

        [TestMethod]
        public void Place6ValueableContainers()
        {
            List<Ship> shipList = new List<Ship>();
            Ship ship = new Ship(3, 4);
            shipList.Add(ship);

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

            ContainerDistribution cDistributor = new ContainerDistribution(shipList, containerList);

            Assert.AreEqual(true, cDistributor.PlaceAllContainers());
        }

        [TestMethod]
        public void PlaceTooManyValueableContainers2()
        {
            List<Ship> shipList = new List<Ship>();
            Ship ship = new Ship(4, 4);
            shipList.Add(ship);

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

            ContainerDistribution cDistributor = new ContainerDistribution(shipList, containerList);

            Assert.AreEqual(false, cDistributor.PlaceAllContainers());
        }

        [TestMethod]
        public void Place7ValueableContainers()
        {
            List<Ship> shipList = new List<Ship>();
            Ship ship = new Ship(3, 4);
            shipList.Add(ship);

            List<Container> containerList = new List<Container>();

            for (int i = 1; i <= 7; i++)
            {
                Container container = new Container(20000, ContainerType.Valuable);
                containerList.Add(container);
            }

            ContainerDistribution cDistributor = new ContainerDistribution(shipList, containerList);

            Assert.AreEqual(false, cDistributor.PlaceAllContainers());
        }

        [TestMethod]
        public void CheckWeightEvenShipWidth()
        {
            List<Ship> shipList = new List<Ship>();
            Ship ship = new Ship(6, 1);
            shipList.Add(ship);

            List<Container> containerList = new List<Container>();

            for (int i = 1; i <= 20; i++)
            {
                Container container = new Container(30000, ContainerType.Normal);
                containerList.Add(container);
            }

            ContainerDistribution cDistributor = new ContainerDistribution(shipList, containerList);

            Assert.AreEqual(true, cDistributor.PlaceAllContainers());
        }

        [TestMethod]
        public void CheckWeightOddShipWidth()
        {
            List<Ship> shipList = new List<Ship>();
            Ship ship = new Ship(5, 1);
            shipList.Add(ship);

            List<Container> containerList = new List<Container>();

            for (int i = 1; i <= 20; i++)
            {
                Container container = new Container(30000, ContainerType.Normal);
                containerList.Add(container);
            }

            ContainerDistribution cDistributor = new ContainerDistribution(shipList, containerList);

            Assert.AreEqual(true, cDistributor.PlaceAllContainers());
        }

        [TestMethod]
        public void PlaceTooManyValueableContainers()
        {
            List<Ship> shipList = new List<Ship>();
            Ship ship = new Ship(4, 4);
            shipList.Add(ship);

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

            ContainerDistribution cDistributor = new ContainerDistribution(shipList, containerList);

            Assert.AreEqual(false, cDistributor.PlaceAllContainers());
        }

        [TestMethod]
        public void PlaceValueableContainersWithOnly1Row()
        {
            List<Ship> shipList = new List<Ship>();
            Ship ship = new Ship(1, 1);
            shipList.Add(ship);

            List<Container> containerList = new List<Container>();

            for (int i = 1; i <= 3; i++)
            {
                Container container = new Container(25000, ContainerType.Valuable);
                containerList.Add(container);
            }

            ContainerDistribution cDistributor = new ContainerDistribution(shipList, containerList);

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