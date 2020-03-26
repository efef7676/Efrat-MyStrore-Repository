using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IHasProducts<T>
        where T:GeneralProduct
    {
        List<T> Products { get; }
        T GetProductBy(Uri uri);
    }
}
