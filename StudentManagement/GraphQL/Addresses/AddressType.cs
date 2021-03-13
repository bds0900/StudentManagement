using HotChocolate.Types;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.GraphQL.Addresses
{
    public class AddressType:ObjectType<Address>
    {
        protected override void Configure(IObjectTypeDescriptor<Address> descriptor)
        {
            base.Configure(descriptor);
        }

        private class Resolvers
        {
        }
    }
}
