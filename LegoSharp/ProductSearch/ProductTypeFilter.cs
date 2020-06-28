using System;
using System.Collections.Generic;
using System.Text;

namespace LegoSharp
{
    public class ProductTypeFilter : ProductSearchValuesFilter<ProductType>
    {
        public ProductTypeFilter() : base("categories.id", "product.facet.productType")
        {
        }

        public override string filterEnumToValue(ProductType type)
        {
            switch (type)
            {
                case ProductType.Books:
                    return "d20ecc4f-1dd8-4f1d-8158-fe2c59bdbbbe";
                case ProductType.BrickAccessories:
                    return "59d5df5c-543e-4b5b-9299-d41b7b480afa";
                case ProductType.Classic:
                    return "975369b1-17a2-42e6-a39f-0386b85def5b";
                case ProductType.ClothingANDAccessories:
                    return "de583581-4dd0-4f6b-981b-8b31b9a0fb48";
                case ProductType.ForTheHome:
                    return "b32cddff-52e5-4f22-a212-1dfb3fd31fbb";
                case ProductType.IndividualBricks:
                    return "b4c8be0b-436f-445a-8b3e-a96cbd531920";
                case ProductType.KeyChains:
                    return "0b05a003-1702-40e9-8f65-185dcfc640ed";
                case ProductType.Minifigures:
                    return "a46f1ffd-db4d-4813-89d1-5d19f8737ef5";
                case ProductType.Polybag:
                    return "c9f9b650-5988-4828-acd8-194a83668100";
                case ProductType.PowerFunctions:
                    return "a6013c1e-72dd-4e0b-a506-c13c0a0dc44b";
                case ProductType.RolePlayAndCostumes:
                    return "5dc73b3a-0138-4e0b-afd2-01a6b30fb94e";
                case ProductType.Sets:
                    return "12ba8640-7fb5-4281-991d-ac55c65d8001";
                case ProductType.Stationery:
                    return "275e987f-0cc8-44fb-9afe-a2ee0791da78";
                case ProductType.VideoGames:
                    return "db541156-1955-4ad9-a45d-679742692c78";
                case ProductType.WatchesAndClocks:
                    return "aa9810a1-cf06-450f-a39f-f3a27100b2aa";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override string filterEnumToName(ProductType type)
        {
            switch (type)
            {
                case ProductType.Books:
                    return "Books";
                case ProductType.BrickAccessories:
                    return "Brick accessories";
                case ProductType.Classic:
                    return "Classic";
                case ProductType.ClothingANDAccessories:
                    return "Clothing & Accessories";
                case ProductType.ForTheHome:
                    return "For the Home";
                case ProductType.IndividualBricks:
                    return "Individual Bricks";
                case ProductType.KeyChains:
                    return "Key Chains";
                case ProductType.Minifigures:
                    return "Minifigures";
                case ProductType.Polybag:
                    return "Polybag";
                case ProductType.PowerFunctions:
                    return "Power Functions";
                case ProductType.RolePlayAndCostumes:
                    return "Role Play & Costumes";
                case ProductType.Sets:
                    return "Sets";
                case ProductType.Stationery:
                    return "Stationery";
                case ProductType.VideoGames:
                    return "Video Games";
                case ProductType.WatchesAndClocks:
                    return "Watches & Clocks";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    public enum ProductType
    {
        Books,
        BrickAccessories,
        Classic,
        ClothingANDAccessories,
        ForTheHome,
        IndividualBricks,
        KeyChains,
        Minifigures,
        Polybag,
        PowerFunctions,
        RolePlayAndCostumes,
        Sets,
        Stationery,
        VideoGames,
        WatchesAndClocks
    }
}
