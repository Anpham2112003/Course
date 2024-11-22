using Api.Schemas.Mutation;
using Api.Schemas.Query;
using Application.MediaR.Comands.Account;
using Domain.Types.ErrorTypes.Erros.Account;
using Domain.Untils;
using GreenDonut;
using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Fetching;
using Infrastructure.DB.SQLDbContext;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Snapshooter;
using Snapshooter.Xunit;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MyTest
{
    public class AccountTest : IClassFixture<CustomWebAppicationFactory<Program>>
    {
        private readonly CustomWebAppicationFactory<Program> webApplicationFactory;

        public AccountTest(CustomWebAppicationFactory<Program> webApplicationFactory)
        {
            this.webApplicationFactory = webApplicationFactory;
        }

        [Fact]
        public async Task Test()
        {
            RequestExecutorProxy executor = webApplicationFactory.Services.GetRequiredService<RequestExecutorProxy>();

            var quey = new QueryRequestBuilder()
                .SetQuery(@"
                         mutation CreateItem($input: LoginAccountRequestInput!) {
                            loginAccount(input: $input){
                                payload{
                                    id
                                }
                                
                                errors{
                                     ...on AccountOrPasswordError{
                                            code
                                            message
                                 }
                            }
                        }
                }")
                .AddVariableValue("input", new LoginAccountRequest
                {
                    Email = "anpham2112003@gmail.com",
                    Password = "taolaso1"
                })
                .Create();



            var result = await executor.ExecuteAsync(quey);

            var ex = result.ExpectQueryResult();

            var Json = JsonSerializer.Serialize(ex.Data);

            var ob = JsonSerializer.Deserialize<MutationPayload<LoginAccountRequest, AccountOrPasswordError>>(Json, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            });








        }
    }
}
