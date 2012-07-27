using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;

namespace WCFTrafficControl.CustomBindings
{
    public class TrafficControlChannelFactory<TChannel> : ChannelFactoryBase<TChannel>
    {
        public IChannelFactory<TChannel> _innerChannelFactory;

        public TrafficControlChannelFactory(BindingContext context)
        {
            this._innerChannelFactory = context.BuildInnerChannelFactory<TChannel>();
        }

        protected override TChannel OnCreateChannel(EndpointAddress address, Uri via)
        {
            IRequestChannel innerChannel = this._innerChannelFactory.CreateChannel(address, via) as IRequestChannel;         
            return (TChannel)(object)innerChannel;
        }

        protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return this._innerChannelFactory.BeginOpen(timeout, callback, state);
        }

        protected override void OnEndOpen(IAsyncResult result)
        {
            this._innerChannelFactory.EndOpen(result);
        }

        protected override void OnOpen(TimeSpan timeout)
        {
            this._innerChannelFactory.Open(timeout);
        }
    }
}
