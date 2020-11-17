using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace demo.Domain
{
    public class SelfValidatableForm : IValidatableObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        [DataType(DataType.Currency)]
        public decimal Balance { get; set; }
        
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.Id > 100)
            {
                yield return new ValidationResult(errorMessage: "ID jest większe od 100", new []{"Id"});
            }

            if (!string.IsNullOrWhiteSpace(this.Name) && this.Name == "Jan")
            {
                yield return new ValidationResult("Coś nie gra z imieniem", new []{"Name"});
            }

            if (this.Balance <= 0)
            {
                yield return new ValidationResult("Stan konta mniejszy od 0", new []{"Balance"});
            }
        }
    }
}