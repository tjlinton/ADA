using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adaOrderingSys
{
    public interface IDataReader : IDisposable, IDataRecord
    {
        int Depth { get; }
        bool IsClosed { get; }
        int RecordsAffected { get; }
        void Close();
        DataTable GetSchemaTable();
        bool NextResult();
        bool Read();
    }
}
