using CashFlowMateus.Application.UseCases.Users.Register;
using CashFlowMateus.Communication.Requests;
using CashFlowMateus.Communication.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CashFlowMateus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpPost]
        [ProducesResponseType(typeof(ReponseRegisterUserJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register(
            [FromBody] RequestRegisterUserJson request, 
            [FromServices] IRegisterUserUseCase useCase)
        {
            var response = await useCase.Execute(request);

            return Created(string.Empty, response);
        }

    }
}
