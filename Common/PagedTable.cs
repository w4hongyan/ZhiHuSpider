using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class PagedTable<T>
    {
        public int total { get; set; }
        public List<T> rows { get; set; }
    }
}
