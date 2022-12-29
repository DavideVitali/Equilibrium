// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let Equilibrium = {
    SortableTable: {},
    /**
        * Communicates the result of a javascript fetch - temporarily an alert
        * @async
        * @function
        * @param {Function} request the fetch request
        * @param {Function} onresponse a function to be called as soon the response arrives, but before it being processed
        * @param {Function} [callback] the final function to be called back upon completion
        */
    FetchOperationResult: function (request, onresponse, callback) {
        request()
            .then(response => {
                onresponse();
                if (response.ok) {
                    return response.json();
                } else {
                    throw new Error(response.responseText);
                };
            })
            .then(result => {
                if (result.errors == null || result.errors.length == 0) {
                    if (!callback) {
                        alert('Ok');
                    } else {
                        callback(result.resultObject);
                    }
                } else {
                    alert(`Error: ${result.errors.join('; ')}`);
                }
            })
            .catch(err => {
                alert(`Error: ${err}`);
            });
    },
};