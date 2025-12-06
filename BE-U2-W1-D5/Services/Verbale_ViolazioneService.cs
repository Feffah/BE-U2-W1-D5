using BE_U2_W1_D5.Models.Entity;

namespace BE_U2_W1_D5.Services
{
     public class Verbale_ViolazioneService : ServiceBase
     {
        private readonly DBContext _dbContext;

        public Verbale_ViolazioneService(DBContext dBContext) : base(dBContext)
        {
            _dbContext = dBContext;
        }

        public List<Verbale_Violazione> GetAll()
        {
            return this._dbContext.Verbale_Violazione.ToList();
        }
    }
}

