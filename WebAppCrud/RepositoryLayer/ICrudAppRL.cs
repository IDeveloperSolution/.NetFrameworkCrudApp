using WebAppCrud.CommonLayer.Model;

namespace WebAppCrud.RepositoryLayer
{
    public interface ICrudAppRL
    {
        public Task<AddInformationResponse> AddInformation(AddInformationRequest request);
    }
}
