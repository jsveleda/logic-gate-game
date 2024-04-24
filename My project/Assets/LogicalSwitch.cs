using UnityEngine;

namespace Operational
{
    public class LogicalSwitch : LogicalElement
    {
        [SerializeField]
        private bool ToggleOutput
        {
            set
            {
                Toggle(value);
            }
        }

        public LogicalSwitch() : base(new OrOperation())
        {

        }

        public void Toggle(bool output)
        {
            this.output = output;
        }
    }
}
