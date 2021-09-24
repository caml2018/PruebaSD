using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class User
    {
        [Key]
        [StringLength(18,ErrorMessage ="Longitud Desbordada")]
        public int usuID { get; set; }
        [StringLength(100, ErrorMessage = "Error de longitud del nombre")]
        public string nombre { get; set; }
        [StringLength(100, ErrorMessage = "Error de longitud del apellido")]
        public string apellido { get; set; }

    }
}
