using System;
using System.Collections.Generic;
using System.Linq;

namespace ContainerVervoer
{
    public class Ship
    {
        private int Width { get; }
        private int Length { get; }
        private int WeightOfAllContainers { get; set; }
        private readonly List<Container> _loadedContainerList = new List<Container>();
        private readonly List<Row> Rows = new List<Row>();
        private readonly int _maximumWeight;

        public Ship(int width, int length)
        {
            Width = width;
            Length = length;
            CreateColumns();
            SetColumnToLeftOrRight();

            _maximumWeight = length * width * 149999;
        }

        public IEnumerable<Row> GetColumns()
        {
            return Rows;
        }

        public override string ToString()
        {
            return "Width: " + Width + ", Length: " + Length;
        }

        private void CreateColumns()
        {
            for (int i = 1; i < Width + 1; i++)
            {
                Rows.Add(new Row(i, Width, Length));
            }
        }

        public void SetWeightOfAllContainers(int totalWeight)
        {
            WeightOfAllContainers = totalWeight;
        }

        public bool LoadCooledContainer(Container c)
        {
            IEnumerable<Row> sortedColumn = SortColumnOnWeight();

            if (!sortedColumn.Any(col => col.LoadCooledContainer(c))) return false;
            _loadedContainerList.Add(c);
            return true;
        }

        public bool LoadNormalContainer(Container c)
        {
            IEnumerable<Row> sortedColumn = SortColumnOnWeight();

            if (!sortedColumn.Any(col => col.LoadNormalContainer(c))) return false;
            _loadedContainerList.Add(c);
            return true;
        }

        private IEnumerable<Row> SortColumnOnWeight()
        {
            IEnumerable<Row> sortedColumns = Rows.OrderBy(x => x.Weight);

            return sortedColumns;
        }

        public bool LoadValuableContainer(Container c)
        {
            IEnumerable<Row> sortedColumns = Rows.OrderBy(x => x.Weight);

            foreach (Row col in sortedColumns)
            {

                IEnumerable<Stack> sortedPiles = col.GetPiles().OrderBy(x => x.Weight);

                foreach (Stack p in sortedPiles)
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
                Row col = con.Pile.GetColumnPile();

                if (!col.ValuableContainerCheck(con))
                {
                    return false;
                }
            }

            return true;
        }

        internal bool MinimumWeightIsReached()
        {
            return WeightOfAllContainers >= _maximumWeight / 2;
        }

        private double MiddleRow()
        {
            if (Rows.Count == 1)
            {
                return 1;
            }
            double middleRow = (double)Rows.Count / 2 + 0.5;

            return middleRow;
        }

        public List<Container> GetAllContainers()
        {
            return _loadedContainerList;
        }

        private void SetColumnToLeftOrRight()
        {
            double middleRow = MiddleRow();
            foreach (Row c in Rows)
            {
                if (c.Columnrow < middleRow)
                {
                    c.Side = Side.Left;
                }
                else if (c.Columnrow > middleRow)
                {
                    c.Side = Side.Right;
                }
                else
                {
                    c.Side = Side.Middle;
                }
            }
        }

        public bool IsOdd()
        {
            return Rows.Count % 2 != 0;
        }

        internal bool CheckWeightOfShipIsInBalance()
        {
            int weightLeftSide = 0;
            int weightMiddleRow = 0;
            decimal percentage;

            if (Rows.Count == 1)
            {
                return true;
            }
            if (IsOdd())
            {
                foreach (Row c in Rows)
                {
                    if (c.Side == Side.Left)
                        weightLeftSide = weightLeftSide + c.Weight;
                    else if (c.Side == Side.Middle) weightMiddleRow = weightMiddleRow + c.Weight;
                }

                int totalWeightMinusMiddleRow = WeightOfAllContainers - weightMiddleRow;
                percentage = weightLeftSide / (decimal)totalWeightMinusMiddleRow * 100;
            }
            else
            {
                foreach (Row c in Rows)
                {
                    if (c.Side == Side.Left)
                        weightLeftSide = weightLeftSide + c.Weight;
                }

                int totalWeightMinusMiddleRow = WeightOfAllContainers - weightMiddleRow;
                percentage = weightLeftSide / (decimal)totalWeightMinusMiddleRow * 100;
            }

            return percentage >= 40 && percentage <= 60;
        }

        public string GetUrl()
        {
            string url = "https://i872272core.venus.fhict.nl/ContainerVisualizer/index.html?length=";

            url += Length.ToString();
            url += "&width=";
            url += Width.ToString();
            url += "&stacks=";

            url = AddContainersToString(url);
            url = AddContainerWeightToString(url);

            return url;
        }

        private string AddContainersToString(string url)
        {
            foreach (Row row in Rows)
            {
                foreach (Stack stack in row.Stacks)
                {
                    var containerListPerStack = stack._containerList.OrderBy(x => x.Y);
                    foreach (var container in containerListPerStack)
                    {
                        if (container.Type == ContainerType.Valuable)
                        {
                            url += 2.ToString() + "-";
                        }
                        else if (container.Type == ContainerType.Cooled)
                        {
                            url += 3.ToString() + "-";
                        }
                        else
                        {
                            url += 1.ToString() + "-";
                        }
                    }
                    url += ",";
                }
                url = url.TrimEnd(',');
                url = url.TrimEnd('-');
                url += "/";
            }
            url = url.TrimEnd('/');
            return url;
        }

        private string AddContainerWeightToString(string url)
        {
            url += "&weights=";

            foreach (Row row in Rows)
            {
                foreach (Stack stack in row.Stacks)
                {
                    var containerListPerStack = stack._containerList.OrderBy(x => x.Y);
                    foreach (var container in containerListPerStack)
                    {

                        url += (container.Weight / 1000).ToString();
                        url += "-";
                    }
                    url = url.TrimEnd('-');
                    url += ",";
                }
                url = url.TrimEnd(',');
                url += "/";
            }
            url = url.TrimEnd('/');
            return url;
        }
    }
}