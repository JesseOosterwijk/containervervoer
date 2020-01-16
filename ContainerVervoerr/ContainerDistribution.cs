using System.Collections.Generic;
using System.Linq;

namespace ContainerVervoer
{
    public class ContainerDistribution
    {
        public Ship _ship { get; }
        public IEnumerable<Container> ContainerList { get; }
        public int WeightOfAllContainers;

        public ContainerDistribution(Ship ship, IEnumerable<Container> containerList)
        {
            _ship = ship;
            ContainerList = containerList.OrderByDescending(w => w.Weight);
            _ship.SetWeightOfAllContainers(CalculateTotalWeight());
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
            return _ship.MinimumWeightIsReached() && PlaceCooledContainers() && PlaceNormalContainers() && PlaceValueableContainers() &&_ship.CheckWeightOfShipIsInBalance();
        }

        private bool PlaceCooledContainers()
        {
            return ContainerList.Where(c => c.Type.Equals(ContainerType.Cooled)).All(c => _ship.LoadCooledContainer(c) != false);
        }

        private bool PlaceNormalContainers()
        {
            return ContainerList.Where(c => c.Type.Equals(ContainerType.Normal)).All(c => _ship.LoadNormalContainer(c) != false);
        }

        private bool PlaceValueableContainers()
        {
            return ContainerList.Where(c => c.Type.Equals(ContainerType.Valuable)).All(c => _ship.LoadValuableContainer(c) != false);
        }


        public List<Container> GetLoadedContainers()
        {
            return _ship.GetAllContainers();
        }      
    }
}
