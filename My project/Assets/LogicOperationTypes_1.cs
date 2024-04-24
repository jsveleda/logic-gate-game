using System;

namespace Operational
{
    public enum LogicOperationTypes
    {
        NONE,
        AND,
        OR,
        NOT,
        XOR
    }

    public static class LogicOperationFactory
    {
        public static LogicOperation CreateLogicOperation(LogicOperationTypes operation)
        {
            return operation switch
            {
                LogicOperationTypes.NONE => new LogicOperation(),
                LogicOperationTypes.AND => new AndOperation(),
                LogicOperationTypes.OR => new OrOperation(),
                LogicOperationTypes.NOT => new NotOperation(),
                LogicOperationTypes.XOR => new XorOperation(),
                _ => throw new ArgumentException("Invalid logic operation."),
            };
        }
    }
}
