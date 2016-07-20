using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShervinShahrdar_HW1
{
    public partial class Prompt : Form
    {
        public string InitialInput { get; set; }
        public string InitialN { get; set; }
        public string FinalStatePegs { get; set; }

        public Prompt()
        {
            InitializeComponent();
            SizeOfN.DropDownStyle = ComboBoxStyle.DropDownList;
            SizeOfN.SelectedItem = "5";
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(InitialEmptyHoles.Text))
            {
                MessageBox.Show("Error. Please insert all values");
            }
            else if(String.IsNullOrEmpty(SizeOfN.SelectedItem.ToString()))
            {
                MessageBox.Show("Error. Please insert all values");
            }
            else if (String.IsNullOrEmpty(FinalPegs.Text))
            {
                MessageBox.Show("Error. Please insert all values");
            }
            else
            {
                InitialInput = InitialEmptyHoles.Text;
                InitialN = SizeOfN.SelectedItem.ToString();
                FinalStatePegs = FinalPegs.Text;
                this.Close();
            }
            
        }

        public int CalculateVertex()
        {
            int originalValue = Int32.Parse(SizeOfN.SelectedItem.ToString());
            int copyOfOriginalValue = originalValue;
            int vertex = 0;
            for(int n =0 ; n < originalValue-1 ;n++)
            {
                vertex += copyOfOriginalValue;
                copyOfOriginalValue--;
            }
            return vertex;
        }

        public void PopulateCanvas()
        {
            int horizantal = 1;
            int deduction = 0;
            for (int count = CalculateVertex(); count > -1; )
            {
                for (int j = 0; j < horizantal; j++)
                {
                    textBox1.AppendText(count.ToString() + " ");
                    if (horizantal != 1)
                    {
                        count++;
                        deduction++;
                    }
                }
                textBox1.AppendText(Environment.NewLine);
                if (count == 5) { break; }
                horizantal++;
                count = count - horizantal - deduction;
                deduction = 0;

            }
        }

        private void SizeOfN_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Clear();
            PopulateCanvas();
        }

    }
}
