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
        public async Task<ActionResult> GetAll()
        {
            return Ok(await this.UserAccountRepository.GetAllByCriteria(x => x.CPF == "123456789" 
                                                                    && x.Name.Contains("Ra")
                                                                    || x.Id != null));
        }


    }
}
