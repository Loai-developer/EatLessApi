﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatLess.Domain.Exceptions
{
    public abstract class DomainException : Exception
    {
        protected DomainException(string Message)
            :base(Message)
        {
            
        }


    }
}
