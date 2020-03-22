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
            if (count > 0)
            {
                relationsMatrixView.RowCount = count;
                relationsMatrixView.ColumnCount = count;
            }
            else
            {
                MessageBox.Show("Значение должно быть больше 0", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            for (int i = 0; i != count; i++)
            {
                relationsMatrixView.Rows[i].HeaderCell.Value = $"{i}";
                relationsMatrixView.Columns[i].HeaderCell.Value = $"{i}";
            }
        }

        private void okButton_Click_1(object sender, EventArgs e)
        {
            List<List<int>> inputValues = new List<List<int>>();
            //for (int i = 0; i != count; ++i)
            //{
            //    DataGridViewRow curRow = relationsMatrixView.Rows[i];
            //    List<int> curList = new List<int>();
            //    for (int j = 0; j != count; ++j)
            //    {
            //        try { 
            //            int val = Int32.Parse(curRow.Cells[j].Value.ToString());
            //            if (val == 1)
            //                curList.Add(j);
            //        }
            //        catch(Exception ex)
            //        {
            //            MessageBox.Show($"Ошибка: {ex.Message}"); 
            //            return;
            //        }
            //    }
            //    inputValues.Add(curList);
            //}
            inputValues.Add(new List<int> { 1, 4, 5 });
            inputValues.Add(new List<int> { 0 });
            inputValues.Add(new List<int> { 1, 3, 4 });
            inputValues.Add(new List<int> { 8 });
            inputValues.Add(new List<int> { 0, 6 });
            inputValues.Add(new List<int> { 4, 7, 9 });
            inputValues.Add(new List<int> { 3 });
            inputValues.Add(new List<int> { 6, 9 });
            inputValues.Add(new List<int> { 6 });
            inputValues.Add(new List<int> { 7 });
            count = 10;
            try
            {
                oper = new GraphOperator(inputValues, count);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"ERROR: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            levels = oper.setList;
            levelUpDown.ReadOnly = false;
            levelUpDown.Value = 0;
            levelUpDown.Maximum = levels.Count - 1;
            List<List<KeyValuePair<int, int>>> BMartix = oper.AtoBMatrix(oper.subsystemMatrix);
            displayData(BMartix, oper.bounds);
            levelDisplayBox.Text = getValue(int.Parse(levelUpDown.Value.ToString()));
        }

        private void displayData(List<List<KeyValuePair<int, int>>> matrix, int bounds)
        {
            relationsMatrixView.Rows.Clear();
            relationsMatrixView.Columns.Clear();
            for (int i = 0; i != bounds; i++) 
                relationsMatrixView.Columns.Add(new DataGridViewTextBoxColumn());
            for (int i= 0; i != matrix.Count; ++i)
            {
                DataGridViewRow curRow = new DataGridViewRow();
                for(int j=0; j!= bounds; ++j)
                {
                    DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
                    if (matrix[i].Contains(new KeyValuePair<int, int> (j,1)))
                        cell.Value = 1;
                    else if (matrix[i].Contains(new KeyValuePair<int, int>(j, -1)))
                        cell.Value = -1;
                    else cell.Value = 0;
                    curRow.Cells.Add(cell);
                }
                relationsMatrixView.Rows.Add(curRow);
                relationsMatrixView.Rows[i].HeaderCell.Value = i.ToString();
            }
            for (int j = 0; j != bounds; ++j)
            {
                relationsMatrixView.Columns[j].HeaderCell.Value = j.ToString();
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int choosed = int.Parse(levelUpDown.Value.ToString());
            levelDisplayBox.Text = getValue(choosed);
        }

        private string getValue(int val)
        {
            string s = "";
            levels[val].ToList().ForEach((x) => s += x.ToString() + " ");
            return s;
        }
    }
}
