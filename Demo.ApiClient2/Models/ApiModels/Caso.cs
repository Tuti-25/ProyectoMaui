using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.ApiClient2.Models.ApiModels
{
    public class Caso
    {
            public int IdCaso { get; set; }
            public string DescripcionCaso { get; set; }
            public int IdUsuario { get; set; }
            public int IdAgente { get; set; }
            public int IdSeveridad { get; set; }
            public int IdEstado { get; set; }
            public DateTime FechaCreacion { get; set; }
            public DateTime? FechaFinalizacion { get; set; }
            public DateTime? FechaActualizacion { get; set; }

            public Usuario? Usuario { get; set; }
            public Severidad? Severidad { get; set; }
            public EstadoCaso? EstadoCaso { get; set; }
        }
    }

