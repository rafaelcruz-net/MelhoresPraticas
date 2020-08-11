using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MelhoresPraticas.Domain
{
    public class OrSpecification<T> : Specification<T>, ISpecification<T>
    {
        private readonly Specification<T> _left;
        private readonly Specification<T> _right;


        public OrSpecification(Expression<Func<T, bool>> expression) : base(expression)
        {

        }

        public OrSpecification(Specification<T> left, Specification<T> right)
        {
            _left = left;
            _right = right;
        }

        public override Expression<Func<T, bool>> SatisfyByCriteria()
        {
            Expression<Func<T, bool>> leftExpression = _left.Criteria;
            Expression<Func<T, bool>> rightExpression = _right.Criteria;

            var paramExpr = Expression.Parameter(typeof(T));

            var exprBody = Expression.OrElse(leftExpression.Body, rightExpression.Body);

            exprBody = (BinaryExpression)new ParameterReplacer(paramExpr).Visit(exprBody);

            var finalExpr = Expression.Lambda<Func<T, bool>>(exprBody, paramExpr);

            return finalExpr;

        }
    }
}
