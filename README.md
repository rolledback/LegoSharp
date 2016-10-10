# LegoSharp

LegoSharp is a library for interacting with Lego's web API. At this time, only searching for bricks in Lego's [Pick a Brick](https://shop.lego.com/en-US/Pick-a-Brick) has been implemented.

## Usage

Using LegoSharp is very simple:
```C#
// create a client
LegoClient client = new LegoClient();

// get brick with element id of 300321
Brick brick = client.getBrickByElementId("300321");

// get all bricks with design id of 3003
List<Brick> bricks = client.getBricksByDesignId("3003");

// get all bricks whose name contains fence (case insensitive)
List<Brick> bricks = client.getBricksByName("fence");
```
For a more thorough example, see the InstructionChecker directory/project.