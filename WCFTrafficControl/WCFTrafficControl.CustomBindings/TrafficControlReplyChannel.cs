using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;

namespace WCFTrafficControl.CustomBindings
{
    public class TrafficControlReplyChannel : IReplyChannel
    {
        private IReplyChannel _innerChannel;

        public TrafficControlReplyChannel(IReplyChannel replyChannel)
        {
            this._innerChannel = replyChannel;
        }

        public IAsyncResult BeginReceiveRequest(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return this._innerChannel.BeginReceiveRequest(timeout, callback, state);
        }

        public IAsyncResult BeginReceiveRequest(AsyncCallback callback, object state)
        {
            return this._innerChannel.BeginReceiveRequest(callback, state);
        }

        public IAsyncResult BeginTryReceiveRequest(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return this._innerChannel.BeginTryReceiveRequest(timeout, callback, state);
        }

        public IAsyncResult BeginWaitForRequest(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return this._innerChannel.BeginWaitForRequest(timeout, callback, state);
        }

        public RequestContext EndReceiveRequest(IAsyncResult result)
        {
            return this._innerChannel.EndReceiveRequest(result);
        }

        public bool EndTryReceiveRequest(IAsyncResult result, out RequestContext context)
        {
            bool endTryReceiveRequestResult = this._innerChannel.EndTryReceiveRequest(result, out context);
            context = new TrafficControlRequestContext(context);
            string accessToken = context.RequestMessage.Headers.To.Query[0].ToString();
            return endTryReceiveRequestResult;
        }

        public bool EndWaitForRequest(IAsyncResult result)
        {
            return this._innerChannel.EndWaitForRequest(result);
        }

        public System.ServiceModel.EndpointAddress LocalAddress
        {
            get { return this._innerChannel.LocalAddress; }
        }

        public RequestContext ReceiveRequest(TimeSpan timeout)
        {
            Console.WriteLine("Receive request with time out");
            RequestContext innerRequestContext = this._innerChannel.ReceiveRequest(timeout);
            return new TrafficControlRequestContext(innerRequestContext);
        }

        public RequestContext ReceiveRequest()
        {
            Console.WriteLine("Receive request");
            RequestContext innerRequestContext = this._innerChannel.ReceiveRequest();
            return new TrafficControlRequestContext(innerRequestContext);
        }

        public bool TryReceiveRequest(TimeSpan timeout, out RequestContext context)
        {
            return this._innerChannel.TryReceiveRequest(timeout, out context);
        }

        public bool WaitForRequest(TimeSpan timeout)
        {
            return this._innerChannel.WaitForRequest(timeout);
        }

        public T GetProperty<T>() where T : class
        {
            return this._innerChannel.GetProperty<T>();
        }

        public void Abort()
        {
            this._innerChannel.Abort();
        }

        public IAsyncResult BeginClose(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return this._innerChannel.BeginClose(timeout, callback, state);
        }

        public IAsyncResult BeginClose(AsyncCallback callback, object state)
        {
            return this._innerChannel.BeginClose(callback, state);
        }

        public IAsyncResult BeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return this._innerChannel.BeginOpen(timeout, callback, state);
        }

        public IAsyncResult BeginOpen(AsyncCallback callback, object state)
        {
            return this._innerChannel.BeginOpen(callback, state);
        }

        public void Close(TimeSpan timeout)
        {
            this._innerChannel.Close(timeout);
        }

        public void Close()
        {
            this._innerChannel.Close();
        }

        public event EventHandler Closed;

        public event EventHandler Closing;

        public void EndClose(IAsyncResult result)
        {
            this._innerChannel.EndClose(result);
        }

        public void EndOpen(IAsyncResult result)
        {
            this._innerChannel.EndOpen(result);
        }

        public event EventHandler Faulted;

        public void Open(TimeSpan timeout)
        {
            this._innerChannel.Open(timeout);
        }

        public void Open()
        {
            this._innerChannel.Open();
        }

        public event EventHandler Opened;

        public event EventHandler Opening;

        public System.ServiceModel.CommunicationState State
        {
            get { return this._innerChannel.State; }
        }
    }
}
