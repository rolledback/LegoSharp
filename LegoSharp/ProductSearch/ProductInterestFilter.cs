using System;
using System.Collections.Generic;
using System.Text;

namespace LegoSharp
{
    public class ProductInterestFilter : ProductSearchValuesFilter<ProductInterest>
    {
        public ProductInterestFilter() : base("categories.id", "product.facet.ProductInterest")
        {
        }
    }

        public class ProductInterest : ValuesFilterValue
    {
        public ProductInterest(string value, string name) : base(value, name)
        {
        }

        public static readonly ProductInterest Animals = new ProductInterest("50b7a1a1-0159-400c-ba83-429a99f91a0f", "Animals");
        public static readonly ProductInterest ArtsAndcrafts = new ProductInterest("63a3bc8f-1eab-418e-a5b2-b27ddd540847", "Arts and crafts");
        public static readonly ProductInterest Boats = new ProductInterest("321004b6-14fc-46e3-bb14-e6f98600acae", "Boats");
        public static readonly ProductInterest Buildings = new ProductInterest("eba35bb6-dbeb-4b0f-a04e-d3b2cee542ce", "Buildings");
        public static readonly ProductInterest Cars = new ProductInterest("1f44e678-85a6-4854-8a1e-528c89f824d0", "Cars");
        public static readonly ProductInterest Dragons = new ProductInterest("6952574c-fc66-4dbf-ac0c-d79c33d63bbd", "Dragons");
        public static readonly ProductInterest Fantasy = new ProductInterest("8aaf47f5-1a76-4839-a476-70f64330631e", "Fantasy");
        public static readonly ProductInterest Gaming = new ProductInterest("6b5dfcc6-1ed8-4ca1-9005-9218150ba055", "Gaming");
        public static readonly ProductInterest Ninjas = new ProductInterest("e6719986-4878-4977-b9fe-848c4dc26d54", "Ninjas");
        public static readonly ProductInterest Police = new ProductInterest("57c6ca5e-857a-4fa4-97b8-44cbd2452ce0", "Police");
        public static readonly ProductInterest Preschool = new ProductInterest("6f426049-6f26-42f0-a498-6676445335fa", "Preschool");
        public static readonly ProductInterest Princesses = new ProductInterest("ef505c47-ae25-4097-b1b5-20db7aa4f9b9", "Princesses");
        public static readonly ProductInterest RealLifeHeroes = new ProductInterest("926b7d0e-0cba-4bcc-8531-be6b3119349c", "Real Life Heroes");
        public static readonly ProductInterest Seasonal = new ProductInterest("783e4181-78bb-4564-88bf-72afe7ce8ac2", "Seasonal");
        public static readonly ProductInterest Space = new ProductInterest("14addeb5-c1c9-47c6-8524-3cc7e52d303e", "Space");
        public static readonly ProductInterest Trains = new ProductInterest("83573af6-f5a6-44be-96c2-6167ed7b6505", "Trains");
        public static readonly ProductInterest Trucks = new ProductInterest("594c8549-705c-40ac-ba7c-e60d9a1c20a8", "Trucks");
        public static readonly ProductInterest Vehicles = new ProductInterest("82d0c99f-90e6-4f74-83ec-1f516fb7b428", "Vehicles");
        public static readonly ProductInterest VideoGames = new ProductInterest("1318b831-310b-454a-b64e-1e7f8347bfec", "Video Games");
    }
}
