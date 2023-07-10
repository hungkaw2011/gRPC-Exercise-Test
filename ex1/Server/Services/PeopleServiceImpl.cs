using Grpc.Core;
using gRPC_Server.Data;
using gRPC_Server.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PeopleService;

namespace gRPC_Server.Services
{
    public class PeopleServiceImpl : PeopleServiceBase
    {
        public override async Task<Person> CreatePerson(CreatePersonRequest request, ServerCallContext context)
        {
            using var ctx = new ServerDbContext();
            var dbPerson = new DbPerson
            {
                LastName = request.LastName,
                Name = request.FirstName,
            };
            ctx.Person.Add(dbPerson);
            await ctx.SaveChangesAsync();

            return new Person { LastName = request.LastName, FirstName = request.FirstName, Id = dbPerson.Id };
        }
    }
}
