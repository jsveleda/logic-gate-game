namespace Operational
{
    public class IdentityOperation : LogicOperation
    {
        public override bool Execute(params bool[] inputs)
        {
            if (inputs.Length > 0)
            {
                return inputs[0];
            }

            return false;
        }
    }
}
