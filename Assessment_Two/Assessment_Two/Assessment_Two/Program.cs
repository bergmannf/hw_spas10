using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Assessment_Two
{
    static class Program
    {
        /// <summary>
        /// \mainpage Web Browser
        /// 
        /// This is the code-documentation of the web browser developed for assignment two of systems programming and scripting 2010/2011.
        /// 
        /// The application is divided into multiple packages:
        /// 
        /// @link Assessment_Two UserInterface @endlink
        /// 
        /// Hosts the user interface related class implemented in WinForms.
        /// 
        /// @link Assessment_Two_Logic.Interfaces Interfaces @endlink
        /// 
        /// Hosts the used interfaces.
        /// 
        /// @link Assessment_Two_Logic.Presenter Presenter @endlink
        /// 
        /// Hosts the presenter used by the gui classes to pass changes to the model.
        /// 
        /// @link Assessment_Two_Logic.Model Model @endlink
        /// 
        /// Hosts the application logic.
        /// 
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
    }
}
