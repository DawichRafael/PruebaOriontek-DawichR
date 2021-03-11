using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EmpresaWeb.Entity.Models
{
    [Table("CLIENTE")]
    public class Cliente
    {
      [Key]
      public int? IdCliente { get; set; }
      public string Nombre { get; set; }
      public string Apellido { get; set; }
      public string Cedula { get; set; }
      public string Telefono { get; set; }
      public string Nacionalidad { get; set; }
      public string EstadoCivil { get; set; }
      public int IdEmpresa { get; set; } 
    }
}
