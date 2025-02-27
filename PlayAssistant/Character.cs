﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace PlayAssistant
{
    using AttributeListType = List<IReturnValue>;
    public class Character
    {
        public string Name { get; set; }
        public static AttributeListType ListGeneralAttributes { get; set; }
        public List<Pair<string,string>> GeneralAttributesValue { get; set; }
        public AttributeListType ListAttributes { get; set; }
        public Character(string name) { 
            Name = name; 
            ListAttributes = new AttributeListType(); 
            if (ListGeneralAttributes == null) 
                ListGeneralAttributes = new AttributeListType(); 
            GeneralAttributesValue= new List<Pair<string, string>>(ListGeneralAttributes.Count());
        }
        public void AddAttribute(IReturnValue stat) {
            if (stat.Title == "")
            {
                stat.Title = $"New Global Character Statistic {ListGeneralAttributes.Count() + ListAttributes.Count() + 1}";
            }
            ListAttributes.Add(stat);
            return;
        }

        public static void AddGeneralAttributes(IReturnValue stat)
        {
            if (stat.Title == "")
            {
                stat.Title = $"New Global Character Statistic {ListGeneralAttributes.Count() + 1}";
            }
            ListGeneralAttributes.Add(stat);
            return;
        }

        public AttributeListType GetAttributes()
        {
            var ans = new AttributeListType();
            if (ListGeneralAttributes != null) { 
                while (GeneralAttributesValue.Count < ListGeneralAttributes.Count)
                {
                    GeneralAttributesValue.Add(new Pair<string, string>("",""));
                }
                for(int i = 0; i < GeneralAttributesValue.Count; i++)
                {
                    ans.Add((IReturnValue)
                        Activator.CreateInstance(ListGeneralAttributes[i].GetType(),
                                                 GeneralAttributesValue[i].First,
                                                 GeneralAttributesValue[i].Second));
                }
            }
            if (ListAttributes != null)
            {
                foreach (var item in ListAttributes)
                {
                    ans.Add((IReturnValue)
                        Activator.CreateInstance(item.GetType(),
                                                 item.Title,
                                                 item.Value));
                }
            }
            return ans;
        }
        public void Refrash(AttributeListType tmplist)
        {
            for(int i = 0; i < GeneralAttributesValue.Count; i++)
            {
                GeneralAttributesValue[i] = new Pair<string, string>(tmplist[i].Value, tmplist[i].Title);
            }
            for(int i = GeneralAttributesValue.Count; i < tmplist.Count; i++)
            {
                ListAttributes[i - GeneralAttributesValue.Count].Value = tmplist[i].Value;
                ListAttributes[i - GeneralAttributesValue.Count].Title = tmplist[i].Title;
            }
        }
    }
}
