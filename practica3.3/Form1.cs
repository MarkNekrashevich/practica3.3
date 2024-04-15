using System;
using System.Windows.Forms;

namespace practica3._3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[,] matrix = GenerateRandomMatrix(5, 5, 19, 49);
            DisplayMatrixInDataGridView(matrix, dataGridView1);
            CalculateColumnAverages(matrix);
        }

        private int[,] GenerateRandomMatrix(int rows, int cols, int min, int max)
        {
            Random rand = new Random();
            int[,] matrix = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = rand.Next(min, max + 1);
                }
            }
            return matrix;
        }

        private void DisplayMatrixInDataGridView(int[,] matrix, DataGridView dgv)
        {
            dgv.Rows.Clear();
            dgv.Columns.Clear();

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                dgv.Columns.Add("Column" + (i + 1), "Column " + (i + 1)); // Генерация названий колонок
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgv);
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    row.Cells[j].Value = matrix[i, j];
                }
                dgv.Rows.Add(row);
            }
        }

        private void CalculateColumnAverages(int[,] matrix)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int sum = 0;
                int count = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] % 2 != 0)
                    {
                        sum += matrix[i, j];
                        count++;
                    }
                }
                double average = count > 0 ? (double)sum / count : 0;
                TextBox textBox = (TextBox)this.Controls.Find("textBox" + (j + 1), true)[0];
                textBox.Text = average.ToString();
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
