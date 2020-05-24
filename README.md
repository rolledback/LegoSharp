# LegoSharp

LegoSharp is an unofficial C# library for interacting with Lego's web APIs.

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

### Pick a Brick

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

### Product Search

You can query for Lego Products.
```C#
LegoGraphClient graphClient = new LegoGraphClient();
await graphClient.authenticateAsync();

ProductSearchQuery query = new ProductSearchQuery();
query.addFilter(new ProductCategoryFilter()
    .addValue(ProductCategory.Sets)
);
query.query = "train";

ProductSearchResult result = await graphClient.productSearch(query);
foreach (Product product in result.products)
{
    // do something with each product
}
```

## Contributing

Contributions are welcome. I'd reccomend first opening an issue for what you want to add so we can talk about implementation details. When you're ready to code, simply fork, make your changes, and then open a pull request. I will ask you to add tests for most code changes, and tests are required to pass before merging.

## Why does this exist?

This library exists for a few reasons:
1. I wanted to see what it is like to reverse engineer an API.
2. I like Legos (though I don't buy them that often, they're pretty expensive...).
3. I work in TS for my day job, so I wanted to do a project in another language. Since C# is used a lot where I work, I chose it. Not only am I keeping myself familiar in C#, it's also fun to see how my TS brain handles having to work in C#.
