using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NavigationSetup.Helpers
{
    public static class WindowHelpers
    {
        private static List<string>? _windowsList;

        public static IReadOnlyList<string>? GetWindowList(Assembly assembly)
        {
            _windowsList = new List<string>();

            try
            {
                Stream? stream = assembly.GetManifestResourceStream(assembly.GetName().Name + ".g.resources");

                using (ResourceReader reader = new ResourceReader(stream))
                {
                    foreach (DictionaryEntry entry in reader)
                    {
                        string str = (string)entry.Key;
                        var name = str.Replace(".baml", ".xaml");
                        _windowsList.Add(name);
                    }
                }
            }
            catch
            {
               
            }

            return _windowsList?.AsReadOnly();
        }
    }
}
