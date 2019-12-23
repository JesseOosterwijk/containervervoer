using System.Collections.Generic;
using System.Linq;

namespace ContainerVervoer
{
    public class Column
    {
        private readonly List<Pile> _pileList = new List<Pile>();
        public int Columnrow;
        public int Weight;
        public string Side { get; set; }

        public Column(int position, int width, int length)
        {
            Columnrow = position;
            CreatePiles(length);
        }

        private void CreatePiles(int length)
        {
            for (int i = 1; i <= length; i++)
            {
                _pileList.Add(new Pile(i, this));
            }
        }

        public List<Pile> GetPiles()
        {
            return _pileList;
        }

        public int CalculateWeightInColumn()
        {
            int weight = 0;

            foreach (Pile p in _pileList)
            {
                weight = weight + p.Weight;
            }

            return weight;
        }

        public bool LoadCooledContainer(Container c)
        {
            IEnumerable<Pile> pilesSortedOnWeight = SortPilesOnWeight();

            foreach (Pile p in pilesSortedOnWeight)
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
            IEnumerable<Pile> pilesSortedOnWeight = SortPilesOnWeight();

            foreach (Pile p in pilesSortedOnWeight)
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

        public IEnumerable<Pile> SortPilesOnWeight()
        {
            IEnumerable<Pile> sortedPileList = _pileList.OrderBy(x => x.Weight);
            return sortedPileList;
        }

        //TODO: Unit Testing
        public bool IsContainerAccessible(Pile p)
        {
            // Front and back blocked.
            if (_pileList.Count == 1)
            {
                return false;
            }
            // First Pile
            else if (p.X == 1)
            {
                if (p.HeightOfPile() + 1 <= _pileList[1].HeightOfPile())
                {
                    return false;
                }
            }
            // Last Pile
            else if (p.X == _pileList.Count)
            {
                if (p.HeightOfPile() + 1 <= _pileList[_pileList.Count - 1].HeightOfPile())
                {
                    return false;
                }
            }
            // In between first and last pile.
            else
            {
                // Previous pile
                if (p.HeightOfPile() + 1 > _pileList[p.X - 1].HeightOfPile()) return true;
                // Next pile
                if (p.HeightOfPile() + 1 <= _pileList[p.X].HeightOfPile())
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
                if (c.Y <= _pileList[1].HeightOfPile())
                {
                    return false;
                }
            }
            // Last Pile
            else if (c.Pile.X == _pileList.Count)
            {
                if (c.Y <= _pileList[_pileList.Count - 2].HeightOfPile())
                {
                    return false;
                }
            }
            // In between first and last pile
            else
            {
                if (c.Y > _pileList[c.Pile.X - 1].HeightOfPile()) return true;
                if (c.Y <= _pileList[c.Pile.X].HeightOfPile())
                {
                    return false;
                }
            }

            return true;
        }

    }
}
