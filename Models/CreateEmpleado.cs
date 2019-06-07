
using System.ComponentModel.DataAnnotations;


namespace TEST.Models
{
    public class CreateEmpleado
    {
        [Required, Key]
        public string tced { get; set; }

        public int trol { get; set; }

        public string tnomb { get; set; }

        public string tape { get; set; }

        public string tuser { get; set; }

        public string tpass { get; set; }


    }
}