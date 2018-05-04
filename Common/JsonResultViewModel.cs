using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class JsonResultViewModel
    {
        public JsonResultViewModel()
        {
            status = JsonStatus.Success;
            msg = string.Empty;
        }

        public string status { get; set; }
        public string msg { get; set; }
    }
    public class JsonStatus
    {
        public static string Success = "success";
        public static string Error = "error";
    }
}
