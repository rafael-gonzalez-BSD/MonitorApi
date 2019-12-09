using System.Collections.Generic;
using System.Reflection;

namespace MonitorProcesos.Utils
{
    public static class DynamicParametersExtension
    {
        public static Dictionary<string, dynamic> CreateParameters(object obj)
        {
            Dictionary<string, dynamic> P = new Dictionary<string, dynamic>();

            var props = obj.GetType().GetProperties();

            foreach (PropertyInfo prop in props)
            {
                string Key = prop.Name.ToString();
                dynamic Value = obj.GetType().GetProperty(Key).GetValue(obj, null);

                P.Add(Key, Value);
            }

            return P;
        }
    }
}