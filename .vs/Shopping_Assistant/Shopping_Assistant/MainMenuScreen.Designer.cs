﻿namespace Shopping_Assistant
{
    partial class MainMenuScreen
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
        /// //this method sets all of the visual aspects of the objects located on the form as well as the form itself (mostly autogenerated while designing the form from the designer)
        /// //non-auto generated additions will have comments added after the line of code
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenuScreen));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groceryListButton = new System.Windows.Forms.Button();
            this.eventsButton = new System.Windows.Forms.Button();
            this.headerLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.couponButton = new System.Windows.Forms.Button();
            this.LocationButton = new System.Windows.Forms.Button();
            this.signOutButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-1, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(286, 17);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // groceryListButton
            // 
            this.groceryListButton.BackColor = System.Drawing.Color.CornflowerBlue;
            this.groceryListButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.groceryListButton.FlatAppearance.BorderSize = 3;
            this.groceryListButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.groceryListButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.groceryListButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groceryListButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groceryListButton.ForeColor = System.Drawing.Color.Black;
            this.groceryListButton.Location = new System.Drawing.Point(83, 175);
            this.groceryListButton.Name = "groceryListButton";
            this.groceryListButton.Size = new System.Drawing.Size(121, 32);
            this.groceryListButton.TabIndex = 24;
            this.groceryListButton.Text = "Grocery Lists";
            this.groceryListButton.UseVisualStyleBackColor = false;
            this.groceryListButton.Click += new System.EventHandler(this.groceryListButton_Click);
            // 
            // eventsButton
            // 
            this.eventsButton.BackColor = System.Drawing.Color.CornflowerBlue;
            this.eventsButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.eventsButton.FlatAppearance.BorderSize = 3;
            this.eventsButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.eventsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.eventsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.eventsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eventsButton.ForeColor = System.Drawing.Color.Black;
            this.eventsButton.Location = new System.Drawing.Point(83, 231);
            this.eventsButton.Name = "eventsButton";
            this.eventsButton.Size = new System.Drawing.Size(121, 32);
            this.eventsButton.TabIndex = 23;
            this.eventsButton.Text = "Sales Events";
            this.eventsButton.UseVisualStyleBackColor = false;
            this.eventsButton.Click += new System.EventHandler(this.eventsButton_Click);
            // 
            // headerLabel
            // 
            this.headerLabel.BackColor = System.Drawing.Color.OrangeRed;
            this.headerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLabel.ForeColor = System.Drawing.Color.White;
            this.headerLabel.Location = new System.Drawing.Point(1, 0);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(284, 52);
            this.headerLabel.TabIndex = 22;
            this.headerLabel.Text = "Main Menu";
            this.headerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.OrangeRed;
            this.titleLabel.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.titleLabel.Location = new System.Drawing.Point(16, 82);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(254, 62);
            this.titleLabel.TabIndex = 19;
            this.titleLabel.Text = "Shopping Assistant \r\nDashboard\r\n";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // couponButton
            // 
            this.couponButton.BackColor = System.Drawing.Color.CornflowerBlue;
            this.couponButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.couponButton.FlatAppearance.BorderSize = 3;
            this.couponButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.couponButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.couponButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.couponButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.couponButton.ForeColor = System.Drawing.Color.Black;
            this.couponButton.Location = new System.Drawing.Point(83, 287);
            this.couponButton.Name = "couponButton";
            this.couponButton.Size = new System.Drawing.Size(121, 32);
            this.couponButton.TabIndex = 29;
            this.couponButton.Text = "Coupons";
            this.couponButton.UseVisualStyleBackColor = false;
            this.couponButton.Click += new System.EventHandler(this.couponButton_Click);
            // 
            // LocationButton
            // 
            this.LocationButton.BackColor = System.Drawing.Color.CornflowerBlue;
            this.LocationButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.LocationButton.FlatAppearance.BorderSize = 3;
            this.LocationButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.LocationButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.LocationButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LocationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LocationButton.ForeColor = System.Drawing.Color.Black;
            this.LocationButton.Location = new System.Drawing.Point(83, 343);
            this.LocationButton.Name = "LocationButton";
            this.LocationButton.Size = new System.Drawing.Size(121, 32);
            this.LocationButton.TabIndex = 28;
            this.LocationButton.Text = "Locations";
            this.LocationButton.UseVisualStyleBackColor = false;
            this.LocationButton.Click += new System.EventHandler(this.LocationButton_Click);
            // 
            // signOutButton
            // 
            this.signOutButton.BackColor = System.Drawing.Color.CornflowerBlue;
            this.signOutButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.signOutButton.FlatAppearance.BorderSize = 3;
            this.signOutButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.signOutButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.signOutButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.signOutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signOutButton.ForeColor = System.Drawing.Color.Black;
            this.signOutButton.Location = new System.Drawing.Point(83, 399);
            this.signOutButton.Name = "signOutButton";
            this.signOutButton.Size = new System.Drawing.Size(121, 32);
            this.signOutButton.TabIndex = 30;
            this.signOutButton.Text = "Sign Out";
            this.signOutButton.UseVisualStyleBackColor = false;
            this.signOutButton.Click += new System.EventHandler(this.signOutButton_Click);
            // 
            // MainMenuScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 444);
            this.Controls.Add(this.signOutButton);
            this.Controls.Add(this.couponButton);
            this.Controls.Add(this.LocationButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groceryListButton);
            this.Controls.Add(this.eventsButton);
            this.Controls.Add(this.headerLabel);
            this.Controls.Add(this.titleLabel);
            this.Name = "MainMenuScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shopping Assistant";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainMenuScreen_Close);//creates an event handler for when the form is closing via the "X" button
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button groceryListButton;
        private System.Windows.Forms.Button eventsButton;
        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button couponButton;
        private System.Windows.Forms.Button LocationButton;
        private System.Windows.Forms.Button signOutButton;
    }
}