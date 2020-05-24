# LegoSharp

LegoSharp is an unofficial library for interacting with Lego's web API. Lego recently changed their web API, so this project is undergoing a significant amount of redevelopment. Functionality is very limited at this time.

[![Build Status](https://mrayermann.visualstudio.com/LegoSharp/_apis/build/status/rolledback.LegoSharp?branchName=master)](https://mrayermann.visualstudio.com/LegoSharp/_build/latest?definitionId=1&branchName=master)

[![Nuget](https://img.shields.io/nuget/v/LegoSharp)](https://www.nuget.org/packages/LegoSharp/)

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

Once you authenticate, you can query different graph APIs.

## Pick a Brick

You can query [Pick a Brick](https://www.lego.com/en-us/page/static/pick-a-brick).
```C#
LegoGraphClient graphClient = new LegoGraphClient();
await graphClient.authenticateAsync();

PickABrickQuery query = new PickABrickQuery();
query.addFilter(new ColorFilter()
    .addValue(BrickColor.Black)
);
query.query = "wheel";

PickABrickQueryResult result = await graphClient.pickABrick(query);
foreach (Brick brick in result.elements)
{
    // do something with each brick
}
```

## Product Search

You can query for Lego Products.
```C#
LegoGraphClient graphClient = new LegoGraphClient();
await graphClient.authenticateAsync();

ProductSearchQuery query = new ProductSearchQuery();
query.addFilter(new ProductCategoryFilter()
    .addValue(ProductCategory.Sets)
);
query.query = "train";

await graphClient.productSearch(query);
```
