using System;
using System.Collections.Generic;
using System.Text;
using PrizeDraw.Data.DataLayer;
using PrizeDraw.Data.Models;
using System.Linq;

namespace PrizeDraw.Data.Services
{
    public class PersonService : IPersonService
    {
        private PZDataContext dbContext { set; get; }
        private IPrizeCodeService codeService;

        public PersonService(PZDataContext context, IPrizeCodeService _codeservice)
        {
            this.dbContext = context;
            codeService = _codeservice;
        }

        public Person Register(Person prsn)
        {

            if (dbContext.Persons.Any(m => m.Phone == prsn.Phone))
                throw new PropertyIsRepititive(nameof(Person.Phone), "شماره تلفن");
            if (dbContext.Persons.Any(m => m.InstaId == prsn.InstaId))
                throw new PropertyIsRepititive(nameof(Person.InstaId), "آیدی اینستا");
           /* if (dbContext.Persons.Any(m => m.Phone == prsn.Phone))
                throw new PropertyIsRepititive(nameof(Person.), "شماره تلفن");*/
            var entry =  dbContext.Persons.Add(new Person {
             Family = prsn.Family,
             InstaId= prsn.InstaId,
             Name= prsn.Name,
             Phone = prsn.Phone

            });

            dbContext.SaveChanges();
            prsn = entry.Entity;
            prsn.PrizeCode = codeService.GenerateCode(prsn);
            dbContext.SaveChanges();
            return prsn;
        }
    }
}
