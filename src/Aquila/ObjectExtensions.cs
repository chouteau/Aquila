using System;
using System.Linq;

namespace Aquila
{
    internal static class ObjectExtensions
    {
        internal static void BindFromConfiguration(this object model, System.Collections.Specialized.NameValueCollection nvc)
        {
            if (model == null
                || nvc == null)
            {
                return;
            }

            var ci = new System.Globalization.CultureInfo("en-US");
            var propertyInfoList = model.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.GetProperty);
            foreach (var propertyInfo in propertyInfoList)
            {
                if (!propertyInfo.CanWrite)
                {
                    continue;
                }

                var key = nvc.AllKeys.SingleOrDefault(i => i.Equals(propertyInfo.Name, StringComparison.InvariantCultureIgnoreCase));
                if (key == null)
                {
                    continue;
                }

                var value = nvc[key];
                if (value == null)
                {
                    continue;
                }

                var typedValue = System.Convert.ChangeType(value, propertyInfo.PropertyType, ci);
                propertyInfo.SetValue(model, typedValue, null);
            }
        }
    }
}