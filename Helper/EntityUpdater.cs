using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPWebApp.Helper
{
    public static class EntityUpdater
    {
        public static void UpdateEntity<T>(T existing, T updated)
        {
            var properties = typeof(T).GetProperties();

            foreach (var prop in properties)
            {
                if (!prop.CanWrite)
                    continue;

                // Skip Id
                if (prop.Name == "Id")
                    continue;

                var newValue = prop.GetValue(updated);
                prop.SetValue(existing, newValue);
            }
        }
    }

}