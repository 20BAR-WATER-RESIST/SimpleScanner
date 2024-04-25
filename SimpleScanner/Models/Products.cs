using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SimpleScanner.Models
{
    public class Products
    {
        [JsonPropertyName("products_Id")]
        public int ProductsId { get; set; }
        [JsonPropertyName("products_Category")]
        public string? ProductsCategory { get; set; }
        [JsonPropertyName("products_Name")]
        public string? ProductsName { get; set; }
        [JsonPropertyName("products_ExpirationDate")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public string? ProductsExpirationDate { get; set; }
        [JsonPropertyName("products_Barcode")]
        public string? ProductsBarcode { get; set; }
        [JsonPropertyName("products_Picture")]
        public string? ProductsPicture { get; set; }
    }
}
