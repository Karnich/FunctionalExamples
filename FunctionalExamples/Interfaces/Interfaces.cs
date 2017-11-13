using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IMathOperation
    {
        decimal Compute(decimal left, decimal right);
    }

    public class AddOperation : IMathOperation
    {
        decimal IMathOperation.Compute(decimal left, decimal right)
        {
            return left + right;
        }
    }

    public class SubtractOperation : IMathOperation
    {
        decimal IMathOperation.Compute(decimal left, decimal right)
        {
            return left - right;
        }
    }

    public class MultiplyOperation : IMathOperation
    {
        decimal IMathOperation.Compute(decimal left, decimal right)
        {
            return left * right;
        }
    }

    public class DivideOperation : IMathOperation
    {
        decimal IMathOperation.Compute(decimal left, decimal right)
        {
            return left / right;
        }
    }
}
