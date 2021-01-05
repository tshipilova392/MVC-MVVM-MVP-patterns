using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVC_pattern
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
            var model = new GameModel(5);
            model.Start();

            var controller = new GameController(model);
            Application.Run(new MyForm(model,controller) { ClientSize = new Size(300, 300) });
        }
    }
}
