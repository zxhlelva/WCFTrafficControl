using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;

namespace WCFTrafficControl.CustomBindings
{
    public class TrafficControlCustomBinding : Binding
    {
        private TransactionFlowBindingElement _transactionFlowBindingElement = new TransactionFlowBindingElement();
        private SecurityBindingElement _symmetricSecurityBindingElement = new SymmetricSecurityBindingElement();
        private TransportBindingElement _transportBindingElement = new HttpTransportBindingElement()
        {
            ManualAddressing = true
        };
        private MessageEncodingBindingElement _messageEncodingBindingElement = new WebMessageEncodingBindingElement();
        private TrafficControlBindingElement _trafficControlBindingElement = new TrafficControlBindingElement();

        public override BindingElementCollection CreateBindingElements()
        {
            BindingElementCollection elements = new BindingElementCollection();
            elements.Add(this._trafficControlBindingElement);
            elements.Add(this._messageEncodingBindingElement);
            //elements.Add(this._symmetricSecurityBindingElement);
            //elements.Add(this._transactionFlowBindingElement);
            elements.Add(this._transportBindingElement);
            return elements.Clone();
        }

        public override string Scheme
        {
            get
            {
                return this._transportBindingElement.Scheme;
            }
        }
    }
}

