using System.ComponentModel.DataAnnotations;

namespace MvcApplication2.Models
{
    public class CustomLoginViewModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string LastName { get; set; }
    }
}