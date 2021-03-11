using System;
using System.Threading.Tasks;
using EmpresaWeb.Entity.Models;
using EmpresaWeb.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EmpresaWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        private readonly ILogger<OperationController> _logger;

        private readonly IOperationService _operationService;
        public OperationController(ILogger<OperationController> logger, IOperationService operationService)
        {
            _logger = logger;
            _operationService = operationService;
        }


        [HttpGet]
        [Route("SeleccionarCliente")]
        public async Task<IActionResult> SeleccionarCliente(int? Id)
        {
            try
            {
                return Ok(await _operationService.SeleccionarCliente(Id));
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "");

                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        [HttpGet]
        [Route("SeleccionarDireccion")]
        public async Task<IActionResult> SeleccionarDireccion(int? Id)
        {
            try
            {
                return Ok(await _operationService.SeleccionarDireccion(Id));
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "");

                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }


        [HttpPost]
        [Route("InsertarActualizarCliente")]
        public async Task<IActionResult> InsertarActualizarCliente(Cliente fields)
        {
            try
            {
                return Ok(await _operationService.InsertarActualizarCliente(fields));
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "");

                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        [HttpPost]
        [Route("InsertarActualizarDireccion")]
        public async Task<IActionResult> InsertarActualizarDireccion(Direccion fields)
        {
            try
            {
                return Ok(await _operationService.InsertarActualizarDireccion(fields));
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "");

                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        [HttpPost]
        [Route("EliminarCliente")]
        public async Task<IActionResult> EliminarCliente(int idCliente)
        {
            try
            {
                return Ok(await _operationService.EliminarCliente(idCliente));
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "");

                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        [HttpPost]
        [Route("EliminarDireccion")]
        public async Task<IActionResult> EliminarDireccion(int idDireccion)
        {
            try
            {
                return Ok(await _operationService.EliminarDireccion(idDireccion));
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "");

                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }
    }
}
