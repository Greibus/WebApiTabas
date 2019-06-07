using System.ComponentModel.DataAnnotations;

namespace TEST.Models
{
    public class CreatePasajero
    {
        [Required, Key]
        public string tpasaporte { get; set; }

        public string tcarne { get; set; }

        public string tnomb { get; set; }

        public string ttelfono { get; set; }

        public string tcorreo { get; set; }

        public string tntarjeta { get; set; }

        public string tpass { get; set; }


    }
}