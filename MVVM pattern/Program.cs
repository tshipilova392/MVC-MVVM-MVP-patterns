using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVVM_pattern
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var game = new GameModel(5);
            game.Start();
            var viewModel = new GameViewModel(game);
            Application.Run(new MyForm(viewModel) { ClientSize = new Size(300, 300) });
        }
    }
}
