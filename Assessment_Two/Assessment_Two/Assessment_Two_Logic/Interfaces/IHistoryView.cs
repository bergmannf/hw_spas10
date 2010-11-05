using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assessment_Two_Logic.Model;

namespace Assessment_Two_Logic.Interfaces
{
    public interface IHistoryView : IView
    {
        void DisplayHistory(History history);
    }
}
