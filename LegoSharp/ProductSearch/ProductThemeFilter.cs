using System;
using System.Collections.Generic;
using System.Text;

namespace LegoSharp
{
    public class ProductThemeFilter : ProductSearchValuesFilter<ProductTheme>
    {
        public ProductThemeFilter() : base("categories.id", "product.facet.theme")
        {
        }
    }

    public class ProductTheme : ValuesFilterValue
    {
        public ProductTheme(string value, string name) : base(value, name)
        {
        }

        public static readonly ProductTheme AngryBirds = new ProductTheme("b43d5be2-ebef-49d4-b216-8e2767b50f56", "Angry Birds™");
        public static readonly ProductTheme Architecture = new ProductTheme("6048f0c8-4ce4-4f5e-bc96-1caadd7c1fbd", "Architecture");
        public static readonly ProductTheme Art = new ProductTheme("60f5b610-f541-4b10-b7f5-6925be132af6", "Art");
        public static readonly ProductTheme Batman = new ProductTheme("babb1fb5-b9ca-4df3-a92c-89b1fa7a9780", "Batman™");
        public static readonly ProductTheme Bionicle = new ProductTheme("0d1814a9-10b1-412d-bcf6-fa4a44bfc0dc", "BIONICLE®");
        public static readonly ProductTheme BOOST = new ProductTheme("0e089d07-20b8-4ef8-a096-d74eb7291c00", "BOOST");
        public static readonly ProductTheme BrickHeadz = new ProductTheme("51d0d8f6-2032-435f-b7a5-492242590842", "BrickHeadz");
        public static readonly ProductTheme BrickSketches = new ProductTheme("43df8665-86da-48aa-9f18-715ce8d57bac", "Brick Sketches™");
        public static readonly ProductTheme City = new ProductTheme("96aff015-13f0-4d30-a4d1-d0a31d16f16c", "City");
        public static readonly ProductTheme Classic = new ProductTheme("38303694-3d52-40a1-9af3-a9606a59550a", "Classic");
        public static readonly ProductTheme Creator3In1 = new ProductTheme("953a74ca-c284-43a8-8240-b3b8d2f5ae1c", "Creator 3-in-1");
        public static readonly ProductTheme CreatorExport = new ProductTheme("450a4b31-0a26-461a-9c2d-994b1c98e945", "Creator Expert");
        public static readonly ProductTheme DC = new ProductTheme("3fb68ba1-d86e-4e85-807b-54a418c01b73", "DC");
        public static readonly ProductTheme DCSuperHeroes = new ProductTheme("3fb68ba1-d86e-4e85-807b-54a418c01b73", "DC Super Heroes");
        public static readonly ProductTheme DCSuperHeroGirls = new ProductTheme("5fc087bb-ce7c-457c-9da3-a902b4660e18", "DC Super Hero Girls");
        public static readonly ProductTheme DIMENSIONS = new ProductTheme("17eb97da-9a8d-467b-9c1e-3366b83cd09d", "DIMENSIONS™");
        public static readonly ProductTheme Disney = new ProductTheme("b57f6c1e-f0a0-48a9-91b0-eda8dab39528", "Disney™");
        public static readonly ProductTheme DisneyMickeyAndFriends = new ProductTheme("4170dac8-fea2-4b56-b640-8c86f500b833", "Disney Mickey and Friends");
        public static readonly ProductTheme DOTS = new ProductTheme("709942a5-8b04-49de-a1c6-3137ecb3853d", "DOTS");
        public static readonly ProductTheme DUPLO = new ProductTheme("4a4493a4-3513-4fa1-888c-353da1437851", "DUPLO®");
        public static readonly ProductTheme Elves = new ProductTheme("5d4a286b-77f9-449f-8aaf-d3d52ba63099", "Elves");
        public static readonly ProductTheme FantasticBeasts = new ProductTheme("fa3fa838-4aa0-49d4-b3e6-e76327a16ade", "Fantastic Beasts™");
        public static readonly ProductTheme Fiends = new ProductTheme("1bcfd7b6-4895-42fb-8e18-9b374a8bb677", "Friends");
        public static readonly ProductTheme Frozen = new ProductTheme("a13df747-09bd-481b-a838-751ec9ef92bf", "Frozen");
        public static readonly ProductTheme Ghostbusters = new ProductTheme("8d49e53e-3102-49fe-8cd2-90eb23a61952", "Ghostbusters™");
        public static readonly ProductTheme HardToFindItems = new ProductTheme("66f37576-ca80-4510-95ed-d8ea51acef41", "Hard to Find Items");
        public static readonly ProductTheme HarryPotte = new ProductTheme("1c926035-83f4-46bd-892e-89c7374dc888", "Harry Potter™");
        public static readonly ProductTheme HiddenSide = new ProductTheme("15f62d9e-936d-49df-adee-5ddab5da6956", "Hidden Side");
        public static readonly ProductTheme Ideas = new ProductTheme("2237887c-51ec-4e65-becf-117ae6180bf0", "Ideas");
        public static readonly ProductTheme JuarssicWold = new ProductTheme("ab2618af-0e1a-415d-a561-ddc7bd8f3e89", "Jurassic World™");
        public static readonly ProductTheme Juniors = new ProductTheme("7bba8647-c0ec-4d29-b6a8-dc0337798886", "Juniors");
        public static readonly ProductTheme LegoArt = new ProductTheme("60f5b610-f541-4b10-b7f5-6925be132af6", "LEGO® Art");
        public static readonly ProductTheme LegoBatman = new ProductTheme("babb1fb5-b9ca-4df3-a92c-89b1fa7a9780", "LEGO® Batman");
        public static readonly ProductTheme LegoBrickSketches = new ProductTheme("43df8665-86da-48aa-9f18-715ce8d57bac", "LEGO® Brick Sketches™");
        public static readonly ProductTheme LegoDOTS = new ProductTheme("709942a5-8b04-49de-a1c6-3137ecb3853d", "LEGO® DOTS");
        public static readonly ProductTheme LegoEducation = new ProductTheme("81acec51-a977-467b-8e8c-41bdc61c1f30", "LEGO® Education");
        public static readonly ProductTheme LegoFrozen2 = new ProductTheme("a13df747-09bd-481b-a838-751ec9ef92bf", "LEGO® Frozen 2");
        public static readonly ProductTheme LegoMarvel = new ProductTheme("e92d1f5f-91be-4083-9e99-766ca3e90c55", "LEGO® Marvel");
        public static readonly ProductTheme LegoMinions = new ProductTheme("7caa382c-966d-4241-bc94-be6b9436d82a", "LEGO® Minions");
        public static readonly ProductTheme LegoMonkieKid = new ProductTheme("42ef643e-d7d3-4b31-b3ed-e4275541ade3", "LEGO® Monkie Kid");
        public static readonly ProductTheme LegoOriginals = new ProductTheme("a12b7c32-c859-40ff-9901-46e498f648a1", "LEGO® Originals");
        public static readonly ProductTheme LegoPirates = new ProductTheme("feabaccb-34f4-4d0d-9a3d-bc3350df684c", "LEGO® Pirates");
        public static readonly ProductTheme LegoSpiderMan = new ProductTheme("241c583a-af08-46ec-9534-a13f1b29e5de", "LEGO® Spider-Man");
        public static readonly ProductTheme LegoSuperMario = new ProductTheme("5762f826-7e6e-4f68-babb-eaf8692b4fa8", "LEGO® Super Mario™");
        public static readonly ProductTheme LegoVidiyo = new ProductTheme("058bac02-f5e0-4971-8303-558416352fe7", "LEGO® VIDIYO™");
        public static readonly ProductTheme Marvel = new ProductTheme("e92d1f5f-91be-4083-9e99-766ca3e90c55", "Marvel");
        public static readonly ProductTheme Mindstorms = new ProductTheme("9651dd8c-6610-4313-9391-9d7ef331aeff", "MINDSTORMS®");
        public static readonly ProductTheme Minecraft = new ProductTheme("3ee0ddbe-0986-42ea-9700-f2aabef966b1", "Minecraft™");
        public static readonly ProductTheme Minecraft2 = new ProductTheme("3ee0ddbe-0986-42ea-9700-f2aabef966b1", "Minecraft®");
        public static readonly ProductTheme Minifigures = new ProductTheme("13afd5e3-4b4f-4ead-89a3-931b961565d2", "Minifigures");
        public static readonly ProductTheme Minions = new ProductTheme("7caa382c-966d-4241-bc94-be6b9436d82a", "Minions");
        public static readonly ProductTheme Miscellaneous = new ProductTheme("9fe455ac-be16-4348-81fe-ddd8261327c1", "Miscellaneous");
        public static readonly ProductTheme Mixels = new ProductTheme("5b4703bc-a5d6-4a03-98e8-ef45d4363abd", "Mixels™");
        public static readonly ProductTheme MonkieKid = new ProductTheme("42ef643e-d7d3-4b31-b3ed-e4275541ade3", "Monkie Kid");
        public static readonly ProductTheme MonkieKid2 = new ProductTheme("42ef643e-d7d3-4b31-b3ed-e4275541ade3", "Monkie Kid™");
        public static readonly ProductTheme NexoKnights = new ProductTheme("aed82de4-65fd-4ed5-9ea5-90e3f2a9035b", "NEXO KNIGHTS™");
        public static readonly ProductTheme NinjaGo = new ProductTheme("008976a6-bf87-435c-89cc-87ea0b2ea63c", "NINJAGO®");
        public static readonly ProductTheme Other = new ProductTheme("9fe455ac-be16-4348-81fe-ddd8261327c1", "Other");
        public static readonly ProductTheme Overwatch = new ProductTheme("501d7529-d6ea-485c-bc62-469513984324", "Overwatch®");
        public static readonly ProductTheme PoweredUP = new ProductTheme("4d494039-babf-4791-bbd2-889acd4cc266", "Powered UP");
        public static readonly ProductTheme PowerpuffGirls = new ProductTheme("501d96f0-6986-4cf2-92ed-d90859df54d5", "Powerpuff Girls™");
        public static readonly ProductTheme SERIOUSPLAY = new ProductTheme("1b9ecd61-c56b-4385-afcb-a6a1d0f8c52a", "SERIOUS PLAY®");
        public static readonly ProductTheme SpeedChampions = new ProductTheme("ae210cc7-ed71-4509-9872-7228f38ef4b0", "Speed Champions");
        public static readonly ProductTheme SpiderMan = new ProductTheme("241c583a-af08-46ec-9534-a13f1b29e5de", "Spider-Man");
        public static readonly ProductTheme StarWars = new ProductTheme("571ed551-f375-4b0b-925b-057aa50973f0", "Star Wars™");
        public static readonly ProductTheme StrangerThings = new ProductTheme("94343006-690d-43ac-bb3c-8474f1e3b401", "Stranger Things");
        public static readonly ProductTheme Technic = new ProductTheme("fc77028c-e984-4dfe-b698-4423f69ee663", "Technic™");
        public static readonly ProductTheme TheLegoBatmanMovie = new ProductTheme("96d7af69-5e46-45d9-84fc-9662ac621602", "THE LEGO® BATMAN MOVIE");
        public static readonly ProductTheme TheLegoMovie = new ProductTheme("419e34c6-5a59-4b64-86fd-e5bf05c44df2", "THE LEGO® MOVIE™");
        public static readonly ProductTheme TheLegoMovie2 = new ProductTheme("407fe674-adbc-4754-a86b-fe184966cba4", "THE LEGO® MOVIE 2™");
        public static readonly ProductTheme TheLegoNinjagoMovie = new ProductTheme("44be4334-442b-4867-8b0b-6b2601b471ca", "THE LEGO® NINJAGO® MOVIE™");
        public static readonly ProductTheme TheSimpsons = new ProductTheme("18dd7025-6986-4910-b6b2-62bb219515ca", "The Simpsons™");
        public static readonly ProductTheme ToyStory4 = new ProductTheme("4649daab-8c3b-458f-8abd-8e7292e8524d", "Toy Story 4");
        public static readonly ProductTheme TrollsWorldTour = new ProductTheme("236de155-02f6-4c54-93bc-34966eaaf029", "Trolls World Tour");
        public static readonly ProductTheme Unikitty = new ProductTheme("82e17b50-b96e-4bf3-86a2-bdf87bcb9db2", "Unikitty!™");
        public static readonly ProductTheme VIDIYO = new ProductTheme("058bac02-f5e0-4971-8303-558416352fe7", "VIDIYO™");
        public static readonly ProductTheme Xtra = new ProductTheme("42ea57d4-2b97-486f-bd35-0daafd7b16ae", "Xtra");

    }
}
