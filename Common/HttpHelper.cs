using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
   public class HttpHelper
    {
        /// <summary>
        /// 下载字符资源
        /// </summary>
        /// <param name="url">url</param>
        /// <returns>字符资源</returns>
        public static string DownLoadString(string url)
        {
            string Source = string.Empty;
            try
            {
               
                //      string proxyHost = "http://proxy.abuyun.com";
                //          string proxyPort = "9020";
                //// 代理隧道验证信息
                //           string proxyUser = "H71T6AMK";
                //            string proxyPass = "D3F01F3AEFE";
                //var proxy = new WebProxy();
                //proxy.Address = new Uri(string.Format("{0}:{1}", proxyHost, proxyPort));
                //proxy.Credentials = new NetworkCredential(proxyUser, proxyPass);
                //ServicePointManager.Expect100Continue = false;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.108 Safari/537.36";
                request.Headers.Add("Cookie", "q_c1=1b1e9c10be3a4f899ec771028aad098d|1514870815000|1514870815000; _zap=ff75d3e1-3335-4288-8c16-acb22197341a; l_cap_id=\"YTcxZTdmZDlmYmNmNGE1ZWE4ZTVjZDE4Mjg5YzEwZDc=|1514875218|cbcb2be596348d08417f15a936b0e4fa56bf350b\"; r_cap_id=\"OWIxNTMyMjlhNTU4NDQxM2JmNzAzNjYyMGVjYjU1MWI=|1514875218|af1e4794fe727d388d46e5f26510a501c3fc1399\"; cap_id=\"YzVlNDUxZDE0MGYyNDc0MTljMjYwNmJkMTJlZjc3MGE=|1514875218|59549acb073ad0799199a4403031830ab518012f\"; capsion_ticket=\"2|1:0|10:1514875223|14:capsion_ticket|44:NjBmMzk2OTlkNGY0NDZmNjkzOWMxNDMwNGY5NzJlNjY=|28d795a670edb4d04c20e9754d50c5037d12e7485116ffade9a6f127aecf58ef\"; z_c0=\"2|1:0|10:1514875229|4:z_c0|80:MS4xOHNFTEFBQUFBQUFtQUFBQVlBSlZUVjEzT0ZzS01aeFB1d3ZqSnNPQ2wwNkh0Qm03SlgxdDRBPT0=|c3193706cc93e19352a16d9723d2ac1f99ef036bd7e4f91ffd243c3ae73bc166\"; aliyungf_tc=AQAAAKYu0xGrXgEARoiDe0W45l2Wl4xM; d_c0=\"APAgjxGx7wyPTrJoOrJtP_rJuwpaEz9yWH4=|1515023866\"; _xsrf=03bf7914-d5fb-4add-9096-2b2fbeedd93e");
                request.Headers.Add("Upgrade-Insecure-Requests", "1");
                request.Headers.Add("Cache-Control", "no-cach");
                request.Headers.Add("authorization", "Bearer 2|1:0|10:1514875229|4:z_c0|80:MS4xOHNFTEFBQUFBQUFtQUFBQVlBSlZUVjEzT0ZzS01aeFB1d3ZqSnNPQ2wwNkh0Qm03SlgxdDRBPT0=|c3193706cc93e19352a16d9723d2ac1f99ef036bd7e4f91ffd243c3ae73bc166");
                request.Headers.Add("X-UDID", "APAgjxGx7wyPTrJoOrJtP_rJuwpaEz9yWH4=");
                request.Accept = "application/json, text/plain, */*";
                request.Method = "GET";
                request.Referer = "https://www.zhihu.com/question/50364416";
                request.Host = "www.zhihu.com";
                //request.Headers.Add("Accept-Encoding", " gzip, deflate, br");
                request.KeepAlive = true;//启用长连接
                                         // request.Proxy = proxy;
                request.ProtocolVersion = HttpVersion.Version10;
                //ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {

                    using (Stream dataStream = response.GetResponseStream())
                    {

                        if (response.ContentEncoding.ToLower().Contains("gzip"))//解压
                        {
                            using (GZipStream stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress))
                            {
                                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                                {
                                    Source = reader.ReadToEnd();
                                }
                            }
                        }
                        else if (response.ContentEncoding.ToLower().Contains("deflate"))//解压
                        {
                            using (DeflateStream stream = new DeflateStream(response.GetResponseStream(), CompressionMode.Decompress))
                            {
                                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                                {
                                    Source = reader.ReadToEnd();
                                }

                            }
                        }
                        else
                        {
                            using (Stream stream = response.GetResponseStream())//原始
                            {
                                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                                {

                                    Source = reader.ReadToEnd();
                                }
                            }
                        }

                    }
                }
                request.Abort();

            }
            catch (Exception ex)
            {
                Console.WriteLine("出错了，请求的URL为{0}", url);

            }
            return Source;
        }
    }
}
