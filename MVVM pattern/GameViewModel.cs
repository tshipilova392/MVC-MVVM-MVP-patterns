using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_pattern
{
    public class GameViewModel
    {
        public event Action<int, int, bool> StateChanged
        {
            add => gameModel.StateChanged += value;
            remove => gameModel.StateChanged -= value;
        }

        private GameModel gameModel;
        public int Size => gameModel.Size;
        public GameViewModel(GameModel gModel)
        {
            gameModel = gModel;
        }

        public void Flip(int row, int column)
        {
            for (int iRow = 0; iRow < gameModel.Size; iRow++)
                if (iRow != row) gameModel.FlipState(iRow, column);
            for (int iColumn = 0; iColumn < gameModel.Size; iColumn++)
                if (iColumn != column) gameModel.FlipState(row, iColumn);
            gameModel.FlipState(row, column);
        }

        public bool GetState(int row, int column) => gameModel.GetState(row, column);
    }
}
