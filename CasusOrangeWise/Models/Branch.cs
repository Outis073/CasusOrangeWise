using System.ComponentModel.DataAnnotations;

namespace CasusOrangeWise.Models
{
    public class Branch
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Adress   { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

    }
}
