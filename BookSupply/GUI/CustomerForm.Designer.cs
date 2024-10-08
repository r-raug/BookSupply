namespace BookSupply.GUI
{
    partial class CustomerForm
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
            System.Windows.Forms.ColumnHeader columnHeader11;
            this.Employee = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.listViewCustomers = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonListAllC = new System.Windows.Forms.Button();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.comboBoxProvince = new System.Windows.Forms.ComboBox();
            this.textBoxCredit = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.textBoxPostalCode = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.textBoxStreet = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.buttonSaveC = new System.Windows.Forms.Button();
            this.textBoxCustomerName = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.textBoxPhoneC = new System.Windows.Forms.TextBox();
            this.textBoxEmailC = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.comboBoxProvinceU = new System.Windows.Forms.ComboBox();
            this.textBoxPostalCodeU = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.textBoxStreetU = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.textBoxCustomerId = new System.Windows.Forms.TextBox();
            this.buttonUpdateCust = new System.Windows.Forms.Button();
            this.label34 = new System.Windows.Forms.Label();
            this.textBoxPhoneCustU = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.textBoxEmailCustU = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label38 = new System.Windows.Forms.Label();
            this.comboBoxSearchC = new System.Windows.Forms.ComboBox();
            this.buttonSearchCust = new System.Windows.Forms.Button();
            this.textBoxSearchC = new System.Windows.Forms.TextBox();
            this.labelSearch1C = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.textBoxCustomerIdToDelete = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.buttonCustDelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCustomerNameU = new System.Windows.Forms.TextBox();
            columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Employee.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // columnHeader11
            // 
            columnHeader11.Text = "Postal Code";
            columnHeader11.Width = 87;
            // 
            // Employee
            // 
            this.Employee.Controls.Add(this.tabPage1);
            this.Employee.Location = new System.Drawing.Point(47, 13);
            this.Employee.Name = "Employee";
            this.Employee.SelectedIndex = 0;
            this.Employee.Size = new System.Drawing.Size(707, 539);
            this.Employee.TabIndex = 18;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonLogout);
            this.tabPage1.Controls.Add(this.listViewCustomers);
            this.tabPage1.Controls.Add(this.buttonListAllC);
            this.tabPage1.Controls.Add(this.tabControl3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(699, 513);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Customer Management";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonLogout
            // 
            this.buttonLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogout.Location = new System.Drawing.Point(619, 5);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(75, 32);
            this.buttonLogout.TabIndex = 26;
            this.buttonLogout.Text = "LogOut";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // listViewCustomers
            // 
            this.listViewCustomers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            columnHeader11,
            this.columnHeader12});
            this.listViewCustomers.HideSelection = false;
            this.listViewCustomers.Location = new System.Drawing.Point(24, 318);
            this.listViewCustomers.Name = "listViewCustomers";
            this.listViewCustomers.Size = new System.Drawing.Size(655, 175);
            this.listViewCustomers.TabIndex = 22;
            this.listViewCustomers.UseCompatibleStateImageBehavior = false;
            this.listViewCustomers.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Customer ID";
            this.columnHeader3.Width = 93;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Custumer Name";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Phone Number";
            this.columnHeader7.Width = 107;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Email";
            this.columnHeader8.Width = 142;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Street";
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Province";
            this.columnHeader10.Width = 71;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Status";
            // 
            // buttonListAllC
            // 
            this.buttonListAllC.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonListAllC.Location = new System.Drawing.Point(26, 225);
            this.buttonListAllC.Name = "buttonListAllC";
            this.buttonListAllC.Size = new System.Drawing.Size(94, 48);
            this.buttonListAllC.TabIndex = 21;
            this.buttonListAllC.Text = "List All Customers";
            this.buttonListAllC.UseVisualStyleBackColor = true;
            this.buttonListAllC.Click += new System.EventHandler(this.buttonListAllC_Click_1);
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tabPage2);
            this.tabControl3.Controls.Add(this.tabPage3);
            this.tabControl3.Controls.Add(this.tabPage4);
            this.tabControl3.Controls.Add(this.tabPage5);
            this.tabControl3.Location = new System.Drawing.Point(23, 24);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(655, 194);
            this.tabControl3.TabIndex = 20;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.comboBoxStatus);
            this.tabPage2.Controls.Add(this.comboBoxProvince);
            this.tabPage2.Controls.Add(this.textBoxCredit);
            this.tabPage2.Controls.Add(this.label32);
            this.tabPage2.Controls.Add(this.label31);
            this.tabPage2.Controls.Add(this.textBoxPostalCode);
            this.tabPage2.Controls.Add(this.label23);
            this.tabPage2.Controls.Add(this.label19);
            this.tabPage2.Controls.Add(this.label18);
            this.tabPage2.Controls.Add(this.textBoxStreet);
            this.tabPage2.Controls.Add(this.label22);
            this.tabPage2.Controls.Add(this.buttonSaveC);
            this.tabPage2.Controls.Add(this.textBoxCustomerName);
            this.tabPage2.Controls.Add(this.label26);
            this.tabPage2.Controls.Add(this.textBoxPhoneC);
            this.tabPage2.Controls.Add(this.textBoxEmailC);
            this.tabPage2.Controls.Add(this.label28);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(647, 168);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "Save";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.FormattingEnabled = true;
            this.comboBoxStatus.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.comboBoxStatus.Location = new System.Drawing.Point(126, 143);
            this.comboBoxStatus.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(100, 21);
            this.comboBoxStatus.TabIndex = 24;
            // 
            // comboBoxProvince
            // 
            this.comboBoxProvince.FormattingEnabled = true;
            this.comboBoxProvince.Items.AddRange(new object[] {
            "AB",
            "BC",
            "MB",
            "NB",
            "NL",
            "NS",
            "NT",
            "NU",
            "ON",
            "PE",
            "QC",
            "SK",
            "YT"});
            this.comboBoxProvince.Location = new System.Drawing.Point(333, 114);
            this.comboBoxProvince.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxProvince.Name = "comboBoxProvince";
            this.comboBoxProvince.Size = new System.Drawing.Size(92, 21);
            this.comboBoxProvince.TabIndex = 23;
            // 
            // textBoxCredit
            // 
            this.textBoxCredit.Location = new System.Drawing.Point(333, 145);
            this.textBoxCredit.Name = "textBoxCredit";
            this.textBoxCredit.Size = new System.Drawing.Size(100, 20);
            this.textBoxCredit.TabIndex = 22;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(247, 143);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(82, 18);
            this.label32.TabIndex = 21;
            this.label32.Text = "Credit Limit";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(19, 145);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(50, 18);
            this.label31.TabIndex = 19;
            this.label31.Text = "Status";
            // 
            // textBoxPostalCode
            // 
            this.textBoxPostalCode.Location = new System.Drawing.Point(536, 112);
            this.textBoxPostalCode.Name = "textBoxPostalCode";
            this.textBoxPostalCode.Size = new System.Drawing.Size(100, 20);
            this.textBoxPostalCode.TabIndex = 18;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(449, 112);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(90, 18);
            this.label23.TabIndex = 17;
            this.label23.Text = "Postal Code";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(247, 112);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(66, 18);
            this.label19.TabIndex = 15;
            this.label19.Text = "Province";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(19, 112);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(91, 18);
            this.label18.TabIndex = 13;
            this.label18.Text = "Street Name";
            // 
            // textBoxStreet
            // 
            this.textBoxStreet.Location = new System.Drawing.Point(126, 109);
            this.textBoxStreet.Name = "textBoxStreet";
            this.textBoxStreet.Size = new System.Drawing.Size(100, 20);
            this.textBoxStreet.TabIndex = 14;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(19, 65);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(108, 18);
            this.label22.TabIndex = 5;
            this.label22.Text = "Phone Number";
            // 
            // buttonSaveC
            // 
            this.buttonSaveC.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSaveC.Location = new System.Drawing.Point(541, 10);
            this.buttonSaveC.Name = "buttonSaveC";
            this.buttonSaveC.Size = new System.Drawing.Size(100, 35);
            this.buttonSaveC.TabIndex = 0;
            this.buttonSaveC.Text = "Save";
            this.buttonSaveC.UseVisualStyleBackColor = true;
            this.buttonSaveC.Click += new System.EventHandler(this.buttonSaveC_Click_1);
            // 
            // textBoxCustomerName
            // 
            this.textBoxCustomerName.Location = new System.Drawing.Point(133, 18);
            this.textBoxCustomerName.Name = "textBoxCustomerName";
            this.textBoxCustomerName.Size = new System.Drawing.Size(388, 20);
            this.textBoxCustomerName.TabIndex = 9;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(247, 64);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(45, 18);
            this.label26.TabIndex = 6;
            this.label26.Text = "Email";
            // 
            // textBoxPhoneC
            // 
            this.textBoxPhoneC.Location = new System.Drawing.Point(126, 64);
            this.textBoxPhoneC.Name = "textBoxPhoneC";
            this.textBoxPhoneC.Size = new System.Drawing.Size(100, 20);
            this.textBoxPhoneC.TabIndex = 11;
            // 
            // textBoxEmailC
            // 
            this.textBoxEmailC.Location = new System.Drawing.Point(333, 65);
            this.textBoxEmailC.Name = "textBoxEmailC";
            this.textBoxEmailC.Size = new System.Drawing.Size(188, 20);
            this.textBoxEmailC.TabIndex = 12;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(9, 18);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(118, 18);
            this.label28.TabIndex = 3;
            this.label28.Text = "Customer Name";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.textBoxCustomerNameU);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.comboBoxProvinceU);
            this.tabPage3.Controls.Add(this.textBoxPostalCodeU);
            this.tabPage3.Controls.Add(this.label25);
            this.tabPage3.Controls.Add(this.label29);
            this.tabPage3.Controls.Add(this.label30);
            this.tabPage3.Controls.Add(this.textBoxStreetU);
            this.tabPage3.Controls.Add(this.label33);
            this.tabPage3.Controls.Add(this.textBoxCustomerId);
            this.tabPage3.Controls.Add(this.buttonUpdateCust);
            this.tabPage3.Controls.Add(this.label34);
            this.tabPage3.Controls.Add(this.textBoxPhoneCustU);
            this.tabPage3.Controls.Add(this.label35);
            this.tabPage3.Controls.Add(this.textBoxEmailCustU);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(647, 168);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "Update";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // comboBoxProvinceU
            // 
            this.comboBoxProvinceU.FormattingEnabled = true;
            this.comboBoxProvinceU.Items.AddRange(new object[] {
            "AB",
            "BC",
            "MB",
            "NB",
            "NL",
            "NS",
            "NT",
            "NU",
            "ON",
            "PE",
            "QC",
            "SK",
            "YT"});
            this.comboBoxProvinceU.Location = new System.Drawing.Point(140, 133);
            this.comboBoxProvinceU.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxProvinceU.Name = "comboBoxProvinceU";
            this.comboBoxProvinceU.Size = new System.Drawing.Size(92, 21);
            this.comboBoxProvinceU.TabIndex = 36;
            // 
            // textBoxPostalCodeU
            // 
            this.textBoxPostalCodeU.Location = new System.Drawing.Point(340, 133);
            this.textBoxPostalCodeU.Name = "textBoxPostalCodeU";
            this.textBoxPostalCodeU.Size = new System.Drawing.Size(100, 20);
            this.textBoxPostalCodeU.TabIndex = 35;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(253, 133);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(90, 18);
            this.label25.TabIndex = 34;
            this.label25.Text = "Postal Code";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(19, 133);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(66, 18);
            this.label29.TabIndex = 32;
            this.label29.Text = "Province";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(254, 101);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(91, 18);
            this.label30.TabIndex = 30;
            this.label30.Text = "Street Name";
            // 
            // textBoxStreetU
            // 
            this.textBoxStreetU.Location = new System.Drawing.Point(339, 98);
            this.textBoxStreetU.Name = "textBoxStreetU";
            this.textBoxStreetU.Size = new System.Drawing.Size(100, 20);
            this.textBoxStreetU.TabIndex = 31;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(238, 29);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(108, 18);
            this.label33.TabIndex = 22;
            this.label33.Text = "Phone Number";
            // 
            // textBoxCustomerId
            // 
            this.textBoxCustomerId.Location = new System.Drawing.Point(132, 29);
            this.textBoxCustomerId.Name = "textBoxCustomerId";
            this.textBoxCustomerId.Size = new System.Drawing.Size(100, 20);
            this.textBoxCustomerId.TabIndex = 25;
            // 
            // buttonUpdateCust
            // 
            this.buttonUpdateCust.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUpdateCust.Location = new System.Drawing.Point(518, 20);
            this.buttonUpdateCust.Name = "buttonUpdateCust";
            this.buttonUpdateCust.Size = new System.Drawing.Size(100, 46);
            this.buttonUpdateCust.TabIndex = 15;
            this.buttonUpdateCust.Text = "Update Customer";
            this.buttonUpdateCust.UseVisualStyleBackColor = true;
            this.buttonUpdateCust.Click += new System.EventHandler(this.buttonUpdateCust_Click_1);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(19, 101);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(45, 18);
            this.label34.TabIndex = 23;
            this.label34.Text = "Email";
            // 
            // textBoxPhoneCustU
            // 
            this.textBoxPhoneCustU.Location = new System.Drawing.Point(340, 29);
            this.textBoxPhoneCustU.Name = "textBoxPhoneCustU";
            this.textBoxPhoneCustU.Size = new System.Drawing.Size(100, 20);
            this.textBoxPhoneCustU.TabIndex = 28;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.Location = new System.Drawing.Point(34, 31);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(92, 18);
            this.label35.TabIndex = 19;
            this.label35.Text = "Customer ID";
            // 
            // textBoxEmailCustU
            // 
            this.textBoxEmailCustU.Location = new System.Drawing.Point(70, 101);
            this.textBoxEmailCustU.Name = "textBoxEmailCustU";
            this.textBoxEmailCustU.Size = new System.Drawing.Size(163, 20);
            this.textBoxEmailCustU.TabIndex = 29;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label38);
            this.tabPage4.Controls.Add(this.comboBoxSearchC);
            this.tabPage4.Controls.Add(this.buttonSearchCust);
            this.tabPage4.Controls.Add(this.textBoxSearchC);
            this.tabPage4.Controls.Add(this.labelSearch1C);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(647, 168);
            this.tabPage4.TabIndex = 2;
            this.tabPage4.Text = "Search";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.Location = new System.Drawing.Point(47, 29);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(78, 18);
            this.label38.TabIndex = 51;
            this.label38.Text = "Search by:";
            // 
            // comboBoxSearchC
            // 
            this.comboBoxSearchC.FormattingEnabled = true;
            this.comboBoxSearchC.Items.AddRange(new object[] {
            "CustomerID",
            "Customer Name"});
            this.comboBoxSearchC.Location = new System.Drawing.Point(131, 26);
            this.comboBoxSearchC.Name = "comboBoxSearchC";
            this.comboBoxSearchC.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSearchC.TabIndex = 50;
            this.comboBoxSearchC.SelectedIndexChanged += new System.EventHandler(this.comboBoxSearchC_SelectedIndexChanged);
            // 
            // buttonSearchCust
            // 
            this.buttonSearchCust.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSearchCust.Location = new System.Drawing.Point(488, 29);
            this.buttonSearchCust.Name = "buttonSearchCust";
            this.buttonSearchCust.Size = new System.Drawing.Size(100, 46);
            this.buttonSearchCust.TabIndex = 49;
            this.buttonSearchCust.Text = "Search Customer";
            this.buttonSearchCust.UseVisualStyleBackColor = true;
            this.buttonSearchCust.Click += new System.EventHandler(this.buttonSearchCust_Click);
            // 
            // textBoxSearchC
            // 
            this.textBoxSearchC.Location = new System.Drawing.Point(139, 65);
            this.textBoxSearchC.Name = "textBoxSearchC";
            this.textBoxSearchC.Size = new System.Drawing.Size(100, 20);
            this.textBoxSearchC.TabIndex = 47;
            this.textBoxSearchC.Visible = false;
            // 
            // labelSearch1C
            // 
            this.labelSearch1C.AutoSize = true;
            this.labelSearch1C.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSearch1C.Location = new System.Drawing.Point(15, 67);
            this.labelSearch1C.Name = "labelSearch1C";
            this.labelSearch1C.Size = new System.Drawing.Size(118, 18);
            this.labelSearch1C.TabIndex = 45;
            this.labelSearch1C.Text = "Customer Name";
            this.labelSearch1C.Visible = false;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.textBoxCustomerIdToDelete);
            this.tabPage5.Controls.Add(this.label45);
            this.tabPage5.Controls.Add(this.buttonCustDelete);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(647, 168);
            this.tabPage5.TabIndex = 3;
            this.tabPage5.Text = "Delete";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // textBoxCustomerIdToDelete
            // 
            this.textBoxCustomerIdToDelete.Location = new System.Drawing.Point(287, 40);
            this.textBoxCustomerIdToDelete.Name = "textBoxCustomerIdToDelete";
            this.textBoxCustomerIdToDelete.Size = new System.Drawing.Size(100, 20);
            this.textBoxCustomerIdToDelete.TabIndex = 19;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.Location = new System.Drawing.Point(189, 42);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(92, 18);
            this.label45.TabIndex = 18;
            this.label45.Text = "Customer ID";
            // 
            // buttonCustDelete
            // 
            this.buttonCustDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCustDelete.Location = new System.Drawing.Point(236, 81);
            this.buttonCustDelete.Name = "buttonCustDelete";
            this.buttonCustDelete.Size = new System.Drawing.Size(100, 46);
            this.buttonCustDelete.TabIndex = 17;
            this.buttonCustDelete.Text = "Delete Customer";
            this.buttonCustDelete.UseVisualStyleBackColor = true;
            this.buttonCustDelete.Click += new System.EventHandler(this.buttonCustDelete_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 18);
            this.label1.TabIndex = 37;
            this.label1.Text = "Customer Name";
            // 
            // textBoxCustomerNameU
            // 
            this.textBoxCustomerNameU.Location = new System.Drawing.Point(132, 64);
            this.textBoxCustomerNameU.Name = "textBoxCustomerNameU";
            this.textBoxCustomerNameU.Size = new System.Drawing.Size(307, 20);
            this.textBoxCustomerNameU.TabIndex = 38;
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 595);
            this.Controls.Add(this.Employee);
            this.Name = "CustomerForm";
            this.Text = "CustomerForm";
            this.Employee.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabControl3.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl Employee;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListView listViewCustomers;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.Button buttonListAllC;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox comboBoxStatus;
        private System.Windows.Forms.ComboBox comboBoxProvince;
        private System.Windows.Forms.TextBox textBoxCredit;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox textBoxPostalCode;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBoxStreet;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button buttonSaveC;
        private System.Windows.Forms.TextBox textBoxCustomerName;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox textBoxPhoneC;
        private System.Windows.Forms.TextBox textBoxEmailC;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ComboBox comboBoxProvinceU;
        private System.Windows.Forms.TextBox textBoxPostalCodeU;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox textBoxStreetU;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox textBoxCustomerId;
        private System.Windows.Forms.Button buttonUpdateCust;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TextBox textBoxPhoneCustU;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox textBoxEmailCustU;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.ComboBox comboBoxSearchC;
        private System.Windows.Forms.Button buttonSearchCust;
        private System.Windows.Forms.TextBox textBoxSearchC;
        private System.Windows.Forms.Label labelSearch1C;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TextBox textBoxCustomerIdToDelete;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Button buttonCustDelete;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxCustomerNameU;
    }
}