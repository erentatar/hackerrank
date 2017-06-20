using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace CaptureTheFlag
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string uri = "https://cdn.hackerrank.com/hackerrank/static/contests/capture-the-flag/secret/secret_json/";
            List<string> resultsList = new List<string>();
            for (int i = 0; i < urlList.Count; i++)
            {
                resultsList.Add(GetResponse(uri + urlList[i] + ".json").news_title);
            }

            resultsList = resultsList.OrderBy(x => x).ToList();
            string lastResult = string.Join(Environment.NewLine, resultsList);
            Console.WriteLine(lastResult);
        }

        public RootObject GetResponse(string uri)
        {
            try
            {
                HttpWebRequest req = WebRequest.Create(uri) as HttpWebRequest;
                req.KeepAlive = false;
                req.Method = "GET";
                HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
                Encoding enc = System.Text.Encoding.GetEncoding(1252);
                StreamReader loResponseStream = new StreamReader(resp.GetResponseStream(), enc);
                string responseJsonStr = loResponseStream.ReadToEnd();
                return JsonConvert.DeserializeObject<RootObject>(responseJsonStr);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public class RootObject
        {
            public string news_title { get; set; }
            public string key { get; set; }
        }

        List<string> urlList = new List<string>()
        {
            "v060r",
            "fxcne",
            "4ijzo",
            "7o40h",
            "vjkf0",
            "96xmi",
            "7hmxu",
            "lefjd",
            "alien",
            "vejhb",
            "mz9a6",
            "tgihv",
            "utohw",
            "rp3g1",
            "fnsdm",
            "gstfd",
            "o020f",
            "i8z4b",
            "e9uak",
            "k9qxx",
            "9jh01",
            "89rcx",
            "yrxnh",
            "2y1b3",
            "xw5np",
            "276xh",
            "x2s57",
            "2b6f7",
            "t76dy",
            "il0d5",
            "ff8vi",
            "m7c30",
            "a5b38",
            "s94o9",
            "w17qs",
            "44bd3",
            "wnpxm",
            "mars",
            "epmqk",
            "ki0ag",
            "rs500",
            "etdbc",
            "nu5q2",
            "223j4",
            "ue9sp",
            "8bue1",
            "me6mc",
            "n0sh4",
            "3hqk3",
            "w8xh4",
            "i5cxs",
            "0rmqe",
            "kpisp",
            "jck0j",
            "k3dip",
            "oywsu",
            "eej3o",
            "wixg4",
            "62al1",
            "tjgzq",
            "jhpfy",
            "o4zx6",
            "wup33",
            "m88dt",
            "tvygb",
            "24hcw",
            "pjfb8",
            "3dfng",
            "wzeai",
            "0z6uz",
            "zaden",
            "pcxjo",
            "z732w",
            "jdjws",
            "byzms"
        };
    }
}
