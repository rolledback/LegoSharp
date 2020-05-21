# LegoSharp

LegoSharp is an unofficial library for interacting with Lego's web API. Lego recently changed their web API, so this project is undergoing a significant amount of redevelopment. Functionality is very limited at this time.

[![Build Status](https://mrayermann.visualstudio.com/LegoSharp/_apis/build/status/rolledback.LegoSharp?branchName=master)](https://mrayermann.visualstudio.com/LegoSharp/_build/latest?definitionId=1&branchName=master)

![Nuget](https://img.shields.io/nuget/v/LegoSharp)

## Usage

Searching the Lego graph is currently the only supported action.

To search the graph, you first make a graph client.
```C#
LegoGraphClient graphClient = new LegoGraphClient();
```

You then authenticate the client (no Lego account is required).
```C#
await graphClient.authenticateAsync();
```

Once you authenticate, you create a graph search. The search can use a variety of filters, or specify a specific text based query.
```C#
LegoGraphSearch graphSearch = new LegoGraphSearch();
graphSearch.addFilter(new ColorFilter()
    .addValue(LegoColor.Black)
);
graphSearch.query = "wheel";
```

Once you have your graph search ready, you give it to the graph client who will execute the search.
```C#
IEnumerable<Brick> result = await graphClient.searchForBricksAsync(graphSearch);

foreach (Brick brick in result)
{
    // do something with each brick
}
```
