using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using Newtonsoft.Json.Linq;

namespace TonyUtil.Helpers
{
    /// <summary>
    /// 万年历调 － 聚合数据
    /// 在线接口文档：http://www.juhe.cn/docs/177
    /// </summary>
    public static class Calendar
    {
        private const string AppKey = "22a7a437468a764ec9a3e44eb448e46a";

        public static bool IsHoliday(DateTime dateTime)
        {
            if (dateTime.DayOfWeek == DayOfWeek.Saturday || dateTime.DayOfWeek == DayOfWeek.Sunday) return true;
            var jsonStr = Day(dateTime.ToString("yyyy-M-d"));
            var jObj = JObject.Parse(jsonStr);
            var data = jObj["result"]["data"];
            return !(data["holiday"] is null);
        }

        /// <summary>
        /// 获取当天的详细信息
        /// </summary>
        /// <param name="day">指定日期,格式为YYYY-MM-DD,如月份和日期小于10,则取个位,如:2012-1-1</param>
        /// <returns></returns>
        public static string Day(string day)
        {
            const string url = "http://v.juhe.cn/calendar/day";
            var parameter = new Dictionary<string, string> {{"date", day}, {"key", AppKey}};
            var result = SendPost(url, parameter, "get");
            return result;
        }

        /// <summary>
        /// 获取当月近期假期
        /// </summary>
        /// <param name="month">指定月份,格式为YYYY-MM,如月份和日期小于10,则取个位,如:2012-1</param>
        /// <returns></returns>
        public static string Month(string month)
        {
            const string url = "http://v.juhe.cn/calendar/month";
            var parameter = new Dictionary<string, string> {{"date", month}, {"key", AppKey}};
            var result = SendPost(url, parameter, "get");
            return result;
        }

        /// <summary>
        /// 获取当年的假期列表
        /// </summary>
        /// <param name="year">指定年份,格式为YYYY,如:2015</param>
        /// <returns></returns>
        public static string Year(string year)
        {
            const string url = "http://v.juhe.cn/calendar/year";
            var parameter = new Dictionary<string, string> {{"date", year}, {"key", AppKey}};
            var result = SendPost(url, parameter, "get");
            return result;
        }

        /// <summary>
        /// Http (GET/POST)
        /// </summary>
        /// <param name="url">请求URL</param>
        /// <param name="parameters">请求参数</param>
        /// <param name="method">请求方法</param>
        /// <returns>响应内容</returns>
        private static string SendPost(string url, IDictionary<string, string> parameters, string method)
        {
            if (method.ToLower() == "post")
            {
                HttpWebRequest req = null;
                HttpWebResponse rsp = null;
                Stream reqStream = null;
                try
                {
                    req = (HttpWebRequest)WebRequest.Create(url);
                    req.Method = method;
                    req.KeepAlive = false;
                    req.ProtocolVersion = HttpVersion.Version10;
                    req.Timeout = 5000;
                    req.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
                    var postData = Encoding.UTF8.GetBytes(BuildQuery(parameters, "utf8"));
                    reqStream = req.GetRequestStream();
                    reqStream.Write(postData, 0, postData.Length);
                    rsp = (HttpWebResponse)req.GetResponse();
                    var encoding = Encoding.GetEncoding(rsp.CharacterSet);
                    return GetResponseAsString(rsp, encoding);
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                finally
                {
                    if (reqStream != null) reqStream.Close();
                    if (rsp != null) rsp.Close();
                }
            }
            //创建请求
            var request = (HttpWebRequest)WebRequest.Create(url + "?" + BuildQuery(parameters, "utf8"));

            //GET请求
            request.Method = "GET";
            request.ReadWriteTimeout = 5000;
            request.ContentType = "text/html;charset=UTF-8";
            var response = (HttpWebResponse)request.GetResponse();
            var myResponseStream = response.GetResponseStream();
            var myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));

            //返回内容
            var retString = myStreamReader.ReadToEnd();
            return retString;
        }

        /// <summary>
        /// 组装普通文本请求参数。
        /// </summary>
        /// <param name="parameters">Key-Value形式请求参数字典</param>
        /// <param name="encode">编码</param>
        /// <returns>URL编码后的请求数据</returns>
        private static string BuildQuery(IDictionary<string, string> parameters, string encode)
        {
            var postData = new StringBuilder();
            var hasParam = false;
            var dem = parameters.GetEnumerator();
            while (dem.MoveNext())
            {
                var name = dem.Current.Key;
                var value = dem.Current.Value;
                if (!string.IsNullOrWhiteSpace(name))
                {
                    if (hasParam) postData.Append("&");
                    postData.Append(name);
                    postData.Append("=");
                    if (encode == "gb2312")
                    {
                        postData.Append(HttpUtility.UrlEncode(value, Encoding.GetEncoding("gb2312")));
                    }
                    else if (encode == "utf8")
                    {
                        postData.Append(HttpUtility.UrlEncode(value, Encoding.UTF8));
                    }
                    else
                    {
                        postData.Append(value);
                    }
                    hasParam = true;
                }
            }
            return postData.ToString();
        }

        /// <summary>
        /// 把响应流转换为文本
        /// </summary>
        /// <param name="rsp"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        private static string GetResponseAsString(HttpWebResponse rsp, Encoding encoding)
        {
            Stream stream = null;
            StreamReader reader = null;

            try
            {
                stream = rsp.GetResponseStream();
                reader = new StreamReader(stream,encoding);
                return reader.ReadToEnd();
            }
            finally
            {
                //释放资源
                if(reader!=null) reader.Close();
                if(stream!=null) stream.Close();
                if(rsp!=null) rsp.Close();
            }
        }
    }


   
}
