using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using HtmlAgilityPack;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CaptureTheFlag
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            string uri = "https://cdn.hackerrank.com/hackerrank/static/contests/capture-the-flag/infinite/";
            List<string> links = new List<string>() { "qds.html" };
            int i = 0;
            List<string> phrases = new List<string>();
            while (i < links.Count)
            {
                string innerHtml = GetResponse(uri + links[i]);
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(innerHtml);
                HtmlNodeCollection phraseNodes = doc.DocumentNode.SelectNodes("//font");
                if (phraseNodes != null)
                {
                    foreach (HtmlNode quote in phraseNodes)
                        phrases.Add(quote.InnerText);
                }
                foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))
                {
                    HtmlAttribute att = link.Attributes["href"];
                    if (!links.Contains(att.Value))
                        links.Add(att.Value);
                }
                i++;
            }
        }

        public string GetResponse(string uri, string content = "", string contentType = "")
        {
            try
            {
                HttpWebRequest req = WebRequest.Create(uri) as HttpWebRequest;
                req.KeepAlive = false;
                req.Method = "GET";
                HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
                Encoding enc = System.Text.Encoding.GetEncoding(1252);
                StreamReader loResponseStream = new StreamReader(resp.GetResponseStream(), enc);
                return loResponseStream.ReadToEnd();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
