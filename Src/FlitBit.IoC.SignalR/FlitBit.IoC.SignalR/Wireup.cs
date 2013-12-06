using FlitBit.Wireup;
using FlitBit.Wireup.Meta;

[assembly: WireupDependency(typeof(FlitBit.IoC.Owin.AssemblyWireup))]
[assembly: Wireup(typeof(FlitBit.IoC.SignalR.AssemblyWireup))]
namespace FlitBit.IoC.SignalR
{
    public class AssemblyWireup : IWireupCommand
    {
        public void Execute(IWireupCoordinator coordinator)
        {
        }
    }
}