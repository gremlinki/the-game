using System.Collections.Generic;

namespace Dbg
{
    public abstract class BaseDebugCommand
    {
        public static Dictionary<string, BaseDebugCommand> commands = new Dictionary<string, BaseDebugCommand>();
        
        public BaseDebugCommand(string name, string description)
        {
            _name = name;
            _description = description;
            commands.Add(name, this);
        }

        public abstract void execute();
        
        public string name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }
        
        public string description
        {
            get
            {
                return _description;
            }

            set
            {
                _description = value;
            }
        }
        
        private string _name, _description;
    }
}