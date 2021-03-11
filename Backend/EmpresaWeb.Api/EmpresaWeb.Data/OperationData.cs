using EmpresaWeb.Data.Database;
using EmpresaWeb.Services;
using EmpresaWeb.Services.Filters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaWeb.Data
{
    public class OperationData : IOperationData
    {
        private readonly ConnectionDBClass _databaseConnection;
        public OperationData(ConnectionDBClass databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }

        public async Task<Empresa> seleccionarClientes(ClientesFilters filter)
        {
            var empresa = await _databaseConnection.EMPRESAS.Where(x => x.IdEmpresas == filter.idCliente).FirstOrDefaultAsync();

            return empresa;
        }
    }
}
