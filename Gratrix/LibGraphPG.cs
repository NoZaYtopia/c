using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gratrix
{
    class Graph_PG
    {
        private int V; // No. of vertices
        private List<int>[] adj; //Adjacency List

        //Constructor
        public Graph_PG(int v)
        {
            V = v;
            adj = new List<int>[v];
            for (int i = 0; i < v; ++i)
                adj[i] = new List<int>();
        }

        //Function to add an edge into the graph
        public void addEdge(int v, int w)
        {
            adj[v].Add(w);
            adj[w].Add(v); //Graph is undirected
        }

        // Assigns colors (starting from 0) to all vertices and
        // prints the assignment of colors
        public string greedyColoring()
        {
            int[] result = new int[V];

            // Initialize all vertices as unassigned
            for (int i = 0; i < V; i++)
            {
                result[i] = -1;
            }

            // Assign the first color to first vertex
            result[0] = 0;

            // A temporary array to store the available colors. False
            // value of available[cr] would mean that the color cr is
            // assigned to one of its adjacent vertices
            bool[] available = new bool[V];

            // Initially, all colors are available
            for (int i = 0; i < V; i++)
            {
                available[i] = true;
            }

            // Assign colors to remaining V-1 vertices
            for (int u = 1; u < V; u++)
            {
                // Process all adjacent vertices and flag their colors
                // as unavailable
                foreach (int i in adj[u])
                {
                    if (result[i] != -1)
                        available[result[i]] = false;
                }

                // Find the first available color
                int cr;
                for (cr = 0; cr < V; cr++)
                {
                    if (available[cr])
                        break;
                }

                result[u] = cr; // Assign the found color

                // Reset the values back to true for the next iteration
                for (int i = 0; i < V; i++)
                {
                    available[i] = true;
                }
            }

            // print the result
            string outcolor = "";

            for (int u = 0; u < V; u++)
                outcolor += "Vertex " + u + " --->  Color " + result[u] + " ___ ";
            return outcolor;
        }


    }
}
