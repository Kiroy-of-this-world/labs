using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Laba_7
{
    class PlayerExceptions : Exception
    {
        public PlayerExceptions(string message)
        : base(message)
        { }
        public string message = "Вы не можете играть, пока вам нет 18!";
        public string howToAvoid = "Вырости, и играй";
    }
    class BenchExceptions : Exception
    {
        public BenchExceptions(string message)
        : base(message)
        { }
        public string message = "Скамейка слишком старa!";
        public string howToAvoid = "Сделайте новую скамейку!";
    }
    class CommonException : ApplicationException
    {
        public CommonException(string str) : base(str) { }
        public override string ToString()
        {
            return Message;
        }
    }
}
