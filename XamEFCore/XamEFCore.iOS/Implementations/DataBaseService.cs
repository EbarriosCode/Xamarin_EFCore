﻿
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using XamEFCore.Interfaces;
using XamEFCore.iOS.Implementations;

[assembly: Dependency(typeof(DataBaseService))]
namespace XamEFCore.iOS.Implementations
{
    public class DataBaseService : IDataBaseService
    {
        public string GetFullPath(string databaseFileName)
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", databaseFileName);
        }
    }
}