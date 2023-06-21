using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PS.Calc.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalcController : ControllerBase
    {
        [HttpGet]
        [Route("addmany")]
        public async Task<IActionResult> Add([FromQuery]params int[] arr)
        {
            int c = 0;
            foreach(int i in arr)
            {
                c += i;
            }
            var res = await Task.FromResult(c);
            return Ok(res);
        }
        [HttpGet]
        [Route("add")]
        public async Task<IActionResult> Add(int a, int b)
        {
            var res = await Task.FromResult(a+b);
            return Ok(res);
        }
        [HttpGet]
        [Route("subtraction")]
        public async Task<IActionResult> Subtraction(int a, int b)
        {
            var res = await Task.FromResult(a - b);
            return Ok(res);
        }
    }
}
