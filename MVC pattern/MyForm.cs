using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVC_pattern
{
	class MyForm : Form
	{
		GameModel model;
		TableLayoutPanel table;

		public MyForm(GameModel model, GameController controller)
		{
			this.model = model;
			table = new TableLayoutPanel();
			for (int i = 0; i < model.Size; i++)
			{
				table.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / model.Size));
				table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / model.Size));
			}
			for (int column = 0; column < model.Size; column++)
				for (int row = 0; row < model.Size; row++)
				{
					var iRow = row;
					var iColumn = column;
					var button = new Button();
					button.Dock = DockStyle.Fill;
					button.BackColor = model.GetState(row,column) ? Color.Black : Color.White;
					//button.Click += (sender, args) => game.Flip(iRow, iColumn);
					button.Click += (sender, args) => controller.Flip(iRow, iColumn);
					table.Controls.Add(button, iColumn, iRow);
				}
			table.Dock = DockStyle.Fill;
			Controls.Add(table);
			model.StateChanged += OnStateChanged;
		}

		private void OnStateChanged(int row, int column, bool state)
		{
			Button button = (Button)table.GetControlFromPosition(column, row);
			button.BackColor = state ? Color.Black : Color.White;
		}

		protected override void OnFormClosed(FormClosedEventArgs e)
		{
			base.OnFormClosed(e);
			model.StateChanged -= OnStateChanged;
		}
	}
}
