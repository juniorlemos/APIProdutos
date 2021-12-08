using Microsoft.AspNetCore.Mvc;
using Modelo.Application.DTOs.ModelView;
using System.Diagnostics;

namespace APIProduto.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("error")]
        public ErrorResponse Error()
        {
            Response.StatusCode = 500;
            var id = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
            return new ErrorResponse(id);
        }
    }
}
