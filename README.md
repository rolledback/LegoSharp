# LegoSharp

LegoSharp is a library for interacting with Lego's web API. At this time, searching for bricks in Lego's [Pick a Brick](https://shop.lego.com/en-US/Pick-a-Brick), a few other [Lego Shop](https://shop.lego.com/) scenarios, and signing into a [LegoId](https://account2.lego.com/en-US/login) account has been implemented.

## Usage

Using LegoSharp is very simple. In order to interact with Lego, you make client objects. These clients interact with various Lego services. There are currently two clients available:

1. `LegoShopClient`: allows you to interact with the Lego Shop, this client is not complete
2. `LegoAccountClient`: allows you to log in to your LegoId Account

But before you make a client, you have to create a `LegoSession`. This object stores information about the current session for a client. 

```C#
// create a lego session
LegoSession session = new LegoSession();
```

You can can then interact with the Lego Shop:
```C#
// create a lego shop client
LegoShopClient client = new LegoShopClient(new LegoSession());

// get brick with element id of 300321
Brick brick = client.getBrickByElementId("300321");

/*
 * For anything other than finding bricks by element Id, use a BrickSearch object
 * to search for the bricks you want. All string related searches (names, category,
 * exact color, and color family) are case insensitive.
 */

// get bricks with exact color black
BrickSearch brickSearch = new BrickSearch();
brickSearch.setExactColor("Black");
List<Brick> result = client.searchForBricks(brickSearch);

// get bricks with name containing "2x2"
brickSearch = new BrickSearch();
brickSearch.setName("2x2");
result = client.searchForBricks(brickSearch);

// get bricks with design id of 3003
brickSearch = new BrickSearch();
brickSearch.setDesignId("3003");
result = client.searchForBricks(brickSearch);

// get bricks with exact color black, name containing "2x2", and design id of 3003
brickSearch = new BrickSearch();
brickSearch.setExactColor("Black");
brickSearch.setName("2x2");
brickSearch.setDesignId("3003");
result = client.searchForBricks(brickSearch);

// get bricks in the black and red color families, in the plates category, and whose names contain "corner"
brickSearch = new BrickSearch();
brickSearch.setCategories(new string[] { "plates" });
brickSearch.setColorFamilies(new string[] { "Red", "Blue" });
brickSearch.setName("corner");
result = client.searchForBricks(brickSearch);
```

Or sign into a LegoId account:
```C#
// create an account client
LegoAccountClient client = new LegoAccountClient(new LegoSession());

// attempt to authenticate using your username and password
AuthenticationResult authenticationResult = client.authenticate(username, password);

if (authenticationResult == AuthenticationResult.Success)
{
    // if the authentication worked, then get the current user
    LegoAccount currUser = client.getCurrentUser();
}
```

Alternatively, you can create a `ClientManager` which will create and manage one of every available client for you:
```C#
// create a client manager
LegoClientManager clientManager = new LegoClientManager();

// the client manager will have one of each type of client
PickABrickClient pickABrickClient = clientManager.pickABrickClient;
LegoAccountClient legoAccountClient = clientManager.legoAccountClient;
```

## Notes

To build the test project, you'll need to create a `PrivateConstants.cs` file. This file will need to declare two public strings, `testUsername` and `testPassword`. These should be valid usernames and passwords for an account you have created.