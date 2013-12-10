using System;
using System.Collections.Generic;
using FlitBit.IoC.Web.Common;
using Microsoft.AspNet.SignalR;

namespace FlitBit.IoC.SignalR
{
    public class FlitBitSignalRDependecyResolver : DefaultDependencyResolver, IDependencyResolver
    {
        readonly IContainer _container;

        public FlitBitSignalRDependecyResolver()
        {
            _container = ContainerHelpers.Current;
        }

        public override object GetService(Type serviceType)
        {
            var service = _container.CanConstruct(serviceType) ?
                _container.CreateInstance(serviceType) :
                base.GetService(serviceType);
            return service;
        }

        public override IEnumerable<object> GetServices(Type serviceType)
        {
            if (_container.CanConstruct(serviceType))
            {
                var enumerable = typeof(IEnumerable<>).MakeGenericType(serviceType);
                return (IEnumerable<object>)_container.NewUntyped(LifespanTracking.Automatic, enumerable);
            } 
            return base.GetServices(serviceType);
        }
    }
}
