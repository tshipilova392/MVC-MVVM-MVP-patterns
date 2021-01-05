using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVP_pattern
{
	public class MyForm : Form
	{
		TableLayoutPanel table;

		public MyForm()
		{
			
		}

		public void FormInit(int size, bool[,] arr,Action<int,int> clicked)
		{
			table = new TableLayoutPanel();

			for (int i = 0; i < size; i++)
			{
				table.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / size));
				table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / size));
			}
			for (int column = 0; column < size; column++)
				for (int row = 0; row < size; row++)
				{
					var iRow = row;
					var iColumn = column;
					var button = new Button();
					button.Dock = DockStyle.Fill;
					button.BackColor = arr[row, column] ? Color.Black : Color.White;

					button.Click += (sender, args) => clicked(iRow, iColumn);
					table.Controls.Add(button, iColumn, iRow);
				}
			table.Dock = DockStyle.Fill;
			Controls.Add(table);
			//viewModel.StateChanged += OnStateChanged;
		}

		public void OnStateChanged(int row, int column, bool state)
		{
			Button button = (Button)table.GetControlFromPosition(column, row);
			button.BackColor = state ? Color.Black : Color.White;
		}
	}
}
