namespace RBS_IT_Project
{
    partial class FormMenu
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMenu));
            this.buttonOpenStaff = new System.Windows.Forms.Button();
            this.buttonOpenOrders = new System.Windows.Forms.Button();
            this.buttonOpenServiсes = new System.Windows.Forms.Button();
            this.buttonOpenHistory = new System.Windows.Forms.Button();
            this.buttonOpenClients = new System.Windows.Forms.Button();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.labelHello = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOpenStaff
            // 
            this.buttonOpenStaff.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonOpenStaff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(182)))), ((int)(((byte)(103)))));
            this.buttonOpenStaff.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonOpenStaff.Font = new System.Drawing.Font("Open Sans", 14F);
            this.buttonOpenStaff.Location = new System.Drawing.Point(12, 137);
            this.buttonOpenStaff.Name = "buttonOpenStaff";
            this.buttonOpenStaff.Size = new System.Drawing.Size(260, 40);
            this.buttonOpenStaff.TabIndex = 2;
            this.buttonOpenStaff.Text = "Сотрудники";
            this.buttonOpenStaff.UseVisualStyleBackColor = false;
            this.buttonOpenStaff.Click += new System.EventHandler(this.buttonOpenStaff_Click);
            // 
            // buttonOpenOrders
            // 
            this.buttonOpenOrders.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonOpenOrders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(182)))), ((int)(((byte)(103)))));
            this.buttonOpenOrders.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonOpenOrders.Font = new System.Drawing.Font("Open Sans", 14F);
            this.buttonOpenOrders.Location = new System.Drawing.Point(12, 183);
            this.buttonOpenOrders.Name = "buttonOpenOrders";
            this.buttonOpenOrders.Size = new System.Drawing.Size(260, 40);
            this.buttonOpenOrders.TabIndex = 4;
            this.buttonOpenOrders.Text = "Заказы";
            this.buttonOpenOrders.UseVisualStyleBackColor = false;
            this.buttonOpenOrders.Click += new System.EventHandler(this.buttonOpenOrders_Click);
            // 
            // buttonOpenServiсes
            // 
            this.buttonOpenServiсes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonOpenServiсes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(182)))), ((int)(((byte)(103)))));
            this.buttonOpenServiсes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonOpenServiсes.Font = new System.Drawing.Font("Open Sans", 14F);
            this.buttonOpenServiсes.Location = new System.Drawing.Point(12, 229);
            this.buttonOpenServiсes.Name = "buttonOpenServiсes";
            this.buttonOpenServiсes.Size = new System.Drawing.Size(260, 40);
            this.buttonOpenServiсes.TabIndex = 5;
            this.buttonOpenServiсes.Text = "Услуги";
            this.buttonOpenServiсes.UseVisualStyleBackColor = false;
            this.buttonOpenServiсes.Click += new System.EventHandler(this.buttonOpenServiсes_Click);
            // 
            // buttonOpenHistory
            // 
            this.buttonOpenHistory.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonOpenHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(182)))), ((int)(((byte)(103)))));
            this.buttonOpenHistory.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonOpenHistory.Font = new System.Drawing.Font("Open Sans", 14F);
            this.buttonOpenHistory.Location = new System.Drawing.Point(12, 275);
            this.buttonOpenHistory.Name = "buttonOpenHistory";
            this.buttonOpenHistory.Size = new System.Drawing.Size(260, 40);
            this.buttonOpenHistory.TabIndex = 6;
            this.buttonOpenHistory.Text = "История";
            this.buttonOpenHistory.UseVisualStyleBackColor = false;
            // 
            // buttonOpenClients
            // 
            this.buttonOpenClients.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonOpenClients.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(182)))), ((int)(((byte)(103)))));
            this.buttonOpenClients.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonOpenClients.Font = new System.Drawing.Font("Open Sans", 14F);
            this.buttonOpenClients.Location = new System.Drawing.Point(12, 91);
            this.buttonOpenClients.Name = "buttonOpenClients";
            this.buttonOpenClients.Size = new System.Drawing.Size(260, 40);
            this.buttonOpenClients.TabIndex = 7;
            this.buttonOpenClients.Text = "Клиенты";
            this.buttonOpenClients.UseVisualStyleBackColor = false;
            this.buttonOpenClients.Click += new System.EventHandler(this.buttonOpenClients_Click);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = global::RBS_IT_Project.Properties.Resources.logo;
            this.pictureBoxLogo.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(260, 40);
            this.pictureBoxLogo.TabIndex = 0;
            this.pictureBoxLogo.TabStop = false;
            // 
            // labelHello
            // 
            this.labelHello.AutoSize = true;
            this.labelHello.Font = new System.Drawing.Font("Open Sans", 10F);
            this.labelHello.Location = new System.Drawing.Point(12, 59);
            this.labelHello.Name = "labelHello";
            this.labelHello.Size = new System.Drawing.Size(145, 19);
            this.labelHello.TabIndex = 8;
            this.labelHello.Text = "Добро пожаловать, ";
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(284, 321);
            this.Controls.Add(this.labelHello);
            this.Controls.Add(this.buttonOpenClients);
            this.Controls.Add(this.buttonOpenHistory);
            this.Controls.Add(this.buttonOpenServiсes);
            this.Controls.Add(this.buttonOpenOrders);
            this.Controls.Add(this.buttonOpenStaff);
            this.Controls.Add(this.pictureBoxLogo);
            this.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 360);
            this.MinimumSize = new System.Drawing.Size(300, 360);
            this.Name = "FormMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Меню";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMenu_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Button buttonOpenStaff;
        private System.Windows.Forms.Button buttonOpenOrders;
        private System.Windows.Forms.Button buttonOpenServiсes;
        private System.Windows.Forms.Button buttonOpenHistory;
        private System.Windows.Forms.Button buttonOpenClients;
        private System.Windows.Forms.Label labelHello;
    }
}

