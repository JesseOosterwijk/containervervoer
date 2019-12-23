using System.Collections.Generic;
using System.Linq;

namespace ContainerVervoer
{
    public class ContainerDistribution
    {
        public List<Ship> ShipList { get; }
        public IEnumerable<Container> ContainerList { get; }
        public int WeightOfAllContainers;

        public ContainerDistribution(List<Ship> shipList, IEnumerable<Container> containerList)
        {
            ShipList = shipList;
            ContainerList = containerList.OrderByDescending(w => w.Weight);
            WeightOfAllContainers = CalculateTotalWeight();
            SortContainers();
        }

        public int CalculateTotalWeight()
        {
            return ContainerList.Aggregate(0, (current, c) => current + c.Weight);
        }

        public void SortContainers()
        {
            ContainerList.OrderBy(w => w.Weight);
        }

        public bool PlaceAllContainers()
        {
            return MinimumWeightIsReached() && PlaceCooledContainers() && PlaceNormalContainers() && PlaceValueableContainers() && ShipInBalance();
        }

        private bool PlaceCooledContainers()
        {
            return ContainerList.Where(c => c.Type.Equals(ContainerType.Cooled)).All(c => ShipList[0].LoadCooledContainer(c) != false);
        }

        private bool PlaceNormalContainers()
        {
            return ContainerList.Where(c => c.Type.Equals(ContainerType.Normal)).All(c => ShipList[0].LoadNormalContainer(c) != false);
        }

        private bool PlaceValueableContainers()
        {
            return ContainerList.Where(c => c.Type.Equals(ContainerType.Valuable)).All(c => ShipList[0].LoadValuableContainer(c) != false);
        }

        public List<Container> GetLoadedContainers()
        {
            return ShipList[0].GetAllContainers();
        }

        private bool ShipInBalance()
        {
            return ShipList[0].CheckWeightOfShip(CalculateTotalWeight());
        }

        private bool MinimumWeightIsReached()
        {
            return ShipList[0].MinimumWeightIsReached(WeightOfAllContainers);
        }
    }
}
