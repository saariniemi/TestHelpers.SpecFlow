using System;
using TechTalk.SpecFlow;

namespace TestHelpers.SpecFlow
{
    public static class SpecFlowExtensions
    {
        public static T Get<T>(
            this TableRow tableRow,
            string columnName)
        {
            var type = typeof(T);

            if (tableRow.ContainsKey(columnName))
            {
                if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    if (string.IsNullOrEmpty(tableRow[columnName])
                    {
                        return null;
                    }
                }  
                return (T)Convert.ChangeType(tableRow[columnName], type);
            }

            throw new ArgumentException($"There is no column named {columnName}");
        }

        public static void TryMap<T>(
            this TableRow tableRow,
            string columnName,
            Action<T> map)
        {
            if (tableRow.ContainsKey(columnName))
            {
                map?.Invoke((T)Convert.ChangeType(tableRow[columnName], typeof(T)));
            }
        }
    }
}
