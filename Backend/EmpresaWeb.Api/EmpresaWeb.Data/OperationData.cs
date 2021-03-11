using EmpresaWeb.Data.Database;
using EmpresaWeb.Entity.Filters;
using EmpresaWeb.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        #region SELECT
        public async Task<IEnumerable<Cliente>> seleccionarClientes(int? id)
        {
            IEnumerable<Cliente> clientes = new List<Cliente>();
            try
            {
                if (id == null)
                {
                    clientes = await _databaseConnection.CLIENTES.ToListAsync();

                }
                else
                {
                    clientes = await _databaseConnection.CLIENTES.Where(x => x.IdCliente == id).ToListAsync();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return clientes;
        }

        public async Task<IEnumerable<Direccion>> SeleccionarDireccion(int? id)
        {

            IEnumerable<Direccion> direcciones = new List<Direccion>();

            try
            {
                if (id == null)
                {
                    direcciones = await _databaseConnection.DIRECCION.ToListAsync();

                }
                else
                {
                    direcciones = await _databaseConnection.DIRECCION.Where(x => x.IdCliente == id).ToListAsync();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return direcciones;

        }
        #endregion

        #region INSERT_UPDATE
        public async Task<Cliente> InsertarActualizarCliente(Cliente fields)
        {
            try
            {

                if (fields.IdCliente == null)
                {
                    await _databaseConnection.CLIENTES.AddAsync(fields);
                    _databaseConnection.SaveChanges();
                }
                else
                {
                    _databaseConnection.CLIENTES.Update(fields);
                    await _databaseConnection.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.InnerException.Message);
            }

            return fields;

        }

        public async Task<Direccion> InsertarActualizarDireccion(Direccion fields)
        {
            try
            {
                if (fields.IdDireccion == null)
                {
                    await _databaseConnection.DIRECCION.AddAsync(fields);
                    _databaseConnection.SaveChanges();
                }
                else
                {
                    _databaseConnection.DIRECCION.Update(fields);
                    await _databaseConnection.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }

            return fields;
        }


        #endregion


        #region DELETE
        public async Task<object> EliminarCliente(int idCliente)
        {
            AuxDelete objetoEliminado = new AuxDelete();
            try
            {

                var registro = _databaseConnection.CLIENTES.Where(x => x.IdCliente == idCliente).FirstOrDefault();
                _databaseConnection.CLIENTES.Remove(registro);
                await _databaseConnection.SaveChangesAsync();

                objetoEliminado.Codigo = idCliente;
                objetoEliminado.Mensaje = "Su Direccion ha sido eliminada";

            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }

            return objetoEliminado;
        }

        public async Task<object> EliminarDireccion(int idDireccion)
        {
            AuxDelete objetoEliminado = new AuxDelete();
            try
            {

                var registro = _databaseConnection.DIRECCION.Where(x => x.IdDireccion == idDireccion).FirstOrDefault();
                _databaseConnection.DIRECCION.Remove(registro);
                await _databaseConnection.SaveChangesAsync();

                objetoEliminado.Codigo = idDireccion;
                objetoEliminado.Mensaje = "Su Direccion ha sido eliminada";

            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }

            return objetoEliminado;
        }
        #endregion
    }
}
