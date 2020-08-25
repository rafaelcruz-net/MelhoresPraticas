using MelhoresPraticas.ApplicationServices.Account;
using MelhoresPraticas.CrossCutting.BusinessException;
using MelhoresPraticas.Domain;
using MelhoresPraticas.Domain.Account.Aggregate;
using MelhoresPraticas.Domain.Account.Aggregate.Repository;
using MelhoresPraticas.Domain.Account.Aggregate.Specification;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MelhoresPraticas.Tests.ApplicationServices
{
    
    [TestClass]
    public class AccountServiceTests
    {
        private AccountService AccountService { get; set; }
        private Mock<IUserAccountRepository> MockRepository { get; set; }
        private UserAccount UserAccount { get; set; }



        [TestInitialize]
        public void TearUp()
        {
            this.MockRepository = new Mock<IUserAccountRepository>();

            this.AccountService = new AccountService(this.MockRepository.Object);

            this.UserAccount = new UserAccount()
            {
                Addresses = new List<UserAddress>()
                {
                    new UserAddress()
                    {
                        Address = "Rua do testes",
                        City = "rio de janeiro",
                        Complement = "Apto 123",
                        Neiborhood = "Geek",
                        State = "RJ",
                        ZipCode = "99999-999"
                    }
                },
                CPF = "00099900000",
                DtBirthday = new DateTime(1981, 03, 17),
                Email = "teste@teste.com.br",
                Name = "Rafael Cruz",
                Phones = new List<UserPhone>()
                {
                    new UserPhone()
                    {
                        PhoneNumber = "99999999999"
                    }

                },
                UserName = "rafael.cruz"
            };

        }

        [TestMethod]
        public void DeveCadastrarUmaContaComSucesso()
        {
            this.MockRepository.SetupSequence(x => x.GetOneByCriteria(It.IsAny<ISpecification<UserAccount>>()))
                               .Returns(Task.FromResult<UserAccount>(null))
                               .Returns(Task.FromResult<UserAccount>(null));

            this.MockRepository.Setup(x => x.Save(It.IsAny<UserAccount>()));

            this.AccountService.CreateAccount(UserAccount).Wait();

            //Assert
            Assert.IsTrue(UserAccount.Id != Guid.Empty);

        }


        [TestMethod]
        [ExpectedException(typeof(System.AggregateException))]
        public void DeveRetornarUmaExcecaoCasoExistaOMesmoCPFNaBase()
        {
            //Arrange
            this.MockRepository.SetupSequence(x => x.GetOneByCriteria(It.IsAny<ISpecification<UserAccount>>()))
                               .Returns(Task.FromResult(UserAccount))
                               .Returns(Task.FromResult<UserAccount>(null));

            //Act
            this.AccountService.CreateAccount(UserAccount).Wait();

            //Assert
            Assert.IsTrue(UserAccount.Id != Guid.Empty);

        }

        [TestMethod]
        [ExpectedException(typeof(System.AggregateException))]
        public void DeveRetornarUmaExcecaoCasoExistaOMesmoEmailNaBase()
        {
            //Arrange
            this.MockRepository.SetupSequence(x => x.GetOneByCriteria(It.IsAny<ISpecification<UserAccount>>()))
                               .Returns(Task.FromResult<UserAccount>(null))
                               .Returns(Task.FromResult(UserAccount));


            //Act
            this.AccountService.CreateAccount(UserAccount).Wait();

            //Assert
            Assert.IsTrue(UserAccount.Id != Guid.Empty);

        }


        [TestCleanup]
        public void TearDown()
        {

        }

    }
}
