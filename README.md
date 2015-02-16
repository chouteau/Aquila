# Aquila (3.3.10)
Send user interaction to **Google Analytics** servers without javascript tag.

**Aquila** can by used with Microsoft .Net 4.5 (minimum).
you can use **Aquila** with an AspNet website (WebForms or MVC) or WinFoms/Wpf

See : https://developers.google.com/analytics/devguides/collection/protocol/v1/devguide

![Aquila GAnalytics](/aquila.png)

## Where can I get it ?

First, [install Nuget](http://docs.nuget.org/docs/start-here/installing-nuget) then, install [Aquila](http://www.nuget.org/packages/aquila) from the package manager console.

> PM> Install-Package Aquila 

With Microsoft Visual Studio :

![Aquila Nuget](/nuget.png)

## Aquila help you to send many informations from your website

* Page
* Event
* Transaction

## Usage sample

### Send simple page to google analytics
```c#

var track = new Aquila.PageTrack();
track.TrackingId = "UA-XXXX-Y";
track.UserId = Guid.NewId().ToString();
track.NonInteraction = true;
track.Url = "http://www.sample.com";
track.Title = "page title";
await track.SendAsync();

```

### Send event to google analytics
```c#

var track = new Aquila.EventTrack();
track.TrackingId = "UA-XXXX-Y";
track.UserId = Guid.NewId().ToString();
track.NonInteraction = true;
track.Action = "action";
track.Category = "category";
track.Label = "label";
track.Value = 10;
await track.SendAsync();

```

### Send eCommerce Transaction to google analytics
```c#

var track = new Aquila.TransactionTrack();
track.TrackingId = "UA-XXXX-Y";
track.UserId = Guid.NewId().ToString();
track.TransactionId = "Tran01";
track.RevenueWithTax = 100.0m;
track.ShippingWithTax = 10.0m;
track.Tax = 20.0m;
track.ItemList.Add(new TransactionItem()
{
	Code = "item1",
	Category = "cat1",
	Name = "item1Name",
	PriceWithTax = 10.0m,
	Quantity = 9
});
await track.SendAsync();

```

## Configuration

You can use configuration file to store settings

```xml
<configuration>
	<configSections>
		<section name="aquila" type="System.Configuration.AppSettingsSection, System.Configuration, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" restartOnExternalChanges="false" requirePermission="false" />
	</configSections>
	<aquila>
		<add key="trackingId" value="UA-XXXX-Y" />
	</aquila>
</configuration>
```

Or by code

```c#
Aquila.GlobalConfiguration.Configuration.Settings.TrackingId = "UA-XXXX-Y";
```

Parameters | Default Value | Description
-----------| --------------|------------- 
AutoStart | false | Use module mode and send all pages to google analytics in AspNet classic website (WebForms)
TrackingId| null | The tracking ID / web property ID. The format is UA-XXXX-Y. All collected data is associated by this ID.
BanishedExtensions | .gif,.png,.bmp,.jpg,.js,.css | if you use automatic sending , this extensions does not sent
CampaignParameterName | utm_campaign | name of parameter in url match the campaign

## Logging

By default Aquila use System.Diagnostic for logging, but you can use your own logger that way :

```c#

public class AquilaLogger : Aquila.ILogger
{
	private YourLogger m_InnerLogger;

	public AquilaLogger(YourLogger logger)
	{
		m_InnerLogger = logger;
	}

	#region ILogger Members

	public void Info(string message)
	{
		m_InnerLogger.Log(message);
	}

	public void Info(string message, params object[] prms)
	{
		m_InnerLogger.Log(message);
	}

	public void Warn(string message)
	{
		m_InnerLogger.Log(message);
	}

	public void Warn(string message, params object[] prms)
	{
		m_InnerLogger.Log(message);
	}

	public void Debug(string message)
	{
		m_InnerLogger.Log(message);
	}

	public void Debug(string message, params object[] prms)
	{
		m_InnerLogger.Log(message);
	}

	public void Error(string message)
	{
		m_InnerLogger.Log(message);
	}

	public void Error(string message, params object[] prms)
	{
		m_InnerLogger.Log(message);
	}

	public void Error(Exception x)
	{
		m_InnerLogger.Log(message);
	}

	public void Fatal(string message)
	{
		m_InnerLogger.Log(message);
	}

	public void Fatal(string message, params object[] prms)
	{
		m_InnerLogger.Log(message);
	}

	public void Fatal(Exception x)
	{
		m_InnerLogger.Log(message);
	}

	public void Notification(string message)
	{
		m_InnerLogger.Log(message);
	}

	public void Notification(string message, params object[] prms)
	{
		m_InnerLogger.Log(message);
	}

	public System.IO.TextWriter Out
	{
		get { return null; }
	}

	public void Watch(string title, System.Threading.ThreadStart method)
	{
		method.Invoke();
	}

	#endregion
}

var aquilaLogger = new AquilaLogger(yourLogger);
Aquila.GlobalConfiguration.Configuration.Logger = aquilaLogger;

```





