using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAgencyApp.Helper
{
    class FilterItem
    {
        private string columnName;
        private string op;
        private string value;

        public FilterItem()
        {
        }

        public FilterItem(string colName, string op, string value)
        {
            this.columnName = colName;
            this.op = op;
            this.value = value;
        }

        public string ColumnName
        {
            get
            {
                return columnName;
            }

            set
            {
                columnName = value;
            }
        }

        public string Value
        {
            get
            {
                return value;
            }

            set
            {
                this.value = value;
            }
        }

        public string Op
        {
            get
            {
                return op;
            }

            set
            {
                op = value;
            }
        }

        public string Cluase(string key)
        {
            if (op == "LIKE")
                return string.Format("{0} LIKE '%' + @{1} + '%'", columnName, key);
            else
                return string.Format("{0} {1} @{2}", columnName, op, key);
        }
    }
}
