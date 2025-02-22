namespace Requests
{
    public class ProductFilterRequest
    {
        public string? Name { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Миниимальная цена должна быть положительным.")]
        public decimal? MinPrice{ get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Максимальная цена должна быть положительным.")]
        public decimal? MaxPrice{ get; set; }
        public Guid ProductCategory { get; set; }
    }
}