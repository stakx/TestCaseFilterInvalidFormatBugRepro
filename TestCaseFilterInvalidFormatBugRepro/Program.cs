using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using NUnit.Framework;

[TestFixture]
public class UnrunnableTests
{
    [TestCaseSource("Source")]
    public void Test(Expression<Func<bool>> expression)
    {
    }

    public static IEnumerable<Expression<Func<bool>>> Source()
    {
        Expression<Func<bool>> expression = () => true;
        yield return expression;
    }
}

[TestFixture]
public class RunnableTests
{
    // The only difference to `UnrunnableTests` is that the test case source
    // wraps the returned value in a `Opaque<T>` wrapper type.

    [TestCaseSource("Source")]
    public void Test(Opaque<Expression<Func<bool>>> wrappedExpression)
    {
    }

    public static IEnumerable<Opaque<Expression<Func<bool>>>> Source()
    {
        Expression<Func<bool>> expression = () => true;
        yield return new Opaque<Expression<Func<bool>>>(expression);
    }

    public readonly struct Opaque<T>
    {
        public readonly T Value;

        public Opaque(T value)
        {
            this.Value = value;
        }

        // Uncomment the following to break test execution.
        // This more or less proves that the test executor doesn't appear to
        // understand formatted LINQ expression trees:

        //public override string ToString()
        //{
        //    return this.Value.ToString();
        //}
    }
}
