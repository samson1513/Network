using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_3
{
    public partial class Form1 : Form
    {

        private Network network;

        public Form1()
        {
            InitializeComponent();

            dataGridView1.RowCount = 3;

            network = new Network();

            network.AddPair(
                new int[] {
                    -1, 1, -1,
                    1, -1, 1,
                    -1, 1, -1}.ToList(), 
                new int[] {1, -1}.ToList(), 
                "X");

            network.AddPair(
                new int[] {
                    -1, -1, -1,
                    1, -1, 1,
                    1, -1, 1}.ToList(),
                new int[] { -1, 1}.ToList(),
                "T");


        }

        private void learn_Click(object sender, EventArgs e)
        {
            if (network.Learn())
                recognize.Enabled = true;
            else
                result.Text = "Не навчило";

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    dataGridView1.Rows[i].Cells[j].Value = "1";
        }

        private void recognize_Click(object sender, EventArgs e)
        {
            List<int> input = new List<int>();
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    input.Add(int.Parse(dataGridView1.Rows[i].Cells[j].Value.ToString()));

            string symbol = network.Recognize(input);
            result.Text = symbol;
        }
        
    }
}
