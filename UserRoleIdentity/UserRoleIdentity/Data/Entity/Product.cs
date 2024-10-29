namespace UserRoleIdentity.Data.Entity
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
