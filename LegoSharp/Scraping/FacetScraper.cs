using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoSharp
{
    public class FacetScraper<GraphQueryT, GraphQueryResultT> where GraphQueryT : IGraphQuery<GraphQueryResultT>
    {
        private IList<FacetScraperQuery<GraphQueryT, GraphQueryResultT>> _facetQueries;

        public FacetScraper(IEnumerable<IGraphQuery<GraphQueryResultT>> queriesToScrapeWith, IFacetExtractor<GraphQueryT> facetExtractor)
        {
            this._facetQueries = new List<FacetScraperQuery<GraphQueryT, GraphQueryResultT>>();
            foreach (var query in queriesToScrapeWith)
            {
                this._facetQueries.Add(new FacetScraperQuery<GraphQueryT, GraphQueryResultT>(query, facetExtractor));
            }
        }

        public async Task<ISet<ScrapedFacetLabel>> scrapeFacet<FilterEnumT>(string facetId, string facetKey)
        {
            var scrapedFacets = new HashSet<ScrapedFacetLabel>(new ScrapedFacetLabelComparaer());

            foreach (var facetQuery in this._facetQueries)
            {
                LegoGraphClient graphClient = new LegoGraphClient();
                await graphClient.authenticateAsync();

                var facets = await graphClient.queryGraph(facetQuery);

                var facet = facets.FirstOrDefault(f => f.key == facetKey && f.id == facetId);

                if (facet != null)
                {
                    foreach (var label in facet.labels)
                    {
                        scrapedFacets.Add(new ScrapedFacetLabel { enumField = "", name = label.name, value = label.value });
                    }
                }
            }

            return scrapedFacets;
        }
    }
}
