using EmpresaWeb.Services.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaWeb.Services
{
    public interface IOperationService
    {
     Task<Empresa> seleccionarClientes(ClientesFilters filter);
    }
}
