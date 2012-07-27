using System.Collections.Generic;
using WCFTrafficControl.Contracts.DataContracts;
using WCFTrafficControl.Contracts.ServiceContracts;
using System.ServiceModel;

namespace WCFTrafficControl.Services
{
    [ServiceBehavior(AddressFilterMode = AddressFilterMode.Any)]
    public class OrganizitionService : IOrganizitionService
    {
        public Organizitions RetrieveOrganizitions(string alt)
        {
            return this.MockOrganizitionData();
        }

        public Organizitions RetrieveOrganizitionsWithOutput(string alt, out Organizitions output)
        {
            output = this.MockOrganizitionData();
            return this.MockOrganizitionData();
        }

        private Organizitions MockOrganizitionData()
        {
            Organizitions organizitions = new Organizitions()
            {
                ResponseLink = "http://test",
                Organizition = new List<string>()
                {
                    "Organizition1",
                    "Organizition2"
                }
            };

            return organizitions;
        }
    }
}
