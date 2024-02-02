using MySqlConnector;
using System.Security.Cryptography.X509Certificates;
using WebAppCrud.Common_Utility;
using WebAppCrud.CommonLayer.Model;

namespace WebAppCrud.RepositoryLayer
{
    public class CrudAppRL : ICrudAppRL
    {
        public readonly IConfiguration _configuration;
        public readonly MySqlConnection _mySqlConnection;
        public CrudAppRL(IConfiguration configuration)
        {
            _configuration = configuration;
            _mySqlConnection = new MySqlConnection(_configuration["ConnectionStrings:MySqlDBString"]);
        }
        public async Task<AddInformationResponse> AddInformation(AddInformationRequest request)
        {
            
            AddInformationResponse response = new AddInformationResponse();
            response.IsSuccess = true;
            response.Message = "Successful";
            try
            {
                if(_mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                    await _mySqlConnection.OpenAsync();
                }
                using (MySqlCommand sqlCommand = new MySqlCommand(SqlQueries.AddInformation, _mySqlConnection)) 
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue("@UserName", request.UserName);
                    sqlCommand.Parameters.AddWithValue("@EmailID", request.EmailID);
                    sqlCommand.Parameters.AddWithValue("@MobileNumber", request.MobileNumber);
                    sqlCommand.Parameters.AddWithValue("@Gender", request.Gender);
                    sqlCommand.Parameters.AddWithValue("@Salary", request.Salary);
                    int status = await sqlCommand.ExecuteNonQueryAsync();
                    if (status <= 0)
                    {
                        response.IsSuccess = false;
                        response.Message = "Query Not Executed";
                        return response;
                    }
                }
            }catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            finally
            {
                await _mySqlConnection.CloseAsync();
                await _mySqlConnection.DisposeAsync();
            }
            return response;
        }
    }
}
