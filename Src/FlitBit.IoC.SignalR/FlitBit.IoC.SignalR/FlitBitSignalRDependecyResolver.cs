using System;
using System.Collections.Generic;
using Microsoft.AspNet.SignalR;

namespace FlitBit.IoC.SignalR
{
    public class FlitBitSignalRDependecyResolver : DefaultDependencyResolver, IDependencyResolver
    {
        readonly IContainer _container;

        public FlitBitSignalRDependecyResolver()
        {
            _container = Container.Current;
        }

        public override object GetService(Type serviceType)
        {
            var service = _container.CanConstruct(serviceType) ?
                _container.CreateInstance(serviceType) :
                default(object);
            return service;
        }

        public override IEnumerable<object> GetServices(Type serviceType)
        {
            var services = default(IEnumerable<object>);
            if (_container.CanConstruct(serviceType))
            {
                var enumerable = typeof(IEnumerable<>).MakeGenericType(serviceType);
                services = (IEnumerable<object>)_container.NewUntyped(LifespanTracking.Automatic, enumerable);
            }
            return services;
        }
    }
}
