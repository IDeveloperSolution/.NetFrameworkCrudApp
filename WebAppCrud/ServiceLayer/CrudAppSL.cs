using WebAppCrud.CommonLayer.Model;
using WebAppCrud.RepositoryLayer;

namespace WebAppCrud.ServiceLayer
{
    public class CrudAppSL : ICrudAppSL
    {
        public readonly ICrudAppRL _crudAppRL;

            public CrudAppSL(ICrudAppRL crudAppRL) {
            _crudAppRL=crudAppRL; //dependancy injections
        }

        public async Task<AddInformationResponse> AddInformation(AddInformationRequest request)
        {
           return await _crudAppRL.AddInformation(request);
        }
    }
}
