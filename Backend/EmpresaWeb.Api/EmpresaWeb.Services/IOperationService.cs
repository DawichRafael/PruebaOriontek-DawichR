using EmpresaWeb.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaWeb.Services
{
    public interface IOperationService
    {
        #region SELECT
        Task<IEnumerable<Cliente>> SeleccionarCliente(int? id);
        Task<IEnumerable<Direccion>> SeleccionarDireccion(int? id);
        #endregion

        #region INSERT UPDATE
        Task<Cliente> InsertarActualizarCliente(Cliente fields);
        Task<Direccion> InsertarActualizarDireccion(Direccion filter);
        #endregion

        #region DELETE
        Task<object> EliminarDireccion(int idDireccion);
        Task<object> EliminarCliente(int idCliente);
        #endregion

    }
}
