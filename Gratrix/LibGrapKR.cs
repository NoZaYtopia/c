using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gratrix
{
    public class Edge : IComparable<Edge>
    {
        public int EdgeWeight { get; set; }
        public string VertexA { get; set; }
        public string VertexB { get; set; }


        public Edge(string vertexA, string vertexB, int weight)
        {
            VertexA = vertexA;
            VertexB = vertexB;
            EdgeWeight = weight;
        }

        public int CompareTo(Edge other)
        {
            if (other == null) return 1;
            return EdgeWeight.CompareTo(other.EdgeWeight);
        }
    }

    public class Graph : IEnumerable<Edge>
    {
        private List<Edge> _graph;

        public Graph()
        {
            _graph = new List<Edge>();
        }

        public Graph(Edge val)
        {
            Edge[] value = new Edge[] { val };

            _graph = new List<Edge>(value);
        }

        public void Add(Graph graph)
        {
            foreach (Edge edge in graph)
            {
                _graph.Add(edge);
            }
        }

        public void Add(Edge edge)
        {
            _graph.Add(edge);
        }

        public int GetWeight()
        {
            int weight = 0;
            foreach (Edge edge in _graph)
            {
                weight += edge.EdgeWeight;
            }
            return weight;
        }

        public Graph FindMinimumSpanningTree()
        {
            Sort();
            var disjointSets = new SystemOfDisjointSets();
            foreach (Edge edge in _graph)
            {
                disjointSets.AddEdgeInSet(edge);
            }

            return disjointSets.Sets.First().SetGraph;
        }

        public override string ToString()
        {
            string result = string.Empty;

            foreach (Edge edge in _graph)
            {
                result += $"{edge.VertexA} {edge.VertexB} {edge.EdgeWeight}" + " - ";
            }

            return result;
        }

        public void Sort()
        {
            _graph.Sort();
        }

        public IEnumerator<Edge> GetEnumerator()
        {
            return _graph.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _graph.GetEnumerator();
        }
    }

    public class Set
    {
        public Graph SetGraph;
        public List<string> Vertices;

        public Set(Edge edge)
        {
            SetGraph = new Graph(edge);

            Vertices = new List<string>();
            Vertices.Add(edge.VertexA);
            Vertices.Add(edge.VertexB);
        }

        public void Union(Set set, Edge connectingEdge)
        {
            SetGraph.Add(set.SetGraph);
            Vertices.AddRange(set.Vertices);
            SetGraph.Add(connectingEdge);
        }

        public void AddEdge(Edge edge)
        {
            SetGraph.Add(edge);
            Vertices.Add(edge.VertexA);
            Vertices.Add(edge.VertexB);
        }

        public bool Contains(string vertex)
        {
            return Vertices.Contains(vertex);
        }
    }

    public class SystemOfDisjointSets
    {
        public List<Set> Sets;

        public SystemOfDisjointSets()
        {
            Sets = new List<Set>();
        }

        public void AddEdgeInSet(Edge edge)
        {
            Set setA = Find(edge.VertexA);
            Set setB = Find(edge.VertexB);

            if (setA != null && setB == null)
            {
                setA.AddEdge(edge);
            }
            else if (setA == null && setB != null)
            {
                setB.AddEdge(edge);
            }
            else if (setA == null && setB == null)
            {
                Set set = new Set(edge);
                Sets.Add(set);
            }
            else if (setA != null && setB != null)
            {
                if (setA != setB)
                {
                    setA.Union(setB, edge);
                    Sets.Remove(setB);
                }
            }
        }

        public Set Find(string vertex)
        {
            foreach (Set set in Sets)
            {
                if (set.Contains(vertex)) return set;
            }
            return null;
        }
    }

    public class Serv
    {
        public Serv()
        {

        }

        public string ConvREStoSTR(Graph graph)
        {
            graph = graph.FindMinimumSpanningTree();
            string res = "___" + "Minimum backbone:___" + graph.ToString() + "___weight: " + graph.GetWeight();
            /*
            Console.WriteLine();
            Console.WriteLine("Minimum backbone: ");
            Console.Write(graph.ToString());
            Console.WriteLine(graph.GetWeight());
            Console.WriteLine();*/
            return res;
        }
    }
}
