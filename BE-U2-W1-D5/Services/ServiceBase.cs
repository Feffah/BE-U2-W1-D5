using BE_U2_W1_D5.Models.Entity;

namespace BE_U2_W1_D5.Services
{
    public abstract class ServiceBase
    {
        protected readonly DBContext _DbContext;

        protected ServiceBase(DBContext DbContext)
        {
            _DbContext = DbContext;
        }

        protected async Task<bool> SaveChangesAsync()
        {
            bool result = false;
            try
            {
                result = await _DbContext.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

            }
            return result;
        }

    }
}