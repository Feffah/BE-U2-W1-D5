using BE_U2_W1_D5.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace BE_U2_W1_D5.Services
{
    public class AnagraficaService : ServiceBase
    {

        private readonly DBContext _dbContext;

        public AnagraficaService(DBContext dBContext) : base(dBContext)
        {
            _dbContext = dBContext;
        }

        public List<Anagrafica> GetAll()
        {
            return this._dbContext.Anagrafica.ToList();
        }

        public bool SaveAnagrafica(Anagrafica anagrafica)
        {
            this._dbContext.Anagrafica.Add(anagrafica);
            if (_dbContext.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Anagrafica GetAnagraficaByID(int id) {

            return _dbContext.Anagrafica.FirstOrDefault(a => a.IDAnagrafica == id);
        }

        public bool UpdateAnagrafica(Anagrafica anagrafica)
        {

            _dbContext.Anagrafica.Update(anagrafica);

            return _dbContext.SaveChanges() > 0;
        }

        public bool DeleteAnagrafica(int id)
        {
            var anagrafica = this.GetAnagraficaByID(id);
            if (anagrafica == null)
                return false;

            _dbContext.Anagrafica.Remove(anagrafica);
            return _dbContext.SaveChanges() > 0;
        }

    }
}
