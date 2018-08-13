namespace Aquila
{
    public class Settings
    {
        public Settings()
        {
            UrlEndPoint = "http://www.google-analytics.com/collect";
            CookieName = "_ga";
            BanishedExtensions = ".gif,.png,.bmp,.jpg,.js,.css";
            CampaignParameterName = "utm_campaign";
            CampaignSourceParameterName = "utm_source";
            CampaignMediumParameterName = "utm_medium";
            CampaignKeywordParameterName = "utm_keyword";
            CampaignContentParameterName = "utm_content";
            CampaignIdParameterName = "utm_campaign_id";
            GoogleAdwordsParameterName = "gclid";
            GoogleDisplayAdsIdParamterName = "dclid";
            AutoStart = false;
            CurrencyCode = "EUR";
            StartSelfAutoMapper = true;
        }

        public bool AutoStart { get; set; }
        public string UrlEndPoint { get; set; }
        public string TrackingId { get; set; }
        public string CookieName { get; set; }
        public string BanishedExtensions { get; set; }
        public string CampaignParameterName { get; set; }
        public string CampaignSourceParameterName { get; set; }
        public string CampaignMediumParameterName { get; set; }
        public string CampaignKeywordParameterName { get; set; }
        public string CampaignContentParameterName { get; set; }
        public string CampaignIdParameterName { get; set; }
        public string GoogleAdwordsParameterName { get; set; }
        public string GoogleDisplayAdsIdParamterName { get; set; }
        public string CurrencyCode { get; set; }
        public bool StartSelfAutoMapper { get; set; }
    }
}