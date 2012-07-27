﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCFTrafficControl.Contracts.DataContracts;

namespace WCFTrafficControl.Contracts.ServiceContracts
{
    [ServiceContract]
    public interface IOrganizitionService
    {
        [WebGet]
        Organizitions RetrieveOrganizitions(string alt);

        [WebGet(BodyStyle = WebMessageBodyStyle.Wrapped)]
        Organizitions RetrieveOrganizitionsWithOutput(string alt, out Organizitions output);
    }
}
