using System;
using System.Text;
using System.Windows.Forms;
using UPSAssignment.Controller;
using UPSAssignment.Model;
using LogManager;
using System.IO;
using UPSAssignment.View.Resources;

namespace UPSAssignment.View
{
    public partial class UsersView : Form, IUsersView
    {
        Logger _logger = new Logger();
        UsersController _controller;

        public UsersView()
        {
            InitializeComponent();
            this.CurrentPage = 1;
        }

        #region Events raised  back to controller
        private void btnReset_Click(object sender, EventArgs e)
        {
            _logger.LogTrace("Calling btnReset_Click.");
            try
            {
                this._controller.AddNewUser();
            }
            catch (Exception ex)
            {
                _logger.LogException(ex);
            }
            finally
            {
                _logger.LogTrace("End of btnReset_Click.");
            }
        }
        private async void btnRemove_Click(object sender, EventArgs e)
        {
            _logger.LogTrace("Calling btnRemove_Click.");
            try
            {
                await this._controller.RemoveUser();
            }
            catch (Exception ex)
            {
                _logger.LogException(ex);
            }
            finally
            {
                _logger.LogTrace("End of btnRemove_Click.");
            }

        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            _logger.LogTrace("Calling btnSubmit_Click.");
            try
            {
                string validateInput = ValidateModel();
                if (string.IsNullOrEmpty(validateInput))
                {
                    await this._controller.SaveUser();
                }
                else
                {
                    DisplayMessage(validateInput);
                }
                
            }
            catch (Exception ex)
            {
                _logger.LogException(ex);
            }
            finally
            {
                _logger.LogTrace("End of btnSubmit_Click.");
            }


        }


        private async void btnAdd_Click(object sender, EventArgs e)
        {
            _logger.LogTrace("Calling btnAdd_Click.");
            try
            {
                //To make sure it will perform the add operation, so id is set to 0;
                this.ID = 0;
                await this._controller.SaveUser();
            }
            catch (Exception ex)
            {
                _logger.LogException(ex);
            }
            finally
            {
                _logger.LogTrace("End of btnAdd_Click.");
            }
        }



        private void grdUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            _logger.LogTrace("Calling grdUsers_SelectedIndexChanged.");
            try
            {
                if (this.grdUsers.SelectedItems.Count > 0)
                    this._controller.SelectedUserChanged(Convert.ToInt32(this.grdUsers.SelectedItems[0].Text));
            }
            catch (Exception ex)
            {
                _logger.LogException(ex);
            }
            finally
            {
                _logger.LogTrace("End of grdUsers_SelectedIndexChanged.");
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            _logger.LogTrace("Calling  btnSearch_Click.");
            try
            {
                CurrentPage = 1;
                await this._controller.SearchUser();
            }
            catch (Exception ex)
            {
                _logger.LogException(ex);
            }
            finally
            {
                _logger.LogTrace("End of  btnSearch_Click.");
            }

        }

        private async void btnFirst_Click(object sender, EventArgs e)
        {
            _logger.LogTrace("Calling  button.");
            try
            {
                this.CurrentPage = 1;
                await this._controller.LoadView(CurrentPage);
            }
            catch (Exception ex)
            {
                _logger.LogException(ex);
            }
            finally
            {
                _logger.LogTrace("End of  button.");
            }


        }

        private async void btnPrevious_Click(object sender, EventArgs e)
        {
            _logger.LogTrace("Calling  btnPrevious_Click.");
            try
            {
                if (this.CurrentPage > 1)
                {
                    this.CurrentPage--;
                    await this._controller.LoadView(CurrentPage);
                }
            }
            catch (Exception ex)
            {
                _logger.LogException(ex);
            }
            finally
            {
                _logger.LogTrace("End of btnPrevious_Click.");
            }

        }

        private async void btnNext_Click(object sender, EventArgs e)
        {
            _logger.LogTrace("Calling  btnNext_Click.");
            try
            {
                if (this.CurrentPage < TotalPages)
                {
                    this.CurrentPage++;
                    await this._controller.LoadView(CurrentPage);
                }
            }
            catch (Exception ex)
            {
                _logger.LogException(ex);
            }
            finally
            {
                _logger.LogTrace("End of btnNext_Click.");
            }

        }

        private async void btnLast_Click(object sender, EventArgs e)
        {
            _logger.LogTrace("Calling btnLast_Click.");
            try
            {
                this.CurrentPage = TotalPages;
                await this._controller.LoadView(CurrentPage);
            }
            catch (Exception ex)
            {
                _logger.LogException(ex);
            }
            finally
            {
                _logger.LogTrace("End of btnLast_Click.");
            }

        }

        private void UsersView_Load(object sender, EventArgs e)
        {

        }

        private string ValidateModel()
        {
            StringBuilder sb = new StringBuilder();
            if (string.IsNullOrEmpty(this.Email))
            {
                sb.AppendLine(Messages.EmailRequired);
            }
            else if (!IsValidEmail(this.Email))
            {
                sb.AppendLine(Messages.EmailFormat);
            }
            if (string.IsNullOrEmpty(this.Name))
            {
                sb.AppendLine(Messages.EnterName);
            }
            return sb.ToString();
        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private async void btnExport_Click(object sender, EventArgs e)
        {
            _logger.LogTrace("Calling btnExport_Click.");
            try
            {
                string fileName = $"UserRecords_{DateTime.Now.ToString("yyyyMMddHHmmss")}";
                var basePath = AppDomain.CurrentDomain.BaseDirectory;
                var fileToWrite = Path.Combine(basePath, fileName + ".csv");
                if (!File.Exists(fileToWrite))
                {
                    var file = File.Create(fileToWrite);
                    file.Close();
                }
                bool exportSuccess = await _controller.ExportToCSV(fileToWrite);
                if (exportSuccess)
                {
                    DisplayMessage($"{Messages.SuccessfullyFileGenerated + " " + fileToWrite}");
                }
                else
                {
                    DisplayMessage($"{ UPSAssignment.View.Resources.Messages.ExportError}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogException(ex);
            }
            finally { _logger.LogTrace("Calling btnExport_Click."); }
        }
        #endregion

        #region IUserview implementation

        public void SetController(UsersController controller)
        {
            _controller = controller;
        }

        public void ClearGrid()
        {
            // Define columns in grid
            this.grdUsers.Columns.Clear();

            this.grdUsers.Columns.Add("Id", 150, HorizontalAlignment.Left);
            this.grdUsers.Columns.Add("Name", 150, HorizontalAlignment.Left);
            this.grdUsers.Columns.Add("Email", 150, HorizontalAlignment.Left);
            this.grdUsers.Columns.Add("Sex", 50, HorizontalAlignment.Left);
            this.grdUsers.Columns.Add("Status", 50, HorizontalAlignment.Left);
            // Add rows to grid
            this.grdUsers.Items.Clear();
        }

        public void AddUserToGrid(User usr)
        {
            ListViewItem parent;
            parent = this.grdUsers.Items.Add(usr.ID.ToString());
            parent.SubItems.Add(usr.Name);
            parent.SubItems.Add(usr.Email);
            parent.SubItems.Add(Enum.GetName(typeof(User.SexOfPerson), usr.Gender));
            parent.SubItems.Add(Enum.GetName(typeof(User.UserStatus), usr.Status));
        }

        public void UpdateGridWithChangedUser(User usr)
        {
            ListViewItem rowToUpdate = null;

            foreach (ListViewItem row in this.grdUsers.Items)
            {
                if (row.Text == usr.ID.ToString())
                {
                    rowToUpdate = row;
                }
            }

            if (rowToUpdate != null)
            {
                rowToUpdate.Text = usr.ID.ToString();
                rowToUpdate.SubItems[1].Text = usr.Name;

                rowToUpdate.SubItems[2].Text = usr.Email;
                rowToUpdate.SubItems[3].Text = Enum.GetName(typeof(User.SexOfPerson), usr.Gender);

                rowToUpdate.SubItems[4].Text = Enum.GetName(typeof(User.UserStatus), usr.Status);
            }
        }

        public void RemoveUserFromGrid(User usr)
        {
            ListViewItem rowToRemove = null;
            foreach (ListViewItem row in this.grdUsers.Items)
            {
                if (row.Text == usr.ID.ToString())
                {
                    rowToRemove = row;
                }
            }
            if (rowToRemove != null)
            {
                this.grdUsers.Items.Remove(rowToRemove);
                this.grdUsers.Focus();
            }
        }

        public int GetIdOfSelectedUserInGrid()
        {
            if (this.grdUsers.SelectedItems.Count > 0)
                return Convert.ToInt32(this.grdUsers.SelectedItems[0].Text);
            else
                return 0;
        }

        public void SetSelectedUserInGrid(User usr)
        {
            foreach (ListViewItem row in this.grdUsers.Items)
            {
                if (row.Text == usr.ID.ToString())
                {
                    row.Selected = true;
                }
            }
        }

        public string Name
        {
            get { return this.txtName.Text; }
            set { this.txtName.Text = _user?.Name; }
        }

        public int ID
        {
            get { return this.txtID.Text == string.Empty ? 0 : Convert.ToInt32(txtID.Text); }
            set { this.txtID.Text = _user?.ID.ToString(); }
        }


        public string Email
        {
            get { return this.txtEmail.Text; }
            set { this.txtEmail.Text = _user?.Email; }
        }

        public User.SexOfPerson Sex
        {
            get
            {
                if (this.rdMale.Checked)
                    return User.SexOfPerson.Male;
                if (this.rdFemale.Checked)
                    return User.SexOfPerson.Female;
                return User.SexOfPerson.NA;
            }
            set
            {
                if (_user?.Gender == User.SexOfPerson.Male)
                    this.rdMale.Checked = true;
                if (_user?.Gender == User.SexOfPerson.Female)
                    this.rdFemale.Checked = true;
            }
        }

        private int _totalPages;

        public int TotalPages
        {
            get { return _totalPages; }

            set
            {
                this.lblPage.Text = CurrentPage + " of pages " + value;
                _totalPages = value;
            }
        }

        private int _currentPage;
        public int CurrentPage
        {
            get { return _currentPage; }
            set { _currentPage = value; }
        }
        public void DisplayMessage(string message)
        {
            MessageBox.Show(message);
        }

        public bool CanModify
        {
            set { this.txtID.Enabled = value;
                this.btnAdd.Enabled = value;
                this.btnSubmit.Enabled = !value;
            }
        }

        public User.UserStatus Status
        {
            get
            {
                if (this.rdActive.Checked)
                    return User.UserStatus.Active;
                if (this.rdInactive.Checked)
                    return User.UserStatus.Inactive;
                return User.UserStatus.NA;
            }
            set
            {
                if (_user?.Status == User.UserStatus.Active)
                    this.rdActive.Checked = true;
                if (_user?.Status == User.UserStatus.Inactive)
                    this.rdInactive.Checked = true;
            }
        }

        private User _user;
        public User UserInfo
        {
            get { return new User(Name, ID, Email, Sex, Status); }// "", "", User.SexOfPerson.Male, User.UserStatus.Active);
            set
            {
                _user = value;
                PopulateView();
            }
        }


        #endregion

        private void PopulateView()
        {
            if (_user?.Status == User.UserStatus.Active)
                this.rdActive.Checked = true;
            if (_user?.Status == User.UserStatus.Inactive)
                this.rdInactive.Checked = true;
            if (_user?.Status == User.UserStatus.NA)
            {
                this.rdActive.Checked = false;
                this.rdInactive.Checked = false;
            }

            if (_user?.Gender == User.SexOfPerson.Male)
                this.rdMale.Checked = true;
            if (_user?.Gender == User.SexOfPerson.Female)
                this.rdFemale.Checked = true;
            if (_user?.Gender == User.SexOfPerson.NA)
            {
                this.rdMale.Checked = false;
                this.rdFemale.Checked = false;
            }

            this.txtEmail.Text = _user?.Email;
            this.txtID.Text = _user?.ID.ToString();
            this.txtName.Text = _user?.Name;
        }


    }


}
