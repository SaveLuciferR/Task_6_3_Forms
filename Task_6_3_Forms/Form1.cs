using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_6_3_Forms
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			textBox1.Text = "";
			textBox3.Text = "";
		}

		private void button2_Click(object sender, EventArgs e)
		{
			try
			{
				textBox3.Text = "";
				int[,] mas;
				int n = Convert.ToInt32(textBox1.Text);

				if (n < 1) throw new Exception();
				mas = new int[n, n];
				
				Random r = new Random();
				for (int i = 0; i < n; i++)
				{
					for (int j = 0; j < n; j++)
					{
						mas[i, j] = r.Next(-100, 100);
					}
				}

				textBox3.Text += String.Format("Начальный массив\r\n");

				for (int i = 0; i < n; i++)
				{
					for (int j = 0; j < n; j++)
					{
						textBox3.Text += String.Format(mas[i, j] + "\t");
					}
					textBox3.Text += "\r\n";
				}

				textBox3.Text += String.Format("\r\nМассив после изменений столбцов\r\n");

				if (n % 2 == 0)
				{
					int a = (n / 2) - 1;
					int b = n / 2;
					int[] temp = new int[n];

					for (int i = 0; i < n; i++)
					{
						temp[i] = mas[i, a];
						mas[i, a] = mas[i, b];
						mas[i, b] = temp[i];
					}
				}
				else
				{
					int a = (int)decimal.Round((n / 2), MidpointRounding.AwayFromZero);
					int b = 0;
					int[] temp = new int[n];

					for (int i = 0; i < n; i++)
					{
						temp[i] = mas[i, a];
						mas[i, a] = mas[i, b];
						mas[i, b] = temp[i];
					}
				}

				for (int i = 0; i < n; i++)
				{
					for (int j = 0; j < n; j++)
					{
						textBox3.Text += String.Format(mas[i, j] + "\t");
					}
					textBox3.Text += "\r\n";
				}

			}
			catch (FormatException)
			{
				textBox3.Text = String.Format("Введите корректные значения");
			}
			catch
			{
				textBox3.Text = String.Format("n и m должны быть натуральным числом");
			}
		}
	}
}
