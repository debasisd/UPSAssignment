using System;
using UPSAssignment.Model;

namespace UPSAssignment.Controller
{
    public interface IUsersView
    {
        #region Methods
        void SetController(UsersController controller);
        void ClearGrid();
        void AddUserToGrid(User user);
        void UpdateGridWithChangedUser(User user);
        void RemoveUserFromGrid(User user);
        int GetIdOfSelectedUserInGrid();
        void SetSelectedUserInGrid(User user);
        void DisplayMessage(string message);

        #endregion

        #region Properties
        int TotalPages { get; set; }
        int CurrentPage { get; set; }
        User UserInfo { get; set; }
        bool CanModify { set; }
        #endregion

    }
}
