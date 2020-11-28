namespace WinAquila
{
	partial class MainForm
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
			this.uxTabControl = new System.Windows.Forms.TabControl();
			this.uxPageTabPage = new System.Windows.Forms.TabPage();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.uxPageTitleTextBox = new System.Windows.Forms.TextBox();
			this.uxRefererTextBox = new System.Windows.Forms.TextBox();
			this.uxUrlTextBox = new System.Windows.Forms.TextBox();
			this.uxEventTabPage = new System.Windows.Forms.TabPage();
			this.uxTransactionTabPage = new System.Windows.Forms.TabPage();
			this.uxCancelButton = new System.Windows.Forms.Button();
			this.uxSendButton = new System.Windows.Forms.Button();
			this.uxTrackerIdTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.uxUserAgentTextBox = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.uxIPTextBox = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.uxClientIdTextBox = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.uxGenerateUserIdButton = new System.Windows.Forms.Button();
			this.uxTabControl.SuspendLayout();
			this.uxPageTabPage.SuspendLayout();
			this.SuspendLayout();
			// 
			// uxTabControl
			// 
			this.uxTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.uxTabControl.Controls.Add(this.uxPageTabPage);
			this.uxTabControl.Controls.Add(this.uxEventTabPage);
			this.uxTabControl.Controls.Add(this.uxTransactionTabPage);
			this.uxTabControl.Location = new System.Drawing.Point(14, 159);
			this.uxTabControl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.uxTabControl.Name = "uxTabControl";
			this.uxTabControl.SelectedIndex = 0;
			this.uxTabControl.Size = new System.Drawing.Size(713, 298);
			this.uxTabControl.TabIndex = 0;
			// 
			// uxPageTabPage
			// 
			this.uxPageTabPage.Controls.Add(this.label4);
			this.uxPageTabPage.Controls.Add(this.label3);
			this.uxPageTabPage.Controls.Add(this.label2);
			this.uxPageTabPage.Controls.Add(this.uxPageTitleTextBox);
			this.uxPageTabPage.Controls.Add(this.uxRefererTextBox);
			this.uxPageTabPage.Controls.Add(this.uxUrlTextBox);
			this.uxPageTabPage.Location = new System.Drawing.Point(4, 24);
			this.uxPageTabPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.uxPageTabPage.Name = "uxPageTabPage";
			this.uxPageTabPage.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.uxPageTabPage.Size = new System.Drawing.Size(705, 270);
			this.uxPageTabPage.TabIndex = 0;
			this.uxPageTabPage.Text = "Page";
			this.uxPageTabPage.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(16, 87);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 15);
			this.label4.TabIndex = 4;
			this.label4.Text = "Page Title :";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(16, 57);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(50, 15);
			this.label3.TabIndex = 4;
			this.label3.Text = "Referer :";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(16, 27);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(28, 15);
			this.label2.TabIndex = 4;
			this.label2.Text = "Url :";
			// 
			// uxPageTitleTextBox
			// 
			this.uxPageTitleTextBox.Location = new System.Drawing.Point(111, 83);
			this.uxPageTitleTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.uxPageTitleTextBox.Name = "uxPageTitleTextBox";
			this.uxPageTitleTextBox.Size = new System.Drawing.Size(574, 23);
			this.uxPageTitleTextBox.TabIndex = 3;
			// 
			// uxRefererTextBox
			// 
			this.uxRefererTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.uxRefererTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllUrl;
			this.uxRefererTextBox.Location = new System.Drawing.Point(111, 53);
			this.uxRefererTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.uxRefererTextBox.Name = "uxRefererTextBox";
			this.uxRefererTextBox.Size = new System.Drawing.Size(574, 23);
			this.uxRefererTextBox.TabIndex = 3;
			// 
			// uxUrlTextBox
			// 
			this.uxUrlTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.uxUrlTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllUrl;
			this.uxUrlTextBox.Location = new System.Drawing.Point(111, 23);
			this.uxUrlTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.uxUrlTextBox.Name = "uxUrlTextBox";
			this.uxUrlTextBox.Size = new System.Drawing.Size(574, 23);
			this.uxUrlTextBox.TabIndex = 3;
			// 
			// uxEventTabPage
			// 
			this.uxEventTabPage.Location = new System.Drawing.Point(4, 24);
			this.uxEventTabPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.uxEventTabPage.Name = "uxEventTabPage";
			this.uxEventTabPage.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.uxEventTabPage.Size = new System.Drawing.Size(705, 191);
			this.uxEventTabPage.TabIndex = 1;
			this.uxEventTabPage.Text = "Event";
			this.uxEventTabPage.UseVisualStyleBackColor = true;
			// 
			// uxTransactionTabPage
			// 
			this.uxTransactionTabPage.Location = new System.Drawing.Point(4, 24);
			this.uxTransactionTabPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.uxTransactionTabPage.Name = "uxTransactionTabPage";
			this.uxTransactionTabPage.Size = new System.Drawing.Size(705, 191);
			this.uxTransactionTabPage.TabIndex = 2;
			this.uxTransactionTabPage.Text = "Transaction";
			this.uxTransactionTabPage.UseVisualStyleBackColor = true;
			// 
			// uxCancelButton
			// 
			this.uxCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.uxCancelButton.Location = new System.Drawing.Point(540, 470);
			this.uxCancelButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.uxCancelButton.Name = "uxCancelButton";
			this.uxCancelButton.Size = new System.Drawing.Size(88, 27);
			this.uxCancelButton.TabIndex = 1;
			this.uxCancelButton.Text = "Cancel";
			this.uxCancelButton.UseVisualStyleBackColor = true;
			// 
			// uxSendButton
			// 
			this.uxSendButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.uxSendButton.Location = new System.Drawing.Point(635, 470);
			this.uxSendButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.uxSendButton.Name = "uxSendButton";
			this.uxSendButton.Size = new System.Drawing.Size(88, 27);
			this.uxSendButton.TabIndex = 2;
			this.uxSendButton.Text = "Send";
			this.uxSendButton.UseVisualStyleBackColor = true;
			this.uxSendButton.Click += new System.EventHandler(this.uxSendButton_Click);
			// 
			// uxTrackerIdTextBox
			// 
			this.uxTrackerIdTextBox.Location = new System.Drawing.Point(113, 24);
			this.uxTrackerIdTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.uxTrackerIdTextBox.Name = "uxTrackerIdTextBox";
			this.uxTrackerIdTextBox.Size = new System.Drawing.Size(134, 23);
			this.uxTrackerIdTextBox.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(19, 28);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(60, 15);
			this.label1.TabIndex = 4;
			this.label1.Text = "TrackerId :";
			// 
			// uxUserAgentTextBox
			// 
			this.uxUserAgentTextBox.Location = new System.Drawing.Point(113, 54);
			this.uxUserAgentTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.uxUserAgentTextBox.Name = "uxUserAgentTextBox";
			this.uxUserAgentTextBox.Size = new System.Drawing.Size(574, 23);
			this.uxUserAgentTextBox.TabIndex = 3;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(19, 58);
			this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(71, 15);
			this.label5.TabIndex = 4;
			this.label5.Text = "User Agent :";
			// 
			// uxIPTextBox
			// 
			this.uxIPTextBox.Location = new System.Drawing.Point(113, 84);
			this.uxIPTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.uxIPTextBox.Name = "uxIPTextBox";
			this.uxIPTextBox.Size = new System.Drawing.Size(134, 23);
			this.uxIPTextBox.TabIndex = 3;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(19, 88);
			this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(23, 15);
			this.label6.TabIndex = 4;
			this.label6.Text = "IP :";
			// 
			// uxClientIdTextBox
			// 
			this.uxClientIdTextBox.Location = new System.Drawing.Point(113, 114);
			this.uxClientIdTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.uxClientIdTextBox.Name = "uxClientIdTextBox";
			this.uxClientIdTextBox.Size = new System.Drawing.Size(462, 23);
			this.uxClientIdTextBox.TabIndex = 3;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(19, 118);
			this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(54, 15);
			this.label7.TabIndex = 4;
			this.label7.Text = "ClientId :";
			// 
			// uxGenerateUserIdButton
			// 
			this.uxGenerateUserIdButton.Location = new System.Drawing.Point(583, 112);
			this.uxGenerateUserIdButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.uxGenerateUserIdButton.Name = "uxGenerateUserIdButton";
			this.uxGenerateUserIdButton.Size = new System.Drawing.Size(105, 27);
			this.uxGenerateUserIdButton.TabIndex = 5;
			this.uxGenerateUserIdButton.Text = "Generate";
			this.uxGenerateUserIdButton.UseVisualStyleBackColor = true;
			this.uxGenerateUserIdButton.Click += new System.EventHandler(this.uxGenerateUserIdButton_Click);
			// 
			// MainForm
			// 
			this.AcceptButton = this.uxSendButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.uxCancelButton;
			this.ClientSize = new System.Drawing.Size(741, 511);
			this.Controls.Add(this.uxGenerateUserIdButton);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.uxTrackerIdTextBox);
			this.Controls.Add(this.uxSendButton);
			this.Controls.Add(this.uxCancelButton);
			this.Controls.Add(this.uxTabControl);
			this.Controls.Add(this.uxClientIdTextBox);
			this.Controls.Add(this.uxIPTextBox);
			this.Controls.Add(this.uxUserAgentTextBox);
			this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.ShowIcon = false;
			this.Text = "Aquila";
			this.uxTabControl.ResumeLayout(false);
			this.uxPageTabPage.ResumeLayout(false);
			this.uxPageTabPage.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TabControl uxTabControl;
		private System.Windows.Forms.TabPage uxPageTabPage;
		private System.Windows.Forms.TabPage uxEventTabPage;
		private System.Windows.Forms.Button uxCancelButton;
		private System.Windows.Forms.Button uxSendButton;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox uxRefererTextBox;
		private System.Windows.Forms.TextBox uxUrlTextBox;
		private System.Windows.Forms.TextBox uxTrackerIdTextBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox uxPageTitleTextBox;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox uxIPTextBox;
		private System.Windows.Forms.TextBox uxUserAgentTextBox;
		private System.Windows.Forms.TabPage uxTransactionTabPage;
		private System.Windows.Forms.TextBox uxClientIdTextBox;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button uxGenerateUserIdButton;
	}
}

