using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP_pattern
{
    public class GamePresenter
    {
        public event Action<int, int, bool> StateChanged
        {
            add => gameModel.StateChanged += value;
            remove => gameModel.StateChanged -= value;
        }

        private GameModel gameModel;
        private MyForm mainForm;
        public int Size => gameModel.Size;
        public GamePresenter(GameModel gModel, MyForm form)
        {
            gameModel = gModel;
            mainForm = form;
            form.FormInit(gameModel.Size, gameModel.game, Flip);
            gameModel.StateChanged += mainForm.OnStateChanged;
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
