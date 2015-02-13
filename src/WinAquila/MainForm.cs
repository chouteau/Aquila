using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinAquila
{
	public partial class MainForm : Form
	{
		private Settings m_Settings;

		public MainForm()
		{
			InitializeComponent();
		}

		protected override void OnLoad(EventArgs e)
		{
			m_Settings = new Settings();
			m_Settings.Load();
			uxClientIdTextBox.Text = Guid.NewGuid().ToString();
			uxTrackerIdTextBox.DataBindings.Add("Text", m_Settings, "TrackerId", false, DataSourceUpdateMode.OnPropertyChanged);
			uxUserAgentTextBox.DataBindings.Add("Text", m_Settings, "UserAgent", false, DataSourceUpdateMode.OnPropertyChanged);
		}

		protected override void OnClosed(EventArgs e)
		{
			m_Settings.SaveSettings();
		}

		private void uxSendButton_Click(object sender, EventArgs e)
		{
			Aquila.TrackBuilder track = null;
			if (uxTabControl.SelectedTab == uxPageTabPage)
			{
				track = CreatePageTrack();
			}
			Task.Run(async () =>
				{
					await track.SendAsync();
				});
		}

		private Aquila.TrackBuilder CreatePageTrack()
		{
			var track = new Aquila.PageTrack();
			track.TrackingId = uxTrackerIdTextBox.Text;
			track.ClientId = Guid.NewGuid().ToString();

			var uri = new Uri(uxUrlTextBox.Text);
			track.HostName = uri.Host;
			track.PathAndQuery = uri.PathAndQuery;
			track.Referer = uxRefererTextBox.Text;
			track.Title = uxPageTitleTextBox.Text;
			track.IPOverride = uxIPTextBox.Text;
			track.UserAgentOverride = uxUserAgentTextBox.Text;

			return track;
		}

		private void uxGenerateUserIdButton_Click(object sender, EventArgs e)
		{
			uxClientIdTextBox.Text = Guid.NewGuid().ToString();
		}
	}
}
