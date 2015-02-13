# Aquila
Send user interaction to **Google Analytics** servers without javascript tag.

## Aquila help you to send many informations from your website

* Page
* Event
* Transaction

You can use **Aquila** with Microsoft AspNet website

## Usage sample

```c#

var track = new Aquila.PageTrack()
track.TrackingId = "UA-XXXX-Y";
track.UserId = Guid.NewId().ToString();
track.NonInteraction = true;
track.Url = "http://www.sample.com";
track.Title = "page title";
await track.SendAsync();

```




