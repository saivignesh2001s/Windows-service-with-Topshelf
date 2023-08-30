using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace Windows_service
{
    internal class configuration
    {
        internal static void Configure()
        {
            HostFactory.Run(configure =>
            {
                configure.Service<OwnService>(service =>
                {
                    service.ConstructUsing(s => new OwnService());
                    service.WhenStarted(s => s.Start());
                    service.WhenStopped(s => s.Stop());
                });
                //Setup Account that window service use to run.  
                configure.RunAsLocalSystem();
                configure.SetServiceName("WinServiceWithTopshelf");
                configure.SetDisplayName("WinServiceWithTopshelf");
                configure.SetDescription("WinService With Topshelf");
            });
        }
    }
}
