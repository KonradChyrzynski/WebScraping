using HtmlAgilityPack;

namespace WebScraping.Interfaces
{
    public interface IGetHtmlElementsService
    {
        HtmlNode[] GetHtmlNodesByClassAttributes(string nodeName);
    }
}
