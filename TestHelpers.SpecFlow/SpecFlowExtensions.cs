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
            if (tableRow.ContainsKey(columnName))
            {
                return (T)Convert.ChangeType(tableRow[columnName], typeof(T));
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
