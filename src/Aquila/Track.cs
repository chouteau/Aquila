using System;
using System.Collections.Generic;

namespace Aquila
{
    /// <summary>
    /// see https://developers.google.com/analytics/devguides/collection/protocol/v1/parameters
    /// </summary>
    internal class Track : ICloneable
    {
        internal Track()
        {
            AnonymizeIp = false;
            ProductList = new List<ProductTrack>();
            ProductImpressionList = new List<ProductImpressionTrack>();
            PromotionList = new List<PromotionTrack>();
        }

        #region General

        /// <summary>
        /// The Protocol version. The current value is '1'. This will only change when there are
        /// changes made that are not backwards compatible.
        /// </summary>
        /// <example>Example value: 1 Example usage: v=1</example>
        [Parameter("v")]
        public string ProtocolVersion { get; set; }

        /// <summary>
        /// The tracking ID / web property ID. The format is UA-XXXX-Y. All collected data is
        /// associated by this ID.
        /// </summary>
        /// <example>Example value: UA-XXXX-Y Example usage: tid=UA-XXXX-Y</example>
        [Parameter("tid")]
        public string TrackingId { get; set; }

        /// <summary> When present, the IP address of the sender will be anonymized. For example, the
        /// IP will be anonymized if any of the following parameters are present in the payload:
        /// &aip=, &aip=0, or &aip=1 </summary> <example> Example value: 1 Example usage: aip=1 </example>
        [Parameter("aip")]
        public bool AnonymizeIp { get; set; }

        /// <summary>
        /// Used to collect offline / latent hits. The value represents the time delta (in
        /// milliseconds) between when the hit being reported occurred and the time the hit was sent.
        /// The value must be greater than or equal to 0. Values greater than four hours may lead to
        /// hits not being processed.
        /// </summary>
        /// <example>Example value: 560 Example usage: qt=560</example>
        [Parameter("qt")]
        public int? QueueTime { get; set; }

        /// <summary>
        /// Used to send a random number in GET requests to ensure browsers and proxies don't cache
        /// hits. It should be sent as the final parameter of the request since we've seen some 3rd
        /// party internet filtering software add additional parameters to HTTP requests incorrectly.
        /// This value is not used in reporting.
        /// </summary>
        /// <example>Example value: 289372387623 Example usage: z=289372387623</example>
        [Parameter("z")]
        public string CacheBuster { get; set; }

        #endregion General

        #region User

        // cid
        /// <summary>
        /// This anonymously identifies a particular user, device, or browser instance. For the web,
        /// this is generally stored as a first-party cookie with a two-year expiration. For mobile
        /// apps, this is randomly generated for each particular instance of an application install.
        /// The value of this field should be a random UUID (version 4) as described in http://www.ietf.org/rfc/rfc4122.txt
        /// </summary>
        /// <example>Example value: 35009a79-1a05-49d7-b876-2b884d0f825b Example usage: cid=35009a79-1a05-49d7-b876-2b884d0f825b</example>
        [Parameter("cid")]
        public string ClientId { get; set; }

        // uid
        /// <summary>
        /// This is intended to be a known identifier for a user provided by the site owner/tracking
        /// library user. It may not itself be PII. The value should never be persisted in GA cookies
        /// or other Analytics provided storage.
        /// </summary>
        /// <example>Example value: as8eknlll Example usage: uid=as8eknlll</example>
        [Parameter("uid")]
        public string UserId { get; set; }

        #endregion User

        #region Session

        // sc
        /// <summary>
        /// Used to control the session duration. A value of 'start' forces a new session to start
        /// with this hit and 'end' forces the current session to end with this hit. All other values
        /// are ignored.
        /// </summary>
        /// <example>
        /// Example value: start Example usage: sc=start
        ///
        /// Example value: end Example usage: sc=end
        /// </example>
        [Parameter("sc")]
        public string SessionControl { get; set; }

        // uip
        /// <summary> The IP address of the user. This should be a valid IP address. It will always
        /// be anonymized just as though &aip (anonymize IP) had been used. </summary> <example>
        /// Example value: 1.2.3.4 Example usage: uip=1.2.3.4 </example>
        [Parameter("uip")]
        public string IPOverride { get; set; }

        // ua
        /// <summary>
        /// The User Agent of the browser. Note that Google has libraries to identify real user
        /// agents. Hand crafting your own agent could break at any time.
        /// </summary>
        /// <example>
        /// Example value: Opera/9.80 (Windows NT 6.0) Presto/2.12.388 Version/12.14 Example usage: ua=Opera%2F9.80%20%28Windows%20NT%206.0%29%20Presto%2F2.12.388%20Version%2F12.14
        /// </example>
        [Parameter("ua")]
        public string UserAgentOverride { get; set; }

        #endregion Session

        #region Traffic Sources

        // dr
        /// <summary>
        /// Specifies which referral source brought traffic to a website. This value is also used to
        /// compute the traffic source. The format of this value is a URL.
        /// </summary>
        /// <example>Example value: http://example.com Example usage: dr=http%3A%2F%2Fexample.com</example>
        [Parameter("dr")]
        public string DocumentReferer { get; set; }

        // cn
        /// <summary>
        /// Specifies the campaign name.
        /// </summary>
        /// <example>Example value: (direct) Example usage: cn=%28direct%29</example>
        [Parameter("cn")]
        public string CampaignName { get; set; }

        // cs
        [Parameter("cs")]
        public string CampaignSource { get; set; }

        // cm
        [Parameter("cm")]
        public string CampaignMedium { get; set; }

        // ck
        [Parameter("ck")]
        public string CampaignKeyword { get; set; }

        // cc
        [Parameter("cc")]
        public string CampaignContent { get; set; }

        // ci
        [Parameter("ci")]
        public string CampaignId { get; set; }

        // gclid
        [Parameter("gclid")]
        public string GoogleAdwordsId { get; set; }

        // dclid
        [Parameter("dclid")]
        public string GoogleDisplayAdsId { get; set; }

        #endregion Traffic Sources

        #region System Info

        // sr
        public string ScreeResolution { get; set; }

        // vp
        public string ViewportSize { get; set; }

        // de
        public string DocumentEncoding { get; set; }

        // sd
        public string ScreenColors { get; set; }

        // ul
        public string UserLanguage { get; set; }

        // je
        public bool? JavaEnabled { get; set; }

        // fl
        public string FlashVersion { get; set; }

        #endregion System Info

        #region Hit

        // t
        /// <summary>
        /// The type of hit. Must be one of 'pageview', 'screenview', 'event', 'transaction', 'item',
        /// 'social', 'exception', 'timing'.
        /// </summary>
        /// <example>Example value: pageview Example usage: t=pageview</example>
        [Parameter("t")]
        public string HitType { get; set; }

        // ni
        [Parameter("ni")]
        public bool NonInteractionHit { get; set; }

        #endregion Hit

        #region Content Information

        /// <summary> Use this parameter to send the full URL (document location) of the page on
        /// which content resides. You can use the &dh and &dp parameters to override the hostname
        /// and path + query portions of the document location, accordingly. The JavaScript clients
        /// determine this parameter using the concatenation of the document.location.origin +
        /// document.location.pathname + document.location.search browser parameters. Be sure to
        /// remove any user authentication or other private information from the URL if present.
        /// </summary> <example> Example value: http://foo.com/home?a=b Example usage:
        /// dl=http%3A%2F%2Ffoo.com%2Fhome%3Fa%3Db </example>
        [Parameter("dl")]
        public string DocumentLocationUrl { get; set; }

        /// <summary>
        /// Specifies the hostname from which content was hosted.
        /// </summary>
        /// <example>Example value: foo.com Example usage: dh=foo.com</example>
        [Parameter("dh")]
        public string DocumentHostName { get; set; }

        /// <summary>
        /// The path portion of the page URL. Should begin with '/'.
        /// </summary>
        /// <example>Example value: /foo Example usage: dp=%2Ffoo</example>
        [Parameter("dp")]
        public string DocumentPath { get; set; }

        /// <summary>
        /// The title of the page / document.
        /// </summary>
        /// <example>Example value: Settings Example usage: dt=Settings</example>
        [Parameter("dt")]
        public string DocumentTitle { get; set; }

        /// <summary> If not specified, this will default to the unique URL of the page by either
        /// using the &dl parameter as-is or assembling it from &dh and &dp. App tracking makes use
        /// of this for the 'Screen Name' of the screenview hit. </summary> <example> Example value:
        /// High Scores Example usage: cd=High%20Scores </example>
        [Parameter("cd")]
        public string ScreenName { get; set; }

        /// <summary>
        /// The ID of a clicked DOM element, used to disambiguate multiple links to the same URL in
        /// In-Page Analytics reports when Enhanced Link Attribution is enabled for the property.
        /// </summary>
        /// <example>Example value: nav_bar Example usage: linkid=nav_bar</example>
        [Parameter("linkid")]
        public string LinkId { get; set; }

        #endregion Content Information

        #region App Tracking

        // an
        public string ApplicationName { get; set; }

        // aid
        public string ApplicationId { get; set; }

        // av
        public string ApplicationVersion { get; set; }

        // aiid
        public string ApplicationInstallerId { get; set; }

        #endregion App Tracking

        #region EventTracking

        /// <summary>
        /// Specifies the event category. Must not be empty.
        /// </summary>
        /// <example>Example value: Category Example usage: ec=Category</example>
        [Parameter("ec", 150)]
        public string EventCategory { get; set; }

        /// <summary>
        /// Specifies the event action. Must not be empty.
        /// </summary>
        /// <example>Example value: Action Example usage: ea=Action</example>
        [Parameter("ea", 500)]
        public string EventAction { get; set; }

        /// <summary>
        /// Specifies the event label.
        /// </summary>
        /// <example>Example value: Label Example usage: el=Label</example>
        [Parameter("el", 500)]
        public string EventLabel { get; set; }

        /// <summary>
        /// Specifies the event value. Values must be non-negative.
        /// </summary>
        /// <example>Example value: 55 Example usage: ev=55</example>
        [Parameter("ev")]
        public int? EventValue { get; set; }

        #endregion EventTracking

        #region E-Commerce

        /// <summary>
        /// Required for transaction hit type. Required for item hit type. A unique identifier for
        /// the transaction. This value should be the same for both the Transaction hit and Items
        /// hits associated to the particular transaction.
        /// </summary>
        /// <example>Example value: OD564 Example usage: ti=OD564</example>
        [Parameter("ti", 500)]
        public string TransactionId { get; set; }

        /// <summary>
        /// Specifies the affiliation or store name.
        /// </summary>
        /// <example>Example value: Member Example usage: ta=Member</example>
        [Parameter("ta", 500)]
        public string TransactionAffiliation { get; set; }

        /// <summary>
        /// Specifies the total revenue associated with the transaction. This value should include
        /// any shipping or tax costs.
        /// </summary>
        /// <example>Example value: 15.47 Example usage: tr=15.47</example>
        [Parameter("tr", 0)]
        public decimal? TransactionRevenue { get; set; }

        /// <summary>
        /// Specifies the total shipping cost of the transaction.
        /// </summary>
        /// <example>Example value: 3.50 Example usage: ts=3.50</example>
        [Parameter("ts")]
        public decimal? TransactionShipping { get; set; }

        /// <summary>
        /// Specifies the total tax of the transaction.
        /// </summary>
        /// <example>Example value: 11.20 Example usage: tt=11.20</example>
        [Parameter("tt")]
        public decimal? TransactionTax { get; set; }

        /// <summary>
        /// Specifies the item name.
        /// </summary>
        /// <example>Example value: Shoe Example usage: in=Shoe</example>
        [Parameter("in", 500)]
        public string ItemName { get; set; }

        /// <summary>
        /// Specifies the price for a single item / unit.
        /// </summary>
        /// <example>Example value: 3.50 Example usage: ip=3.50</example>
        [Parameter("ip")]
        public decimal? ItemPrice { get; set; }

        /// <summary>
        /// Specifies the number of items purchased.
        /// </summary>
        /// <example>Example value: 4 Example usage: iq=4</example>
        [Parameter("iq")]
        public int? ItemQuantity { get; set; }

        /// <summary>
        /// Specifies the SKU or item code.
        /// </summary>
        /// <example>Example value: SKU47 Example usage: ic=SKU47</example>
        [Parameter("ic", 500)]
        public string ItemCode { get; set; }

        /// <summary>
        /// Specifies the category that the item belongs to.
        /// </summary>
        /// <example>Example value: Blue Example usage: iv=Blue</example>
        [Parameter("iv", 500)]
        public string ItemCategory { get; set; }

        /// <summary>
        /// When present indicates the local currency for all transaction currency values. Value
        /// should be a valid ISO 4217 currency code.
        /// </summary>
        /// <example>Example value: EUR Example usage: cu=EUR</example>
        [Parameter("cu", 10)]
        public string CurrencyCode { get; set; }

        #endregion E-Commerce

        #region Enhanced E-Commerce

        /// <summary>
        /// The role of the products included in a hit. If a product action is not specified, all
        /// product definitions included with the hit will be ignored. Must be one of: detail, click,
        /// add, remove, checkout, checkout_option, purchase, refund. For analytics.js the Enhanced
        /// Ecommerce plugin must be installed before using this field.
        /// </summary>
        /// <example>Example value: detail Example usage: pa=detail</example>
        [Parameter(@"pa")]
        public string ProductAction { get; set; }

        /// <summary>
        /// The list or collection from which a product action occurred. This is an additional
        /// parameter that can be sent when Product Action is set to 'detail' or 'click'. For
        /// analytics.js the Enhanced Ecommerce plugin must be installed before using this field.
        /// </summary>
        /// <example>Example value: Search Results Example usage: pal=Search%20Results</example>
        [Parameter(@"pal")]
        public string ProductActionList { get; set; }

        /// <summary>
        /// List of product
        /// </summary>
        public IList<ProductTrack> ProductList { get; private set; }

        /// <summary>
        /// The role of the products included in a hit. If a product action is not specified, all
        /// product definitions included with the hit will be ignored. Must be one of: detail, click,
        /// add, remove, checkout, checkout_option, purchase, refund. For analytics.js the Enhanced
        /// Ecommerce plugin must be installed before using this field.
        /// </summary>
        /// <example>Example value: 2 Example usage: cos=2</example>
        [Parameter(@"cos")]
        public int CheckoutStep { get; set; }

        /// <summary>
        /// Additional information about a checkout step. This is an additional parameter that can be
        /// sent when Product Action is set to 'checkout'. For analytics.js the Enhanced Ecommerce
        /// plugin must be installed before using this field.
        /// </summary>
        /// <example>Example value: Visa Example usage: col=Visa</example>
        [Parameter(@"col")]
        public string CheckoutStepOption { get; set; }

        /// <summary>
        /// List of product impression
        /// </summary>
        public IList<ProductImpressionTrack> ProductImpressionList { get; private set; }

        /// <summary>
        /// Specifies the role of the promotions included in a hit. If a promotion action is not
        /// specified, the default promotion action, 'view', is assumed. To measure a user click on a
        /// promotion set this to 'promo_click'. For analytics.js the Enhanced Ecommerce plugin must
        /// be installed before using this field.
        /// </summary>
        /// <example>Example value: click Example usage: promoa=click</example>
        [Parameter(@"promoa")]
        public int PromotionAction { get; set; }

        /// <summary>
        /// List of promotions
        /// </summary>
        public IList<PromotionTrack> PromotionList { get; private set; }

        #endregion Enhanced E-Commerce

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}