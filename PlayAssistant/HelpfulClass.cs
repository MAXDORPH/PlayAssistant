using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Newtonsoft.Json;

namespace WpfApp1
{
    interface IReturnValue
    {
        string ReturnValue();
        void setByValue(string value);
    }
internal class HelpfulClass
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

        public static List<Dictionary<String, String>> GetParams() {
            return FakeData();
        }

        public static UserControl GetByName(string name)
        {
            var serializer = new JsonSerializer();
            Type ans;
            using (StreamReader fs = new StreamReader("BaseUserControls.json"))
            {
                var tmp_ser = (Dictionary<String, Type>)serializer.Deserialize(fs, typeof(Dictionary<String, Type>));
                ans = tmp_ser[name];
            }

            var instance = Activator.CreateInstance(
                ans
                );

            return instance as UserControl;
        }

        public static void SaveToJson(Dictionary<Type, List<string>> items, string code = "")
        {
            var serializer = new JsonSerializer();

            using (StreamWriter fs = new StreamWriter($"SavedParams{code}.json"))
            {
                serializer.Serialize(fs, items);
            }
            return;
        }

        public static Dictionary<Type, List<string>> LoadFromJson(string code = "")
        {
            var serializer = new JsonSerializer();
            var tmp = new Dictionary<Type, List<string>>();
            using (StreamReader fs = new StreamReader($"SavedParams{code}.json"))
            {
                tmp = (Dictionary<Type, List<string>>)serializer.Deserialize(fs, typeof(Dictionary<Type, List<string>>));
            }
            return tmp;
        }
    }
}