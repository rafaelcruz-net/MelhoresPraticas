using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MelhoresPraticas.Domain.Account.Aggregate.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MelhoresPraticas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private IUserAccountRepository UserAccountRepository { get; set; }

        public UserAccountController(IUserAccountRepository userAccountRepository)
        {
            this.UserAccountRepository = userAccountRepository;
        }

        [Route("")]
        public ActionResult GetAll()
        {
            return Ok(this.UserAccountRepository.GetAll());
        }


    }
}
