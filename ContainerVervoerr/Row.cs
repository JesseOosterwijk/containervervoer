using System.Collections.Generic;
using System.Linq;

namespace ContainerVervoer
{
    public class Row
    {
        private readonly List<Stack> Stacks = new List<Stack>();
        public int row;
        public int Weight;
        public Side Side { get; set; }

        public Row(int position, int width, int length)
        {
            row = position;
            CreateStacks(length);
        }

        private void CreateStacks(int length)
        {
            for (int i = 1; i <= length; i++)
            {
                Stacks.Add(new Stack(i, this));
            }
        }

        public List<Stack> GetStacks()
        {
            return Stacks;
        }

        public int CalculateWeightInRow()
        {
            int weight = 0;

            foreach (Stack p in Stacks)
            {
                weight = weight + p.Weight;
            }

            return weight;
        }

        public bool LoadCooledContainer(Container c)
        {
            IEnumerable<Stack> stacksSortedOnWeight = SortStacksByWeight();

            foreach (Stack p in stacksSortedOnWeight)
            {
                if (p.LoadCooledContainer(c))
                {
                    Weight = Weight + c.Weight;
                    return true;
                }
            }
            return false;
        }

        public bool LoadNormalContainer(Container c)
        {
            IEnumerable<Stack> stacksSortedOnWeight = SortStacksByWeight();

            foreach (Stack p in stacksSortedOnWeight)
            {
                if (p.LoadNormalContainer(c))
                {
                    Weight = Weight + c.Weight;
                    return true;
                }
            }
            return false;
        }

        public void LoadValuableContainer(Container c)
        {
            Weight = Weight + c.Weight;
        }

        public IEnumerable<Stack> SortStacksByWeight()
        {
            IEnumerable<Stack> sortedStackList = Stacks.OrderBy(x => x.Weight);
            return sortedStackList;
        }

        //TODO: Unit Testing
        public bool IsContainerAccessible(Stack p)
        {
            // Front and back blocked.
            if (Stacks.Count == 1)
            {
                return false;
            }
            // First Stack
            else if (p.X == 1)
            {
                if (p.HeightOfStack() + 1 <= Stacks[1].HeightOfStack())
                {
                    return false;
                }
            }
            // Last Stack
            else if (p.X == Stacks.Count)
            {
                if (p.HeightOfStack() + 1 <= Stacks[Stacks.Count - 1].HeightOfStack())
                {
                    return false;
                }
            }
            // In between first and last stack.
            else
            {
                // Previous stack
                if (p.HeightOfStack() + 1 > Stacks[p.X - 1].HeightOfStack()) return true;
                // Next stack
                if (p.HeightOfStack() + 1 <= Stacks[p.X].HeightOfStack())
                {
                    return false;
                }
            }

            return true;
        }

        public bool ValuableContainerCheck(Container c)
        {
            // First stack
            if (c.Stack.X == 1)
            {
                if (c.Y <= Stacks[1].HeightOfStack())
                {
                    return false;
                }
            }
            // Last stack
            else if (c.Stack.X == Stacks.Count)
            {
                if (c.Y <= Stacks[Stacks.Count - 2].HeightOfStack())
                {
                    return false;
                }
            }
            // In between first and last stack
            else
            {
                if (c.Y > Stacks[c.Stack.X - 1].HeightOfStack()) return true;
                if (c.Y <= Stacks[c.Stack.X].HeightOfStack())
                {
                    return false;
                }
            }

            return true;
        }

    }
}
