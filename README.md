# LegoSharp

LegoSharp is a library for interacting with Lego's web API. At this time, only searching for bricks in Lego's [Pick a Brick](https://shop.lego.com/en-US/Pick-a-Brick) has been implemented.

## Usage

Using LegoSharp is very simple:
```C#
// create a client
LegoClient client = new LegoClient();

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
