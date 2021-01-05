using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_pattern
{
	public class GameModel
	{
		bool[,] game;
		public readonly int Size;

		public GameModel(int size)
		{
			Size = size;
			game = new bool[size, size];
		}

		public void Start()
		{
			for (int row = 0; row < Size; row++)
				for (int column = 0; column < Size; column++)
					SetState(row, column, (row + column) % 2 == 0);
		}

		void SetState(int row, int column, bool state)
		{
			game[row, column] = state;
			if (StateChanged != null) 
				StateChanged.Invoke(row, column, game[row, column]);
		}
		public bool GetState(int row, int column)
		{
			return game[row, column];
		}

		public void FlipState(int row, int column)
		{
			SetState(row, column, !game[row, column]);
		}

		public event Action<int, int, bool> StateChanged;
	}
}
