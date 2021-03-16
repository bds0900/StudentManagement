using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.GraphQL
{
    public class Subscription
    {
        [Subscribe]
        [Topic]
        public Models.Program OnProgramAdd([EventMessage] Models.Program program)
        {
            return program; 
        }
    }
}
