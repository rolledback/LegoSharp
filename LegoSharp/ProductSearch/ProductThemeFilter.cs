using System;
using System.Collections.Generic;
using System.Text;

namespace LegoSharp
{
    public class ProductThemeFilter : ProductSearchFilter<ProductTheme>
    {
        public ProductThemeFilter() : base("categories.id", "product.facet.theme")
        {
        }

        public override string filterEnumToValue(ProductTheme category)
        {
            switch (category)
            {
                case ProductTheme.Architecture:
                    return "6048f0c8-4ce4-4f5e-bc96-1caadd7c1fbd";
                case ProductTheme.Bionicle:
                    return "0d1814a9-10b1-412d-bcf6-fa4a44bfc0dc";
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
                case ProductTheme.DCSuperHeroGirls:
                    return "5fc087bb-ce7c-457c-9da3-a902b4660e18";
                case ProductTheme.DCSuperHeroes:
                    return "3fb68ba1-d86e-4e85-807b-54a418c01b73";
                case ProductTheme.Disney:
                    return "b57f6c1e-f0a0-48a9-91b0-eda8dab39528";
                case ProductTheme.DUPLO:
                    return "4a4493a4-3513-4fa1-888c-353da1437851";
                case ProductTheme.Elves:
                    return "5d4a286b-77f9-449f-8aaf-d3d52ba63099";
                case ProductTheme.Fiends:
                    return "1bcfd7b6-4895-42fb-8e18-9b374a8bb677";
                case ProductTheme.HardToFindItems:
                    return "66f37576-ca80-4510-95ed-d8ea51acef41";
                case ProductTheme.HarryPotte:
                    return "1c926035-83f4-46bd-892e-89c7374dc888";
                case ProductTheme.HiddenSide:
                    return "15f62d9e-936d-49df-adee-5ddab5da6956";
                case ProductTheme.Ideas:
                    return "2237887c-51ec-4e65-becf-117ae6180bf0";
                case ProductTheme.Juniors:
                    return "7bba8647-c0ec-4d29-b6a8-dc0337798886";
                case ProductTheme.JuarssicWold:
                    return "ab2618af-0e1a-415d-a561-ddc7bd8f3e89";
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
                case ProductTheme.LegoMonkieKid:
                    return "42ef643e-d7d3-4b31-b3ed-e4275541ade3";
                case ProductTheme.LegoSpiderMan:
                    return "241c583a-af08-46ec-9534-a13f1b29e5de";
                case ProductTheme.Mindstorms:
                    return "9651dd8c-6610-4313-9391-9d7ef331aeff";
                case ProductTheme.Minecraft:
                    return "3ee0ddbe-0986-42ea-9700-f2aabef966b1";
                case ProductTheme.Minifigures:
                    return "13afd5e3-4b4f-4ead-89a3-931b961565d2";
                case ProductTheme.LegoMinions:
                    return "7caa382c-966d-4241-bc94-be6b9436d82a";
                case ProductTheme.Miscellaneous:
                    return "9fe455ac-be16-4348-81fe-ddd8261327c1";
                case ProductTheme.Mixels:
                    return "5b4703bc-a5d6-4a03-98e8-ef45d4363abd";
                case ProductTheme.NexoKnights:
                    return "aed82de4-65fd-4ed5-9ea5-90e3f2a9035b";
                case ProductTheme.NinjaGo:
                    return "008976a6-bf87-435c-89cc-87ea0b2ea63c";
                case ProductTheme.Overwatch:
                    return "501d7529-d6ea-485c-bc62-469513984324";
                case ProductTheme.PoweredUP:
                    return "4d494039-babf-4791-bbd2-889acd4cc266";
                case ProductTheme.SpeedChampions:
                    return "ae210cc7-ed71-4509-9872-7228f38ef4b0";
                case ProductTheme.StarWars:
                    return "571ed551-f375-4b0b-925b-057aa50973f0";
                case ProductTheme.Technic:
                    return "fc77028c-e984-4dfe-b698-4423f69ee663";
                case ProductTheme.TheLegoBatmanMovie:
                    return "96d7af69-5e46-45d9-84fc-9662ac621602";
                case ProductTheme.TheLegoMovie2:
                    return "407fe674-adbc-4754-a86b-fe184966cba4";
                case ProductTheme.TheLegoNinjagoMovie:
                    return "44be4334-442b-4867-8b0b-6b2601b471ca";
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
                case ProductTheme.Architecture:
                    return "Architecture";
                case ProductTheme.Bionicle:
                    return "BIONICLE®";
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
                case ProductTheme.DCSuperHeroGirls:
                    return "DC Super Hero Girls";
                case ProductTheme.DCSuperHeroes:
                    return "DC Super Heroes";
                case ProductTheme.Disney:
                    return "Disney™";
                case ProductTheme.DUPLO:
                    return "DUPLO®";
                case ProductTheme.Elves:
                    return "Elves";
                case ProductTheme.Fiends:
                    return "Friends";
                case ProductTheme.HardToFindItems:
                    return "Hard to Find Items";
                case ProductTheme.HarryPotte:
                    return "Harry Potter™";
                case ProductTheme.HiddenSide:
                    return "Hidden Side";
                case ProductTheme.Ideas:
                    return "Ideas";
                case ProductTheme.Juniors:
                    return "Juniors";
                case ProductTheme.JuarssicWold:
                    return "Jurassic World™";
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
                case ProductTheme.LegoMonkieKid:
                    return "LEGO® Monkie Kid";
                case ProductTheme.LegoSpiderMan:
                    return "LEGO® Spider-Man";
                case ProductTheme.Mindstorms:
                    return "MINDSTORMS®";
                case ProductTheme.Minecraft:
                    return "Minecraft™";
                case ProductTheme.Minifigures:
                    return "Minifigures";
                case ProductTheme.LegoMinions:
                    return "LEGO® Minions";
                case ProductTheme.Miscellaneous:
                    return "Miscellaneous";
                case ProductTheme.Mixels:
                    return "Mixels™";
                case ProductTheme.NexoKnights:
                    return "NEXO KNIGHTS™";
                case ProductTheme.NinjaGo:
                    return "NINJAGO®";
                case ProductTheme.Overwatch:
                    return "Overwatch®";
                case ProductTheme.PoweredUP:
                    return "Powered UP";
                case ProductTheme.SpeedChampions:
                    return "Speed Champions";
                case ProductTheme.StarWars:
                    return "Star Wars™";
                case ProductTheme.Technic:
                    return "Technic™";
                case ProductTheme.TheLegoBatmanMovie:
                    return "THE LEGO® BATMAN MOVIE";
                case ProductTheme.TheLegoMovie2:
                    return "THE LEGO® MOVIE 2™";
                case ProductTheme.TheLegoNinjagoMovie:
                    return "THE LEGO® NINJAGO® MOVIE™";
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
        Architecture,
        Bionicle,
        BrickHeadz,
        City,
        Classic,
        Creator3In1,
        CreatorExport,
        DCSuperHeroGirls,
        DCSuperHeroes,
        Disney,
        DUPLO,
        Elves,
        Fiends,
        HardToFindItems,
        HarryPotte,
        HiddenSide,
        Ideas,
        Juniors,
        JuarssicWold,
        LegoBatman,
        LegoDOTS,
        LegoEducation,
        LegoFrozen2,
        LegoMarvel,
        LegoMonkieKid,
        LegoSpiderMan,
        Mindstorms,
        Minecraft,
        Minifigures,
        LegoMinions,
        Miscellaneous,
        Mixels,
        NexoKnights,
        NinjaGo,
        Overwatch,
        PoweredUP,
        SpeedChampions,
        StarWars,
        Technic,
        TheLegoBatmanMovie,
        TheLegoMovie2,
        TheLegoNinjagoMovie,
        Unikitty,
        Xtra
    }
}
