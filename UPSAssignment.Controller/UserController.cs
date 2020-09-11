using System.Collections;
using UPSAssignment.Model;
using UPSAssignment.Service;
using System.Collections.Generic;
using UPSAssignment.Service.Model;
using System.Threading.Tasks;
using System.Text;
using System.IO;
using System.Configuration;

namespace UPSAssignment.Controller
{
    public class UsersController
    {
        IUsersView _userView;
        IList _users;
        User _selectedUser;
        IService _service;
       

        public UsersController(IUsersView userView)
        {
            _userView = userView;
            _userView.UserInfo = new User("", 0, "", User.SexOfPerson.Male, User.UserStatus.Active);

            userView.SetController(this);
            _service = new UPSAssignment.Service.Service();
            _service.SetConfiguration(ConfigurationManager.AppSettings["ServiceApiURL"].ToString(), ConfigurationManager.AppSettings["ApiToken"].ToString());
        }
        private void UpdateViewDetailValues(User user)
        {
            _userView.UserInfo = user;

        }
        private void UpdateUserWithViewValues(User user)
        {
            var userInfo = _userView.UserInfo;
            user.Name = userInfo.Name;
            user.ID = userInfo.ID;
            user.Email = userInfo.Email;
            user.Gender = userInfo.Gender;
            user.Status = userInfo.Status;
        }
        public async Task LoadView(int pageno)
        {
            try
            {
                _userView.ClearGrid();
                _users = await this.GetUserList(pageno);


                foreach (User usr in _users)
                    _userView.AddUserToGrid(usr);
                if (_users.Count > 0)
                    _userView.SetSelectedUserInGrid((User)_users[0]);

            }
            catch
            {
                throw;
            }

        }
        public void SelectedUserChanged(int selectedUserId)
        {
            try
            {
                foreach (User usr in this._users)
                {
                    if (usr.ID == selectedUserId)
                    {
                        _selectedUser = usr;
                        UpdateViewDetailValues(usr);
                        _userView.SetSelectedUserInGrid(usr);
                        this._userView.CanModify = false;
                        break;
                    }
                }
            }
            catch
            {

                throw;
            }
        }
        public void AddNewUser()
        {
            _selectedUser = new User("" /*lastname*/,
                                     0  /*id*/,
                                     "" /*department*/,
                                     User.SexOfPerson.Male /*sex*/,
                                    User.UserStatus.Active);

            this.UpdateViewDetailValues(_selectedUser);
            this._userView.CanModify = true;
        }
        public async Task SearchUser()
        {
            try
            {
                UpdateUserWithViewValues(_selectedUser);
                _userView.ClearGrid();
                _users = await Search(_selectedUser);
                foreach (User usr in _users)
                    _userView.AddUserToGrid(usr);
                if (_users.Count > 0)
                    _userView.SetSelectedUserInGrid((User)_users[0]);

            }
            catch
            {
                throw;
            }
        }
        public async Task RemoveUser()
        {
            int id = this._userView.GetIdOfSelectedUserInGrid();
            User userToRemove = null;

            if (id != 0)
            {
                foreach (User usr in this._users)
                {
                    if (usr.ID == id)
                    {
                        userToRemove = usr;
                        break;
                    }
                }

                if (userToRemove != null)
                {
                    await Delete(userToRemove.ID);
                    //int newSelectedIndex = this._users.IndexOf(userToRemove);
                    //this._users.Remove(userToRemove);
                    //this._view.RemoveUserFromGrid(userToRemove);

                    //if (newSelectedIndex > -1 && newSelectedIndex < _users.Count)
                    //{
                    //    this._view.SetSelectedUserInGrid((User)_users[newSelectedIndex]);
                    //}
                }
            }
        }
        public async Task SaveUser()
        {
            UpdateUserWithViewValues(_selectedUser);
            if (!this._users.Contains(_selectedUser))
            {
                await Save(_selectedUser);
            }
            else
            {
                await Save(_selectedUser);
            }
            _userView.SetSelectedUserInGrid(_selectedUser);
            this._userView.CanModify = false;

        }

        #region Controller calling services
        public async Task Save(User user)
        {
            var response = await _service.SaveUser(user);
            await LoadView(_userView.CurrentPage);
            if (!response.IsSuccess)
                _userView.DisplayMessage(response.ErrorInfo);
        }

        public async Task Delete(int userId)
        {
            var response = await _service.DeleteUser(userId);
            await LoadView(_userView.CurrentPage);
            if (!response.IsSuccess)
            {
                _userView.DisplayMessage(response.ErrorInfo);
            }
        }

        public async Task<List<User>> Search(User user)
        {
            List<User> users = new List<User>();
            try
            {
                var response = await _service.SearchUser(user);
                if (response.IsSuccess)
                {
                    _userView.TotalPages = response.Meta.Pagination.Pages;
                    response.UserInfoList.ForEach(
                        i => users.Add(new User(i.Name, i.Id, i.Email, i.Gender.ToLower() == "male" ? User.SexOfPerson.Male : User.SexOfPerson.Female, i.Status.ToLower() == "active" ? User.UserStatus.Active : User.UserStatus.Inactive)));
                }
            }
            catch { throw; }
            return users;
        }



        public async Task<List<User>> GetUserList(int pageno)
        {
            List<User> users = new List<User>();
            try
            {
                var response = await _service.GetUserList(pageno);
                if (response.IsSuccess)
                {
                    _userView.TotalPages = response.Meta.Pagination.Pages;
                    response.UserInfoList.ForEach(
                        i => users.Add(new User(i.Name, i.Id, i.Email, i.Gender.ToLower() == "male" ? User.SexOfPerson.Male : User.SexOfPerson.Female,
                        i.Status.ToLower() == "active" ? User.UserStatus.Active : User.UserStatus.Inactive, i.Created_At, i.Updated_At)));
                }
            }
            catch { throw; }
            return users;
        }

        public async Task<bool> ExportToCSV(string fileToWrite)
        {

            int currentPage = 1;
            int totalPage = 0;

            do
            {
                var serviceResponse = await _service.GetUserList(currentPage);
                if (serviceResponse.IsSuccess)
                {
                    List<UserInfo> exportList = serviceResponse.UserInfoList;
                    totalPage = serviceResponse.Meta.Pagination.Pages;
                    bool isExportSuccess = ExportCSV(exportList, fileToWrite, currentPage == 1);
                }
                else
                {
                    ////KEEP PULLING FOR REST PAGES 
                    ////LOG ERROR
                }
                currentPage++;
            } while (currentPage < totalPage);
            return true;
        }

        private bool ExportCSV<T>(List<T> genericList, string finalPath, bool withHeader)
        {
            var sb = new StringBuilder();
            var header = "";
            var info = typeof(T).GetProperties();

            if (withHeader)
            {
                foreach (var prop in typeof(T).GetProperties())
                {
                    header += prop.Name + ", ";
                }
                header = header.Substring(0, header.Length - 2);
                sb.AppendLine(header);
            }

            foreach (var obj in genericList)
            {
                var line = "";
                foreach (var prop in info)
                {
                    line += prop.GetValue(obj, null) + ", ";
                }
                line = line.Substring(0, line.Length - 2);
                sb.AppendLine(line);
            }
            using (var sw = new StreamWriter(finalPath, true))
            {
                sw.Write(sb.ToString());
                sw.Close();
            }
            return true;
        }

        #endregion
    }
    //public static class PageGlobVar
    //{
    //    public static int TotalRec; //Variable for getting Total Records of the Table
    //    public static int NRPP; //Variable for Setting the Number of Recrods per listiview page
    //    public static int Page; //List View Page for Navigate or move
    //    public static int TotalPages; //Varibale for Counting Total Pages.
    //    public static int RecStart; //Variable for Getting Every Page Starting Record Index
    //    public static int RecEnd; //Variable for Getting Every Page End Record Index
    //}
}
