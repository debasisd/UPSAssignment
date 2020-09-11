using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPSAssignment.Model;
using UPSAssignment.Service.Model;

namespace UPSAssignment.Service
{
    public interface IService
    {
        Task<UserInfoResponse> GetUser(int userId);
        Task<OperationResponse> SaveUser(User user);

        Task<OperationResponse> DeleteUser(int userId);

        Task<UserListResponse> SearchUser(User user);

        Task<UserListResponse> GetUserList(int pageno);
        void SetConfiguration(string URL, string ApiKey);
        
    }
}
