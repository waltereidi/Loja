﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.loja.Interfaces
{
    public interface IStringValidationAttribute
    {
        string RegexPattern { get;  }

    }
}
