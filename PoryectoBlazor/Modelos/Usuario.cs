﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Usuario
    {
        [Required(ErrorMessage = "El Campo Codigo es Obligatorio")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "El Campo Nombre es Obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El Campo Rol es Obligatorio")]
        public string Rol { get; set; }
        public string Clave { get; set; }
        public bool EstaActivo { get; set; }
    }
}
