using System;

namespace Operational
{
    public enum LogicOperationType
    {
        none,
        and,
        or,
        not,
        xor
    }

    public static class LogicOperationFactory
    {
        public static LogicOperation CreateLogicOperation(LogicOperationType operation)
        {
            return operation switch
            {
                LogicOperationType.none => new IdentityOperation(),
                LogicOperationType.and => new AndOperation(),
                LogicOperationType.or => new OrOperation(),
                LogicOperationType.not => new NotOperation(),
                LogicOperationType.xor => new XorOperation(),
                _ => throw new ArgumentException("Invalid logic operation."),
            };
        }
    }
}
