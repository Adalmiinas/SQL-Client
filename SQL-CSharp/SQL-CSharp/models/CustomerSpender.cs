using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_CSharp.models
{
    public readonly record struct CustomerSpender(int id, decimal total);
}
