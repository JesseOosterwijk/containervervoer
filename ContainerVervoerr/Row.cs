using System.Collections.Generic;
using System.Linq;

namespace ContainerVervoer
{
    public class Row
    {
        public readonly List<Stack> Stacks = new List<Stack>();
        public int Columnrow;
        public int Weight;
        public Side Side { get; set; }

        public Row(int position, int width, int length)
        {
            Columnrow = position;
            CreatePiles(length);
        }

        private void CreatePiles(int length)
        {
            for (int i = 1; i <= length; i++)
            {
                Stacks.Add(new Stack(i, this));
            }
        }

        public List<Stack> GetPiles()
        {
            return Stacks;
        }

        public int CalculateWeightInColumn()
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
            IEnumerable<Stack> pilesSortedOnWeight = SortPilesOnWeight();

            foreach (Stack p in pilesSortedOnWeight)
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
            IEnumerable<Stack> pilesSortedOnWeight = SortPilesOnWeight();

            foreach (Stack p in pilesSortedOnWeight)
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

        public IEnumerable<Stack> SortPilesOnWeight()
        {
            IEnumerable<Stack> sortedPileList = Stacks.OrderBy(x => x.Weight);
            return sortedPileList;
        }

        //TODO: Unit Testing
        public bool IsContainerAccessible(Stack p)
        {
            // Front and back blocked.
            if (Stacks.Count == 1)
            {
                return false;
            }
            // First Pile
            else if (p.X == 1)
            {
                if (p.HeightOfPile() + 1 <= Stacks[1].HeightOfPile())
                {
                    return false;
                }
            }
            // Last Pile
            else if (p.X == Stacks.Count)
            {
                if (p.HeightOfPile() + 1 <= Stacks[Stacks.Count - 1].HeightOfPile())
                {
                    return false;
                }
            }
            // In between first and last pile.
            else
            {
                // Previous pile
                if (p.HeightOfPile() + 1 > Stacks[p.X - 1].HeightOfPile()) return true;
                // Next pile
                if (p.HeightOfPile() + 1 <= Stacks[p.X].HeightOfPile())
                {
                    return false;
                }
            }

            return true;
        }

        public bool ValuableContainerCheck(Container c)
        {
            // First Pile
            if (c.Pile.X == 1)
            {
                if (c.Y <= Stacks[1].HeightOfPile())
                {
                    return false;
                }
            }
            // Last Pile
            else if (c.Pile.X == Stacks.Count)
            {
                if (c.Y <= Stacks[Stacks.Count - 2].HeightOfPile())
                {
                    return false;
                }
            }
            // In between first and last pile
            else
            {
                if (c.Y > Stacks[c.Pile.X - 1].HeightOfPile()) return true;
                if (c.Y <= Stacks[c.Pile.X].HeightOfPile())
                {
                    return false;
                }
            }

            return true;
        }

    }
}
