using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_pattern
{
    public class GameController
    {
        private GameModel gameModel;
        public GameController(GameModel gModel)
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
    }
}
