using System.ComponentModel.DataAnnotations;

namespace TEST.Models
{
    public class CreateRoles
    {

        [Required, Key]
        public int tnumero { get; set; }

        public string trol { get; set; }
    }
}