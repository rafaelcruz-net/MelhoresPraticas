using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MelhoresPraticas.ApplicationServices.Account;
using MelhoresPraticas.Domain;
using MelhoresPraticas.Domain.Account.Aggregate;
using MelhoresPraticas.Domain.Account.Aggregate.Repository;
using MelhoresPraticas.Domain.Account.Aggregate.Specification;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MelhoresPraticas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private IUserAccountRepository UserAccountRepository { get; set; }
        private IAccountService AccountService { get; set; }

        public UserAccountController(IUserAccountRepository userAccountRepository, IAccountService accountService)
        {
            this.UserAccountRepository = userAccountRepository;
            this.AccountService = accountService;
        }

        [Route("")]
        public async Task<ActionResult> GetAll()
        {

            var x = new int[] { 1, 2, 3, 4, 5, 5, 6 };

            return Ok(await this.UserAccountRepository.GetAll());
        }

        [Route("{cpf}")]
        public async Task<ActionResult> GetAll(string cpf)
        {
            return Ok(await this.UserAccountRepository.GetAllByCriteria(UserAccountSpecification.GetByCPF(cpf)));
        }


        [Route("")]
        [HttpPost]
        public async Task<ActionResult> Post(UserAccount userAccount)
        {

            await this.AccountService.CreateAccount(userAccount);
            return Created("", null);
        }



    }
}
