using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EmpresaWeb.Entity.Models
{
    [Table("DIRECCION")]
    public class Direccion
    {
        [Key]
        public int? IdDireccion { get; set; }
        
        [Column("Direccion_Principal")]
        public string DireccionPrincipal { get; set; }
        
        [Column("Direccion_Secundaria")]
        public string DireccionSecundaria { get; set; }
        public string Ciudad { get; set; }
        public string Provincia { get; set; }
        public string Numero { get; set; }
        public string CodigoPostal { get; set; }
        public int IdCliente { get; set; }

    }
} 