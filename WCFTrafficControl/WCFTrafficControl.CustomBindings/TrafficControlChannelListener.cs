using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Channels;

namespace WCFTrafficControl.CustomBindings
{
    public class TrafficControlChannelListener<TChannel> : ChannelListenerBase<TChannel> where TChannel : class, IChannel
    {
        private IChannelListener<TChannel> _innerChanneListener;

        public TrafficControlChannelListener(BindingContext context)
        {
            this._innerChanneListener = context.BuildInnerChannelListener<TChannel>();
        }

        protected override TChannel OnAcceptChannel(TimeSpan timeout)
        {
            IReplyChannel innerChannel = this._innerChanneListener.AcceptChannel(timeout) as IReplyChannel;
            return new TrafficControlReplyChannel(innerChannel) as TChannel;
        }

        protected override IAsyncResult OnBeginAcceptChannel(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return this._innerChanneListener.BeginAcceptChannel(timeout, callback, state);
        }

        protected override TChannel OnEndAcceptChannel(IAsyncResult result)
        {
            IReplyChannel innerChannel = this._innerChanneListener.EndAcceptChannel(result) as IReplyChannel;
            return new TrafficControlReplyChannel(innerChannel) as TChannel;
        }

        protected override IAsyncResult OnBeginWaitForChannel(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return _innerChanneListener.BeginWaitForChannel(timeout, callback, state);
        }

        protected override bool OnEndWaitForChannel(IAsyncResult result)
        {
            return _innerChanneListener.EndWaitForChannel(result);
        }

        protected override bool OnWaitForChannel(TimeSpan timeout)
        {
            return _innerChanneListener.WaitForChannel(timeout);
        }

        public override Uri Uri
        {
            get { return _innerChanneListener.Uri; }
        }

        protected override void OnAbort()
        {
            _innerChanneListener.Abort();
        }

        protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return _innerChanneListener.BeginClose(timeout, callback, state);
        }

        protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return _innerChanneListener.BeginOpen(timeout, callback, state);
        }

        protected override void OnClose(TimeSpan timeout)
        {
            _innerChanneListener.Close(timeout);
        }

        protected override void OnEndClose(IAsyncResult result)
        {
            _innerChanneListener.EndClose(result);
        }

        protected override void OnEndOpen(IAsyncResult result)
        {
            _innerChanneListener.EndOpen(result);
        }

        protected override void OnOpen(TimeSpan timeout)
        {
            _innerChanneListener.Open(timeout);
        }
    }
}
