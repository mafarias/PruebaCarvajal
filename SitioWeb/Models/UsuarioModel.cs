using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SitioWeb.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Int16 IdTipoDoc { get; set; }
        public string NroDoc { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
