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
    }

    public class ProductType : ValuesFilterValue
    {
        public ProductType(string value, string name) : base(value, name)
        {
        }

        public static readonly ProductType Books = new ProductType("d20ecc4f-1dd8-4f1d-8158-fe2c59bdbbbe", "Books");
        public static readonly ProductType BrickAccessories = new ProductType("59d5df5c-543e-4b5b-9299-d41b7b480afa", "Brick accessories");
        public static readonly ProductType Classic = new ProductType("975369b1-17a2-42e6-a39f-0386b85def5b", "Classic");
        public static readonly ProductType ClothingANDAccessories = new ProductType("de583581-4dd0-4f6b-981b-8b31b9a0fb48", "Clothing & Accessories");
        public static readonly ProductType ForTheHome = new ProductType("b32cddff-52e5-4f22-a212-1dfb3fd31fbb", "For the Home");
        public static readonly ProductType IndividualBricks = new ProductType("b4c8be0b-436f-445a-8b3e-a96cbd531920", "Individual Bricks");
        public static readonly ProductType KeyChains = new ProductType("0b05a003-1702-40e9-8f65-185dcfc640ed", "Key Chains");
        public static readonly ProductType Minifigures = new ProductType("a46f1ffd-db4d-4813-89d1-5d19f8737ef5", "Minifigures");
        public static readonly ProductType Polybag = new ProductType("c9f9b650-5988-4828-acd8-194a83668100", "Polybag");
        public static readonly ProductType PowerFunctions = new ProductType("a6013c1e-72dd-4e0b-a506-c13c0a0dc44b", "Power Functions");
        public static readonly ProductType RolePlayAndCostumes = new ProductType("5dc73b3a-0138-4e0b-afd2-01a6b30fb94e", "Role Play & Costumes");
        public static readonly ProductType Sets = new ProductType("12ba8640-7fb5-4281-991d-ac55c65d8001", "Sets");
        public static readonly ProductType Stationery = new ProductType("275e987f-0cc8-44fb-9afe-a2ee0791da78", "Stationery");
        public static readonly ProductType VideoGames = new ProductType("db541156-1955-4ad9-a45d-679742692c78", "Video Games");
        public static readonly ProductType WatchesAndClocks = new ProductType("aa9810a1-cf06-450f-a39f-f3a27100b2aa", "Watches & Clocks");
    }
}
