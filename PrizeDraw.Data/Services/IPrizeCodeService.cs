using PrizeDraw.Data.Models;

namespace PrizeDraw.Data.Services
{
    public interface IPrizeCodeService
    {
        string GenerateCode(Person prsn);
    }
}