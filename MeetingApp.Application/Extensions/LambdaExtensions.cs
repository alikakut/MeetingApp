using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MeetingApp.Application.Extensions
{
    public class ExpressionRebinder : ExpressionVisitor
    {
        /// <summary>
        /// The map
        /// </summary>
        private readonly Dictionary<ParameterExpression, ParameterExpression> map;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionRebinder"/> class.
        /// </summary>
        /// <param name="map">The map.</param>
        public ExpressionRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
        {
            this.map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
        }

        /// <summary>
        /// Replacements the expression.
        /// </summary>
        /// <param name="map">The map.</param>
        /// <param name="exp">The exp.</param>
        /// <returns>Returns replaced expression</returns>
        public static Expression ReplacementExpression(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
        {
            return new ExpressionRebinder(map).Visit(exp);
        }

        /// <summary>
        /// Visits the <see cref="T:System.Linq.Expressions.ParameterExpression" />.
        /// </summary>
        /// <param name="node">The expression to visit.</param>
        /// <returns>
        /// The modified expression, if it or any subexpression was modified; otherwise, returns the original expression.
        /// </returns>
        protected override Expression VisitParameter(ParameterExpression node)
        {
            ParameterExpression replacement;
            if (this.map.TryGetValue(node, out replacement))
            {
                node = replacement;
            }

            return base.VisitParameter(node);
        }
    }

    public static class LambdaExtensions
    {
        public static Expression<Func<T, bool>> AndAlso<T>(
    this Expression<Func<T, bool>> expr1,
    Expression<Func<T, bool>> expr2)
        {
            ParameterExpression param = expr1.Parameters[0];
            if (ReferenceEquals(param, expr2.Parameters[0]))
            {
                // simple version
                return Expression.Lambda<Func<T, bool>>(
                    Expression.AndAlso(expr1.Body, expr2.Body), param);
            }
            return Expression.Lambda<Func<T, bool>>(
                Expression.AndAlso(
                    expr1.Body,
                    Expression.Invoke(expr2, param)), param);
        }

        public static string LambdaToString<T>(this Expression<Func<T, bool>> expression)
        {

            var replacements = new Dictionary<string, string>();
            WalkExpression(replacements, expression);


            string body = expression.Body.ToString();

            foreach (var parm in expression.Parameters)
            {
                var parmName = parm.Name;
                var parmTypeName = parm.Type.Name;
                body = body.Replace(parmName + ".", parmTypeName + ".");
            }

            foreach (var replacement in replacements)
            {
                body = body.Replace(replacement.Key, replacement.Value);
            }

            return body;
        }

        private static void WalkExpression(Dictionary<string, string> replacements, Expression expression)
        {
            switch (expression.NodeType)
            {
                case ExpressionType.MemberAccess:
                    string replacementExpression = expression.ToString();
                    if (replacementExpression.Contains("value("))
                    {
                        string replacementValue = Expression.Lambda(expression).Compile().DynamicInvoke().ToString();
                        if (!replacements.ContainsKey(replacementExpression))
                        {
                            replacements.Add(replacementExpression, replacementValue.ToString());
                        }
                    }
                    break;

                case ExpressionType.GreaterThan:
                case ExpressionType.GreaterThanOrEqual:
                case ExpressionType.LessThan:
                case ExpressionType.LessThanOrEqual:
                case ExpressionType.OrElse:
                case ExpressionType.AndAlso:
                case ExpressionType.Equal:
                    var bexp = expression as BinaryExpression;
                    WalkExpression(replacements, bexp.Left);
                    WalkExpression(replacements, bexp.Right);
                    break;

                case ExpressionType.Call:
                    var mcexp = expression as MethodCallExpression;
                    foreach (var argument in mcexp.Arguments)
                    {
                        WalkExpression(replacements, argument);
                    }
                    break;

                case ExpressionType.Lambda:
                    var lexp = expression as LambdaExpression;
                    WalkExpression(replacements, lexp.Body);
                    break;

                case ExpressionType.Constant:
                    //do nothing
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Composes the specified left expression.
        /// </summary>
        /// <typeparam name="T">Param Type</typeparam>
        /// <param name="leftExpression">The left expression.</param>
        /// <param name="rightExpression">The right expression.</param>
        /// <param name="merge">The merge.</param>
        /// <returns>Returns the expression</returns>
        public static Expression<T> Compose<T>(this Expression<T> leftExpression, Expression<T> rightExpression, Func<Expression, Expression, Expression> merge)
        {
            var map = leftExpression.Parameters.Select((left, i) => new
            {
                left,
                right = rightExpression.Parameters[i]
            }).ToDictionary(p => p.right, p => p.left);

            var rightBody = ExpressionRebinder.ReplacementExpression(map, rightExpression.Body);

            return Expression.Lambda<T>(merge(leftExpression.Body, rightBody), leftExpression.Parameters);
        }

        /// <summary>
        /// Performs an "AND" operation
        /// </summary>
        /// <typeparam name="T">Param Type</typeparam>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>Returns the expression</returns>
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
        {
            return left.Compose(right, Expression.And);
        }

        /// <summary>
        /// Performs an "OR" operation
        /// </summary>
        /// <typeparam name="T">Param Type</typeparam>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>Returns the expression</returns>
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
        {
            return left.Compose(right, Expression.Or);
        }
    }
}
