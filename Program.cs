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
            string userInput = "NONE";

            while (userInput == "NONE")
            {
                Console.Write("Enter a states name: ");
                userInput = Console.ReadLine();
                userInput = StateSelector.SelectState(userInput.ToLower());
            }

            OutputToJson(GetGasPrices(userInput));
        }

        /* Get Gas Prices Function
         * - Accesses and stores prices from html
         * PARAMS - (string) state url
         * RETURNS - (CurrentPrices) object containing current prices
         */
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

        /* Get Html Function
         * - Accesses and store webpage html
         * PARAMS - (string) state url
         * RETURNS - (HtmlNode) webpage doc
         */
        static HtmlNode GetHtml(string url)
        {
            WebPage webpage = _scrapingBrowser.NavigateToPage(new Uri(url));
            return webpage.Html;
        }

        /* Output to Json Function 
         * - Outputs CurrentPrices object to json file in 'Temp' folder
         * PARAMS - (CurrentPrices) object containing current prices
         */
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
}
