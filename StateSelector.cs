using System;
using System.Collections.Generic;
using System.Text;

namespace Webscraper
{
    class StateSelector
    {
        // 'StateUrl' object list containing all states and matching urls
        public static List<StateUrl> stateUrlList = new List<StateUrl>()
        {
            new StateUrl("alabama", "https://gasprices.aaa.com/?state=AL"),
            new StateUrl("alaska", "https://gasprices.aaa.com/?state=AK"),
            new StateUrl("arizona", "https://gasprices.aaa.com/?state=AZ"),
            new StateUrl("arkansas", "https://gasprices.aaa.com/?state=AR"),
            new StateUrl("california", "https://gasprices.aaa.com/?state=CA"),
            new StateUrl("colorado", "https://gasprices.aaa.com/?state=CO"),
            new StateUrl("connecticut", "https://gasprices.aaa.com/?state=CT"),
            new StateUrl("delaware", "https://gasprices.aaa.com/?state=DE"),
            new StateUrl("florida", "https://gasprices.aaa.com/?state=FL"),
            new StateUrl("georgia", "https://gasprices.aaa.com/?state=GA"),
            new StateUrl("hawaii", "https://gasprices.aaa.com/?state=HI"),
            new StateUrl("idaho", "https://gasprices.aaa.com/?state=ID"),
            new StateUrl("illinois", "https://gasprices.aaa.com/?state=IL"),
            new StateUrl("indiana", "https://gasprices.aaa.com/?state=IN"),
            new StateUrl("iowa", "https://gasprices.aaa.com/?state=IA"),
            new StateUrl("kansas", "https://gasprices.aaa.com/?state=KS"),
            new StateUrl("kentucky", "https://gasprices.aaa.com/?state=KY"),
            new StateUrl("louisiana", "https://gasprices.aaa.com/?state=LA"),
            new StateUrl("maine", "https://gasprices.aaa.com/?state=ME"),
            new StateUrl("maryland", "https://gasprices.aaa.com/?state=MD"),
            new StateUrl("massachusetts", "https://gasprices.aaa.com/?state=MA"),
            new StateUrl("michigan", "https://gasprices.aaa.com/?state=MI"),
            new StateUrl("minnesota", "https://gasprices.aaa.com/?state=MN"),
            new StateUrl("mississippi", "https://gasprices.aaa.com/?state=MS"),
            new StateUrl("missouri", "https://gasprices.aaa.com/?state=MO"),
            new StateUrl("montana", "https://gasprices.aaa.com/?state=MT"),
            new StateUrl("nebraska", "https://gasprices.aaa.com/?state=NE"),
            new StateUrl("nevada", "https://gasprices.aaa.com/?state=NV"),
            new StateUrl("new hampshire", "https://gasprices.aaa.com/?state=NH"),
            new StateUrl("new jersey", "https://gasprices.aaa.com/?state=NJ"),
            new StateUrl("new mexico", "https://gasprices.aaa.com/?state=NM"),
            new StateUrl("new york", "https://gasprices.aaa.com/?state=NY"),
            new StateUrl("north carolina", "https://gasprices.aaa.com/?state=NC"),
            new StateUrl("north dakota", "https://gasprices.aaa.com/?state=ND"),
            new StateUrl("ohio", "https://gasprices.aaa.com/?state=OH"),
            new StateUrl("oklahoma", "https://gasprices.aaa.com/?state=OK"),
            new StateUrl("oregon", "https://gasprices.aaa.com/?state=OR"),
            new StateUrl("pennsylvania", "https://gasprices.aaa.com/?state=PA"),
            new StateUrl("rhode island", "https://gasprices.aaa.com/?state=RI"),
            new StateUrl("south carolina", "https://gasprices.aaa.com/?state=SC"),
            new StateUrl("south dakota", "https://gasprices.aaa.com/?state=SD"),
            new StateUrl("tennessee", "https://gasprices.aaa.com/?state=TN"),
            new StateUrl("texas", "https://gasprices.aaa.com/?state=TX"),
            new StateUrl("utah", "https://gasprices.aaa.com/?state=UT"),
            new StateUrl("vermont", "https://gasprices.aaa.com/?state=VT"),
            new StateUrl("virginia", "https://gasprices.aaa.com/?state=VA"),
            new StateUrl("washington", "https://gasprices.aaa.com/?state=WA"),
            new StateUrl("west virginia", "https://gasprices.aaa.com/?state=WV"),
            new StateUrl("wisconsin", "https://gasprices.aaa.com/?state=WI"),
            new StateUrl("wyoming", "https://gasprices.aaa.com/?state=WY"),
        };

        /* State Select Function
         * - Searches through a list of states to return matching url
         * PARAMS - (string) state name
         * RETURNS - (string) state url // null
         */
        public static string SelectState(string stateName)
        {
            // iterate through list
            for (int i = 0; i < stateUrlList.Count; i++)
            {
                // return url if true
                if (stateName == stateUrlList[i].state)
                {
                    return stateUrlList[i].url;
                }
            }
            // if no state is found return "NONE"
            return "NONE";
        }
    }
}
