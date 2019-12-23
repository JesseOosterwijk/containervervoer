using System.Collections.Generic;
using System.Linq;

namespace ContainerVervoer
{
    public class Ship
    {
        private int Width { get; }
        private int Length { get; }
        private readonly List<Container> _loadedContainerList = new List<Container>();
        private readonly List<Column> _columnList = new List<Column>();
        private readonly int _maximumWeight;

        public Ship(int width, int length)
        {
            Width = width;
            Length = length;
            CreateColumns();
            IsColumnLeftOrRight();

            _maximumWeight = length * width * 149999;
        }

        public IEnumerable<Column> GetColumns()
        {
            return _columnList;
        }

        public override string ToString()
        {
            return "Width: " + Width + ", Length: " + Length;
        }

        private void CreateColumns()
        {
            for (int i = 1; i < Width + 1; i++)
            {
                _columnList.Add(new Column(i, Width, Length));
            }
        }

        public bool LoadCooledContainer(Container c)
        {
            IEnumerable<Column> sortedColumn = SortColumnOnWeight();

            if (!sortedColumn.Any(col => col.LoadCooledContainer(c))) return false;
            _loadedContainerList.Add(c);
            return true;
        }

        public bool LoadNormalContainer(Container c)
        {
            IEnumerable<Column> sortedColumn = SortColumnOnWeight();

            if (!sortedColumn.Any(col => col.LoadNormalContainer(c))) return false;
            _loadedContainerList.Add(c);
            return true;
        }

        private IEnumerable<Column> SortColumnOnWeight()
        {
            IEnumerable<Column> sortedColumns = _columnList.OrderBy(x => x.Weight);

            return sortedColumns;
        }

        public bool LoadValuableContainer(Container c)
        {
            IEnumerable<Column> sortedColumns = _columnList.OrderBy(x => x.Weight);

            foreach (Column col in sortedColumns)
            {

                IEnumerable<Pile> sortedPiles = col.GetPiles().OrderBy(x => x.Weight);

                foreach (Pile p in sortedPiles)
                {
                    if (p.LoadValuableContainer(c) != true) continue;
                    if (CheckLoadedValuableContainersAgain() == true)
                    {
                        _loadedContainerList.Add(c);
                        col.LoadValuableContainer(c);
                        return true;
                    }
                    else
                    {
                        p.RemoveLastContainer(c);
                    }

                }
            }

            return false;

        }

        private bool CheckLoadedValuableContainersAgain()
        {
            foreach (Container con in _loadedContainerList)
            {
                if (!con.Type.Equals(ContainerType.Valuable)) continue;
                Column col = con.Column;

                if (!col.ValuableContainerCheck(con))
                {
                    return false;
                }
            }

            return true;
        }

        public bool MinimumWeightIsReached(int weightOfAllContainers)
        {
            return weightOfAllContainers >= _maximumWeight / 2;
        }

        private double MiddleRow()
        {
            if(_columnList.Count == 1)
            {
                return 1;
            }
            double middleRow = (double)_columnList.Count / 2 + 0.5;

            return middleRow;
        }

        public List<Container> GetAllContainers()
        {
            return _loadedContainerList;
        }

        private void IsColumnLeftOrRight()
        {
            double middleRow = MiddleRow();
            foreach (Column c in _columnList)
            {
                if (c.Columnrow < middleRow)
                {
                    c.Side = "Left";
                }
                else if (c.Columnrow > middleRow)
                {
                    c.Side = "Right";
                }
                else
                {
                    c.Side = "Middle";
                }
            }
        }

        public bool IsOdd()
        {
            return _columnList.Count % 2 != 0;
        }

        public bool CheckWeightOfShip(int totalWeight)
        {
            int weightLeftSide = 0;
            int weightMiddleRow = 0;
            decimal percentage;

            if (IsOdd())
            {
                foreach (Column c in _columnList)
                {
                    if (c.Side == "Left")
                        weightLeftSide = weightLeftSide + c.Weight;
                    else if (c.Side == "Middle") weightMiddleRow = weightMiddleRow + c.Weight;
                }

                int totalWeightMinusMiddleRow = totalWeight - weightMiddleRow;
                percentage = (decimal)weightLeftSide / (decimal)totalWeightMinusMiddleRow * (decimal)100;
            }
            else if(_columnList.Count == 1)
            {
                return true;
            }
            else
            {
                foreach (Column c in _columnList)
                {
                    if (c.Side == "Left")
                        weightLeftSide = weightLeftSide + c.Weight;                    
                }

                int totalWeightMinusMiddleRow = totalWeight - weightMiddleRow;
                percentage = (decimal)weightLeftSide / (decimal)totalWeightMinusMiddleRow * (decimal)100;
            }

            return percentage >= 40 && percentage <= 60;
        }
    }
}