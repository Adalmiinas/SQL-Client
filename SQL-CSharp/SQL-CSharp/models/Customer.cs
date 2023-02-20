using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_CSharp.models
{
    public readonly record struct Customer(int id, string firstname, string lastname, string? country, string? postalcode, string? phone, string? email); 
    
}
