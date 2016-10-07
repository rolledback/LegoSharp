using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace LegoSharp
{
    public class Brick
    {
        public double price { get; }
        public string name { get; }
        public string elementId { get; }
        public string designId { get; }
        public bool isAvailable { get; }
        public int inventoryQuantity { get; }

        private Brick() { }

        internal Brick(JsonBrick jsonBrick)
        {
            price = jsonBrick.price;
            name = jsonBrick.name;
            elementId = jsonBrick.elementId;
            designId = jsonBrick.designId;
            isAvailable = jsonBrick.availabilityStatus == "E_AVAILABLE";
            inventoryQuantity = jsonBrick.inventoryQuantity;
        }
    }

    internal class JsonBrickList
    {
        [JsonProperty("elements")]
        public List<JsonBrick> elements { get; set; }

        public JsonBrickList()
        {
            elements = new List<JsonBrick>();
        }
    }

    internal class JsonBrick
    {
        [JsonProperty("price")]
        public double price { get; set; }
        [JsonProperty("price_formatted")]
        public string priceFormatted { get; set; }
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("element_id")]
        public string elementId { get; set; }
        [JsonProperty("color_family")]
        public string colorFamily { get; set; }
        [JsonProperty("exact_color")]
        public string exactColor { get; set; }
        [JsonProperty("category")]
        public string category { get; set; }
        [JsonProperty("design_id")]
        public string designId { get; set; }
        [JsonProperty("availability_status")]
        public string availabilityStatus { get; set; }
        [JsonProperty("restricted_status")]
        public string restrictedStatus { get; set; }
        [JsonProperty("inventory_quantity")]
        public int inventoryQuantity { get; set; }
    }
}
