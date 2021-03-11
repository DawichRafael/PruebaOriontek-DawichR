using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmpresaWeb.Services;
using EmpresaWeb.Services.Filters;
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

        [HttpPost]
        [Route("seleccionarClientes")]
        public async Task<IActionResult> seleccionarClientes(ClientesFilters filter)
        {
            try
            {
                return Ok(await _operationService.seleccionarClientes(filter));
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "");

                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }
    }
}
