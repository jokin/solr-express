﻿using SolrExpress.Core.Query;

namespace SolrExpress.Solr5.Tests
{
    public class TestDocument : IDocument
    {
        public string Id { get; set; }

        public decimal Score { get; set; }

        public GeoCoordinate Spatial { get; set; }
    }
}
