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
    class Player
    {
        //Board board = new Board();
        public List<Hole> Goal { get; set; }
        public bool Result = false;
        public TextBox canvas;
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
        public bool Play(Board parentBoard)
        {
            Board board = DeepClone(parentBoard);
            if (IsitOver(board, Goal))
            {
                Result = true;
                return Result;
            }
            if (!Result)
            {
                foreach (Hole hole in board.holes)
                {
                    if (hole.HasPeg)
                    {
                        for (int i = 0; i <= 5; i++)
                        {
                            switch (i)
                            {
                                case 0:
                                    if (board.IsOnBoard(hole.X + 1, hole.Y) && board.IsOnBoard(hole.X + 2, hole.Y) && board.IsOccupied(hole.X + 1, hole.Y) && !board.IsOccupied(hole.X + 2, hole.Y))
                                    {
                                        board.GetPegWithCoordinates(hole.X, hole.Y).HasPeg = false;
                                        board.GetPegWithCoordinates(hole.X + 1, hole.Y).HasPeg = false;
                                        board.GetPegWithCoordinates(hole.X + 2, hole.Y).HasPeg = true;
                                        //PopulateCanvas();
                                        //board.Marked = true;
                                        PopulateCanvas(board);
                                        Result = Play(board);
                                    }
                                    continue;
                                case 1:
                                    if (board.IsOnBoard(hole.X, hole.Y + 1) && board.IsOnBoard(hole.X, hole.Y + 2) && board.IsOccupied(hole.X, hole.Y + 1) && !board.IsOccupied(hole.X, hole.Y + 2))
                                    {
                                        board.GetPegWithCoordinates(hole.X, hole.Y).HasPeg = false;
                                        board.GetPegWithCoordinates(hole.X, hole.Y + 1).HasPeg = false;
                                        board.GetPegWithCoordinates(hole.X, hole.Y + 2).HasPeg = true;
                                        //PopulateCanvas();
                                        //board.Marked = true;
                                        PopulateCanvas(board);
                                        Result = Play(board);
                                    }
                                    continue;
                                case 2:
                                    if (board.IsOnBoard(hole.X - 1, hole.Y + 1) && board.IsOnBoard(hole.X - 2, hole.Y + 2) && board.IsOccupied(hole.X - 1, hole.Y + 1) && !board.IsOccupied(hole.X - 2, hole.Y + 2))
                                    {
                                        board.GetPegWithCoordinates(hole.X, hole.Y).HasPeg = false;
                                        board.GetPegWithCoordinates(hole.X - 1, hole.Y + 1).HasPeg = false;
                                        board.GetPegWithCoordinates(hole.X - 2, hole.Y + 2).HasPeg = true;
                                        //PopulateCanvas();
                                        //board.Marked = true;
                                        PopulateCanvas(board);
                                        Result = Play(board);
                                    }
                                    continue;
                                case 3:
                                    if (board.IsOnBoard(hole.X - 1, hole.Y) && board.IsOnBoard(hole.X - 2, hole.Y) && board.IsOccupied(hole.X - 1, hole.Y) && !board.IsOccupied(hole.X - 2, hole.Y))
                                    {
                                        board.GetPegWithCoordinates(hole.X, hole.Y).HasPeg = false;
                                        board.GetPegWithCoordinates(hole.X - 1, hole.Y).HasPeg = false;
                                        board.GetPegWithCoordinates(hole.X - 2, hole.Y).HasPeg = true;
                                        //PopulateCanvas();
                                        //board.Marked = true;
                                        PopulateCanvas(board);
                                        Result = Play(board);
                                    }
                                    continue;
                                case 4:
                                    if (board.IsOnBoard(hole.X, hole.Y - 1) && board.IsOnBoard(hole.X, hole.Y - 2) && board.IsOccupied(hole.X, hole.Y - 1) && !board.IsOccupied(hole.X, hole.Y - 2))
                                    {
                                        board.GetPegWithCoordinates(hole.X, hole.Y).HasPeg = false;
                                        board.GetPegWithCoordinates(hole.X, hole.Y - 1).HasPeg = false;
                                        board.GetPegWithCoordinates(hole.X, hole.Y - 2).HasPeg = true;
                                        // PopulateCanvas();
                                        //board.Marked = true;
                                        PopulateCanvas(board);
                                        Result = Play(board);
                                    }
                                    continue;
                                case 5:
                                    if (board.IsOnBoard(hole.X + 1, hole.Y - 1) && board.IsOnBoard(hole.X + 2, hole.Y - 2) && board.IsOccupied(hole.X + 1, hole.Y - 1) && !board.IsOccupied(hole.X + 2, hole.Y - 2))
                                    {
                                        board.GetPegWithCoordinates(hole.X, hole.Y).HasPeg = false;
                                        board.GetPegWithCoordinates(hole.X + 1, hole.Y - 1).HasPeg = false;
                                        board.GetPegWithCoordinates(hole.X + 2, hole.Y - 2).HasPeg = true;
                                        //PopulateCanvas();
                                        //board.Marked = true;
                                        PopulateCanvas(board);
                                        Result = Play(board);
                                    }
                                    continue;
                            }
                        }
                    }
                }
            }
            
   
            return Result;
        }

        public void PopulateCanvas(Board board)
        {
            int horizantal = 1;
            int deduction = 0;
            for (int count = board.holes.Count - 1; count > -1; )
            {
                for (int j = 0; j < horizantal; j++)
                {
                    if (board.holes[count].HasPeg)
                    {
                        canvas.AppendText("X");
                    }
                    else
                    {
                        canvas.AppendText("O");
                    }
                    if (horizantal != 1)
                    {
                        count++;
                        deduction++;
                    }
                }
                canvas.AppendText(Environment.NewLine);
                if (count == 5) { break; }
                horizantal++;
                count = count - horizantal - deduction;
                deduction = 0;

            }
        }
    }
}
