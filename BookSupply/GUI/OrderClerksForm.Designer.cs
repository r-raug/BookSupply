namespace BookSupply.GUI
{
    partial class OrderClerksForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonListAllO = new System.Windows.Forms.Button();
            this.buttonSearchO = new System.Windows.Forms.Button();
            this.textBoxSearchO = new System.Windows.Forms.TextBox();
            this.textBoxDate = new System.Windows.Forms.TextBox();
            this.textBoxOrderId = new System.Windows.Forms.TextBox();
            this.comboBoxSearchO = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonUpdateO = new System.Windows.Forms.Button();
            this.buttonAddO = new System.Windows.Forms.Button();
            this.comboBoxOrderStatus = new System.Windows.Forms.ComboBox();
            this.comboBoxOrderType = new System.Windows.Forms.ComboBox();
            this.comboBoxEmployeeId = new System.Windows.Forms.ComboBox();
            this.comboBoxCustomerId = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.listViewOrder = new System.Windows.Forms.ListView();
            this.OrderId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OrderDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ShippingDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OrderStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CustomerId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EmployeeId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OrderType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label9 = new System.Windows.Forms.Label();
            this.comboBoxOrderId = new System.Windows.Forms.ComboBox();
            this.comboBoxISBN = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxQuantity = new System.Windows.Forms.TextBox();
            this.buttonAddOrderLine = new System.Windows.Forms.Button();
            this.buttonListAllOrderLine = new System.Windows.Forms.Button();
            this.listViewOrderLine = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(250, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Order Maintenance";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(55, 88);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(660, 273);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonListAllO);
            this.tabPage1.Controls.Add(this.buttonSearchO);
            this.tabPage1.Controls.Add(this.textBoxSearchO);
            this.tabPage1.Controls.Add(this.textBoxDate);
            this.tabPage1.Controls.Add(this.textBoxOrderId);
            this.tabPage1.Controls.Add(this.comboBoxSearchO);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.buttonCancel);
            this.tabPage1.Controls.Add(this.buttonUpdateO);
            this.tabPage1.Controls.Add(this.buttonAddO);
            this.tabPage1.Controls.Add(this.comboBoxOrderStatus);
            this.tabPage1.Controls.Add(this.comboBoxOrderType);
            this.tabPage1.Controls.Add(this.comboBoxEmployeeId);
            this.tabPage1.Controls.Add(this.comboBoxCustomerId);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(652, 247);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Order";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonListAllO
            // 
            this.buttonListAllO.Location = new System.Drawing.Point(497, 145);
            this.buttonListAllO.Name = "buttonListAllO";
            this.buttonListAllO.Size = new System.Drawing.Size(135, 23);
            this.buttonListAllO.TabIndex = 19;
            this.buttonListAllO.Text = "List All Orders";
            this.buttonListAllO.UseVisualStyleBackColor = true;
            this.buttonListAllO.Click += new System.EventHandler(this.buttonListAllO_Click);
            // 
            // buttonSearchO
            // 
            this.buttonSearchO.Location = new System.Drawing.Point(497, 94);
            this.buttonSearchO.Name = "buttonSearchO";
            this.buttonSearchO.Size = new System.Drawing.Size(135, 23);
            this.buttonSearchO.TabIndex = 18;
            this.buttonSearchO.Text = "Search";
            this.buttonSearchO.UseVisualStyleBackColor = true;
            this.buttonSearchO.Click += new System.EventHandler(this.buttonSearchO_Click);
            // 
            // textBoxSearchO
            // 
            this.textBoxSearchO.Location = new System.Drawing.Point(497, 58);
            this.textBoxSearchO.Name = "textBoxSearchO";
            this.textBoxSearchO.Size = new System.Drawing.Size(135, 20);
            this.textBoxSearchO.TabIndex = 17;
            // 
            // textBoxDate
            // 
            this.textBoxDate.Location = new System.Drawing.Point(132, 127);
            this.textBoxDate.Name = "textBoxDate";
            this.textBoxDate.Size = new System.Drawing.Size(135, 20);
            this.textBoxDate.TabIndex = 11;
            this.textBoxDate.Text = "yyyy-mm-dd";
            // 
            // textBoxOrderId
            // 
            this.textBoxOrderId.Location = new System.Drawing.Point(132, 27);
            this.textBoxOrderId.Name = "textBoxOrderId";
            this.textBoxOrderId.Size = new System.Drawing.Size(135, 20);
            this.textBoxOrderId.TabIndex = 6;
            // 
            // comboBoxSearchO
            // 
            this.comboBoxSearchO.FormattingEnabled = true;
            this.comboBoxSearchO.Items.AddRange(new object[] {
            "Order ID",
            "Customer ID",
            "Employee ID",
            "Status ID"});
            this.comboBoxSearchO.Location = new System.Drawing.Point(497, 24);
            this.comboBoxSearchO.Name = "comboBoxSearchO";
            this.comboBoxSearchO.Size = new System.Drawing.Size(135, 21);
            this.comboBoxSearchO.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(432, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Search By:";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(326, 125);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 14;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonUpdateO
            // 
            this.buttonUpdateO.Location = new System.Drawing.Point(326, 75);
            this.buttonUpdateO.Name = "buttonUpdateO";
            this.buttonUpdateO.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdateO.TabIndex = 13;
            this.buttonUpdateO.Text = "Update";
            this.buttonUpdateO.UseVisualStyleBackColor = true;
            this.buttonUpdateO.Click += new System.EventHandler(this.buttonUpdateO_Click);
            // 
            // buttonAddO
            // 
            this.buttonAddO.Location = new System.Drawing.Point(326, 27);
            this.buttonAddO.Name = "buttonAddO";
            this.buttonAddO.Size = new System.Drawing.Size(75, 23);
            this.buttonAddO.TabIndex = 12;
            this.buttonAddO.Text = "Add";
            this.buttonAddO.UseVisualStyleBackColor = true;
            this.buttonAddO.Click += new System.EventHandler(this.buttonAddO_Click_1);
            // 
            // comboBoxOrderStatus
            // 
            this.comboBoxOrderStatus.FormattingEnabled = true;
            this.comboBoxOrderStatus.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.comboBoxOrderStatus.Location = new System.Drawing.Point(132, 217);
            this.comboBoxOrderStatus.Name = "comboBoxOrderStatus";
            this.comboBoxOrderStatus.Size = new System.Drawing.Size(135, 21);
            this.comboBoxOrderStatus.TabIndex = 10;
            // 
            // comboBoxOrderType
            // 
            this.comboBoxOrderType.FormattingEnabled = true;
            this.comboBoxOrderType.Items.AddRange(new object[] {
            "Fax",
            "Email",
            "Phone"});
            this.comboBoxOrderType.Location = new System.Drawing.Point(132, 170);
            this.comboBoxOrderType.Name = "comboBoxOrderType";
            this.comboBoxOrderType.Size = new System.Drawing.Size(135, 21);
            this.comboBoxOrderType.TabIndex = 9;
            // 
            // comboBoxEmployeeId
            // 
            this.comboBoxEmployeeId.FormattingEnabled = true;
            this.comboBoxEmployeeId.Location = new System.Drawing.Point(132, 96);
            this.comboBoxEmployeeId.Name = "comboBoxEmployeeId";
            this.comboBoxEmployeeId.Size = new System.Drawing.Size(135, 21);
            this.comboBoxEmployeeId.TabIndex = 8;
            // 
            // comboBoxCustomerId
            // 
            this.comboBoxCustomerId.FormattingEnabled = true;
            this.comboBoxCustomerId.Location = new System.Drawing.Point(132, 61);
            this.comboBoxCustomerId.Name = "comboBoxCustomerId";
            this.comboBoxCustomerId.Size = new System.Drawing.Size(135, 21);
            this.comboBoxCustomerId.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(47, 220);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Order Status:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(50, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Order Type:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(54, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Order Date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Employee Id:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Customer Id:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Order Id:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listViewOrderLine);
            this.tabPage2.Controls.Add(this.buttonListAllOrderLine);
            this.tabPage2.Controls.Add(this.buttonAddOrderLine);
            this.tabPage2.Controls.Add(this.textBoxQuantity);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.comboBoxISBN);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.comboBoxOrderId);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(652, 247);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "OrderLines";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonLogout
            // 
            this.buttonLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogout.Location = new System.Drawing.Point(636, 50);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(75, 32);
            this.buttonLogout.TabIndex = 27;
            this.buttonLogout.Text = "LogOut";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // listViewOrder
            // 
            this.listViewOrder.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.OrderId,
            this.OrderDate,
            this.ShippingDate,
            this.OrderStatus,
            this.CustomerId,
            this.EmployeeId,
            this.OrderType});
            this.listViewOrder.GridLines = true;
            this.listViewOrder.HideSelection = false;
            this.listViewOrder.Location = new System.Drawing.Point(60, 411);
            this.listViewOrder.Name = "listViewOrder";
            this.listViewOrder.Size = new System.Drawing.Size(655, 175);
            this.listViewOrder.TabIndex = 28;
            this.listViewOrder.UseCompatibleStateImageBehavior = false;
            this.listViewOrder.View = System.Windows.Forms.View.Details;
            // 
            // OrderId
            // 
            this.OrderId.Text = "Order Id";
            this.OrderId.Width = 78;
            // 
            // OrderDate
            // 
            this.OrderDate.Text = "Order Date";
            this.OrderDate.Width = 100;
            // 
            // ShippingDate
            // 
            this.ShippingDate.Text = "Shipping Date";
            this.ShippingDate.Width = 102;
            // 
            // OrderStatus
            // 
            this.OrderStatus.Text = "Order Status";
            this.OrderStatus.Width = 107;
            // 
            // CustomerId
            // 
            this.CustomerId.Text = "Customer Id";
            this.CustomerId.Width = 142;
            // 
            // EmployeeId
            // 
            this.EmployeeId.Text = "Employee Id";
            // 
            // OrderType
            // 
            this.OrderType.Text = "Order Type";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(32, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Order Id:";
            // 
            // comboBoxOrderId
            // 
            this.comboBoxOrderId.FormattingEnabled = true;
            this.comboBoxOrderId.Location = new System.Drawing.Point(86, 26);
            this.comboBoxOrderId.Name = "comboBoxOrderId";
            this.comboBoxOrderId.Size = new System.Drawing.Size(121, 21);
            this.comboBoxOrderId.TabIndex = 8;
            // 
            // comboBoxISBN
            // 
            this.comboBoxISBN.FormattingEnabled = true;
            this.comboBoxISBN.Location = new System.Drawing.Point(86, 78);
            this.comboBoxISBN.Name = "comboBoxISBN";
            this.comboBoxISBN.Size = new System.Drawing.Size(121, 21);
            this.comboBoxISBN.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(32, 81);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "ISBN:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(32, 128);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "Quantity:";
            // 
            // textBoxQuantity
            // 
            this.textBoxQuantity.Location = new System.Drawing.Point(86, 128);
            this.textBoxQuantity.Name = "textBoxQuantity";
            this.textBoxQuantity.Size = new System.Drawing.Size(121, 20);
            this.textBoxQuantity.TabIndex = 12;
            // 
            // buttonAddOrderLine
            // 
            this.buttonAddOrderLine.Location = new System.Drawing.Point(314, 194);
            this.buttonAddOrderLine.Name = "buttonAddOrderLine";
            this.buttonAddOrderLine.Size = new System.Drawing.Size(120, 23);
            this.buttonAddOrderLine.TabIndex = 14;
            this.buttonAddOrderLine.Text = "Add";
            this.buttonAddOrderLine.UseVisualStyleBackColor = true;
            this.buttonAddOrderLine.Click += new System.EventHandler(this.buttonAddOrderLine_Click);
            // 
            // buttonListAllOrderLine
            // 
            this.buttonListAllOrderLine.Location = new System.Drawing.Point(509, 194);
            this.buttonListAllOrderLine.Name = "buttonListAllOrderLine";
            this.buttonListAllOrderLine.Size = new System.Drawing.Size(120, 23);
            this.buttonListAllOrderLine.TabIndex = 15;
            this.buttonListAllOrderLine.Text = "ListOrderLine";
            this.buttonListAllOrderLine.UseVisualStyleBackColor = true;
            this.buttonListAllOrderLine.Click += new System.EventHandler(this.buttonListAllOrderLine_Click);
            // 
            // listViewOrderLine
            // 
            this.listViewOrderLine.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewOrderLine.GridLines = true;
            this.listViewOrderLine.HideSelection = false;
            this.listViewOrderLine.Location = new System.Drawing.Point(314, 26);
            this.listViewOrderLine.Name = "listViewOrderLine";
            this.listViewOrderLine.Size = new System.Drawing.Size(315, 122);
            this.listViewOrderLine.TabIndex = 29;
            this.listViewOrderLine.UseCompatibleStateImageBehavior = false;
            this.listViewOrderLine.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Order Id";
            this.columnHeader1.Width = 94;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ISBN";
            this.columnHeader2.Width = 123;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Quantity";
            this.columnHeader3.Width = 93;
            // 
            // OrderClerksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 627);
            this.Controls.Add(this.listViewOrder);
            this.Controls.Add(this.buttonLogout);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Name = "OrderClerksForm";
            this.Text = "OrderClerksForm";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button buttonListAllO;
        private System.Windows.Forms.Button buttonSearchO;
        private System.Windows.Forms.TextBox textBoxSearchO;
        private System.Windows.Forms.TextBox textBoxDate;
        private System.Windows.Forms.TextBox textBoxOrderId;
        private System.Windows.Forms.ComboBox comboBoxSearchO;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonUpdateO;
        private System.Windows.Forms.Button buttonAddO;
        private System.Windows.Forms.ComboBox comboBoxOrderStatus;
        private System.Windows.Forms.ComboBox comboBoxOrderType;
        private System.Windows.Forms.ComboBox comboBoxEmployeeId;
        private System.Windows.Forms.ComboBox comboBoxCustomerId;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.ListView listViewOrder;
        private System.Windows.Forms.ColumnHeader OrderId;
        private System.Windows.Forms.ColumnHeader OrderDate;
        private System.Windows.Forms.ColumnHeader ShippingDate;
        private System.Windows.Forms.ColumnHeader OrderStatus;
        private System.Windows.Forms.ColumnHeader CustomerId;
        private System.Windows.Forms.ColumnHeader EmployeeId;
        private System.Windows.Forms.ColumnHeader OrderType;
        private System.Windows.Forms.Button buttonAddOrderLine;
        private System.Windows.Forms.TextBox textBoxQuantity;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBoxISBN;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBoxOrderId;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonListAllOrderLine;
        private System.Windows.Forms.ListView listViewOrderLine;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}