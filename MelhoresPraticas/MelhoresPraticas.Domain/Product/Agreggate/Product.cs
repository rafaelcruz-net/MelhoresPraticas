using System;
using System.Collections.Generic;
using System.Text;

namespace MelhoresPraticas.Domain.Product.Agreggate
{
    public class Product
    {
        public Guid Id { get; set; }

        public String Name { get; set; }

        public String Description { get; set; }

        public Decimal Price { get; set; }
    }
}
