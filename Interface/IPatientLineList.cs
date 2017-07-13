using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQTools.Interface
{
   public interface IPatientLineList
    {
        DataTable DueForVL(DateTime asof);
    }
}
