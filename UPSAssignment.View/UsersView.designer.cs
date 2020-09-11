namespace UPSAssignment.View
{
    partial class UsersView 
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            this.grpDetails = new System.Windows.Forms.GroupBox();
            this.grbStatus = new System.Windows.Forms.GroupBox();
            this.grbSex = new System.Windows.Forms.GroupBox();
            this.rdFemale = new System.Windows.Forms.RadioButton();
            this.rdMale = new System.Windows.Forms.RadioButton();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.grdUsers = new System.Windows.Forms.ListView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPage = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.rdInactive = new System.Windows.Forms.RadioButton();
            this.rdActive = new System.Windows.Forms.RadioButton();
            this.grpDetails.SuspendLayout();
            this.grbStatus.SuspendLayout();
            this.grbSex.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(84, 18);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(207, 20);
            this.txtID.TabIndex = 1;
            // 
            // lblID
            // 
            this.lblID.Location = new System.Drawing.Point(19, 20);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(80, 23);
            this.lblID.TabIndex = 25;
            this.lblID.Text = "ID:";
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(641, 85);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(97, 23);
            this.btnRemove.TabIndex = 10;
            this.btnRemove.Text = "&Remove User";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // grpDetails
            // 
            this.grpDetails.Controls.Add(this.grbStatus);
            this.grpDetails.Controls.Add(this.grbSex);
            this.grpDetails.Controls.Add(this.txtEmail);
            this.grpDetails.Controls.Add(this.lblEmail);
            this.grpDetails.Controls.Add(this.txtID);
            this.grpDetails.Controls.Add(this.lblID);
            this.grpDetails.Controls.Add(this.txtName);
            this.grpDetails.Controls.Add(this.lblName);
            this.grpDetails.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.grpDetails.Location = new System.Drawing.Point(12, 12);
            this.grpDetails.Name = "grpDetails";
            this.grpDetails.Size = new System.Drawing.Size(614, 144);
            this.grpDetails.TabIndex = 34;
            this.grpDetails.TabStop = false;
            this.grpDetails.Text = "User :";
            // 
            // grbStatus
            // 
            this.grbStatus.Controls.Add(this.rdActive);
            this.grbStatus.Controls.Add(this.rdInactive);
            this.grbStatus.Location = new System.Drawing.Point(321, 78);
            this.grbStatus.Name = "grbStatus";
            this.grbStatus.Size = new System.Drawing.Size(275, 55);
            this.grbStatus.TabIndex = 30;
            this.grbStatus.TabStop = false;
            this.grbStatus.Text = "Status";
            // 
            // grbSex
            // 
            this.grbSex.Controls.Add(this.rdFemale);
            this.grbSex.Controls.Add(this.rdMale);
            this.grbSex.ForeColor = System.Drawing.SystemColors.MenuText;
            this.grbSex.Location = new System.Drawing.Point(21, 79);
            this.grbSex.Name = "grbSex";
            this.grbSex.Size = new System.Drawing.Size(275, 55);
            this.grbSex.TabIndex = 29;
            this.grbSex.TabStop = false;
            this.grbSex.Text = "Sex";
            // 
            // rdFemale
            // 
            this.rdFemale.Location = new System.Drawing.Point(138, 19);
            this.rdFemale.Name = "rdFemale";
            this.rdFemale.Size = new System.Drawing.Size(67, 24);
            this.rdFemale.TabIndex = 5;
            this.rdFemale.Text = "Female";
            // 
            // rdMale
            // 
            this.rdMale.Checked = true;
            this.rdMale.Location = new System.Drawing.Point(57, 19);
            this.rdMale.Name = "rdMale";
            this.rdMale.Size = new System.Drawing.Size(53, 24);
            this.rdMale.TabIndex = 4;
            this.rdMale.TabStop = true;
            this.rdMale.Text = "Male";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(84, 46);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(207, 20);
            this.txtEmail.TabIndex = 3;
            // 
            // lblEmail
            // 
            this.lblEmail.Location = new System.Drawing.Point(19, 50);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(80, 23);
            this.lblEmail.TabIndex = 28;
            this.lblEmail.Text = "Email:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(370, 18);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(219, 20);
            this.txtName.TabIndex = 2;
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(317, 19);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(63, 23);
            this.lblName.TabIndex = 19;
            this.lblName.Text = "Name:";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(641, 3);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(97, 23);
            this.btnReset.TabIndex = 8;
            this.btnReset.Text = "&Reset";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(641, 55);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(97, 23);
            this.btnSubmit.TabIndex = 9;
            this.btnSubmit.Text = "&Update";
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // grdUsers
            // 
            this.grdUsers.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grdUsers.FullRowSelect = true;
            this.grdUsers.GridLines = true;
            this.grdUsers.HideSelection = false;
            this.grdUsers.Location = new System.Drawing.Point(0, 191);
            this.grdUsers.Name = "grdUsers";
            this.grdUsers.Size = new System.Drawing.Size(787, 285);
            this.grdUsers.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.grdUsers.TabIndex = 12;
            this.grdUsers.UseCompatibleStateImageBehavior = false;
            this.grdUsers.View = System.Windows.Forms.View.Details;
            this.grdUsers.SelectedIndexChanged += new System.EventHandler(this.grdUsers_SelectedIndexChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(641, 113);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(97, 23);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "&Search User";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblPage);
            this.panel1.Controls.Add(this.btnNext);
            this.panel1.Controls.Add(this.btnLast);
            this.panel1.Controls.Add(this.btnPrevious);
            this.panel1.Controls.Add(this.btnFirst);
            this.panel1.Location = new System.Drawing.Point(13, 476);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(750, 41);
            this.panel1.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(96, 3);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 5;
            // 
            // lblPage
            // 
            this.lblPage.AutoSize = true;
            this.lblPage.Location = new System.Drawing.Point(329, 14);
            this.lblPage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPage.Name = "lblPage";
            this.lblPage.Size = new System.Drawing.Size(0, 13);
            this.lblPage.TabIndex = 4;
            // 
            // btnNext
            // 
            this.btnNext.Image = global::UPSAssignment.View.Properties.Resources.next;
            this.btnNext.Location = new System.Drawing.Point(663, 2);
            this.btnNext.Margin = new System.Windows.Forms.Padding(2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(34, 34);
            this.btnNext.TabIndex = 3;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnLast
            // 
            this.btnLast.Image = global::UPSAssignment.View.Properties.Resources.last;
            this.btnLast.Location = new System.Drawing.Point(702, 4);
            this.btnLast.Margin = new System.Windows.Forms.Padding(2);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(38, 32);
            this.btnLast.TabIndex = 2;
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Image = global::UPSAssignment.View.Properties.Resources.previous;
            this.btnPrevious.Location = new System.Drawing.Point(46, 0);
            this.btnPrevious.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(37, 37);
            this.btnPrevious.TabIndex = 1;
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.Image = global::UPSAssignment.View.Properties.Resources.first;
            this.btnFirst.Location = new System.Drawing.Point(2, 0);
            this.btnFirst.Margin = new System.Windows.Forms.Padding(2);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(41, 38);
            this.btnFirst.TabIndex = 0;
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(641, 142);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(97, 23);
            this.btnExport.TabIndex = 36;
            this.btnExport.Text = "&Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(641, 28);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(97, 23);
            this.btnAdd.TabIndex = 37;
            this.btnAdd.Text = "&Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // rdInactive
            // 
            this.rdInactive.AutoSize = true;
            this.rdInactive.Location = new System.Drawing.Point(162, 23);
            this.rdInactive.Name = "rdInactive";
            this.rdInactive.Size = new System.Drawing.Size(63, 17);
            this.rdInactive.TabIndex = 8;
            this.rdInactive.TabStop = true;
            this.rdInactive.Text = "Inactive";
            this.rdInactive.UseVisualStyleBackColor = true;
            // 
            // rdActive
            // 
            this.rdActive.AutoSize = true;
            this.rdActive.Location = new System.Drawing.Point(49, 23);
            this.rdActive.Name = "rdActive";
            this.rdActive.Size = new System.Drawing.Size(55, 17);
            this.rdActive.TabIndex = 9;
            this.rdActive.TabStop = true;
            this.rdActive.Text = "Active";
            this.rdActive.UseVisualStyleBackColor = true;
            // 
            // UsersView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 517);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.grdUsers);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.grpDetails);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSubmit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "UsersView";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 41);
            this.Text = "User Activity";
            this.Load += new System.EventHandler(this.UsersView_Load);
            this.grpDetails.ResumeLayout(false);
            this.grpDetails.PerformLayout();
            this.grbStatus.ResumeLayout(false);
            this.grbStatus.PerformLayout();
            this.grbSex.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TextBox txtID;
        internal System.Windows.Forms.Label lblID;
        internal System.Windows.Forms.Button btnRemove;
        internal System.Windows.Forms.GroupBox grpDetails;
        internal System.Windows.Forms.TextBox txtName;
        internal System.Windows.Forms.Label lblName;
        internal System.Windows.Forms.Button btnReset;
        internal System.Windows.Forms.Button btnSubmit;
        internal System.Windows.Forms.ListView grdUsers;
        internal System.Windows.Forms.TextBox txtEmail;
        internal System.Windows.Forms.Label lblEmail;
        private  System.Windows.Forms.GroupBox grbSex;
        internal System.Windows.Forms.RadioButton rdFemale;
        internal System.Windows.Forms.RadioButton rdMale;
        internal System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPage;
        internal System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.GroupBox grbStatus;
        internal System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.RadioButton rdActive;
        private System.Windows.Forms.RadioButton rdInactive;
    }
}

