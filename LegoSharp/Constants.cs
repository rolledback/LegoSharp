using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoSharp
{
    internal class Constants
    {
        public static readonly string baseLegoUri = "https://www.lego.com/";
        public static readonly string graphAuthUri = "api/graphql/Login";
        public static readonly string pickABrickUri = "api/graphql/PickABrickQuery";

        public static readonly string authenticateQuery = "mutation Login($forceCtLogin: Boolean) { login(forceCtLogin: $forceCtLogin) }";
        public static readonly string pickABrickQuery = 
            "query PickABrickQuery($query: String, $page: Int, $perPage: Int, $filters: [Filter!]) { " + 
            "elements(query: $query, page: $page, perPage: $perPage, filters: $filters) { " +
            "count facets { ...FacetData __typename } results { ...ElementLeafData __typename } total "+
            "__typename } me { ... on LegoUser { ...UserData pabCart { PABLineItems { ...PABLineItemData __typename "+
            "} taxedPrice { totalGross { currencyCode formattedAmount formattedValue __typename } __typename } "+
            "__typename } __typename } __typename } } fragment FacetData on Facet { id key name labels { "+
            "count key name ... on FacetValue { value __typename } ... on FacetRange { from to __typename } "+
            "__typename   } __typename } fragment ElementLeafData on Element { id name primaryImageUrl spinset { "+
            "frames { url __typename } __typename   } ... on SingleVariantElement { variant { "+
            "...ElementLeafVariant __typename } __typename } ... on MultiVariantElement { variants "+
            "{ ...ElementLeafVariant __typename } __typename } __typename } fragment ElementLeafVariant on "+
            "ElementVariant { id price { currencyCode centAmount formattedAmount __typename } attributes "+
            "{ availabilityStatus canAddToBag colour colourFamily designNumber mainGroup materialGroup materialType "+
            "maxOrderQuantity showInListing __typename } __typename } fragment UserData on LegoUser { pabCart "+
            "{ id PABLineItems { id quantity element { id __typename } __typename } __typename } __typename } "+
            "fragment PABLineItemData on PABCartLineItem { id quantity element { id name primaryImageUrl __typename } "+
            "price { centAmount currencyCode __typename } elementVariant { id attributes { designNumber "+
            "__typename } __typename } totalPrice { formattedAmount __typename   } __typename}";
    }
}
