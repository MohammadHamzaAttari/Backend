using Backend.Data;
using Backend.Repository.Interface;

namespace Backend.Repository.Implementation
{
    public class BodyService : IBodyService
    {
        private readonly BackendDbContext _backendDbContext;

        public BodyService(BackendDbContext backendDbContext)
        {
            this._backendDbContext = backendDbContext;
        }
        public async Task PostFileAsync(IFormFile formFile)
        {
            try
            {
                var bodies = new Body
                {
                    Id = 0,
                    
                };
                using (var stream = new MemoryStream())
                {
                    formFile.CopyTo(stream);
                    bodies.Image = stream.ToArray();
                }
                var result=await _backendDbContext.AddAsync(bodies);
                await _backendDbContext.SaveChangesAsync();
            }
            catch (Exception ex) {
                throw;
            }
            
        }
    }
}
