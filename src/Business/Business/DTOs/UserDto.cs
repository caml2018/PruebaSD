using System;
using System.ComponentModel.DataAnnotations;

namespace Business.DTOs
{
    public class UserDto
    {
        public int usuID { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
    }
}
