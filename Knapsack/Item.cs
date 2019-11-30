namespace Knapsack
{
    public struct Item
    {
        public int index;
        public int weight;
        public int value;

        public Item(int index, int weight, int value)
        {
            this.index = index;
            this.weight = weight;
            this.value = value;
        }

        public override string ToString()
        {
            return $"Item {this.index}: Value = {this.value}; Weight = {this.weight}";
        }
    }
}
