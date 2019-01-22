using System;
using System.Collections.Generic;
using System.Text;

namespace XamEFCore.Interfaces
{
    public interface IDataBaseService
    {
        string GetFullPath(string databaseFileName);
    }
}
