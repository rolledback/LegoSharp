using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LegoSharp
{
    public class BrickCategoryFilter : PickABrickValuesFilter<BrickCategory>
    {
        public BrickCategoryFilter() : base("categories.id", "element.facet.pickABrick")
        {
        }
    }

    public class BrickCategory : ValuesFilterValue
    {
        public BrickCategory(string value, string name) : base(value, name)
        {
        }

        public static readonly BrickCategory AnimalsAndCreatures = new BrickCategory("b7ec4069-c319-443d-b49f-0cba7a1d204e", "Animals & Creatures");
        public static readonly BrickCategory Bricks = new BrickCategory("b3495055-2386-4968-bc47-e980b02d01a1", "Bricks");
        public static readonly BrickCategory BricksBowsAndArches = new BrickCategory("d3e1cbdf-b57c-4ee4-bb82-df3a3c22073d", "Bricks, bows & arches");
        public static readonly BrickCategory BricksRoundAndAngles = new BrickCategory("dfb159f7-cb98-4d84-85e3-df6b7ab4165d", "Bricks, round & angles");
        public static readonly BrickCategory BricksSlopes = new BrickCategory("e748c86a-3a97-492e-996b-526f31aa8956", "Bricks, slopes");
        public static readonly BrickCategory BricksSpecial = new BrickCategory("496a8819-5276-4c06-95a9-f2a01d1dfaad", "Bricks, special");
        public static readonly BrickCategory Connectors = new BrickCategory("898bcfe9-5b97-4b72-a32b-6b796083d611", "Connectors");
        public static readonly BrickCategory CupboardsChairsBoxesAndYaps = new BrickCategory("6b1dd2c8-6444-44fb-a6c6-9ea3abdb4210", "Cupboards, chairs, boxes & taps");
        public static readonly BrickCategory Decoration = new BrickCategory("40e85be0-7002-4108-bf23-f4c5406f0cd3", "Decoration");
        public static readonly BrickCategory FencesAndLadders = new BrickCategory("dd60b424-a584-4854-bd63-d11d1e75bdea", "Fences & ladders");
        public static readonly BrickCategory FigureHairAndhats = new BrickCategory("8a40da75-9dfa-4ce6-b8e4-9bf514a84073", "Figure hair & hats");
        public static readonly BrickCategory FigureHandAccessories = new BrickCategory("333a66f7-1e0c-491f-8d97-fb0935542278", "Figure hand accessories");
        public static readonly BrickCategory FigureHeads = new BrickCategory("c44e9b08-90e9-45e1-9572-54996ffb8c1f", "Figure heads");
        public static readonly BrickCategory FigureParts = new BrickCategory("5dbba164-c2e7-46b6-b1fc-9de3874bf697", "Figure parts");
        public static readonly BrickCategory FigureWeapons = new BrickCategory("2de32f56-5004-4e51-8c14-374a580654ab", "Figure weapons");
        public static readonly BrickCategory Food = new BrickCategory("293caf57-9482-4ec3-8c4d-f338adc715e5", "Food");
        public static readonly BrickCategory FunctionalElements = new BrickCategory("0c5a2510-e591-4bc4-9c77-3359986fe839", "Functional elements");
        public static readonly BrickCategory GatesAndRoofs = new BrickCategory("bea51066-55ef-43aa-a268-b5ae54fd7e7a", "Gates and roofs");
        public static readonly BrickCategory PlantsAndFlowers = new BrickCategory("5982c311-a5ea-45f3-9839-2f5f435560d6", "Plants & Flowers");
        public static readonly BrickCategory Plates = new BrickCategory("83a6a194-2411-4f62-9f1f-7c3ddbadc973", "Plates");
        public static readonly BrickCategory PlatesCirclesAndAngles = new BrickCategory("8d6f6db0-e7f6-4bcf-aa05-1595fc83b251", "Plates, circles & angles");
        public static readonly BrickCategory PlatesSpecial = new BrickCategory("4b1ab1f9-7d2e-45b4-a497-d017f05d20fb", "Plates, special");
        public static readonly BrickCategory Scaffold = new BrickCategory("1fd6f437-aad3-4f2e-ba53-769b945f625a", "Scaffold");
        public static readonly BrickCategory SignsFlagsAndpoles = new BrickCategory("7cd0435a-7419-4387-8712-9183c2a3ac9b", "Signs, flags & poles");
        public static readonly BrickCategory TechnicBeams = new BrickCategory("f51938f0-7246-446a-a174-f379c2b08b67", "Technic beams");
        public static readonly BrickCategory TechnicBricks = new BrickCategory("1b5e2c2a-caa6-4499-afd5-5aaccc33d152", "Technic bricks");
        public static readonly BrickCategory Transportation = new BrickCategory("4aa0cae5-cbbb-49f7-ad7c-1287ac3b78f8", "Transportation");
        public static readonly BrickCategory WheelBase = new BrickCategory("a8e98c1d-787e-4e08-9d1f-63afd61c228f", "Wheel base");
        public static readonly BrickCategory Wheels = new BrickCategory("85923e85-894d-42d7-a2d9-c15d46ba11ff", "Wheels");
        public static readonly BrickCategory WindowsWallsAndDoors = new BrickCategory("f749363e-c46b-414e-bc9a-b43279c6a76d", "Windows, walls & doors");
        public static readonly BrickCategory Windscreens = new BrickCategory("fc8e40d1-02e4-49e2-aa8d-da51ebe547f8", "Windscreens");
    }
}
