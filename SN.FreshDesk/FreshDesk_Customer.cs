using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SN.FreshDesk.Models;

namespace SN.FreshDesk
{
    public partial class FreshDesk
    {
        /// <summary>
        /// Gets list of all customers
        /// </summary>
        /// <returns></returns>
        public async Task<List<customer>> GetCustomers()
        {
            var relativeUrl = "/customers.json";
            var x =  await SendGetRequest<SN.FreshDesk.Models.Responses.response_customer[]>(relativeUrl);
            return  x.Select(f => f.customer).ToList();
        }
    }
}
