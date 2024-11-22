using System.Diagnostics;
using System.Security.Claims;
using System.Text;
using Application.MediaR.Comands.Account;
using Application.MediaR.Comands.Payment;
using CloudinaryDotNet;
using Domain.Options;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Stripe;
using Stripe.Checkout;

namespace Api.RestApi
{
    public static class RestApi
    {
        public static IEndpointRouteBuilder AddRestApi(this IEndpointRouteBuilder builder)
        {
            builder.MapGet("api/google", async (HttpContext context,IOptionsMonitor<GoogleOption> options , CancellationToken cancellationToken) =>
            {
                
                 await context.ChallengeAsync(GoogleDefaults.AuthenticationScheme,new AuthenticationProperties
                 {
                     RedirectUri = options.CurrentValue.Redirect_path,
                     
                 });
                 
                 
            });

            builder.MapGet("api/google/callback",
                async (IMediator mediator,IOptionsMonitor<GoogleOption> options, HttpContext context, CancellationToken cancellationToken) =>
                {
                    var authenResult = await context.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                    
                    if (!authenResult.Succeeded)
                    {
                        return Results.Unauthorized();
                    }
                    
                    Debug.Write(authenResult.Ticket.Principal.Claims);
                    
                    var email = authenResult.Ticket.Principal.FindFirst(ClaimTypes.Email)?.Value;
                    
                    var name = authenResult.Ticket.Principal.FindFirst(ClaimTypes.Name)?.Value;

                    var result = await mediator.Send(new GoogleLoginRequest
                    {
                        Email = email,
                        Name = name,
                    },cancellationToken);

                    return Results.Ok(result);

                });

            builder.MapGet("api/tiktok", (HttpContext context ,IOptionsMonitor<TiktokOption> _options) =>
            {
                var csrf = Guid.NewGuid().ToString();
                
                
                var queryBuilder = new StringBuilder()
                    .Append($"client_key={_options.CurrentValue.Client_id}")
                    .Append($"?response_type={_options.CurrentValue.ResponseType}")
                    .Append($"?scope={_options.CurrentValue.Scope}")
                    .Append($"?redirect_uri={_options.CurrentValue.Redirect_uri}")
                    .Append($"?state={csrf}");
                
                var uri = new UriBuilder(_options.CurrentValue.Url!);
                    
                    uri.Query=queryBuilder.ToString();
                    
                
                
                context.Response.Cookies.Append("csrfState", csrf,new CookieOptions
                {
                    MaxAge = TimeSpan.FromMinutes(10)
                });

              return  Results.Redirect(uri.ToString());
            });


            builder.MapPost("api/payment/stripe",
                async ([FromServices] IMediator media,  HttpContext context, StripePaymentRequest input,
                    CancellationToken cancellationToken) =>
                {
                    var result = await media.Send(input, cancellationToken);

                    if (result.errors.Any())
                    {
                        return Results.BadRequest(result.errors.FirstOrDefault());
                    }

                    

                    return Results.Ok(result);
                });
            
            
            
            
            builder.MapGet("api/tiktok/callback", () =>
            {
                Results.Ok("Ok!");
            });

            builder.MapGet("api/payment/stripe/success/callback", () =>
            {
                Results.Ok(new
                {
                    message="ok"
                });
            });

            builder.MapGet("hello", () =>
            {
                return Results.Ok("Ok");
            });

            builder.MapPost("webhook", async (IMediator mediator,IHttpContextAccessor httpContext) =>
            {
                var json= await new StreamReader(httpContext.HttpContext!.Request.Body).ReadToEndAsync();

                try
                {
                    var stripeEvent =EventUtility.ParseEvent(json);

                    if (stripeEvent.Type == EventTypes.CheckoutSessionCompleted)
                    {
                        var session = stripeEvent.Data.Object as Session ;

                        var command = new StripeWebhookRequest
                        {
                            BankTransationId = session!.Id,
                            CartId = Guid.Parse(session.Metadata["cartId"]),
                            Amount = (float)session.AmountTotal!,
                            CourseId = Guid.Parse(session.Metadata["courseId"]),
                            UserId = Guid.Parse(session.Metadata["userId"])
                        };

                        await mediator.Send(command);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            });
            

            
           


            return builder;
        }
    }
}
