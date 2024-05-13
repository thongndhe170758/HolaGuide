// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.addEventListener("DOMContentLoaded", function () {
    // Get the height of the navbar
    var navbarHeight = document.getElementById("myNavbar").offsetHeight;

    // Set padding-top for the content area
    document.getElementById("content").style.paddingTop = navbarHeight + "px";
});