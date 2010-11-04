using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Assessment_Two
{
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
