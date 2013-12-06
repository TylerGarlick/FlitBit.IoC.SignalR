using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hosting;

namespace FlitBit.IoC.SignalR
{
    
    public class FlitBitDependencyResolver : DefaultDependencyResolver, IDependencyResolver
    {
        public override object GetService(Type serviceType)
        {
            var hostContext = GlobalHost.DependencyResolver.Resolve<HostContext>();
            if (hostContext != null)
            {
                
            }
            return base.GetService(serviceType);
        }
    }
}
