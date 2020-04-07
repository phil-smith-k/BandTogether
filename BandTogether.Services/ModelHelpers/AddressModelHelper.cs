using BandTogether.Data.Entities;
using BandTogether.Models.SchoolModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandTogether.Services.ModelHelpers
{
    public class AddressModelHelper
    {
        public Address BuildAddress(SchoolCreate model)
        {
            var address = new Address();

            address.StreetAddress = model.StreetAddress;
            address.City = model.City;
            address.State = model.State;
            address.ZipCode = model.ZipCode;

            return address;
        }
    }
}
