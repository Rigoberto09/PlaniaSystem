﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPlania.Shared
{
    public class VentaDTO
    {
        public int IdVenta { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? TipoPago { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public decimal? Total { get; set; }
        public string? Isv { get; set; }
        public string? SubTotal { get; set; }
        public string? Correo { get; set; }
        public string? TotalTexto {

            get { 
                decimal? sum = 0;
                if (DetalleVenta.Count > 0)
                    sum = DetalleVenta.Sum(p => p.Total);

                return sum.ToString();
            }
        }
        public virtual List<DetalleVentaDTO>? DetalleVenta { get; set; }
    }
}
