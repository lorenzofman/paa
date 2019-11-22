using System.Collections.Generic;

namespace Graph
{
    public class Node<T>
    {
        public T data;
        public List<Path<T>> outNeighboors = new List<Path<T>>();

        public Node(T data)
        {
            this.data = data;
        }

        public void AddNeighboor(params Path<T>[] neighboorNodes)
        {
            foreach (Path<T> neighboorNode in neighboorNodes)
            {
                this.outNeighboors.Add(neighboorNode);
            }
        }

        public override string ToString()
        {
            return $"Node<{ data.ToString() }>";
        }
    }
}
