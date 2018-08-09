namespace Aquila
{
    public class Campaign
	{
		private Track m_Track;

		internal Campaign(Track track)
		{
			m_Track = track;
		}

		public string CampaignName 
		{ 
			get
			{
				return m_Track.CampaignName;
			}
			set
			{
				m_Track.CampaignName = value;
			}
		}

		public string CampaignSource 
		{ 
			get
			{
				return m_Track.CampaignSource;
			}
			set
			{
				m_Track.CampaignSource = value;
			}
		}

		public string CampaignMedium 
		{ 
			get
			{
				return m_Track.CampaignMedium;
			}
			set
			{
				m_Track.CampaignMedium = value;
			}
		}

		public string CampaignKeyword 
		{ 
			get
			{
				return m_Track.CampaignKeyword;
			}
			set
			{
				m_Track.CampaignKeyword = value;
			}
		}

		public string CampaignContent 
		{
			get
			{
				return m_Track.CampaignContent;
			}
			set
			{
				m_Track.CampaignContent = value;
			}
		}

		public string CampaignId 
		{ 
			get
			{
				return m_Track.CampaignId;
			}
			set
			{
				m_Track.CampaignId = value;
			}
		}

	}
}
