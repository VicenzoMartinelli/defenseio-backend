using DefenseIO.Infra.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace DefenseIO.Infra.Shared.Utils
{
    public static class EnumUtils
    {
        public static string[] ObterPropriedades<T>(this T enumerationValue) where T : struct
        {    
            string descricao = string.Empty;
            Type type = enumerationValue.GetType();

            if (!type.IsEnum)
            {
                throw new ArgumentException("Argumento deve ser um Enumerador.", "enumerationValue");
            }

            MemberInfo[] memberInfo = type.GetMember(enumerationValue.ToString());

            if (memberInfo != null && memberInfo.Length > 0)
            {
                object[] attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    descricao = ((DescriptionAttribute)attrs[0]).Description;
                }
            }
            else  
            {
                descricao = enumerationValue.ToString();
            }
                        
            return descricao.Split(';');    
        }

        public static ICollection<T> ObterListaDeValores<T>()
        {
            if (typeof(T).BaseType != typeof(Enum))
            {
                throw new ArgumentException("Argumento deve ser um Enumerador.", "enumerationValue");
            }

            return Enum.GetValues(typeof(T)).Cast<T>().ToList();
        }

        public static string ObterDescricao<T>(this T enumerationValue) where T : struct
        {
            Type type = enumerationValue.GetType();

            if (!type.IsEnum)
            {
                throw new ArgumentException("Argumento deve ser um Enumerador.", "enumerationValue");
            }

            MemberInfo[] memberInfo = type.GetMember(enumerationValue.ToString());

            if (memberInfo != null && memberInfo.Length > 0)
            {
                object[] attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            return enumerationValue.ToString();
        }
    }

    public class EnumUtils<T> where T : struct, IConvertible
    {
        public static List<KeyValueViewModel> Propiedadades
        {
            get
            {
                List<KeyValueViewModel> enumValList = new List<KeyValueViewModel>();

                foreach (var e in Enum.GetValues(typeof(T)))
                {
                    var fi = e.GetType().GetField(e.ToString());
                    var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

                    enumValList.Add(new KeyValueViewModel((attributes.Length > 0) ? attributes[0].Description : e.ToString(), (int) e));
                }

                return enumValList;
            }
        }
    }
}