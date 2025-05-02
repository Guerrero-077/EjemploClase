using DataGeneric.RepositoryDataGeneric;
using Entity.context;
using Entity.Models;
using Microsoft.Extensions.Logging;

namespace Data.RepositoryData;

public class PersonRepository : DataGeneric<PersonRepository>
{
    public PersonRepository(AplicationDbContext context) : base(context)
    {
        
    }
}
