using EmpresaWeb.Data;
using EmpresaWeb.Services.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaWeb.Services
{
    public class OperationService : IOperationService
    {

        private readonly IOperationData _operationData;

        public OperationService(IOperationData operationData)
        {
            _operationData = operationData;
        }

        public async Task<Empresa> seleccionarClientes(ClientesFilters filter)
        {
            return await _operationData.seleccionarClientes(filter);
        }
    }
}
