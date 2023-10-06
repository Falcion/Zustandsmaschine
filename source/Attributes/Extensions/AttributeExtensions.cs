using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zustand.Attributes.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class AttributeExtensions
    {
        // Module of ExterNAP (External Native Attribute Parser)
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="type"></param>
        /// <param name="valueSelector"></param>
        /// <returns></returns>
        public static TValue? GetAttributeValue<TAttribute, TValue>(this Type type, Func<TAttribute, TValue> valueSelector) where TAttribute : Attribute
        {
            if (type.GetCustomAttributes(
                typeof(TAttribute), true
            ).FirstOrDefault() is TAttribute att)
            {
                return valueSelector(att);
            }
#pragma warning disable IDE0034
            return default(TValue);
#pragma warning restore IDE0034
        }
    }
}
