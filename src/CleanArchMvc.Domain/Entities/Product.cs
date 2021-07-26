using CleanArchMvc.Domain.Validations;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : Base
    {
        #region Properties
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string? Image { get; private set; }
        #endregion

        #region Ctor

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value.");
            Id = id;
            ValidateDomain(name,description,price,stock,image);
        }

        public Product(string name, string description, decimal price, int stock, string image)
        {
           ValidateDomain(name,description,price,stock,image);
        }
        
        #endregion

        #region Methods

        public void Update(string name, string description, decimal price, int stock, string image, int categoryId, Category category)
        {
            ValidateDomain(name,description,price,stock,image);
        }

        #endregion
        
        #region Ef
        public int CategoryId { get;  set; }
        public Category Category { get;  set; }
        #endregion

        #region Validations

        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            // Name
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name, Name is required");
            DomainExceptionValidation.When(name is {Length: < 3}, "Invalid name, too short, minimum 3 characters");
            
            // Description
            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Invalid Description, Description is required");
            DomainExceptionValidation.When(description is {Length: < 5}, "Invalid description, too short, minimal 5 characters ");
            
            // price
            DomainExceptionValidation.When(price < 0, "Invalid price value");
            
            // stock
            DomainExceptionValidation.When(stock < 0, "Invalid stock value");
            
            // Image
            DomainExceptionValidation.When(image?.Length > 250, "Invalid Image name, too long, maximum 250 characters");

            #region assignment
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
            #endregion

        }
        #endregion
    }
}