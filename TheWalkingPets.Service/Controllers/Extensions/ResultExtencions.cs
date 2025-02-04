using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using TheWalkingPets.Service.common;

namespace TheWalkingPets.Service.Controllers.Extensions
{
    public static class ResultExtencions
    {
        public static IResult ToProblemDetailsResult(this Result result)
        {
            if (result.IsSuccess)
            {
                throw new InvalidOperationException("cannot create problem details for a successful result. ");
            }

            var serverError = result.Error.Code.Contains("Unhandled");

            return Results.Problem(
                statusCode: serverError ? StatusCodes.Status500InternalServerError : StatusCodes.Status400BadRequest,
                title: serverError ? "serverError" : "Bad request",
                type: serverError ? "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1" : "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                extensions: new Dictionary<string, object?>
                {
                    {"errors", new[] {result.Error} }
                }
            );
        }
        public static ActionResult ToProblemDetails(this Result result)
        {
            if(result.IsSuccess)
            {
                throw new InvalidOperationException("Cannot create problem details for a successful result.");
            }

            var serverError = result.Error.Code.Contains("unhandled");

            var problemDetails = new ProblemDetails
            {
                Status = serverError ? StatusCodes.Status500InternalServerError : StatusCodes.Status400BadRequest,
                Title = serverError ? "sever Error" : "badRequest",
                Type = serverError ? "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1" : "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                Extensions =
                {
                    {"errors", new[] {result.Error} }
                }
            };

            return new ObjectResult(problemDetails)
            {
                StatusCode = serverError ? StatusCodes.Status500InternalServerError : StatusCodes.Status400BadRequest,
            };
        }

    }
}
