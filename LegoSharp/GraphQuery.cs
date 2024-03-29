﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LegoSharp
{
    public abstract class GraphQuery<ResultT, ItemT> : IGraphQuery<ResultT> where ResultT : EnumerableQueryResult<ItemT>
    {
        public string query;
        public int page;
        public int perPage;

        public string endpoint { get; }

        private List<IQueryFilter> _filters;
        private string _operationName;
        private string _queryString;

        public GraphQuery(string endpoint, string operationName, string queryString)
        {
            this._filters = new List<IQueryFilter>();
            this.page = 1;
            this.perPage = 12;
            this.query = "";
            this.endpoint = endpoint;
            this._operationName = operationName;
            this._queryString = queryString;
        }

        public IGraphQuery<ResultT> addFilter(IQueryFilter filter)
        {
            this._addFilter(filter);
            return this;
        }

        protected void _addFilter(IQueryFilter filter)
        {
            this._filters.Add(filter);
        }

        public dynamic getPayload()
        {
            return new
            {
                operationName = this._operationName,
                variables = this._getVariables(),
                query = this._queryString
            };
        }

        protected dynamic[] _getFiltersInQL()
        {
            dynamic[] returnValue = new object[this._filters.Count];

            var i = 0;
            foreach (IQueryFilter filter in this._filters)
            {
                returnValue[i++] = filter.getQueryLangValue();
            }

            return returnValue;
        }

        public abstract ResultT parseResponse(string responseBody);

        protected abstract dynamic _getVariables();
    }
}
