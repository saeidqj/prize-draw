using PrizeDraw.Data.Models;

namespace PrizeDraw.Data.Services
{
    public interface IPersonService
    {
        Person Register(Person prsn);
    }
}