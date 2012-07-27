using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;

namespace WCFTrafficControl.CustomBindings
{
    public class TrafficControlBindingElement : BindingElement
    {
        public TrafficControlBindingElement()
        {
        }

        public override BindingElement Clone()
        {
            return new TrafficControlBindingElement();
        }

        public override T GetProperty<T>(BindingContext context)
        {
            return context.GetInnerProperty<T>();
        }

        public override IChannelFactory<TChannel> BuildChannelFactory<TChannel>(BindingContext context)
        {
            return new TrafficControlChannelFactory<TChannel>(context) as IChannelFactory<TChannel>;
        }

        public override IChannelListener<TChannel> BuildChannelListener<TChannel>(BindingContext context)
        {
            return new TrafficControlChannelListener<TChannel>(context) as IChannelListener<TChannel>;
        }
    }
}
