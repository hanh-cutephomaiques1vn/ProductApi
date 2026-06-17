using System.ComponentModel.DataAnnotations;

namespace ProductApi.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm là bắt buộc")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Tên sản phẩm phải từ 2 đến 100 ký tự")]
        public string Name { get; set; } = "";

        [Required(ErrorMessage = "Giá sản phẩm là bắt buộc")]
        [Range(0, 1000000000, ErrorMessage = "Giá sản phẩm phải từ 0 đến 1,000,000,000 VND")]
        public decimal Price { get; set; }
    }
}
