using EmpresaWeb.Data;
using EmpresaWeb.Entity.Models;
using System.Collections.Generic;
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


        #region SELECT
        public async Task<IEnumerable<Cliente>> SeleccionarCliente(int? id)
        {
            return await _operationData.seleccionarClientes(id);
        }
        public async Task<IEnumerable<Direccion>> SeleccionarDireccion(int? id)
        {
            return await _operationData.SeleccionarDireccion(id);
        }
        #endregion

        #region INSERT UPDATE
        public async Task<Cliente> InsertarActualizarCliente(Cliente fields)
        {
            return await _operationData.InsertarActualizarCliente(fields);
        }

        public async Task<Direccion> InsertarActualizarDireccion(Direccion fields)
        {
            return await _operationData.InsertarActualizarDireccion(fields);
        }
        #endregion

        #region DELETE
        public async Task<object> EliminarCliente(int idCliente)
        {
            return await _operationData.EliminarCliente(idCliente);
        }

        public async Task<object> EliminarDireccion(int idDireccion)
        {
            return await _operationData.EliminarDireccion(idDireccion);
        }
        #endregion


    
    }
}
