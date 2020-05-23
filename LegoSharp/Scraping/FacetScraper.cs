using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LegoSharp
{
    public class FacetScraper<GraphQueryT, GraphQueryResultT> : IGraphQuery<IEnumerable<Facet>> where GraphQueryT : IGraphQuery<GraphQueryResultT>
    {
        public string endpoint { get; }

        private IGraphQuery<GraphQueryResultT> _queryToScrape;
        private IFacetExtractor<GraphQueryT> _facetExtractor;

        public FacetScraper(IGraphQuery<GraphQueryResultT> queryToScrape, IFacetExtractor<GraphQueryT> facetExtractor)
        {
            this._queryToScrape = queryToScrape;
            this._facetExtractor = facetExtractor;
            this.endpoint = queryToScrape.endpoint;
        }

        public dynamic getPayload()
        {
            return this._queryToScrape.getPayload();
        }

        public IEnumerable<Facet> parseResponse(string responseBody)
        {
            return this._facetExtractor.extractFacets(responseBody);
        }
    }
}
