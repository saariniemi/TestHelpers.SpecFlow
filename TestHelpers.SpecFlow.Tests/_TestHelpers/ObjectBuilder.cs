using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SpecFlowExtensionsTests._TestHelpers
{
    public static class ObjectBuilder
    {
        public static Table CreateTable(
            string[] headers,
            params TableRowWithValues[] rows)
        {
            var table = new Table(headers);
            foreach (var tableRowWithValuese in rows)
            {
                table.AddRow(tableRowWithValuese.ColumnValues);
            }

            return table;
        }

        public static TableRowWithValues CreateRowWithValues(params string[] columnValues)
        {
            return new TableRowWithValues(columnValues);
        }

        public static TableRow CreateTableRow(
            string[] headers,
            string[] columnValues)
        {
            var table = CreateTable(headers, CreateRowWithValues(columnValues));
            return table.Rows[0];
        }
    }

    public class TableRowWithValues
    {
        public string[] ColumnValues { get; }

        public TableRowWithValues(params string[] columnValues)
        {
            ColumnValues = columnValues;
        }
    }
}