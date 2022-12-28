using Microsoft.AspNetCore.Mvc;
using System.Data.SqlTypes;
using System.Net.Sockets;
using System.Runtime.CompilerServices;

namespace Equilibrium.Components.OperationResult
{ 
    /// <summary>
    /// This class acts mainly as a bridge between server and client to easily manage exceptions and
    /// to provide a means to show consistently formatted messages to the final user.
    /// </summary>
    public class OperationResult : IActionResult
    {
        private bool succeeded = false;
        private IEnumerable<string>? errors;
        private object? resultObject;

        /// <summary>
        /// Check whether the operation was successful.
        /// </summary>
        internal bool Succeeded => succeeded;
        
        /// <summary>
        /// Get a list of errors in case of operation failure.
        /// </summary>
        internal IEnumerable<string> Errors 
        {
            get
            {
                return errors ?? new List<string>();
            }
        }

        /// <summary>
        /// Get the underlying object result of the operation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        internal T? FromResult<T>() => (T?)resultObject;

        private OperationResult(bool succeeded, object? resultObject = null, IEnumerable<string>? errors = null)
        {
            this.succeeded = succeeded;
            this.errors = errors;
            this.resultObject = resultObject;
        }

        /// <summary>
        /// Returns a successful operation without further details.
        /// </summary>
        /// <returns></returns>
        internal static OperationResult Success()
        {
            return new OperationResult(true);
        }

        /// <summary>
        /// Returns a successful operation.
        /// </summary>
        /// <param name="resultObject">The underlying object result of the operation.</param>
        /// <returns></returns>
        internal static OperationResult Success(object? resultObject)
        {
            return new OperationResult(true, resultObject);
        }

        /// <summary>
        /// Returns a failed operation.
        /// </summary>
        /// <param name="error">The error message.</param>
        /// <returns></returns>
        internal static OperationResult Failure(string error)
        {
            IEnumerable<string> errors = new List<string> { error };
            return new OperationResult(false, null, errors);
        }

        /// <summary>
        /// Returns a failed operation.
        /// </summary>
        /// <param name="errors">The error messages.</param>
        /// <returns></returns>
        internal static OperationResult Failure(IEnumerable<string> errors)
        {
            return new OperationResult(false, null, errors);
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            var objectResult = new ObjectResult(_result.Exception ?? _result.Data)
            {
                StatusCode = _result.Exception != null
                ? StatusCodes.Status500InternalServerError
                : StatusCodes.Status200OK
            };

            await objectResult.ExecuteResultAsync(context);
        }
    }
}
