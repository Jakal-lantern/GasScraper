using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using ScrapySharp.Network;
using System.IO;
using Newtonsoft.Json;

namespace Webscraper
{
    class Program
    {
        static ScrapingBrowser _scrapingBrowser = new ScrapingBrowser();

        static void Main(string[] args)
        {
            OutputToJson(GetGasPrices("https://gasprices.aaa.com/?state=OH"));
        }

        // Access and store prices from html
        // RETURNS: CurrentPrices
        static CurrentPrices GetGasPrices(string url)
        {
            // Access Html
            var HtmlNode = GetHtml(url);
            // Create new 'CurrentPrices' object
            var currentPrices = new CurrentPrices();

            // Access and store gas prices
            currentPrices.Regular = HtmlNode.OwnerDocument.DocumentNode.SelectSingleNode("//html/body/main/div[4]/table/tbody/tr/td[2]").InnerText;
            currentPrices.MidGrade = HtmlNode.OwnerDocument.DocumentNode.SelectSingleNode("//html/body/main/div[4]/table/tbody/tr/td[3]").InnerText;
            currentPrices.Premium = HtmlNode.OwnerDocument.DocumentNode.SelectSingleNode("//html/body/main/div[4]/table/tbody/tr/td[4]").InnerText;
            currentPrices.Diesel = HtmlNode.OwnerDocument.DocumentNode.SelectSingleNode("//html/body/main/div[4]/table/tbody/tr/td[5]").InnerText;
            
            return currentPrices;
        }

        // Access and store webpage html
        // RETURNS: Html
        static HtmlNode GetHtml(string url)
        {
            WebPage webpage = _scrapingBrowser.NavigateToPage(new Uri(url));
            return webpage.Html;
        }

        // Output 'currentPrices' to json file
        static void OutputToJson(CurrentPrices currentPrices)
        {
            // Create output variable
            List<CurrentPrices> outputData = new List<CurrentPrices>();
            // Format 'outputData'
            outputData.Add(new CurrentPrices()
            {
                Regular = currentPrices.Regular,
                MidGrade = currentPrices.MidGrade,
                Premium = currentPrices.Premium,
                Diesel = currentPrices.Diesel
            });

            // Convert to string
            string json = JsonConvert.SerializeObject(outputData.ToArray());

            // Write string to file
            File.WriteAllText(@"C:\Temp\CurrentGasPrices.json", json);
        }
    }

    // Object for storing gas prices
    public class CurrentPrices
    {
        public string Regular { get; set; }
        public string MidGrade { get; set; }
        public string Premium { get; set; }
        public string Diesel { get; set; }
    }
}
