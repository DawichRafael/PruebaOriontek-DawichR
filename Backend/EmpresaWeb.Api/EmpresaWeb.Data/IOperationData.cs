using EmpresaWeb.Services;
using EmpresaWeb.Services.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaWeb.Data
{
    public interface IOperationData
    {
        Task<Empresa> seleccionarClientes(ClientesFilters filter);
    }
}
