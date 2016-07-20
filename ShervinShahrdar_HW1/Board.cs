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
    [Serializable]
    public class Hole
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool HasPeg { get; set; }
        //public Form MainForm { get; set; }
        
        public Hole(int i, int j)
        {
            X = i;
            Y = j;
        }
    }
    [Serializable]
    public class Board
    {
        //public int[,] array2D = new int[,] { { 0, 0 }, { 0, 1 }, { 0, 2 }, { 0, 3 }, { 0, 4 }, { 0, 5 } };
        public List<Hole> holes;
        public List<Hole> SolutionState;
        bool Result { get; set; }
        //public TextBox canvas;
        public int sizeOfGraph{get;set;}
        public bool Marked { get; set; }
        //public Board(int n)
        //{
        //    //canvas = c;
        //    int horizontal = n;
        //    sizeOfGraph = horizontal;
        //    holes = new List<Hole>();
        //    for (int i = 0; i < n; i++)
        //    {
        //        for (int j = 0; j < horizontal; j++)
        //        { 
        //            holes.Add(new Hole(j,i));
        //        }
        //        horizontal--;
        //    }
        //}

        public Board(int n)
        {
            holes = new List<Hole>();
            int horizontal = n;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < horizontal; j++)
                {
                    holes.Add(new Hole(j, i));
                }
                horizontal--;
            }
        }

        public Board()
        {
            // TODO: Complete member initialization
        }

        public void PutPegs(int[] emptyHoles)
        {
            List<int> empty = new List<int>();
            empty = emptyHoles.ToList();
            
            //First, populate all holes
            foreach (Hole hole in holes)
            {
                hole.HasPeg = true;
            }

            //Remove ones instructed
            foreach (int emptyIndex in empty)
            {
                holes[emptyIndex].HasPeg = false;
            }
        }

        public void SetSolutionState(int[] OccupiedHoles)
        {
            SolutionState = new List<Hole>();

            //First, add some holes to the new list
            foreach (Hole hole in holes)
            {
                SolutionState.Add(new Hole(hole.X,hole.Y));
            }

            foreach (Hole hole in SolutionState)
            {
                hole.HasPeg = false;
            }

            foreach (int occupiedHoles in OccupiedHoles)
            {
                SolutionState[occupiedHoles].HasPeg = true;
            }
        }

        public bool IsOnBoard(int x, int y)
        {
            foreach (Hole hole in holes)
            {
                if (hole.X == x && hole.Y == y)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsOccupied(int x, int y)
        {
            foreach (Hole hole in holes)
            {
                if (hole.X == x && hole.Y == y)
                {
                    if (hole.HasPeg)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        public Hole GetPegWithCoordinates(int x,int y)
        {
            foreach (Hole hole in holes)
            {
                if (hole.X == x && hole.Y == y)
                {
                    return hole;
                }
            }
            throw new Exception();  //not found
        }

        public int GetNumOfPegs()
        {
            int count = 0;
            foreach (Hole hole in holes)
            {
                
                if (hole.HasPeg)
                {
                    count++;
                }
            }
            return count;
        }

        public int GetNumOFHoles()
        {
            int count = 0;
            foreach (Hole hole in holes)
            {
                if (!hole.HasPeg)
                {
                    count++;
                }
            }
            return count;
        }

        public bool IsSolution = false;

        //public void PopulateCanvas()
        //{
        //    int horizantal = 1;
        //    int deduction = 0;
        //    for (int count = this.holes.Count - 1; count > -1; )
        //    {
        //        for (int j = 0; j < horizantal; j++)
        //        {
        //            if (this.holes[count].HasPeg)
        //            {
        //                canvas.AppendText("X");
        //            }
        //            else
        //            {
        //                canvas.AppendText("O");
        //            }
        //            if (horizantal != 1)
        //            {
        //                count++;
        //                deduction++;
        //            }
        //        }
        //        canvas.AppendText(Environment.NewLine);
        //        if (count == 5) { break; }
        //        horizantal++;
        //        count = count - horizantal - deduction;
        //        deduction = 0;

        //    }
        //}
        public bool play()
        {
            //int numOFEqualPegs = 0;
            //int numOfEqualHoles = 0;
            int count = 0;
            foreach (Hole h in holes)
            {
                foreach (Hole sHole in SolutionState)
                {
                    if (h.X == sHole.X && h.Y == sHole.Y && h.HasPeg == sHole.HasPeg)
                    {
                        count++; //match
                    }
                }
            }

            if (count == holes.Count)
            {
                Result = true;
                return Result; //Solution!
            }

            foreach (Hole hole in holes)
            {
                if (hole.HasPeg)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        #region Conditions
                        
                        switch(i)
                        {
                            case 0:
                                if (IsOnBoard(hole.X + 1, hole.Y) && IsOnBoard(hole.X + 2, hole.Y) && IsOccupied(hole.X + 1, hole.Y) && !IsOccupied(hole.X + 2, hole.Y))
                                {
                                    hole.HasPeg = false;
                                    GetPegWithCoordinates(hole.X + 1, hole.Y).HasPeg = false;
                                    GetPegWithCoordinates(hole.X + 2, hole.Y).HasPeg = true;
                                    //PopulateCanvas();
                                    Marked = true;
                                    play();
                                 }
                                break;
                            case 1:
                                if (IsOnBoard(hole.X, hole.Y + 1) && IsOnBoard(hole.X, hole.Y + 2) && IsOccupied(hole.X, hole.Y + 1) && !IsOccupied(hole.X, hole.Y + 2))
                                {
                                    hole.HasPeg = false;
                                    GetPegWithCoordinates(hole.X, hole.Y + 1).HasPeg = false;
                                    GetPegWithCoordinates(hole.X, hole.Y + 2).HasPeg = true;
                                    //PopulateCanvas();
                                    Marked = true;
                                    play();
                                }
                                break;
                            case 2:
                                if (IsOnBoard(hole.X - 1, hole.Y + 1) && IsOnBoard(hole.X - 2, hole.Y + 2) && IsOccupied(hole.X - 1, hole.Y + 1) && !IsOccupied(hole.X - 2, hole.Y + 2))
                                {
                                    hole.HasPeg = false;
                                    GetPegWithCoordinates(hole.X - 1, hole.Y + 1).HasPeg = false;
                                    GetPegWithCoordinates(hole.X - 2, hole.Y + 2).HasPeg = true;
                                    //PopulateCanvas();
                                    Marked = true;
                                    play();
                                }
                                break;
                            case 3:
                                if (IsOnBoard(hole.X - 1, hole.Y) && IsOnBoard(hole.X - 2, hole.Y) && IsOccupied(hole.X - 1, hole.Y) && !IsOccupied(hole.X - 2, hole.Y))
                                {
                                    hole.HasPeg = false;
                                    GetPegWithCoordinates(hole.X - 1, hole.Y).HasPeg = false;
                                    GetPegWithCoordinates(hole.X - 2, hole.Y).HasPeg = true;
                                    //PopulateCanvas();
                                    Marked = true;
                                    play();
                                }
                                break;
                            case 4:
                                if (IsOnBoard(hole.X, hole.Y - 1) && IsOnBoard(hole.X, hole.Y - 2) && IsOccupied(hole.X, hole.Y - 1) && !IsOccupied(hole.X, hole.Y - 2))
                                {
                                    hole.HasPeg = false;
                                    GetPegWithCoordinates(hole.X, hole.Y - 1).HasPeg = false;
                                    GetPegWithCoordinates(hole.X, hole.Y - 2).HasPeg = true;
                                   // PopulateCanvas();
                                    Marked = true;
                                    play();
                                }
                                break;
                            case 5:
                                if (IsOnBoard(hole.X + 1, hole.Y - 1) && IsOnBoard(hole.X + 2, hole.Y - 2) && IsOccupied(hole.X + 1, hole.Y - 1) && !IsOccupied(hole.X + 2, hole.Y - 2))
                                {
                                    hole.HasPeg = false;
                                    GetPegWithCoordinates(hole.X + 1, hole.Y - 1).HasPeg = false;
                                    GetPegWithCoordinates(hole.X + 2, hole.Y - 2).HasPeg = true;
                                    //PopulateCanvas();
                                    Marked = true;
                                    play();
                                }
                                break;
                        }
                    }
                    
                    #endregion
                }
            }
            return Result;
        }
     
    }
    
}
