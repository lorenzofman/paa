﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    public class Node<T>
    {
        public T data;
        public List<Node<T>> outNeighboors = new List<Node<T>>();
        public List<Node<T>> backtraceNodes = new List<Node<T>>();

        public Node(T data)
        {
            this.data = data;
        }

        public void AddNeighboor(params T[] neighboors)
        {
            foreach (T neighboor in neighboors)
            {
                Node<T> neighboorNode = new Node<T>(neighboor);
                AddNeighboor(neighboorNode);
            }
        }

        public void AddNeighboor(params Node<T>[] neighboorNodes)
        {
            foreach (Node<T> neighboorNode in neighboorNodes)
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
