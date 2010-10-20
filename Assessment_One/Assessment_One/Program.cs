using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Assessment_One
{
    /// <summary>
    /// \mainpage Stock Manager Application
    /// 
    /// This is the code-documentation of the stock manager application for the Big MACS company.
    /// 
    /// The application is divided into multiple packages:
    /// 
    /// @link Assessment_One UserInterface @endlink
    /// 
    /// Hosts the user interface related class implemented in WinForms.
    /// 
    /// @link ApplicationLogic.Interfaces Interfaces @endlink
    /// 
    /// Hosts the used interfaces.
    /// 
    /// @link ApplicationLogic.Presenter Presenter @endlink
    /// 
    /// Hosts the presenter used by the gui classes to pass changes to the model.
    /// 
    /// @link ApplicationLogic.Model Model @endlink
    /// 
    /// Hosts the application logic.
    /// 
    /// </summary>
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
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
