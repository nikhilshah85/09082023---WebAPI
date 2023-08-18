using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace di_demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {

        // Accounts accObj = new Accounts(); //this is bad, please use DI instead


        Accounts _accObj; //not createing the object


        public AccountsController(Accounts accObjREF)
        {
            _accObj = accObjREF;
        }

        [HttpGet]
        [Route("/accounts/list")]
        public IActionResult AccountsList()
        {
            var data = _accObj.GetAllAccounts();
            return Ok(data);
        }
    }
}
