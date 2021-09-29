using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using ROP;

namespace ApiWithROP.Utils
{
    public static class ResultsExtentions
    {
        public static ActionResult<T> ToActionResult<T>(this Result<T> result)
         => result.Match(FromSuccess, FromFailure<T>);

        public static ActionResult<T> ToActionResult<T>(this Result<T> result, IStringLocalizer localizer)
         => result.Match(FromSuccess, f => FromFailure<T>(f, localizer));


        private static ActionResult<T> FromSuccess<T>(T t) => new OkObjectResult(t);
        private static ActionResult<T> FromFailure<T>(Failure f) => new ObjectResult(f) { StatusCode = 403 };
        private static ActionResult<T> FromFailure<T>(Failure f, IStringLocalizer localizer)
        {
            var localizedFailure = new Failure(f.ReasonId, localizer[f.ReasonId]);
            return new ObjectResult(localizedFailure) { StatusCode = 403 };
        }
    }
}