namespace ContainerVervoer
{
    public class Container
    {
        public int Weight { get; set; }
        public ContainerType Type { get; internal set; }
        public int Y { get; private set; }
        public Pile Pile { get; set; }
        public Column Column { get; set; }

        public Container(int weight, ContainerType containerType)
        {
            Type = containerType;
            Weight = weight;
        }

        public void SetHeightPosition(int y)
        {
            Y = y;
        }

        public string ContainerInformation()
        {
            return
                $"Weight: {Weight}KG, Type: {Type}, on row: {Column.Columnrow}, and on pile: {Pile.X}, Height: {Y}";
        }

        public override string ToString()
        {
            return $"Weight: {Weight} KG, Type: {Type} ";
        }

    }
}   