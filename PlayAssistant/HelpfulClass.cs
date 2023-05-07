using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfApp1.Properties;
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

        public static UserControl get_by_name(string name)
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

        public static void SaveToJson(List<IReturnValue> items)
        {

            var serializer = new JsonSerializer();
            var tmp = new List<Tuple<IReturnValue, string>>();

            foreach( var item in items ) {
                Tuple<IReturnValue, string> tuple = new Tuple<IReturnValue, string>(item, item.ReturnValue());
                tmp.Add(tuple);
            }

            using (StreamWriter fs = new StreamWriter("SavedParams.json"))
            {
                serializer.Serialize(fs, tmp);
            }
            return;
        }

        public static List<IReturnValue> LoadFromJson()
        {
            var serializer = new JsonSerializer();  

        }
    }

}
