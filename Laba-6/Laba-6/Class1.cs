﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_6
{
    abstract public partial class Tennis : IMessage
    {
        public override int GetHashCode()
        {
            return Year.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;
            else return true;
        }
        public abstract void MainMessage();
    }
}
