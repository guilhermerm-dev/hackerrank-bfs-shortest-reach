using System.Linq;
using System.Collections.Generic;

namespace hackerrank_bfs_shortest_reach
{
    public class Node
    {

        private readonly IList<Node> _neighbors;

        public Node(int id)
        {
            Id = id;
            Distance = -1;
            _neighbors = new List<Node>();
        }

        public int Id { get; private set; }
        public int Distance { get; private set; }
        public IReadOnlyCollection<Node> Neighbors => _neighbors.ToArray();

        public void ConnectTo(Node neighbor)
        {
            _neighbors.Add(neighbor);
            neighbor.AddReferenceOfThisNodeToTheNeighboringNode();
        }

        public void AddReferenceOfThisNodeToTheNeighboringNode()
        {
            _neighbors.Add(this);
        }

        public void SetDistance(int distance)
        {
            Distance = distance;
        }
    }
}
