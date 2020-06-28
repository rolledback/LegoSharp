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

        public override string filterEnumToValue(ProductTheme category)
        {
            switch (category)
            {
                case ProductTheme.AngryBirds:
                    return "b43d5be2-ebef-49d4-b216-8e2767b50f56";
                case ProductTheme.Architecture:
                    return "6048f0c8-4ce4-4f5e-bc96-1caadd7c1fbd";
                case ProductTheme.Batman:
                    return "babb1fb5-b9ca-4df3-a92c-89b1fa7a9780";
                case ProductTheme.Bionicle:
                    return "0d1814a9-10b1-412d-bcf6-fa4a44bfc0dc";
                case ProductTheme.BOOST:
                    return "0e089d07-20b8-4ef8-a096-d74eb7291c00";
                case ProductTheme.BrickHeadz:
                    return "51d0d8f6-2032-435f-b7a5-492242590842";
                case ProductTheme.City:
                    return "96aff015-13f0-4d30-a4d1-d0a31d16f16c";
                case ProductTheme.Classic:
                    return "38303694-3d52-40a1-9af3-a9606a59550a";
                case ProductTheme.Creator3In1:
                    return "953a74ca-c284-43a8-8240-b3b8d2f5ae1c";
                case ProductTheme.CreatorExport:
                    return "450a4b31-0a26-461a-9c2d-994b1c98e945";
                case ProductTheme.DC:
                    return "3fb68ba1-d86e-4e85-807b-54a418c01b73";
                case ProductTheme.DCSuperHeroes:
                    return "3fb68ba1-d86e-4e85-807b-54a418c01b73";
                case ProductTheme.DCSuperHeroGirls:
                    return "5fc087bb-ce7c-457c-9da3-a902b4660e18";
                case ProductTheme.DIMENSIONS:
                    return "17eb97da-9a8d-467b-9c1e-3366b83cd09d";
                case ProductTheme.Disney:
                    return "b57f6c1e-f0a0-48a9-91b0-eda8dab39528";
                case ProductTheme.DOTS:
                    return "709942a5-8b04-49de-a1c6-3137ecb3853d";
                case ProductTheme.DUPLO:
                    return "4a4493a4-3513-4fa1-888c-353da1437851";
                case ProductTheme.Elves:
                    return "5d4a286b-77f9-449f-8aaf-d3d52ba63099";
                case ProductTheme.FantasticBeasts:
                    return "fa3fa838-4aa0-49d4-b3e6-e76327a16ade";
                case ProductTheme.Fiends:
                    return "1bcfd7b6-4895-42fb-8e18-9b374a8bb677";
                case ProductTheme.Ghostbusters:
                    return "8d49e53e-3102-49fe-8cd2-90eb23a61952";
                case ProductTheme.HardToFindItems:
                    return "66f37576-ca80-4510-95ed-d8ea51acef41";
                case ProductTheme.HarryPotte:
                    return "1c926035-83f4-46bd-892e-89c7374dc888";
                case ProductTheme.HiddenSide:
                    return "15f62d9e-936d-49df-adee-5ddab5da6956";
                case ProductTheme.Ideas:
                    return "2237887c-51ec-4e65-becf-117ae6180bf0";
                case ProductTheme.JuarssicWold:
                    return "ab2618af-0e1a-415d-a561-ddc7bd8f3e89";
                case ProductTheme.Juniors:
                    return "7bba8647-c0ec-4d29-b6a8-dc0337798886";
                case ProductTheme.LegoBatman:
                    return "babb1fb5-b9ca-4df3-a92c-89b1fa7a9780";
                case ProductTheme.LegoDOTS:
                    return "709942a5-8b04-49de-a1c6-3137ecb3853d";
                case ProductTheme.LegoEducation:
                    return "81acec51-a977-467b-8e8c-41bdc61c1f30";
                case ProductTheme.LegoFrozen2:
                    return "a13df747-09bd-481b-a838-751ec9ef92bf";
                case ProductTheme.LegoMarvel:
                    return "e92d1f5f-91be-4083-9e99-766ca3e90c55";
                case ProductTheme.LegoMinions:
                    return "7caa382c-966d-4241-bc94-be6b9436d82a";
                case ProductTheme.LegoMonkieKid:
                    return "42ef643e-d7d3-4b31-b3ed-e4275541ade3";
                case ProductTheme.LegoOriginals:
                    return "a12b7c32-c859-40ff-9901-46e498f648a1";
                case ProductTheme.LegoPirates:
                    return "feabaccb-34f4-4d0d-9a3d-bc3350df684c";
                case ProductTheme.LegoSpiderMan:
                    return "241c583a-af08-46ec-9534-a13f1b29e5de";
                case ProductTheme.LegoSuperMario:
                    return "5762f826-7e6e-4f68-babb-eaf8692b4fa8";
                case ProductTheme.Marvel:
                    return "e92d1f5f-91be-4083-9e99-766ca3e90c55";
                case ProductTheme.Mindstorms:
                    return "9651dd8c-6610-4313-9391-9d7ef331aeff";
                case ProductTheme.Minecraft:
                    return "3ee0ddbe-0986-42ea-9700-f2aabef966b1";
                case ProductTheme.Minifigures:
                    return "13afd5e3-4b4f-4ead-89a3-931b961565d2";
                case ProductTheme.Minions:
                    return "7caa382c-966d-4241-bc94-be6b9436d82a";
                case ProductTheme.Miscellaneous:
                    return "9fe455ac-be16-4348-81fe-ddd8261327c1";
                case ProductTheme.Mixels:
                    return "5b4703bc-a5d6-4a03-98e8-ef45d4363abd";
                case ProductTheme.MonkieKid:
                    return "42ef643e-d7d3-4b31-b3ed-e4275541ade3";
                case ProductTheme.NexoKnights:
                    return "aed82de4-65fd-4ed5-9ea5-90e3f2a9035b";
                case ProductTheme.NinjaGo:
                    return "008976a6-bf87-435c-89cc-87ea0b2ea63c";
                case ProductTheme.Overwatch:
                    return "501d7529-d6ea-485c-bc62-469513984324";
                case ProductTheme.PoweredUP:
                    return "4d494039-babf-4791-bbd2-889acd4cc266";
                case ProductTheme.PowerpuffGirls:
                    return "501d96f0-6986-4cf2-92ed-d90859df54d5";
                case ProductTheme.SERIOUSPLAY:
                    return "1b9ecd61-c56b-4385-afcb-a6a1d0f8c52a";
                case ProductTheme.SpeedChampions:
                    return "ae210cc7-ed71-4509-9872-7228f38ef4b0";
                case ProductTheme.SpiderMan:
                    return "241c583a-af08-46ec-9534-a13f1b29e5de";
                case ProductTheme.StarWars:
                    return "571ed551-f375-4b0b-925b-057aa50973f0";
                case ProductTheme.StrangerThings:
                    return "94343006-690d-43ac-bb3c-8474f1e3b401";
                case ProductTheme.Technic:
                    return "fc77028c-e984-4dfe-b698-4423f69ee663";
                case ProductTheme.TheLegoBatmanMovie:
                    return "96d7af69-5e46-45d9-84fc-9662ac621602";
                case ProductTheme.TheLegoMovie2:
                    return "407fe674-adbc-4754-a86b-fe184966cba4";
                case ProductTheme.THELEGOMOVIE:
                    return "419e34c6-5a59-4b64-86fd-e5bf05c44df2";
                case ProductTheme.TheLegoNinjagoMovie:
                    return "44be4334-442b-4867-8b0b-6b2601b471ca";
                case ProductTheme.TheSimpsons:
                    return "18dd7025-6986-4910-b6b2-62bb219515ca";
                case ProductTheme.ToyStory4:
                    return "4649daab-8c3b-458f-8abd-8e7292e8524d";
                case ProductTheme.TrollsWorldTour:
                    return "236de155-02f6-4c54-93bc-34966eaaf029";
                case ProductTheme.Unikitty:
                    return "82e17b50-b96e-4bf3-86a2-bdf87bcb9db2";
                case ProductTheme.Xtra:
                    return "42ea57d4-2b97-486f-bd35-0daafd7b16ae";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override string filterEnumToName(ProductTheme category)
        {
            switch (category)
            {
                case ProductTheme.AngryBirds:
                    return "Angry Birds™";
                case ProductTheme.Architecture:
                    return "Architecture";
                case ProductTheme.Batman:
                    return "Batman";
                case ProductTheme.Bionicle:
                    return "BIONICLE®";
                case ProductTheme.BOOST:
                    return "BOOST";
                case ProductTheme.BrickHeadz:
                    return "BrickHeadz";
                case ProductTheme.City:
                    return "City";
                case ProductTheme.Classic:
                    return "Classic";
                case ProductTheme.Creator3In1:
                    return "Creator 3-in-1";
                case ProductTheme.CreatorExport:
                    return "Creator Expert";
                case ProductTheme.DC:
                    return "DC";
                case ProductTheme.DCSuperHeroes:
                    return "DC Super Heroes";
                case ProductTheme.DCSuperHeroGirls:
                    return "DC Super Hero Girls";
                case ProductTheme.DIMENSIONS:
                    return "DIMENSIONS™";
                case ProductTheme.Disney:
                    return "Disney™";
                case ProductTheme.DOTS:
                    return "DOTS";
                case ProductTheme.DUPLO:
                    return "DUPLO®";
                case ProductTheme.Elves:
                    return "Elves";
                case ProductTheme.FantasticBeasts:
                    return "Fantastic Beasts™";
                case ProductTheme.Fiends:
                    return "Friends";
                case ProductTheme.Ghostbusters:
                    return "Ghostbusters™";
                case ProductTheme.HardToFindItems:
                    return "Hard to Find Items";
                case ProductTheme.HarryPotte:
                    return "Harry Potter™";
                case ProductTheme.HiddenSide:
                    return "Hidden Side";
                case ProductTheme.Ideas:
                    return "Ideas";
                case ProductTheme.JuarssicWold:
                    return "Jurassic World™";
                case ProductTheme.Juniors:
                    return "Juniors";
                case ProductTheme.LegoBatman:
                    return "LEGO® Batman";
                case ProductTheme.LegoDOTS:
                    return "LEGO® DOTS";
                case ProductTheme.LegoEducation:
                    return "LEGO® Education";
                case ProductTheme.LegoFrozen2:
                    return "LEGO® Frozen 2";
                case ProductTheme.LegoMarvel:
                    return "LEGO® Marvel";
                case ProductTheme.LegoMinions:
                    return "LEGO® Minions";
                case ProductTheme.LegoMonkieKid:
                    return "LEGO® Monkie Kid";
                case ProductTheme.LegoOriginals:
                    return "LEGO® Originals";
                case ProductTheme.LegoPirates:
                    return "LEGO® Pirates";
                case ProductTheme.LegoSpiderMan:
                    return "LEGO® Spider-Man";
                case ProductTheme.LegoSuperMario:
                    return "LEGO® Super Mario™";
                case ProductTheme.Marvel:
                    return "Marvel";
                case ProductTheme.Mindstorms:
                    return "MINDSTORMS®";
                case ProductTheme.Minecraft:
                    return "Minecraft™";
                case ProductTheme.Minifigures:
                    return "Minifigures";
                case ProductTheme.Minions:
                    return "Minions";
                case ProductTheme.Miscellaneous:
                    return "Miscellaneous";
                case ProductTheme.Mixels:
                    return "Mixels™";
                case ProductTheme.MonkieKid:
                    return "Monkie Kid";
                case ProductTheme.NexoKnights:
                    return "NEXO KNIGHTS™";
                case ProductTheme.NinjaGo:
                    return "NINJAGO®";
                case ProductTheme.Overwatch:
                    return "Overwatch®";
                case ProductTheme.PoweredUP:
                    return "Powered UP";
                case ProductTheme.PowerpuffGirls:
                    return "Powerpuff Girls™";
                case ProductTheme.SERIOUSPLAY:
                    return "SERIOUS PLAY®";
                case ProductTheme.SpeedChampions:
                    return "Speed Champions";
                case ProductTheme.SpiderMan:
                    return "Spider-Man";
                case ProductTheme.StarWars:
                    return "Star Wars™";
                case ProductTheme.StrangerThings:
                    return "Stranger Things";
                case ProductTheme.Technic:
                    return "Technic™";
                case ProductTheme.TheLegoBatmanMovie:
                    return "THE LEGO® BATMAN MOVIE";
                case ProductTheme.TheLegoMovie2:
                    return "THE LEGO® MOVIE 2™";
                case ProductTheme.THELEGOMOVIE:
                    return "THE LEGO® MOVIE™";
                case ProductTheme.TheLegoNinjagoMovie:
                    return "THE LEGO® NINJAGO® MOVIE™";
                case ProductTheme.TheSimpsons:
                    return "The Simpsons™";
                case ProductTheme.ToyStory4:
                    return "Toy Story 4";
                case ProductTheme.TrollsWorldTour:
                    return "Trolls World Tour";
                case ProductTheme.Unikitty:
                    return "Unikitty!™";
                case ProductTheme.Xtra:
                    return "Xtra";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    public enum ProductTheme
    {
        AngryBirds,
        Architecture,
        Batman,
        Bionicle,
        BOOST,
        BrickHeadz,
        City,
        Classic,
        Creator3In1,
        CreatorExport,
        DC,
        DCSuperHeroes,
        DCSuperHeroGirls,
        DIMENSIONS,
        Disney,
        DOTS,
        DUPLO,
        Elves,
        FantasticBeasts,
        Fiends,
        Ghostbusters,
        HardToFindItems,
        HarryPotte,
        HiddenSide,
        Ideas,
        JuarssicWold,
        Juniors,
        LegoBatman,
        LegoDOTS,
        LegoEducation,
        LegoFrozen2,
        LegoMarvel,
        LegoMinions,
        LegoMonkieKid,
        LegoOriginals,
        LegoPirates,
        LegoSpiderMan,
        LegoSuperMario,
        Marvel,
        Mindstorms,
        Minecraft,
        Minifigures,
        Minions,
        Miscellaneous,
        Mixels,
        MonkieKid,
        NexoKnights,
        NinjaGo,
        Overwatch,
        PoweredUP,
        PowerpuffGirls,
        SERIOUSPLAY,
        SpeedChampions,
        SpiderMan,
        StarWars,
        StrangerThings,
        Technic,
        TheLegoBatmanMovie,
        TheLegoMovie2,
        THELEGOMOVIE,
        TheLegoNinjagoMovie,
        TheSimpsons,
        ToyStory4,
        TrollsWorldTour,
        Unikitty,
        Xtra
    }
}
