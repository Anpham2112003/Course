using Api.Schemas.Mutation;
using Api.Schemas.Query;
using Application.Account;
using Domain.Errors.UnionError;
using Domain.Errors.UnionError.AccountUnion;
using Domain.Errors.UnionErrorImplement.AccountUnionImplemnt;
using Domain.Untils;
using GreenDonut;
using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Fetching;
using Infrastructure.DB.SQLDbContext;
using Infrastructure.Services.UnitOfWorkService;
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
using System.Threading.Tasks;

namespace AccountTest
{
    public class AccountTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> webApplicationFactory;

        public AccountTest(WebApplicationFactory<Program> webApplicationFactory)
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
                .AddVariableValue("input",new LoginAccountRequest
                {
                    Email="anpham2112003@gmail.com",
                    Password="taolaso1"
                })
                .Create();

          

           var result = await executor.ExecuteAsync(quey);

           
            

          

            
            

        }
    }
}
