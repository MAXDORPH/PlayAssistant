using Newtonsoft.Json;

namespace ServiceLibrary
{
    internal static class HelpfulClass
    {
        static List<Dictionary<String, String>> FakeData()
        {
            List<Dictionary<String, String>> ans = new List<Dictionary<String, String>>();
            Dictionary<String, String> tmp = new Dictionary<String, String>();
            tmp["Title"] = "Кнопка";
            tmp["Description"] = "Кнопка которая меняет цвет";
            tmp["PicPath"] = "none.png";
            ans.Add(tmp);
            tmp = new Dictionary<String, String>();
            tmp["Title"] = "Поле с текстом";
            tmp["Description"] = "Тут текстик красивый";
            tmp["PicPath"] = "none.png";
            ans.Add(tmp);
            return ans;
        }

        public static List<IReturnValue> GetParams() {
            return null;
        }
                
        public static void SaveToJson(Dictionary<Type, List<string>> items, List<Pair<string,Character>> PlaysCharacters, string code = "")
        {
            var serializer = new JsonSerializer();

            using (StreamWriter fs = new StreamWriter($"SavedParams{code}.json"))
            {
                serializer.Serialize(fs, items);
            }
            return;
        }

        public static Pair<Dictionary<Type, List<string>>, List<Pair<string, Character>>> LoadPSFromJson(string code = "")
        {
            var serializer = new JsonSerializer();
            var tmp = new Dictionary<Type, List<string>>();
            using (StreamReader fs = new StreamReader($"SavedParams{code}.json"))
            {
                tmp = (Dictionary<Type, List<string>>)serializer.Deserialize(fs, typeof(Dictionary<Type, List<string>>));
            }
            return null;
        }

        public static void SafeCHRToJson(string code = "")
        {
            var serializer = new JsonSerializer();
        }

        public static void CreateGame(string name = "")
        {
            Character.ListGeneralAttributes.Clear();
        }
        public static List<IReturnValue> GetAttributes()
        {
            var ans = new List<IReturnValue>
            {
                
            };
            return ans;
        }
    }
}