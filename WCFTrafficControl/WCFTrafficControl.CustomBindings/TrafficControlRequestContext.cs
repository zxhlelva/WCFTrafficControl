using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Channels;

namespace WCFTrafficControl.CustomBindings
{
    public class TrafficControlRequestContext:RequestContext
    {
        private RequestContext _innerRequestContext;

        public TrafficControlRequestContext(RequestContext requestContext)
        {
            this._innerRequestContext = requestContext;
        }

        public override void Abort()
        {
            this._innerRequestContext.Abort();
        }

        public override IAsyncResult BeginReply(Message message, TimeSpan timeout, AsyncCallback callback, object state)
        {
            return this._innerRequestContext.BeginReply(message, timeout, callback, state);
        }

        public override IAsyncResult BeginReply(Message message, AsyncCallback callback, object state)
        {
            return this._innerRequestContext.BeginReply(message, callback, state);
        }

        public override void Close(TimeSpan timeout)
        {
            this._innerRequestContext.Close(timeout);
        }

        public override void Close()
        {
            this._innerRequestContext.Close();
        }

        public override void EndReply(IAsyncResult result)
        {
            this._innerRequestContext.EndReply(result);
        }

        public override void Reply(Message message, TimeSpan timeout)
        {
            this._innerRequestContext.Reply(message, timeout);
        }

        public override void Reply(Message message)
        {
            this._innerRequestContext.Reply(message);
        }

        public override Message RequestMessage
        {
            get { return this._innerRequestContext.RequestMessage; }
        }
    }
}
