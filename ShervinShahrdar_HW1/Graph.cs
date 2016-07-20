using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShervinShahrdar_HW1
{
    class EdgeInfo
    {
        public List<Board> adjacent = new List<Board>();
    }

    public class Graph
    {
        public Board current { get; set; }
        Stack<Board> stack = new Stack<Board>();
        Dictionary<Board, Board> parentBoard = new Dictionary<Board, Board>();
        EdgeInfo edges = new EdgeInfo();
        public TextBox canvas;
        bool gameOver = false;
        public bool DFS(Board start, List<Hole> Goal)
        {
            //stack.Push(start);
            //parentBoard.Add(start, null);   //no parent
            if (!IsitOver(start, Goal))
            {
                //Board current = DeepClone(start);
                //current = start.play();
                DFS(current, Goal);
                
            }
            else
            {
                gameOver = true;
                return gameOver;
            }

            
            //while (stack.Count() != 0)
            //{
            //    current = stack.Pop();
            //    start.play();
            //    if (IsitOver(current, Goal))
            //    {
            //        break; //Solution
            //    }
            //    foreach (Board NextState in edges.adjacent)
            //    { 
                    
            //    }
            //}
            return gameOver;

        }

        public bool IsitOver(Board current, List<Hole> Goal)
        {
            bool result = false;
            int count = 0;
            foreach (Hole h in current.holes)
            {
                foreach (Hole sHole in Goal)
                {
                    if (h.X == sHole.X && h.Y == sHole.Y && h.HasPeg == sHole.HasPeg)
                    {
                        count++; //match
                    }
                }
            }

            if (count == current.holes.Count)
            {
                result = true; ; //Solution!
            }
            return result;
        }

        public static T DeepClone<T>(T obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;

                return (T)formatter.Deserialize(ms);
            }
        }
    }
}
