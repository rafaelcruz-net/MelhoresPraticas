using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace MelhoresPraticas.CrossCutting.BusinessException
{
    public class BusinessException : System.Exception
    {
        public List<BusinessValidationFailure> Errors { get; private set; } = new List<BusinessValidationFailure>();
        public String Detail { get; set; } = "Ocorreu um erro ao processar a sua requisição";

        public BusinessException()
        {

        }

        public BusinessException(string detail) : base(detail)
        {
            this.Detail = detail;
            
        }

        public BusinessException(string detail, System.Exception innerException) : base(detail, innerException)
        {
            this.Detail = detail;
        }

        public void AddError(BusinessValidationFailure error)
        {
            this.Errors.Add(error);

        }

        public void ValidateAndThrow()
        {
            if (this.Errors.Count > 0)
                throw this;
        }
    }
}
