using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckLinksConsole
{
    public class LinkChecker
    {
        public static IEnumerable<string> GetLinks(string body)
        {
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(body);
            var links = htmlDocument.DocumentNode.SelectNodes("//a[@href]").
                Select(n => n.GetAttributeValue("href", string.Empty))
                .Where(l => !String.IsNullOrEmpty(l))
                .Where(l => l.StartsWith("http"));
            return links;

        }
    }
}