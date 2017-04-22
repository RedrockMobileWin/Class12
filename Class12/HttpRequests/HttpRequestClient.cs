using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace Class12.HttpRequests
{
    public class HttpRequestClient
    {
        public static async Task<string> LastestRequest()
        {
            HttpClient httpclient = new HttpClient();
            HttpResponseMessage response = null;
            List<KeyValuePair<string, string>> param = new List<KeyValuePair<string, string>>();
            string result = null;
            try
            {
                param.Add(new KeyValuePair<string, string>("p", "1"));
                param.Add(new KeyValuePair<string, string>("size", "20"));
                param.Add(new KeyValuePair<string, string>("tab", "lastest"));
                response = await httpclient.PostAsync(new Uri("http://app.vmoiver.com/apiv3/post/getPostByTab"), new HttpFormUrlEncodedContent(param));
                result = await response.Content.ReadAsStringAsync();
                return result;
            }
            catch (Exception)
            {
                return result;
            }
        }
    }
}
