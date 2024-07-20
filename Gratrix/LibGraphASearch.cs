using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gratrix
{
    class AStar
    {
        // <summary>
        // 2D coordinate point
        // </summary>

        public struct Point
        {
            public int x, y;
            public Point(int _x, int _y)
            {
                x = _x;
                y = _y;
            }
        }
        // <summary>
        // Each node of A*
        // </summary>

        public class ANode
        {
            public Point point;
            public ANode parent;
            public int fn, gn, hn;
        }

        private AStar() { }
        public static AStar Instance { get; } = new AStar();
        private int[,] map = null;
        private Dictionary<Point, ANode> openList = null;
        private HashSet<Point> closedList = null;
        private Point dist;
        private int reachableVal;

        // <summary>
        // Execution algorithm
        // </summary>
        // <param name="map">Two-dimensional grid map, edges need to be filled with unreachable values</param>
        // <param name="srcX">current point X coordinate</param>
        // <param name="srcY">current point Y coordinate </param>
        // <param name="distX">target point X coordinate</param>
        // <param name="distY">target point Y coordinate</param>

        public ANode Execute(int[,] map, int srcX, int srcY, int distX, int distY, int reachableVal = 0, bool allowDiagonal = false)
        {
            openList = new Dictionary<Point, ANode>();
            closedList = new HashSet<Point>();
            this.map = map;
            this.dist = new Point(distX, distY);
            this.reachableVal = reachableVal;

            // Add the initial node to the open list
            ANode aNode = new ANode();
            aNode.point = new Point(srcX, srcY);
            aNode.parent = null;
            aNode.gn = 0;
            aNode.hn = ManHattan(aNode.point, dist);
            aNode.fn = aNode.gn + aNode.hn;
            openList.Add(aNode.point, aNode);

            while (openList.Count > 0)
            {
                // Find the smallest node of f(n) from the open list
                ANode minFn = FindMinFn(openList);
                Point point = minFn.point;
                // Determine whether to reach the end
                if (point.x == dist.x && point.y == dist.y) return minFn;
                // Remove minFn, add to the closed list
                openList.Remove(minFn.point);
                closedList.Add(minFn.point);
                // Add the nodes around minFn to the open list
                AddToOpenList(new Point(point.x - 1, point.y), minFn); //left
                AddToOpenList(new Point(point.x + 1, point.y), minFn); //right
                AddToOpenList(new Point(point.x, point.y - 1), minFn); //Upper
                AddToOpenList(new Point(point.x, point.y + 1), minFn); // 
                if (allowDiagonal)
                {
                    AddToOpenList(new Point(point.x - 1, point.y - 1), minFn); //top left
                    AddToOpenList(new Point(point.x + 1, point.y - 1), minFn); //Upper right
                    AddToOpenList(new Point(point.x - 1, point.y + 1), minFn); //Bottom left
                    AddToOpenList(new Point(point.x + 1, point.y + 1), minFn); //bottom right
                }
            }
            return null;
        }

        // <summary>
        // Output shortest path
        // </summary>
        // <param name="aNode"></param>

        public void DisplayPath(ANode aNode)
        {
            while (aNode != null)
            {
                Console.WriteLine(aNode.point.x + "," + aNode.point.y);
                aNode = aNode.parent;
            }
        }

        public string ConvPATHtoSTRING(ANode aNode)
        {
            string result = "";

            while (aNode != null)
            {
                // Console.WriteLine(aNode.point.x + "," + aNode.point.y);
                result = result + "(" + aNode.point.x.ToString() + "," + aNode.point.y.ToString() + ") ";

                aNode = aNode.parent;
            }
            return result;
        }

        // <summary>
        // Determine if the node is reachable. If it is reachable, add the node to the open list.
        // </summary>
        // <param name="a"></param>
        // <param name="parent"></param>

        private void AddToOpenList(Point point, ANode parent)
        {
            if (IsReachable(point) && !closedList.Contains(point))
            {
                ANode aNode = new ANode();
                aNode.point = point;
                aNode.parent = parent;
                aNode.gn = parent.gn + 1;
                aNode.hn = ManHattan(point, dist);
                aNode.fn = aNode.gn + aNode.hn;
                if (openList.ContainsKey(aNode.point))
                {
                    if (aNode.fn < openList[aNode.point].fn)
                    {
                        openList[aNode.point] = aNode;
                    }
                }
                else
                    openList.Add(aNode.point, aNode);
            }
        }

        // <summary>
        // Determine if the point is reachable
        // </summary>
        // <param name="a"></param>
        // <returns></returns>

        private bool IsReachable(Point a)
        {
            return map[a.y, a.x] == this.reachableVal;
        }

        // <summary>
        // Calculate the Manhattan distance between two points
        // </summary>
        // <param name="a"></param>
        // <param name="b"></param>
        // <returns></returns>

        private int ManHattan(Point a, Point b)
        {
            return Math.Abs(a.x - b.x) + Math.Abs(a.y - b.y);
        }

        // <summary>
        // Get the smallest f(n) node from the open list
        // </summary>
        // <param name="aNodes"></param>
        // <returns></returns>
        private ANode FindMinFn(Dictionary<Point, ANode> aNodes)
        {
            ANode minANode = null;
            foreach (var e in aNodes)
            {
                if (minANode == null || e.Value.fn < minANode.fn)
                {
                    minANode = e.Value;
                }
            }
            return minANode;
        }
    }
}
