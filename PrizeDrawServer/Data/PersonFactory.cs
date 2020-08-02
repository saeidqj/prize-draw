using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrizeDraw.Data.Services;
using PrizeDraw.Data.Models;
using PrizeDraw.Data;

namespace PrizeDrawServer.Data
{
    public class RegisterResult
    {
        public bool Successed { get; set; }
        public bool HasError { get; set; }
        public string ErrorMessage { get; set; }
        public string PrizeCode { get; set; }
    }
    public class PersonFactory
    {
        public IPersonService _personService;
        
        public PersonFactory(IPersonService prsnsrvce)
        {
            _personService = prsnsrvce;
        }

        public RegisterResult RegisterUserNdGetCode(Person prsn)
        {
            RegisterResult res = new RegisterResult();
            try
            {
                var cod= _personService.Register(prsn).PrizeCode;
                res.Successed = true;
                res.PrizeCode = cod;
            }
            catch (PropertyIsRepititive ex)
            {
                res.Successed = false;
                res.ErrorMessage = ex.ErrorMessage;
            }
            return res;
        }
    }
}
