using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _02_Layout.Areas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuccessController : ControllerBase
    {
        [HttpGet("{id}")]
        public string Get(int id)
        { 
            return "Thêm thành công"; 
        }

    }
}
