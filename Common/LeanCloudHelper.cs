using LeanCloud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class LeanCloudHelper
    {
        static LeanCloudHelper()
        {
            AVClient.Initialize("mrtAQGRAp5huH092rlls3QKC-gzGzoHsz", "71Fx3jgH0cq0WoHgkQOoRNTO");

        }
        public static async void Add(AVObject obj)
        {
            try
            {
                Task saveTask = obj.SaveAsync();
                await saveTask;
            }
            catch (Exception ex)
            {

                throw;
            }
          
        }
    }
}
