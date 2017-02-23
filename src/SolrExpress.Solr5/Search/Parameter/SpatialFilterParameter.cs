﻿using Newtonsoft.Json.Linq;
using SolrExpress.Core.Search.Parameter;
using SolrExpress.Search;
using SolrExpress.Search.Parameter;
using System;
using System.Linq.Expressions;
using SolrExpress.Utility;

namespace SolrExpress.Solr5.Search.Parameter
{
    public class SpatialFilterParameter<TDocument> : ISpatialFilterParameter<TDocument>, ISearchItemExecution<JObject>
        where TDocument : IDocument
    {
        private readonly ExpressionBuilder<TDocument> _expressionBuilder;
        private JProperty _result;

        public SpatialFilterParameter(ExpressionBuilder<TDocument> expressionBuilder)
        {
            this._expressionBuilder = expressionBuilder;
        }

        GeoCoordinate ISpatialFilterParameter<TDocument>.CenterPoint { get; set; }

        decimal ISpatialFilterParameter<TDocument>.Distance { get; set; }

        Expression<Func<TDocument, object>> ISpatialFilterParameter<TDocument>.FieldExpression { get; set; }

        SpatialFunctionType ISpatialFilterParameter<TDocument>.FunctionType { get; set; }

        void ISearchItemExecution<JObject>.AddResultInContainer(JObject container)
        {
            var jObj = (JObject)container["params"] ?? new JObject();
            jObj.Add(this._result);
            container["params"] = jObj;
        }

        void ISearchItemExecution<JObject>.Execute()
        {
            var parameter = (ISpatialFilterParameter<TDocument>)this;
            var fieldName = this._expressionBuilder.GetFieldNameFromExpression(parameter.FieldExpression);

            var formule = ParameterUtil.GetSpatialFormule(
                fieldName,
                parameter.FunctionType,
                parameter.CenterPoint,
                parameter.Distance);

            this._result = new JProperty("fq", formule);
        }
    }
}