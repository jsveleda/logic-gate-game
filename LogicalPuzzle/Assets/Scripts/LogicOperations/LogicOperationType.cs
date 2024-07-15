using System;

namespace Operational
{
    public enum LogicOperationType
    {
        none,
        and,
        or,
        not,
        nand,
        nor,
        xor,
        xnor
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
                LogicOperationType.nand => new NandOperation(),
                LogicOperationType.nor => new NorOperation(),
                LogicOperationType.xor => new XorOperation(),
                LogicOperationType.xnor => new XnorOperation(),
                _ => throw new ArgumentException("Invalid logic operation."),
            };
        }
    }
}
