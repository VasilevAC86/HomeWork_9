using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_9
{
    public class NoPositiveNumbersException:Exception
    {
        public NoPositiveNumbersException(string str):base(str) { }
    }
}
