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
    using ChrDataType = Pair<List<IReturnValue>, List<Character>>;
    using MdDataType = List<IReturnValue>;
    internal static class SessionService
    {
        public static string SessionName {get; set; }
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
                var tmpChr = new ChrDataType();
                var tmpMd = new MdDataType();
                serializer.Serialize(new StreamWriter(chr), tmpChr);
                serializer.Serialize(new StreamWriter(md), tmpMd);
            }
        }
        public static void SaveSession(Pair<ChrDataType, MdDataType> ChrAndMd)
        {
            var ChrData = ChrAndMd.First;
            var MdData = ChrAndMd.Second;
            using (StreamWriter chr = new StreamWriter(@$"{SessionName}/Characters.json"), md = new StreamWriter($@"{SessionName}/Modules.json"))
            {
                var serializer = new JsonSerializer();
                serializer.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                serializer.Serialize(chr, ChrData);
                serializer.Serialize(md, MdData);
            }
            return;
        }
        public static Pair<ChrDataType, MdDataType> LoadSession()
        {
            
            Pair<ChrDataType, MdDataType> ans;
            using (StreamReader chr = new StreamReader(@$"{SessionName}/Characters.json"), md = new StreamReader($@"{SessionName}/Modules.json"))
            {
                var serializer =new JsonSerializer();
                var ChrData = serializer.Deserialize(chr, typeof(ChrDataType)) as ChrDataType;
                var MdData = serializer.Deserialize(md, typeof(MdDataType)) as MdDataType;
                ans = new Pair<ChrDataType, MdDataType>(ChrData, MdData);
            }
            return ans;
        }
    }
}
