using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using CleanArchMvc.Domain.Validations;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category : Base
    {
        #region Properties
        public string Name { get; private set; }
        public ICollection<Product> Products { get; set; }
        #endregion

        #region Ctors
        public Category(string name)
        {
            ValidateDomain(name);
        }
        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id Value.");
            Id = id;
            ValidateDomain(name);
        }
        #endregion

        #region Methods
        private void Update(string name)
        {
            ValidateDomain(name);
        }
        #endregion
        
        #region Validations
        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name, Name is required");
            DomainExceptionValidation.When(name is {Length: < 3}, "Invalid name, too short, minimum 3 characters");
            Name = name;
        }
        #endregion
    }
}