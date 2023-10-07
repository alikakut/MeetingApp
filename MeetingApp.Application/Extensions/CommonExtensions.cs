using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MeetingApp.Application.Extensions
{
    public static class CommonExtensions
    {
        public static TDerived ToDerived<TBase, TDerived>(this TBase tBase)
   where TDerived : TBase, new()
        {
            TDerived tDerived = new TDerived();
            foreach (PropertyInfo propBase in typeof(TBase).GetProperties())
            {
                PropertyInfo propDerived = typeof(TDerived).GetProperty(propBase.Name);
                propDerived.SetValue(tDerived, propBase.GetValue(tBase, null), null);
            }
            return tDerived;
        }

        public static T ConvertTo<T>(this object obj)
        {
            try
            {
                return ((T)obj);
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

        public static bool IsNull(this string value)
        {
            if (value == null)
                return true;
            return string.IsNullOrEmpty(value.Trim());
        }

        public static decimal TwoPrecisionDecimal(this decimal value)
        {
            NumberFormatInfo numberFormatInfo = new NumberFormatInfo { NumberDecimalDigits = 2 };
            string a = value.ToString(numberFormatInfo).Replace(".", ",");
            return Convert.ToDecimal(a);
        }

        public static long AsLong(this object @object)
        {
            return Convert.ToInt64(@object);
        }

        public static byte AsByte(this Boolean value)
        {
            return Convert.ToByte(value);
        }

        public static bool TryConvertTo<T>(this object obj)
        {
            try
            {
                var casting = ((T)obj);

                if (casting != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }
    }
}
