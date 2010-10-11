using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApplicationLogic.Model;

namespace ApplicationLogic.Interfaces
{
    public interface ICongregateView
    {
        bool ConfirmDelete();

        bool ConfirmClose();
    }
}
