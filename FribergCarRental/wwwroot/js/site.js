// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.addEventListener("DOMContentLoaded", function () {
    var toastElement = document.getElementById("successToast");
    if (toastElement) {
        var toast = new bootstrap.Toast(toastElement, { delay: 5000 });
        toast.show();
    }
});