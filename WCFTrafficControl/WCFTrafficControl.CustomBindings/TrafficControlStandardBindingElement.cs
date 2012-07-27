using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Configuration;

namespace WCFTrafficControl.CustomBindings
{
    public class TrafficControlStandardBindingElement:StandardBindingElement
    {
        protected override Type BindingElementType
        {
            get { return typeof(TrafficControlCustomBinding); }
        }

        protected override void OnApplyConfiguration(System.ServiceModel.Channels.Binding binding)
        {
        }
    }
}
