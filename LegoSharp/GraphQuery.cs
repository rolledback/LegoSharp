using LegoSharp.PickABrick;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LegoSharp
{
    public abstract class GraphQuery<ResultT> : IGraphQuery<ResultT>
    {
        public string query;
        public int page;
        public int perPage;

        public string endpoint { get; }
        
        private Dictionary<string, IQueryFilter> _filters;
        private string _operationName;
        private string _queryString;

        public GraphQuery(string endpoint, string operationName, string queryString)
        {
            this._filters = new Dictionary<string, IQueryFilter>();
            this.page = 1;
            this.perPage = 12;
            this.endpoint = endpoint;
            this._operationName = operationName;
            this._queryString = queryString;
        }

        public void addFilter(IQueryFilter filter)
        {
            this._filters[filter.key] = filter;
        }

        public dynamic getPayload()
        {
            return new
            {
                operationName = this._operationName,
                variables = new
                {
                    page = this.page,
                    perPage = this.perPage,
                    query = this.query,
                    filters = this._getFiltersInQL()
                },
                query = this._queryString
            };
        }

        private dynamic[] _getFiltersInQL()
        {
            dynamic[] returnValue = new object[this._filters.Count];

            var i = 0;
            foreach (KeyValuePair<string, IQueryFilter> entry in this._filters)
            {
                returnValue[i++] = new
                {
                    key = entry.Key,
                    values = entry.Value.getValues()
                };
            }

            return returnValue;
        }

        public abstract ResultT parseResponse(string responseBody);        
    }
}
