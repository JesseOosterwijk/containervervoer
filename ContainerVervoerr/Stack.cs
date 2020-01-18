using System.Collections.Generic;
using System.Linq;

namespace ContainerVervoer
{
    public class Stack
    {
        public int X { get; private set; }
        public int Weight { get; private set; }
        private Row Row { get; }
        internal readonly List<Container> _containerList = new List<Container>();

        public Stack(int x, Row row)
        {
            X = x;
            Row = row;
        }

        public Row row()
        {
            return Row;
        }

        public void AddContainer(Container container, int y)
        {
            container.SetHeightPosition(y);
            container.Stack = this;

            Weight = Weight + container.Weight;
            _containerList.Add(container);
        }

        public int WeightOnTopOfBottomContainer()
        {
            if (_containerList.Count == 0)
            {
                return 0;
            }

            Container bottomContainer = _containerList.Find(x => x.Y == 1);

            int bottomContainerWeight = bottomContainer.Weight;

            return Weight - bottomContainerWeight;
        }

        public bool LoadCooledContainer(Container c)
        {
            if (!IsInFrontRow())
            {
                return false;
            }
            else if (!ContainerWeightAllowed(c))
            {
                return false;
            }
            else
            {
                int y = HeightOfStack() + 1;
                AddContainer(c, y);
                return true;
            }
        }

        public bool LoadNormalContainer(Container c)
        {
            if (!ContainerWeightAllowed(c))
            {
                return false;
            }
            else
            {
                int y = HeightOfStack() + 1;
                AddContainer(c, y);
                return true;
            }
        }

        //TODO: Unit Testing
        public bool LoadValuableContainer(Container c)
        {
            if (!ContainerWeightAllowed(c))
            {
                return false;
            }
            if (ContainerUnderneathIsValueable())
            {
                return false;
            }
            else
            {
                if (!Row.IsContainerAccessible(this)) return false;
                AddContainer(c, HeightOfStack() + 1);
                return true;
            }

        }

        private bool ContainerUnderneathIsValueable()
        {
            if (_containerList.Count == 0) return false;
            Container c = _containerList.Find(x => x.Y == HeightOfStack());
            return c.Type.Equals(ContainerType.Valuable);
        }

        public int HeightOfStack()
        {
            return _containerList.Count == 0 ? 0 : _containerList.Max(container => container.Y);
        }

        public bool IsInFrontRow()
        {
            return X == 1;
        }

        public bool ContainerWeightAllowed(Container c)
        {
            return c.Weight + WeightOnTopOfBottomContainer() < 120000;
        }

        public void RemoveLastContainer(Container c)
        {
            _containerList.RemoveAt(_containerList.Count - 1);
            Weight = Weight - c.Weight;
        }
    }
}
