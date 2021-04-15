using System;
using System.Collections.Generic;
using System.Text;

namespace Webscraper
{
    // Object to store state urls
    class StateUrl
    {
        public string state;
        public string url;

        // CONSTRUCTOR
        public StateUrl(string stateText, string urlText)
        {
            this.state = stateText;
            this.url = urlText;
        }
    }
}
