using EmpresaWeb.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmpresaWeb.Data.Database
{
    public class ConnectionDBClass : DbContext
    {

        public ConnectionDBClass(DbContextOptions<ConnectionDBClass> options) : base(options)
        {
        }

        public DbSet<Empresa> EMPRESAS { get; set; }
        public DbSet<Cliente> CLIENTES { get; set; }
        public DbSet<Direccion> DIRECCION { get; set; }
    }
}
