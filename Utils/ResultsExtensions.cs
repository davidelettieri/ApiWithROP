using Microsoft.AspNetCore.Mvc;
using ROP;

namespace ApiWithROP.Utils
{
    public static class ResultsExtentions
    {
        public static ActionResult<T> ToActionResult<T>(this Result<T> result)
         => result.Match(FromSuccess, FromFailure<T>);


        private static ActionResult<T> FromSuccess<T>(T t) => new OkObjectResult(t);
        private static ActionResult<T> FromFailure<T>(Failure f) => new ObjectResult(f) { StatusCode = 403 };
    }
}