using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using XamEFCore.Droid.Implementations;
using XamEFCore.Interfaces;

[assembly: Dependency(typeof(DataBaseService))]
namespace XamEFCore.Droid.Implementations
{
    public class DataBaseService : IDataBaseService
    {
        public string GetFullPath(string databaseFileName)
        {
            return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), databaseFileName);
        }
    }
}