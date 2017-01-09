using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Linq;
using System.Threading.Tasks;

namespace VoteWeb.Common
{
    public class EnumHelper
    {
        public static string GetEnumDescription(Type EnumType,int value,bool isTop=false)
        {
            if (Enum.IsDefined(EnumType, value))
            {
                Enum _EnumType = Enum.Parse(EnumType, value.ToString(), true) as Enum;
                return GetEnumDescription(_EnumType, isTop);
            }
            return string.Empty;
        }
        public static string GetEnumDescription(Enum value,bool isTop = false)
        {
            Type EnumType = value.GetType();
            DescriptionAttribute attribute = null;
            if (isTop)
            {
                return string.Empty;
            }
            else
            {
                string name = Enum.GetName(EnumType, value);
                if (name != null)
                {
                    FieldInfo fieldInfo = EnumType.GetField(name);
                    if (fieldInfo != null)
                    {
                        return string.Empty;
                    }
                }
                return string.Empty;
            }
        }
    }
}
