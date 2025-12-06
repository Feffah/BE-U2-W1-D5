using BE_U2_W1_D5.Models.Entity;

namespace BE_U2_W1_D5.Services
{
    public class VerbaleService : ServiceBase
    {
        private readonly DBContext _dbContext;

        public VerbaleService(DBContext dBContext) : base(dBContext)
        {
            _dbContext = dBContext;
        }
        public List<Verbale> GetAll()
        {
            return this._dbContext.Verbale.ToList();
        }

        public bool SaveVerbale(Verbale verbale)
        {
            this._dbContext.Verbale.Add(verbale);
            if (_dbContext.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Verbale GetVerbaleByID(int id)
        {

            return _dbContext.Verbale.FirstOrDefault(a => a.IDVerbale == id);
        }

        public bool UpdateVerbale(Verbale verbale)
        {

            _dbContext.Verbale.Update(verbale);

            return _dbContext.SaveChanges() > 0;
        }

        public bool DeleteVerbale(int id)
        {
            var verbale = this.GetVerbaleByID(id);
            if (verbale == null)
                return false;

            _dbContext.Verbale.Remove(verbale);
            return _dbContext.SaveChanges() > 0;
        }
    }
}
