﻿// -------------------------------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// -------------------------------------------------------------------------------------------------

using Hl7.Fhir.Model;
using Microsoft.Health.Fhir.Core.Features.Search.SearchValues;
using Microsoft.Health.Fhir.SqlServer.Features.Schema.Model;

namespace Microsoft.Health.Fhir.SqlServer.Features.Storage.TvpRowGeneration
{
    internal class TokenSearchParameterRowGenerator : SearchParameterRowGenerator<TokenSearchValue, V1.TokenSearchParamTableTypeRow>
    {
        public TokenSearchParameterRowGenerator(SqlServerFhirModel model)
            : base(model)
        {
        }

        protected override bool ShouldGenerateRow(SearchParameter searchParameter, TokenSearchValue searchValue) => !string.IsNullOrWhiteSpace(searchValue.Code);

        protected override V1.TokenSearchParamTableTypeRow GenerateRow(short searchParamId, SearchParameter searchParameter, TokenSearchValue searchValue)
        {
            return new V1.TokenSearchParamTableTypeRow(
                searchParamId,
                searchValue.System == null ? (int?)null : Model.GetSystem(searchValue.System),
                searchValue.Code);
        }
    }
}