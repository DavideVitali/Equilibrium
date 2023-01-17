using Microsoft.AspNetCore.Mvc;
using System.Data.SqlTypes;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Equilibrium.Components.Communication
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
        public bool Succeeded => succeeded;
        
        /// <summary>
        /// Get a list of errors in case of operation failure.
        /// </summary>
        public IEnumerable<string> Errors => errors ?? new List<string>();

        /// <summary>
        /// Get the underlying object result of the operation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public object? ResultObject => resultObject;

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
        public static OperationResult Success()
        {
            return new OperationResult(true);
        }

        /// <summary>
        /// Returns a successful operation.
        /// </summary>
        /// <param name="resultObject">The underlying object result of the operation.</param>
        /// <returns></returns>
        public static OperationResult Success(object? resultObject)
        {
            return new OperationResult(true, resultObject);
        }

        /// <summary>
        /// Returns a failed operation.
        /// </summary>
        /// <param name="error">The error message.</param>
        /// <returns></returns>
        public static OperationResult Failure(string error)
        {
            IEnumerable<string> errors = new List<string> { error };
            return new OperationResult(false, null, errors);
        }

        /// <summary>
        /// Returns a failed operation.
        /// </summary>
        /// <param name="errors">The error messages.</param>
        /// <returns></returns>
        public static OperationResult Failure(IEnumerable<string> errors)
        {
            return new OperationResult(false, null, errors);
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status200OK;
            string jsonResult = JsonSerializer.Serialize(new OperationResult(succeeded, resultObject, errors));

            await HttpResponseWritingExtensions.WriteAsync(context.HttpContext.Response, jsonResult);
        }
    }
}
