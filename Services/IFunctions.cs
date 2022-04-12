using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IFunctions
    {
        string Clock();
        string ValidateHour(string hourInput);
        string ValidateMinutes(string minuteInput);
    }
}
