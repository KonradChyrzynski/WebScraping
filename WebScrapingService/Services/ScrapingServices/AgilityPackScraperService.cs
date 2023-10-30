using HtmlAgilityPack;
using WebScraping.Interfaces;

namespace WebScraping.ScrapingServices
{
    public class AgilityPackScraperService : IGetHtmlElementsService
    {
        private readonly string[] urls;

        public AgilityPackScraperService(string[] _urls) 
        {
            this.urls = _urls;
        }

        public HtmlNode[] GetHtmlNodesByClassAttributes(string classAttributes)
        {
            if (!string.IsNullOrEmpty(classAttributes) || string.IsNullOrWhiteSpace(classAttributes))
            {
                HtmlWeb web = new HtmlWeb();

                HtmlNode[] nodes = new HtmlNode[urls.Length];

                for (int i = 0; i < urls.Length; i++)
                {
                    HtmlDocument doc = web.Load(urls[i]);

                    // Find the element with the given class attributes
                    HtmlNode node = doc.DocumentNode.SelectSingleNode($"//*[@class='{classAttributes}']");

                    nodes[i] = node;
                }

                return nodes;
            }

            throw new ArgumentException($"'{nameof(classAttributes)}' cannot be null or empty or whitespace.", nameof(classAttributes));
        }
    }
}
