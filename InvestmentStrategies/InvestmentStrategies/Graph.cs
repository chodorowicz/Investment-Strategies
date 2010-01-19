using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace InvestmentStrategies
{
    /// <summary>
    /// Represents a graph.  A graph is an arbitrary collection of GraphNode instances.
    /// </summary>
    /// <typeparam name="T">The type of data stored in the graph's nodes.</typeparam>
    public class Graph<T> : IEnumerable<T>
    {
        #region Private Member Variables
        private NodeList<T> nodeSet;        // the set of nodes in the graph
        #endregion

        #region Constructors
        public Graph() : this(null) { }
        public Graph(NodeList<T> nodeSet)
        {
            if (nodeSet == null)
                this.nodeSet = new NodeList<T>();
            else
                this.nodeSet = nodeSet;
        }
        #endregion

        #region Methods
        #region Add
        #region AddNode
        /// <summary>
        /// Adds a new GraphNode instance to the Graph
        /// </summary>
        /// <param name="node">The GraphNode instance to add.</param>
        public void AddNode(GraphNode<T> node)
        {
            // adds a node to the graph
            nodeSet.Add(node);
        }

        /// <summary>
        /// Adds a new value to the graph.
        /// </summary>
        /// <param name="value">The value to add to the graph</param>
        public void AddNode(T value)
        {
            nodeSet.Add(new GraphNode<T>(value));
        }
        #endregion

        #region Add*Edge Methods
        /// <summary>
        /// Adds a directed edge from a GraphNode with one value (from) to a GraphNode with another value (to).
        /// </summary>
        /// <param name="from">The value of the GraphNode from which the directed edge eminates.</param>
        /// <param name="to">The value of the GraphNode to which the edge leads.</param>
        public void AddDirectedEdge(T from, T to)
        {
            AddDirectedEdge(from, to, 0);
        }

        /// <summary>
        /// Adds a directed edge from one GraphNode (from) to another (to).
        /// </summary>
        /// <param name="from">The GraphNode from which the directed edge eminates.</param>
        /// <param name="to">The GraphNode to which the edge leads.</param>
        public void AddDirectedEdge(GraphNode<T> from, GraphNode<T> to)
        {
            AddDirectedEdge(from, to, 0);
        }

        /// <summary>
        /// Adds a directed edge from one GraphNode (from) to another (to) with an associated cost.
        /// </summary>
        /// <param name="from">The GraphNode from which the directed edge eminates.</param>
        /// <param name="to">The GraphNode to which the edge leads.</param>
        /// <param name="cost">The cost of the edge from "from" to "to".</param>
        public void AddDirectedEdge(GraphNode<T> from, GraphNode<T> to, int cost)
        {
            from.Neighbors.Add(to);
            from.Costs.Add(cost);
        }

        /// <summary>
        /// Adds a directed edge from a GraphNode with one value (from) to a GraphNode with another value (to)
        /// with an associated cost.
        /// </summary>
        /// <param name="from">The value of the GraphNode from which the directed edge eminates.</param>
        /// <param name="to">The value of the GraphNode to which the edge leads.</param>
        /// <param name="cost">The cost of the edge from "from" to "to".</param>
        public void AddDirectedEdge(T from, T to, int cost)
        {
            ((GraphNode<T>)nodeSet.FindByValue(from)).Neighbors.Add(nodeSet.FindByValue(to));
            ((GraphNode<T>)nodeSet.FindByValue(from)).Costs.Add(cost);
        }

        /// <summary>
        /// Adds an undirected edge from a GraphNode with one value (from) to a GraphNode with another value (to).
        /// </summary>
        /// <param name="from">The value of one of the GraphNodes that is joined by the edge.</param>
        /// <param name="to">The value of one of the GraphNodes that is joined by the edge.</param>
        public void AddUndirectedEdge(T from, T to)
        {
            AddUndirectedEdge(from, to, 0);
        }

        /// <summary>
        /// Adds an undirected edge from one GraphNode to another.
        /// </summary>
        /// <param name="from">One of the GraphNodes that is joined by the edge.</param>
        /// <param name="to">One of the GraphNodes that is joined by the edge.</param>
        public void AddUndirectedEdge(GraphNode<T> from, GraphNode<T> to)
        {
            AddUndirectedEdge(from, to, 0);
        }

        /// <summary>
        /// Adds an undirected edge from one GraphNode to another with an associated cost.
        /// </summary>
        /// <param name="from">One of the GraphNodes that is joined by the edge.</param>
        /// <param name="to">One of the GraphNodes that is joined by the edge.</param>
        /// <param name="cost">The cost of the undirected edge.</param>
        public void AddUndirectedEdge(GraphNode<T> from, GraphNode<T> to, int cost)
        {
            from.Neighbors.Add(to);
            from.Costs.Add(cost);

            to.Neighbors.Add(from);
            to.Costs.Add(cost);
        }

        /// <summary>
        /// Adds an undirected edge from a GraphNode with one value (from) to a GraphNode with another value (to)
        /// with an associated cost.
        /// </summary>
        /// <param name="from">The value of one of the GraphNodes that is joined by the edge.</param>
        /// <param name="to">The value of one of the GraphNodes that is joined by the edge.</param>
        /// <param name="cost">The cost of the undirected edge.</param>
        public void AddUndirectedEdge(T from, T to, int cost)
        {
            ((GraphNode<T>)nodeSet.FindByValue(from)).Neighbors.Add(nodeSet.FindByValue(to));
            ((GraphNode<T>)nodeSet.FindByValue(from)).Costs.Add(cost);

            ((GraphNode<T>)nodeSet.FindByValue(to)).Neighbors.Add(nodeSet.FindByValue(from));
            ((GraphNode<T>)nodeSet.FindByValue(to)).Costs.Add(cost);
        }
        #endregion
        #endregion

        #region Clear
        /// <summary>
        /// Clears out the contents of the Graph.
        /// </summary>
        public void Clear()
        {
            nodeSet.Clear();
        }
        #endregion

        #region Contains
        /// <summary>
        /// Returns a Boolean, indicating if a particular value exists within the graph.
        /// </summary>
        /// <param name="value">The value to search for.</param>
        /// <returns>True if the value exist in the graph; false otherwise.</returns>
        public bool Contains(T value)
        {
            return nodeSet.FindByValue(value) != null;
        }
        #endregion

        #region Remove
        /// <summary>
        /// Attempts to remove a node from a graph.
        /// </summary>
        /// <param name="value">The value that is to be removed from the graph.</param>
        /// <returns>True if the corresponding node was found, and removed; false if the value was not
        /// present in the graph.</returns>
        /// <remarks>This method removes the GraphNode instance, and all edges leading to or from the
        /// GraphNode.</remarks>
        public bool Remove(T value)
        {
            // first remove the node from the nodeset
            GraphNode<T> nodeToRemove = (GraphNode<T>)nodeSet.FindByValue(value);
            if (nodeToRemove == null)
                // node wasn't found
                return false;

            // otherwise, the node was found
            nodeSet.Remove(nodeToRemove);

            // enumerate through each node in the nodeSet, removing edges to this node
            foreach (GraphNode<T> gnode in nodeSet)
            {
                int index = gnode.Neighbors.IndexOf(nodeToRemove);
                if (index != -1)
                {
                    // remove the reference to the node and associated cost
                    gnode.Neighbors.RemoveAt(index);
                    gnode.Costs.RemoveAt(index);
                }
            }

            return true;
        }
        #endregion

        #region IEnumerable<T> Members
        /// <summary>
        /// Returns an enumerator that allows for iterating through the contents of the graph.
        public IEnumerator<T> GetEnumerator()
        {
            foreach (GraphNode<T> gnode in nodeSet)
                yield return gnode.Value;
        }
        #endregion
        #endregion

        #region Public Properties
        /// <summary>
        /// Returns the set of nodes in the graph.
        /// </summary>
        public NodeList<T> Nodes
        {
            get
            {
                return nodeSet;
            }
        }

        /// <summary>
        /// Returns the number of vertices in the graph.
        /// </summary>
        public int Count
        {
            get { return nodeSet.Count; }
        }
        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion
    }


    /// <summary>
    /// Represents a node in a graph.  A graph node contains some piece of data, along with a set of
    /// neighbors.  There can be an optional cost between a graph node and each of its neighbors.
    /// </summary>
    /// <typeparam name="T">The type of data stored in the graph node.</typeparam>
    public class GraphNode<T> : Node<T>
    {
        #region Private Member Variables
        private List<int> costs;        // the cost associated with each edge
        #endregion

        #region Constructors
        public GraphNode() : base() { }
        public GraphNode(T value) : base(value) { }
        public GraphNode(T value, NodeList<T> neighbors) : base(value, neighbors) { }
        #endregion

        #region Properties
        /// <summary>
        /// Returns the set of neighbors for this graph node.
        /// </summary>
        new public NodeList<T> Neighbors
        {
            get
            {
                if (base.Neighbors == null)
                    base.Neighbors = new NodeList<T>();

                return base.Neighbors;
            }
        }

        /// <summary>
        /// Returns the set of costs for the edges eminating from this graph node.
        /// The k<sup>th</sup> cost (Cost[k]) represents the cost from the graph node to the node
        /// represented by its k<sup>th</sup> neighbor (Neighbors[k]).
        /// </summary>
        /// <value></value>
        public List<int> Costs
        {
            get
            {
                if (costs == null)
                    costs = new List<int>();

                return costs;
            }
        }
        #endregion
    }


    /// <summary>
    /// Represents a collection of Node&lt;T&gt; instances.
    /// </summary>
    /// <typeparam name="T">The type of data held in the Node instances referenced by this class.</typeparam>
    public class NodeList<T> : Collection<Node<T>>
    {
        #region Constructors
        public NodeList() : base() { }

        public NodeList(int initialSize)
        {
            // Add the specified number of items
            for (int i = 0; i < initialSize; i++)
                base.Items.Add(default(Node<T>));
        }
        #endregion

        #region Methods
        /// <summary>
        /// Searches the NodeList for a Node containing a particular value.
        /// </summary>
        /// <param name="value">The value to search for.</param>
        /// <returns>The Node in the NodeList, if it exists; null otherwise.</returns>
        public Node<T> FindByValue(T value)
        {
            // search the list for the value
            foreach (Node<T> node in Items)
                if (node.Value.Equals(value))
                    return node;

            // if we reached here, we didn't find a matching node
            return null;
        }
        #endregion
    }

    /// <summary>
    /// The Node&lt;T&gt; class represents the base concept of a Node for a tree or graph.  It contains
    /// a data item of type T, and a list of neighbors.
    /// </summary>
    /// <typeparam name="T">The type of data contained in the Node.</typeparam>
    /// <remarks>None of the classes in the InvestmentStrategies namespace use the Node class directly;
    /// they all derive from this class, adding necessary functionality specific to each data structure.</remarks>
    public class Node<T>
    {
        #region Private Members
        private T data;
        private NodeList<T> neighbors = null;
        #endregion

        #region Constructors
        public Node() { }
        public Node(T data) : this(data, null) { }
        public Node(T data, NodeList<T> neighbors)
        {
            this.data = data;
            this.neighbors = neighbors;
        }
        #endregion

        #region Properties
        public T Value
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
            }
        }

        protected NodeList<T> Neighbors
        {
            get
            {
                return neighbors;
            }
            set
            {
                neighbors = value;
            }
        }
        #endregion
    }
}
