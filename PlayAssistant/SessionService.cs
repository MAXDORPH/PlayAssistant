using ServiceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PlayAssistant
{
    internal static class SessionService
    {
        public static List<IReturnValue> GetParams()
        {
            var ans = new List<IReturnValue>();
            foreach(Type t in Assembly.GetAssembly(typeof(PSModules.ControlClass)).GetTypes())
            {
                if (t.GetInterface("IReturnValue") != null)
                    ans.Add((IReturnValue)Activator.CreateInstance(t));
            }
            return ans;
        }
        public static List<IReturnValue> GetAttributes()
        {
            var ans = new List<IReturnValue>();
            foreach (Type t in Assembly.GetAssembly(typeof(CHRSModules.ControlClass)).GetTypes())
            {
                if (t.GetInterface("IReturnValue") != null)
                    ans.Add((IReturnValue)Activator.CreateInstance(t));
            }
            return ans;
        }
    }
}
