using MelhoresPraticas.Domain.Product.Agreggate;
using MelhoresPraticas.Domain.Product.Agreggate.Repository;
using MelhoresPraticas.Repository.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace MelhoresPraticas.Repository.Repository
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(MelhoresPraticasContext context) : base(context)
        {
            this.
        }
    }
}
