using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CasusOrangeWise.Models
{
    public class ShoppingSunday
    {
        public int Id { get; set; }
        [Required]
        public DateTime BeginTime  { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        [Required]
        public virtual Branch Branch { get; set; }

    }
}
