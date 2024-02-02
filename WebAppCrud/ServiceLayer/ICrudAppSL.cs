using WebAppCrud.CommonLayer.Model;

namespace WebAppCrud.ServiceLayer
{
    public interface ICrudAppSL
    {
        public Task<AddInformationResponse> AddInformation(AddInformationRequest request);
    }
}
