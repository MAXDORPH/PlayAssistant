using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace PlayAssistant
{
    using AttributeListType = List<Pair<IReturnValue, Pair<string, string>>>;
    internal class Character
    {
        public string Name { get; set; }
        public static AttributeListType ListGeneralAttributes { get; set; }
        public AttributeListType ListAttributes { get; set; }
        public Character(string name) { Name = name; }
        public void AddAttribute(String Title = "", String Value = "", bool IsDigit = false, bool IsGeneral = false) {
            if (Title == "")
            {
                Title = $"New Character Statistic {ListGeneralAttributes.Count() + ListAttributes.Count() + 1}";
            }
            IReturnValue CurAtrType = (IReturnValue)(IsDigit ? typeof(DigitalStatiscic) : typeof(StringStatiscic));
            if (IsGeneral)
            {
                ListGeneralAttributes.Add(new Pair<IReturnValue, Pair<string, string>>(CurAtrType, new Pair<string, string>(Title, Value)));
            }
            else { 
                ListAttributes.Add(new Pair<IReturnValue, Pair<string, string>>(CurAtrType, new Pair<string, string>(Title, Value)) );
            }
            return;
        }

        public List<UserControl> GetAttributes()
        {
            var ans = new List<UserControl>(); 
            foreach(var item in ListGeneralAttributes)
            {
                ans.Add((UserControl)
                    Activator.CreateInstance(
                        item.First.GetType(), item.Second.First, item.Second.Second
                    ));
            }
            foreach (var item in ListAttributes)
            {
                ans.Add((UserControl)
                    Activator.CreateInstance(
                        item.First.GetType(), item.Second.First, item.Second.Second
                    ));
            }
            return ans;
        }
    }
}
