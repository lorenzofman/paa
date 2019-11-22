namespace Graph
{
    public class Path<T>
    {
        public Node<T> node;
        public int cost;

        public Path(Node<T> node, int cost)
        {
            this.node = node;
            this.cost = cost;
        }
    }
}
