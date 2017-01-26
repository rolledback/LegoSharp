# LegoSharp

LegoSharp is a library for interacting with Lego's web API. At this time, searching for bricks in Lego's [Pick a Brick](https://shop.lego.com/en-US/Pick-a-Brick) and signing into a [LegoId](https://account2.lego.com/en-US/login) account has been implemented.

## Usage

Using LegoSharp is very simple. For querying Pick a Prick:
```C#
// create a pick a brick client
PickABrickClient client = new PickABrickClient();

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
List<Brick> result = testClient.searchForBricks(brickSearch);

// get bricks with name containing "2x2"
brickSearch = new BrickSearch();
brickSearch.setName("2x2");
result = testClient.searchForBricks(brickSearch);

// get bricks with design id of 3003
brickSearch = new BrickSearch();
brickSearch.setDesignId("3003");
result = testClient.searchForBricks(brickSearch);

// get bricks with exact color black, name containing "2x2", and design id of 3003
brickSearch = new BrickSearch();
brickSearch.setExactColor("Black");
brickSearch.setName("2x2");
brickSearch.setDesignId("3003");
result = testClient.searchForBricks(brickSearch);

// get bricks in the black and red color families, in the plates category, and whose names contain "corner"
brickSearch = new BrickSearch();
brickSearch.setCategories(new string[] { "plates" });
brickSearch.setColorFamilies(new string[] { "Red", "Blue" });
brickSearch.setName("corner");
result = testClient.searchForBricks(brickSearch);
```

And to sign into a LegoId account:
```C#
// create an account client
LegoAccountClient client = new LegoAccountClient();

// attempt to authenticate using your username and password
bool authenticationSuccessful = client.authenticate(username, password);

if (authenticationSuccessful)
{
    // if the authentication worked, then get the current user
    LegoAccount currUser = client.getCurrentUser();
}
```

## Notes

If you'd like to run any of the account tests, you'll need to create a `PrivateConstants.cs` file in the LegoSharpTest project. This file will need to declare two public strings, `testUsername` and `testPassword`.