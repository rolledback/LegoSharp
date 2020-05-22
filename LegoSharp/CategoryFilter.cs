using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LegoSharp
{
    public class CategoryFilter : LegoGraphFilter<LegoCategory>
    {
        public CategoryFilter() : base("categories.id")
        {
        }

        public override string filterEnumToValue(LegoCategory category)
        {
            switch (category)
            {
                case LegoCategory.AnimalsAndCreatures:
                    return "b7ec4069-c319-443d-b49f-0cba7a1d204e";
                case LegoCategory.Bricks:
                    return "b3495055-2386-4968-bc47-e980b02d01a1";
                case LegoCategory.BricksBowsAndArches:
                    return "d3e1cbdf-b57c-4ee4-bb82-df3a3c22073d";
                case LegoCategory.BricksRoundAndAngles:
                    return "dfb159f7-cb98-4d84-85e3-df6b7ab4165d";
                case LegoCategory.BricksSlopes:
                    return "e748c86a-3a97-492e-996b-526f31aa8956";
                case LegoCategory.BricksSpecial:
                    return "496a8819-5276-4c06-95a9-f2a01d1dfaad";
                case LegoCategory.Connectors:
                    return "898bcfe9-5b97-4b72-a32b-6b796083d611";
                case LegoCategory.CupboardsChairsBoxesAndYaps:
                    return "6b1dd2c8-6444-44fb-a6c6-9ea3abdb4210";
                case LegoCategory.Decoration:
                    return "40e85be0-7002-4108-bf23-f4c5406f0cd3";
                case LegoCategory.FencesAndLadders:
                    return "dd60b424-a584-4854-bd63-d11d1e75bdea";
                case LegoCategory.FigureHairAndhats:
                    return "8a40da75-9dfa-4ce6-b8e4-9bf514a84073";
                case LegoCategory.FigureHandAccessories:
                    return "333a66f7-1e0c-491f-8d97-fb0935542278";
                case LegoCategory.FigureHeads:
                    return "c44e9b08-90e9-45e1-9572-54996ffb8c1f";
                case LegoCategory.FigureParts:
                    return "5dbba164-c2e7-46b6-b1fc-9de3874bf697";
                case LegoCategory.FigureWeapons:
                    return "2de32f56-5004-4e51-8c14-374a580654ab";
                case LegoCategory.Food:
                    return "293caf57-9482-4ec3-8c4d-f338adc715e5";
                case LegoCategory.FunctionalElements:
                    return "0c5a2510-e591-4bc4-9c77-3359986fe839";
                case LegoCategory.GatesAndRoofs:
                    return "bea51066-55ef-43aa-a268-b5ae54fd7e7a";
                case LegoCategory.PlantsAndFlowers:
                    return "5982c311-a5ea-45f3-9839-2f5f435560d6";
                case LegoCategory.Plates:
                    return "83a6a194-2411-4f62-9f1f-7c3ddbadc973";
                case LegoCategory.PlatesCirclesAndAngles:
                    return "8d6f6db0-e7f6-4bcf-aa05-1595fc83b251";
                case LegoCategory.PlatesSpecial:
                    return "4b1ab1f9-7d2e-45b4-a497-d017f05d20fb";
                case LegoCategory.Scaffold:
                    return "1fd6f437-aad3-4f2e-ba53-769b945f625a";
                case LegoCategory.SignsFlagsAndpoles:
                    return "7cd0435a-7419-4387-8712-9183c2a3ac9b";
                case LegoCategory.TechnicBeams:
                    return "f51938f0-7246-446a-a174-f379c2b08b67";
                case LegoCategory.TechnicBricks:
                    return "1b5e2c2a-caa6-4499-afd5-5aaccc33d152";
                case LegoCategory.Transportation:
                    return "4aa0cae5-cbbb-49f7-ad7c-1287ac3b78f8";
                case LegoCategory.WheelBase:
                    return "a8e98c1d-787e-4e08-9d1f-63afd61c228f";
                case LegoCategory.Wheels:
                    return "85923e85-894d-42d7-a2d9-c15d46ba11ff";
                case LegoCategory.WindowsWallsAndDoors:
                    return "f749363e-c46b-414e-bc9a-b43279c6a76d";
                case LegoCategory.Windscreens:
                    return "fc8e40d1-02e4-49e2-aa8d-da51ebe547f8";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override string filterEnumToName(LegoCategory category)
        {
            switch (category)
            {
                case LegoCategory.AnimalsAndCreatures:
                    return "Animals & Creatures";
                case LegoCategory.Bricks:
                    return "Bricks";
                case LegoCategory.BricksBowsAndArches:
                    return "Bricks, bows & arches";
                case LegoCategory.BricksRoundAndAngles:
                    return "Bricks, round & angles";
                case LegoCategory.BricksSlopes:
                    return "Bricks, slopes";
                case LegoCategory.BricksSpecial:
                    return "Bricks, special";
                case LegoCategory.Connectors:
                    return "Connectors";
                case LegoCategory.CupboardsChairsBoxesAndYaps:
                    return "Cupboards, chairs, boxes & taps";
                case LegoCategory.Decoration:
                    return "Decoration";
                case LegoCategory.FencesAndLadders:
                    return "Fences & ladders";
                case LegoCategory.FigureHairAndhats:
                    return "Figure hair & hats";
                case LegoCategory.FigureHandAccessories:
                    return "Figure hand accessories";
                case LegoCategory.FigureHeads:
                    return "Figure heads";
                case LegoCategory.FigureParts:
                    return "Figure parts";
                case LegoCategory.FigureWeapons:
                    return "Figure weapons";
                case LegoCategory.Food:
                    return "Food";
                case LegoCategory.FunctionalElements:
                    return "Functional elements";
                case LegoCategory.GatesAndRoofs:
                    return "Gates and roofs";
                case LegoCategory.PlantsAndFlowers:
                    return "Plants & Flowers";
                case LegoCategory.Plates:
                    return "Plates";
                case LegoCategory.PlatesCirclesAndAngles:
                    return "Plates, circles & angles";
                case LegoCategory.PlatesSpecial:
                    return "Plates, special";
                case LegoCategory.Scaffold:
                    return "Scaffold";
                case LegoCategory.SignsFlagsAndpoles:
                    return "Signs, flags & poles";
                case LegoCategory.TechnicBeams:
                    return "Technic beams";
                case LegoCategory.TechnicBricks:
                    return "Technic bricks";
                case LegoCategory.Transportation:
                    return "Transportation";
                case LegoCategory.WheelBase:
                    return "Wheel base";
                case LegoCategory.Wheels:
                    return "Wheels";
                case LegoCategory.WindowsWallsAndDoors:
                    return "Windows, walls & doors";
                case LegoCategory.Windscreens:
                    return "Windscreens";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    public enum LegoCategory
    {
        AnimalsAndCreatures,
        Bricks,
        BricksBowsAndArches,
        BricksRoundAndAngles,
        BricksSlopes,
        BricksSpecial,
        Connectors,
        CupboardsChairsBoxesAndYaps,
        Decoration,
        FencesAndLadders,
        FigureHairAndhats,
        FigureHandAccessories,
        FigureHeads,
        FigureParts,
        FigureWeapons,
        Food,
        FunctionalElements,
        GatesAndRoofs,
        PlantsAndFlowers,
        Plates,
        PlatesCirclesAndAngles,
        PlatesSpecial,
        Scaffold,
        SignsFlagsAndpoles,
        TechnicBeams,
        TechnicBricks,
        Transportation,
        WheelBase,
        Wheels,
        WindowsWallsAndDoors,
        Windscreens
    }
}
