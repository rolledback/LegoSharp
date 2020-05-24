using System;
using System.Collections.Generic;
using System.Text;

namespace LegoSharp
{
    public class ProductCategoryFilter : ProductSearchFilter<ProductCategory>
    {
        public ProductCategoryFilter() : base("categories.id")
        {
        }

        public override string filterEnumToValue(ProductCategory category)
        {
            switch (category)
            {
                case ProductCategory.Sets:
                    return "12ba8640-7fb5-4281-991d-ac55c65d8001";
                case ProductCategory.ForTheHome:
                    return "b32cddff-52e5-4f22-a212-1dfb3fd31fbb";
                case ProductCategory.KeyChains:
                    return "0b05a003-1702-40e9-8f65-185dcfc640ed";
                case ProductCategory.ClothingANDAccessories:
                    return "de583581-4dd0-4f6b-981b-8b31b9a0fb48";
                case ProductCategory.IndividualBricks:
                    return "b4c8be0b-436f-445a-8b3e-a96cbd531920";
                case ProductCategory.Minifigures:
                    return "a46f1ffd-db4d-4813-89d1-5d19f8737ef5";
                case ProductCategory.PowerFunctions:
                    return "a6013c1e-72dd-4e0b-a506-c13c0a0dc44b";
                case ProductCategory.BrickAccessories:
                    return "59d5df5c-543e-4b5b-9299-d41b7b480afa";
                case ProductCategory.Classic:
                    return "975369b1-17a2-42e6-a39f-0386b85def5b";
                case ProductCategory.Stationery:
                    return "275e987f-0cc8-44fb-9afe-a2ee0791da78";
                case ProductCategory.Books:
                    return "d20ecc4f-1dd8-4f1d-8158-fe2c59bdbbbe";
                case ProductCategory.WatchesAndClocks:
                    return "aa9810a1-cf06-450f-a39f-f3a27100b2aa";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override string filterEnumToName(ProductCategory category)
        {
            switch (category)
            {
                case ProductCategory.Sets:
                    return "Sets";
                case ProductCategory.ForTheHome:
                    return "For the Home";
                case ProductCategory.KeyChains:
                    return "Key Chains";
                case ProductCategory.ClothingANDAccessories:
                    return "Clothing & Accessories";
                case ProductCategory.IndividualBricks:
                    return "Individual Bricks";
                case ProductCategory.Minifigures:
                    return "Minifigures";
                case ProductCategory.PowerFunctions:
                    return "Power Functions";
                case ProductCategory.BrickAccessories:
                    return "Brick accessories";
                case ProductCategory.Classic:
                    return "Classic";
                case ProductCategory.Stationery:
                    return "Stationery";
                case ProductCategory.Books:
                    return "Books";
                case ProductCategory.WatchesAndClocks:
                    return "Watches & Clocks";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    public enum ProductCategory
    {
        Sets,
        ForTheHome,
        KeyChains,
        ClothingANDAccessories,
        IndividualBricks,
        Minifigures,
        PowerFunctions,
        BrickAccessories,
        Classic,
        Stationery,
        Books,
        WatchesAndClocks
    }
}
