﻿using System.Collections.Generic;
using SolrExpress.Core.Query;

namespace SolrExpress.Solr4.Parameter
{
    public sealed class QueryFieldParameter : IParameter<List<string>>
    {
        private readonly string _query;

        /// <summary>
        /// Create a query field parameter
        /// </summary>
        /// <param name="query">Query used to make the query field</param>
        public QueryFieldParameter(string query)
        {
            this._query = query;
        }

        /// <summary>
        /// True to indicate multiple instances of the parameter, otherwise false
        /// </summary>
        public bool AllowMultipleInstances { get { return false; } }

        /// <summary>
        /// Execute the creation of the parameter "query field"
        /// </summary>
        /// <param name="container">Container to parameters to request to SOLR</param>
        public void Execute(List<string> container)
        {
            container.Add(string.Concat("qf=", this._query));
        }
    }
}