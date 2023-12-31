﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Articulo
    {
        public int id { get; set; }
        public string codArticulo { get; set; }
        public string nombre { get; set; }  
        public string descripcion { get; set; }
        public Marcar marca { get; set; }
        public Categoria categoria { get; set; }
        public decimal precio { get; set; }  
    }
}
