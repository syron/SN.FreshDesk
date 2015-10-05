# SN.FreshDesk .NET

<a href="https://ci.appveyor.com/project/syron/ibss-freshdesk" target="_blank"><img src="https://ci.appveyor.com/api/projects/status/w0vft5yxfndhekcb?svg=true" /></a>


Links List:

* [NuGet Package Site](https://www.nuget.org/packages/FreshDesk/)
* [FreshDesk API](http://freshdesk.com/api)


### Get Started
Description coming soon.

#### Install NuGet Package
```C#
Install-Package SN.FreshDesk
```

#### Create FreshDesk Object
```C#
FreshDesk fd = new FreshDesk("YOUR-API-KEY", "YOUR FRESHDESK DOMAIN");
```

#### Tickets

##### Get List of Tickets
```C#
FreshDesk fd = new FreshDesk("YOUR-API-KEY", "YOUR FRESHDESK DOMAIN");
var tickets = await fd.GetTickets();
```

##### Get Ticket Details
```C#
FreshDesk fd = new FreshDesk("YOUR-API-KEY", "YOUR FRESHDESK DOMAIN");
var ticket = await fd.GetTicket(TICKET_ID);
```

#### Forum

##### Get Forum Details
```C#
FreshDesk fd = new FreshDesk("YOUR-API-KEY", "YOUR FRESHDESK DOMAIN");
var forum = await fd.GetForum(FORUM_ID);
```

#### Topics

##### Get Topic Details
```C#
FreshDesk fd = new FreshDesk("YOUR-API-KEY", "YOUR FRESHDESK DOMAIN");
var forum = await fd.GetTopic(FORUM_ID);
```
