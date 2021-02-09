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

        public static readonly ProductType Accessories = new ProductType("de583581-4dd0-4f6b-981b-8b31b9a0fb48", "Accessories");
        public static readonly ProductType Accessories2021 = new ProductType("dd68422b-55a5-435d-9cf0-0f8d92e0438f", "Accessories");
        public static readonly ProductType AllOccasions = new ProductType("46b31f0e-4ecc-468e-a798-c763a617de1f", "All Occasions");
        public static readonly ProductType BackpacksAndLunchBoxes = new ProductType("0583fca4-8422-489d-a46d-c4bdcb294fd3", "Backpacks & Lunch Boxes");
        public static readonly ProductType Birthday = new ProductType("50cc97a5-c9c8-4e2e-90b6-df8e4ec8e359", "Birthday");
        public static readonly ProductType Books = new ProductType("d20ecc4f-1dd8-4f1d-8158-fe2c59bdbbbe", "Books");
        public static readonly ProductType Bottoms = new ProductType("839a7260-9a8a-43fb-a867-ac96ec23b007", "Bottoms");
        public static readonly ProductType BrickAccessories = new ProductType("59d5df5c-543e-4b5b-9299-d41b7b480afa", "Brick accessories");
        public static readonly ProductType ChineseNewYear = new ProductType("6c7eae27-1b84-46dc-93b0-a8718f099a30", "Chinese New Year");
        public static readonly ProductType Classic = new ProductType("975369b1-17a2-42e6-a39f-0386b85def5b", "Classic");
        public static readonly ProductType Clothing = new ProductType("8b96cb22-1131-4d2a-a3ad-7e2d7f51f800", "Clothing");
        public static readonly ProductType ClothingANDAccessories = new ProductType("de583581-4dd0-4f6b-981b-8b31b9a0fb48", "Clothing & Accessories");
        public static readonly ProductType ForTheHome = new ProductType("b32cddff-52e5-4f22-a212-1dfb3fd31fbb", "For the Home");
        public static readonly ProductType Holiday = new ProductType("5c4baed9-c35d-4495-b988-6a9585a36854", "Holiday");
        public static readonly ProductType HomeDecor = new ProductType("b32cddff-52e5-4f22-a212-1dfb3fd31fbb", "Home decor");
        public static readonly ProductType IndividualBricks = new ProductType("b4c8be0b-436f-445a-8b3e-a96cbd531920", "Individual Bricks");
        public static readonly ProductType KeyChains = new ProductType("0b05a003-1702-40e9-8f65-185dcfc640ed", "Key Chains");
        public static readonly ProductType Magnets = new ProductType("5b114ca9-6e0f-4a92-96b0-bd103c06b47b", "Magnets");
        public static readonly ProductType Minifigures = new ProductType("a46f1ffd-db4d-4813-89d1-5d19f8737ef5", "Minifigures");
        public static readonly ProductType Mugs = new ProductType("de52c0e8-5ae5-4ae6-a32c-7749360e1fba", "Mugs");
        public static readonly ProductType Ornaments = new ProductType("40ddce98-5599-40bf-a674-23388ae4632c", "Ornaments");
        public static readonly ProductType Pets = new ProductType("0a223b30-5191-4939-821a-3f5c33e68cbc", "Pets");
        public static readonly ProductType Polybag = new ProductType("c9f9b650-5988-4828-acd8-194a83668100", "Polybag");
        public static readonly ProductType PowerFunctions = new ProductType("a6013c1e-72dd-4e0b-a506-c13c0a0dc44b", "Power Functions");
        public static readonly ProductType RolePlayAndCostumes = new ProductType("5dc73b3a-0138-4e0b-afd2-01a6b30fb94e", "Role Play & Costumes");
        public static readonly ProductType Sets = new ProductType("12ba8640-7fb5-4281-991d-ac55c65d8001", "Sets");
        public static readonly ProductType Sneakers = new ProductType("698ef177-5804-4186-9b36-5b78cc89eecd", "Sneakers");
        public static readonly ProductType Stationery = new ProductType("275e987f-0cc8-44fb-9afe-a2ee0791da78", "Stationery");
        public static readonly ProductType Sweatshirts = new ProductType("dcf8f875-2414-40cb-b7c4-c532797e34fc", "Sweatshirts");
        public static readonly ProductType TShirts = new ProductType("c55e4054-c667-4a86-80a7-b1fc56726132", "T-Shirts");
        public static readonly ProductType ValentinesDay = new ProductType("a6738084-d303-48b4-994b-57d02b7e22c8", "Valentine's Day");
        public static readonly ProductType VideoGames = new ProductType("db541156-1955-4ad9-a45d-679742692c78", "Video Games");
        public static readonly ProductType WatchesAndClocks = new ProductType("aa9810a1-cf06-450f-a39f-f3a27100b2aa", "Watches & Clocks");
        public static readonly ProductType Wedding = new ProductType("dd2c1d83-bd9b-4cc8-b7a9-02cbc8520531", "Wedding");
    }
}
