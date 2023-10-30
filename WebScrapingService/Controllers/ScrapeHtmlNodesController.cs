using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using WebScraping.Interfaces;

namespace WebScraping.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HtmlScrapingController : ControllerBase
    {
        private readonly IGetHtmlElementsService _scraperService;

        public HtmlScrapingController(IGetHtmlElementsService getHtmlElementsService)
        {
            this._scraperService = getHtmlElementsService;
        }

        [HttpGet]
        public IActionResult GetHtmlNodesByClassAttributes(string classAttributes)
        {
            try
            {
                // Call the GetHtmlNodesByClassAttributes method from the AgilityPackScraperService
                HtmlNode[] nodes = _scraperService.GetHtmlNodesByClassAttributes(classAttributes);

                nodes = nodes.TakeWhile(x => x != null).ToArray();

                // Extract inner text from each node
                string[] nodeTexts = new string[nodes.Length];

                for (int i = 0; i < nodes.Length; i++)
                {
                    nodeTexts[i] = nodes[i].InnerHtml;
                }

                return Ok(nodeTexts);
            }
            catch (ArgumentException ex)
            {
                // Return a bad request if classAttributes is invalid
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                // Handle other exceptions
                Console.WriteLine(ex.ToString());
                return StatusCode(500, "An error occurred while scraping the HTML.");
            }
        }
    }
}
