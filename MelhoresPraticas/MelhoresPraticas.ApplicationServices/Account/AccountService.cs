using MelhoresPraticas.CrossCutting.BusinessException;
using MelhoresPraticas.Domain.Account.Aggregate;
using MelhoresPraticas.Domain.Account.Aggregate.Repository;
using MelhoresPraticas.Domain.Account.Aggregate.Specification;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MelhoresPraticas.ApplicationServices.Account
{
    public class AccountService : IAccountService
    {
        private IUserAccountRepository UserAccountRepository { get; set; }

        public AccountService(IUserAccountRepository userAccountRepository)
        {
            this.UserAccountRepository = userAccountRepository;
        }

        public async Task CreateAccount(UserAccount userAccount)
        {
            BusinessException businessException = new BusinessException(); 

            if (await this.UserAccountRepository.GetOneByCriteria(UserAccountSpecification.GetByCPF(userAccount.CPF)) != null)
            {
                businessException.AddError(new BusinessValidationFailure()
                {
                    ErrorCode = "0001A",
                    ErrorMessage = "Já existe um CPF cadastrado em nossa base"
                });

            }

            if (await this.UserAccountRepository.GetOneByCriteria(UserAccountSpecification.GetByEmail(userAccount.Email)) != null)
            {
                businessException.AddError(new BusinessValidationFailure()
                {
                    ErrorCode = "0001B",
                    ErrorMessage = "Já existe um Email cadastrado em nossa base"
                });

            }

            businessException.ValidateAndThrow();



            using (var transaction = this.UserAccountRepository.CreateTransaction(isolationLevel: System.Data.IsolationLevel.ReadUncommitted))
            {

                try
                {
                    await this.UserAccountRepository.Save(userAccount);
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                }
            }
        }



    }
}
