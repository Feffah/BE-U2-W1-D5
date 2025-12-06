using BE_U2_W1_D5.Models.Entity;

namespace BE_U2_W1_D5.Services
{
    public class TipoViolazioneService : ServiceBase
    {

        private readonly DBContext _dbContext;
        public TipoViolazioneService(DBContext dBContext) : base(dBContext)
        {
            _dbContext = dBContext;
        }
        public List<TipoViolazione> GetAll()
        {
            return this._dbContext.TipoViolazione.ToList();
        }
    }
}
