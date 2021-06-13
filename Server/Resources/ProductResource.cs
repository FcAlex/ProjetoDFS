
namespace Server.Resources
{
    public class ProductResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Value { get; set; }
        public string Observation { get; set; }
        public int CompanyId { get; set; }

        public string imageURL { get; set; }
    }
}
