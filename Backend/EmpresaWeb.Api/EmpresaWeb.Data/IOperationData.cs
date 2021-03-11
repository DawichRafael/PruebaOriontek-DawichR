using EmpresaWeb.Entity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmpresaWeb.Data
{
    public interface IOperationData
    {
        
        Task<IEnumerable<Cliente>> seleccionarClientes(int? id);
        Task<IEnumerable<Direccion>> SeleccionarDireccion(int? id);
        Task<Direccion> InsertarActualizarDireccion(Direccion fields);
        Task<Cliente> InsertarActualizarCliente(Cliente fields);
        Task<object> EliminarCliente(int idCliente);
        Task<object> EliminarDireccion(int idDireccion);
    }
}
