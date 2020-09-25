using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace Financeiro_Installer {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {

        public App () {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
        }

        private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args) {
            try {
                //gets the main Assembly
                var parentAssembly = Assembly.GetExecutingAssembly();
                //args.Name will be something like this
                //[ MahApps.Metro, Version=1.1.3.81, Culture=en-US, PublicKeyToken=null ]
                //so we take the name of the Assembly (MahApps.Metro) then add (.dll) to it
                var finalname = args.Name.Substring(0, args.Name.IndexOf(',')) + ".dll";
                //here we search the resources for our dll and get the first match
                var ResourcesList = parentAssembly.GetManifestResourceNames();
                string OurResourceName = null;
                //(you can replace this with a LINQ extension like [Find] or [First])
                for (int i = 0; i < ResourcesList.Length; i++) {
                    var name = ResourcesList[i];
                    if (name.EndsWith(finalname)) {
                        //Get the name then close the loop to get the first occuring value
                        OurResourceName = name;
                        break;
                    }
                }

                if (!string.IsNullOrWhiteSpace(OurResourceName)) {
                    //get a stream representing our resource then load it as bytes
                    using Stream stream = parentAssembly.GetManifestResourceStream(OurResourceName);
                    //in vb.net use [ New Byte(stream.Length - 1) ]
                    //in c#.net use [ new byte[stream.Length]; ]
                    byte[] block = new byte[stream.Length];
                    stream.Read(block, 0, block.Length);
                    return Assembly.Load(block);
                } else {
                    return null;
                }
            } catch (Exception) {
                return null;
            }
        }
    }
}
