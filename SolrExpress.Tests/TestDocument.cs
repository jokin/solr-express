﻿using SolrExpress.QueryBuilder;

namespace SolrExpress.Tests
{
    public class TestDocument : IDocument
    {
        public string Id { get; set; }

        public decimal Score { get; set; }
    }
}
