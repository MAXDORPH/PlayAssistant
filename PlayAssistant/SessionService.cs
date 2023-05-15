using ServiceLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PlayAssistant
{
    internal static class SessionService
    {
        static string SessionName {get; set; }
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

        public static void CreateSession(string _SessionName)
        {
            SessionName = _SessionName;
            Directory.CreateDirectory(SessionName);
            using (FileStream chr = File.Create($@"{SessionName}/Characters.json"), md = File.Create($@"{SessionName}/Modules.json"))
            {
                var serializer = new JsonSerializer();
                var tmpChr = new Pair<List<string>, List<Character>>();
                var tmpMd = new List<IReturnValue>();
                serializer.Serialize(new StreamWriter(chr), tmpChr);
                serializer.Serialize(new StreamWriter(md), tmpMd);
            }
        }
        public static void SaveSession(Pair<Pair<List<string>, List<Character>>, List<IReturnValue>> ChrAndMd)
        {
            var ChrData = ChrAndMd.First;
            var MdData = ChrAndMd.Second;
            using (StreamWriter chr = new StreamWriter(@$"{SessionName}/Characters.json"), md = new StreamWriter($@"{SessionName}/Modules.json"))
            {
                var serializer = new JsonSerializer();
                serializer.Serialize(chr, ChrData);
                serializer.Serialize(md, MdData);
            }
            return;
        }
        public static Pair<Pair<List<string>, List<Character>>, List<IReturnValue>> LoadSession()
        {
            
            Pair<Pair<List<string>, List<Character>>, List<IReturnValue>> ans;
            using (StreamReader chr = new StreamReader(@$"{SessionName}/Characters.json"), md = new StreamReader($@"{SessionName}/Modules.json"))
            {
                var serializer =new JsonSerializer();
                var ChrData = serializer.Deserialize(chr, typeof(Pair<List<string>, List<Character>>)) as Pair<List<string>, List<Character>>;
                var MdData = serializer.Deserialize(md, typeof(List<IReturnValue>)) as List<IReturnValue>;
                ans = new Pair<Pair<List<string>, List<Character>>, List<IReturnValue>>(ChrData, MdData);
            }
            return ans;
        }
    }
}
