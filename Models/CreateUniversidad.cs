using System.ComponentModel.DataAnnotations;

namespace TEST.Models
{
    public class CreateUniversidad
    {

        [Required, Key]
        public int tnumero { get; set; }

        public string tnombre { get; set; }
    }
}