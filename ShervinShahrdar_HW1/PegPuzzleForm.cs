using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ShervinShahrdar_HW1
{
    public partial class PegPuzzleForm : Form
    {

        public Board board;
       
        public int turn = 0;
        public List<int> InitialEmptyHolesFromUser { get; set; }
        public int valueOfN { get; set; }
        public List<int> FinalPegPositionFromUser { get; set; }
        
        public PegPuzzleForm()
        {
            InitializeComponent();
            button1.Enabled = false;
            Restart.Hide();
        }
        

        public void button1_Click(object sender, EventArgs e)
        {
            if (turn == 0)
            {
                board = new Board(valueOfN);

                int[] emptyHoles = InitialEmptyHolesFromUser.ToArray();

                int[] pegPositionSolution = FinalPegPositionFromUser.ToArray();

                board.PutPegs(emptyHoles);    //initialze pegs
                board.SetSolutionState(pegPositionSolution);
                PopulateCanvas();
                turn++;
            }
            else 
            {
                /**
                 * ***************************************
                 * Experimental block
                 **/
                //Graph graph = new Graph();
                Board solutionBoard = new Board(board.sizeOfGraph);
                solutionBoard.SolutionState = board.SolutionState;
                //bool isSolution = graph.DFS(board, board.SolutionState);
                
                /**
                 * **************************
                 **/


                //canvas.Clear();
                Player player = new Player();
                player.canvas = canvas;
                player.Goal = board.SolutionState;
                bool isSolution = false;


                isSolution = player.Play(board);
                      
                    
                
                if (!isSolution)
                {
                    //PopulateCanvas();
                    MessageBox.Show("no Solution Found");
                }
                else
                {
                    //PopulateCanvas();
                    MessageBox.Show("Game Over!");
                    button1.Enabled = false;
                    Restart.Show();
                }
                Restart.Show();
                //PopulateCanvas(changed);
                //Thread.Sleep(200);
                //canvas.Clear();
                
            }
           
        }

        public void PopulateCanvas()
        {
            int horizantal = 1;
            int deduction = 0;
            for (int count = board.holes.Count-1; count > -1;)
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
        private void PopulateCanvas(Hole hole)
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
                        if (board.holes[count] == hole)
                        {
                            canvas.AppendText("8");
                        }
                        else
                        {
                            canvas.AppendText("O");
                        }
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

        private void Settings_Click(object sender, EventArgs e)
        {
            //Prompt prompt = new Prompt();
            //prompt.ShowDialog(this);
            string InitialHoles;
            using (Prompt prompt = new Prompt())
            {
               prompt.ShowDialog();
               InitialHoles = prompt.InitialInput;
               if (!String.IsNullOrEmpty(InitialHoles))
               {
                   InitialEmptyHolesFromUser = new List<int>();
                   InitialEmptyHolesFromUser = InitialHoles.Split(',').Select(int.Parse).ToList();
                   valueOfN = Int32.Parse(prompt.InitialN);
                   FinalPegPositionFromUser = new List<int>();
                   FinalPegPositionFromUser = prompt.FinalStatePegs.Split(',').Select(int.Parse).ToList();
                   button1.Enabled = true;
               }

            }
        }

        private void Restart_Click(object sender, EventArgs e)
        {
            canvas.Clear();
            button1.Enabled = false;
            InitialEmptyHolesFromUser.Clear();
            FinalPegPositionFromUser.Clear();
            valueOfN = 0;
            Restart.Hide();
        }

        private void canvas_Enter(object sender, EventArgs e)
        {
            ActiveControl = null;
        }


        /**private void PegPuzzle_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphicsObj = this.CreateGraphics();
            Brush red = new SolidBrush(Color.Red);
            Brush black = new SolidBrush(Color.Black);
            Pen redPen = new Pen(red, 8);
            Pen blackPen = new Pen(black, 5);

            Point[] points = new Point[3];
            points[0] = new Point(this.Width / 2, 100);
            points[1] = new Point(this.Width / 2 + 180, 400);
            points[2] = new Point(this.Width / 2 - 190, 400);
            graphicsObj.DrawPolygon(redPen, points);

            int center = this.Width / 2;
            int xAxis = -150; //start
            int yAxis = 340;
            int width = 50;
            int height = 50;
            for (int i = 0; i < 5; i++) //bottom row
            {
                graphicsObj.DrawEllipse(blackPen, center + xAxis, yAxis, width, height);
                xAxis += 60;
            }

        }**/

    }
}
