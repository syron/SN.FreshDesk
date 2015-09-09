# IBSS.FreshDesk .NET

<a href="https://ci.appveyor.com/project/syron/ibss-freshdesk" target="_blank"><img src="https://ci.appveyor.com/api/projects/status/w0vft5yxfndhekcb?svg=true" /></a>



Links List:

* [NuGet Package Site](https://www.nuget.org/packages/IBSS.FreshDesk/)
* [Integration Software](http://www.integrationsoftware.se/)


### Get Started
Description coming soon.

#### Install NuGet Package
```C#
Install-Package IBSS.FreshDesk
```

#### Create FreshDesk Object
```C#
FreshDesk fd = new FreshDesk("YOUR-API-KEY, "YOUR FRESHDESK DOMAIN");
```

#### Forum

##### Get Forum Details
```C#
FreshDesk fd = new FreshDesk("YOUR-API-KEY, "YOUR FRESHDESK DOMAIN");
var forum = await fd.GetForum(FORUM_ID);
```

#### Topics

##### Get Topic Details
```C#
FreshDesk fd = new FreshDesk("YOUR-API-KEY, "YOUR FRESHDESK DOMAIN");
var forum = await fd.GetTopic(FORUM_ID);
```
