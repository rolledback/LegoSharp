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

        public async Task<ISet<ScrapedFacetLabel>> scrapeFacet(string facetId, string facetKey)
        {
            var scrapedFacets = new HashSet<ScrapedFacetLabel>(new ScrapedFacetLabelComparaer());

            foreach (var facetQuery in this._facetQueries)
            {
                LegoGraphClient graphClient = new LegoGraphClient();

                var facets = await graphClient.queryGraph(facetQuery);

                var facet = facets.FirstOrDefault(f => f.key == facetKey && f.id == facetId);

                if (facet != null)
                {
                    foreach (var label in facet.labels)
                    {
                        scrapedFacets.Add(new ScrapedFacetLabel { name = label.name, value = label.value });
                    }
                }
            }

            return scrapedFacets;
        }

        public async Task<IDictionary<string, ISet<ScrapedFacetLabel>>> scrapeFacets()
        {
            var result = new Dictionary<string, ISet<ScrapedFacetLabel>>();

            foreach (var facetQuery in this._facetQueries)
            {
                LegoGraphClient graphClient = new LegoGraphClient();

                var facets = await graphClient.queryGraph(facetQuery);
                foreach (var facet in facets)
                {
                    var dictionaryIdx = facet.id + "," + facet.key;
                    if (!result.ContainsKey(dictionaryIdx))
                    {
                        result[dictionaryIdx] = new HashSet<ScrapedFacetLabel>(new ScrapedFacetLabelComparaer());
                    }
                    foreach (var label in facet.labels)
                    {
                        result[dictionaryIdx].Add(new ScrapedFacetLabel { name = label.name, value = label.value });
                    }
                }
            }

            return result;
        }
    }
}
