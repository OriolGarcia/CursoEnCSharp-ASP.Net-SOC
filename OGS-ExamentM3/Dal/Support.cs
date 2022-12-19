using System;
using System.Collections.Generic;

#nullable disable

namespace OGS_ExamentM3.Dal
{
    public partial class Support
    {
        public int SupportId { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Tema { get; set; }
        public string Mensaje { get; set; }
        public DateTime Fecha { get; set; }
    }
}
