using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Assessment_Two
{
    /// <summary>
    /// Class provides all inheriting views with delegate mechanism to allow threads to redraw elements on the main thread.
    /// </summary>
    public class ThreadingView : Form
    {
        protected void UpdateUI(MethodInvoker uiDelegate)
        {
            if (InvokeRequired)
            {
                this.Invoke(uiDelegate);
            }
            else
            {
                uiDelegate();
            }
        }
    }
}
