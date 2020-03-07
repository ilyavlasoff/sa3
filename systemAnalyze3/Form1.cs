using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace systemAnalyze3
{
    public partial class Form1 : Form
    {
        private int count = 0;
        private GraphOperator oper = null;
        private List<HashSet<int>> levels;
        public Form1()
        {
            InitializeComponent();
        }

        private void topsCount_ValueChanged(object sender, EventArgs e)
        {
            count = Int32.Parse(topsCount.Value.ToString());
            relationsMatrixView.RowCount = count;
            relationsMatrixView.ColumnCount = count;
            for (int i = 0; i != count; i++)
            {
                relationsMatrixView.Rows[i].HeaderCell.Value = $"{i}";
                relationsMatrixView.Columns[i].HeaderCell.Value = $"{i}";
            }
        }

        private void okButton_Click_1(object sender, EventArgs e)
        {
            List<List<int>> inputValues = new List<List<int>>();
            for (int i = 0; i != count; ++i)
            {
                DataGridViewRow curRow = relationsMatrixView.Rows[i];
                List<int> curList = new List<int>();
                for (int j = 0; j != count; ++j)
                {
                    int val = 0;
                    if (!Int32.TryParse(curRow.Cells[j].Value.ToString(), out val))
                    {
                        MessageBox.Show("неверные значения");
                        return;
                    }
                    if (val == 1)
                        curList.Add(j);
                }
                inputValues.Add(curList);
            }
            //inputValues.Add(new List<int> { 1, 6 });
            //inputValues.Add(new List<int> { 2, 3 });
            //inputValues.Add(new List<int> { });
            //inputValues.Add(new List<int> { });
            //inputValues.Add(new List<int> { 3 });
            //inputValues.Add(new List<int> { 2, 3 });
            //inputValues.Add(new List<int> { 1 });
            //inputValues.Add(new List<int> { 5, 6 });
            //inputValues.Add(new List<int> { 1 });
            //inputValues.Add(new List<int> { 4, 6, 7, 8 });
            //count = 10;
            oper = new GraphOperator(inputValues, count);
            levels = oper.createDecompositionLists();
            levelUpDown.ReadOnly = false;
            levelUpDown.Value = 0;
            levelUpDown.Maximum = levels.Count - 1;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int choosed = int.Parse(levelUpDown.Value.ToString());
            string s = "";
            levels[choosed].ToList().ForEach((x) => s += x.ToString() + " ");
            levelDisplayBox.Text = s;
        }
    }
}
