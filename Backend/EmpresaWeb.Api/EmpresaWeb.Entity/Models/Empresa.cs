using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpresaWeb.Entity.Models
{
    [Table("EMPRESAS")]
    public class Empresa
    {
        [Key]
        public int IdEmpresas { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string Telefono { get; set; }
        public string CodigoPostal { get; set; }
        public string Estado { get; set; }
    }
}
