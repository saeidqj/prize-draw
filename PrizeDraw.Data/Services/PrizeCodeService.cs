using System;
using System.Collections.Generic;
using System.Text;
using PrizeDraw.Data.DataLayer;
using PrizeDraw.Data.Models;

namespace PrizeDraw.Data.Services
{
    public class PrizeCodeService : IPrizeCodeService
    {
        private PZDataContext dbcontext { get; set; }
        public PrizeCodeService(PZDataContext context)
        {
            this.dbcontext = context;
        }

        /// <summary>
        /// bayad bad azinke karbar zakhire shod ino estefade konim, ta az doplicate jologiri shavad
        /// </summary>
        /// <param name="prsn"></param>
        /// <returns></returns>
        public string GenerateCode(Person prsn)
        {
            return $"{prsn.Name[0].ToString() + prsn.Family[0].ToString()}{prsn.Id.ToString()}";
        }
    }
}
