# SN.FreshDesk .NET

<a href="https://ci.appveyor.com/project/syron/sn-freshdesk" target="_blank"><img src="https://ci.appveyor.com/api/projects/status/tua55bko590mtoax?svg=true" /></a>
<a href="https://www.nuget.org/packages/sn.FreshDesk/" target="_blank"><img src="https://img.shields.io/nuget/dt/SN.FreshDesk.svg" /></a>
<a href="https://www.nuget.org/packages/sn.FreshDesk/" target="_blank"><img src="https://img.shields.io/nuget/v/SN.FreshDesk.svg" /></a>

##### Links
* [NuGet Package Site](https://www.nuget.org/packages/SN.FreshDesk/)
* [FreshDesk API](http://freshdesk.com/api)


##### Table of Contents
- [SN.FreshDesk .NET](#snfreshdesk-net)
        - [Links](#links)
  - [NuGet Package](#nuget-package)
    - [Get Started](#get-started)
      - [Install NuGet Package](#install-nuget-package)
      - [Usage](#usage)
        - [Create FreshDesk Object](#create-freshdesk-object)
        - [Tickets](#tickets)
          - [Get List of Tickets](#get-list-of-tickets)
          - [Get Ticket Details](#get-ticket-details)
        - [Forum](#forum)
          - [Get Forum Details](#get-forum-details)
        - [Topics](#topics)
          - [Get Topic Details](#get-topic-details)
  - [Connector](#connector)
    - [Trigger](#trigger)
      - [TopicPoll](#topicpoll)

## NuGet Package

### Get Started
Description coming soon.

#### Install NuGet Package
```C#
Install-Package SN.FreshDesk
```

#### Usage
#####  Create FreshDesk Object
```C#
FreshDesk fd = new FreshDesk("YOUR-API-KEY", "YOUR FRESHDESK DOMAIN");
```

##### Customers

###### Get List of Customers
```C#
FreshDesk fd = new FreshDesk("YOUR-API-KEY", "YOUR FRESHDESK DOMAIN");
var customers = await fd.GetCustomers();
```

##### Tickets

###### Get List of Tickets
```C#
FreshDesk fd = new FreshDesk("YOUR-API-KEY", "YOUR FRESHDESK DOMAIN");
var tickets = await fd.GetTickets();
```

###### Get Ticket Details
```C#
FreshDesk fd = new FreshDesk("YOUR-API-KEY", "YOUR FRESHDESK DOMAIN");
var ticket = await fd.GetTicket(TICKET_ID);
```

##### Forum

###### Get Forum Details
```C#
FreshDesk fd = new FreshDesk("YOUR-API-KEY", "YOUR FRESHDESK DOMAIN");
var forum = await fd.GetForum(FORUM_ID);
```

##### Topics

###### Get Topic Details
```C#
FreshDesk fd = new FreshDesk("YOUR-API-KEY", "YOUR FRESHDESK DOMAIN");
var forum = await fd.GetTopic(FORUM_ID);
```


## Connector

### Trigger

#### TopicPoll

Polls a specific forum for newly created topics and its first post.
