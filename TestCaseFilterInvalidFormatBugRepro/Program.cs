using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using NUnit.Framework;

[TestFixture]
public class Tests
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
