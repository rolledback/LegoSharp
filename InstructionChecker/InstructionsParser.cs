using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HtmlAgilityPack;

namespace InstructionChecker
{
    public class InstructionsParser
    {
        public static List<HtmlBrick> parseInstructions(string filePath)
        {
            Console.WriteLine(string.Format("Opening: {0}", filePath));

            List<HtmlBrick> neededBricks = new List<HtmlBrick>();
            HtmlDocument doc = new HtmlDocument();
            doc.Load(filePath);

            foreach (HtmlNode brickNode in doc.DocumentNode.SelectNodes("//div[contains(concat(' ', normalize-space(@class), ' '), ' biElement ')]"))
            {
                HtmlNode tableRow = brickNode.ChildNodes[1].ChildNodes[1];
                List<HtmlNode> tableColumns = tableRow.ChildNodes.ToArray().ToList();
                HtmlNode[] brickAttributes = tableColumns.Where((item, index) => index == 1 || index == 5 || index == 7).ToArray();

                string quantity = brickAttributes[0].InnerHtml;
                string brickId = brickAttributes[1].InnerHtml;
                string name = brickAttributes[2].InnerHtml;

                neededBricks.Add(new HtmlBrick(brickId, int.Parse(quantity.Substring(0, quantity.IndexOf("&"))), name));
            }

            return neededBricks;
        }
    }
}
