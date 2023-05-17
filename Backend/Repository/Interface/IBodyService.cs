namespace Backend.Repository.Interface
{
    public interface IBodyService
    {
        public Task PostFileAsync(IFormFile formFile);
    }
}
