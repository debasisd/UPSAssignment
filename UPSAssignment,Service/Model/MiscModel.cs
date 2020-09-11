using System.Collections.Generic;

namespace UPSAssignment.Service.Model
{

    public class UserInfoResponse: OperationResponse
    {
       public UserInfo UserInfo { get; set; }
    }

    public class UserListResponse : OperationResponse
    {
        public List<UserInfo> UserInfoList { get; set; }
        public Meta Meta { get; set; }
    }
}
