using System;
using System.Collections.Generic;
using System.Text;

namespace MelhoresPraticas.CrossCutting.BusinessException
{
    public class BusinessValidationFailure
    {
        public String ErrorCode { get; set; }
        public String ErrorMessage { get; set; }
    }
}
