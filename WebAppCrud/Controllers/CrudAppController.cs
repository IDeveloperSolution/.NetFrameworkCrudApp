using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppCrud.CommonLayer.Model;
using WebAppCrud.ServiceLayer;

namespace WebAppCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudAppController : ControllerBase
    {
        public readonly ICrudAppSL _cRudAppSL;
            public CrudAppController(ICrudAppSL cRudAppSL) {
            _cRudAppSL = cRudAppSL;
        }



        [HttpPost]
        public async Task<IActionResult> AddInformation(AddInformationRequest request)
        {
            AddInformationResponse response= new AddInformationResponse();
            try
            {
                response=await _cRudAppSL.AddInformation(request);
            }catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }
    }
}
