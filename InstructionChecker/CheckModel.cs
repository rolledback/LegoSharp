using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LegoSharp;

namespace InstructionChecker
{
    class CheckModel
    {
        public static LegoClient client;

        public static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                List<HtmlBrick> neededBricks = InstructionsParser.parseInstructions(args[0]);
                client = new LegoClient();

                foreach (HtmlBrick brick in neededBricks)
                {
                    Brick result = client.getBrickByElementId(brick.id);
                    ConsoleColor originalColor = Console.ForegroundColor;
                    checkAgainstRequirement(brick, result);
                    Console.ForegroundColor = originalColor;
                }
            }
            else
            {
                Console.WriteLine("Wrong usage.");
            }

            exit();
        }

        public static void exit()
        {
            Console.WriteLine("Press any key to close...");
            Console.ReadKey();
        }

        public static void checkAgainstRequirement(HtmlBrick neededBrick, Brick brick)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            if (brick == null)
            {
                Console.WriteLine(string.Format(Constants.noMatchingBricksFound, neededBrick.name, neededBrick.id));
                return;
            }

            if (!brick.isAvailable)
            {
                Console.WriteLine(string.Format(Constants.brickUnavailable, neededBrick.name, neededBrick.id));
                findSimilarBricks(brick);
                return;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;

            if (brick.inventoryQuantity < neededBrick.quantity)
            {
                Console.WriteLine(string.Format(Constants.brickStockLow, neededBrick.name, neededBrick.id, neededBrick.quantity, brick.inventoryQuantity));
                return;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(string.Format(Constants.brickAvailable, neededBrick.name, neededBrick.id));

            return;
        }

        public static void findSimilarBricks(Brick brick)
        {
            BrickSearch similarBrickSearch = new BrickSearch();
            similarBrickSearch.setDesignId(brick.designId);

            List<Brick> similarBricks = client.searchForBricks(similarBrickSearch);

            if (similarBricks.Count > 0)
            {
                Console.WriteLine("  Similar bricks.");

                foreach (Brick similarBrick in similarBricks)
                {
                    Console.WriteLine("    -" + similarBrick.name + "(" + similarBrick.elementId + ")");
                }
            }
        }
    }
}
