
document.addEventListener("DOMContentLoaded", function () {
    // Get the height of the navbar
    let navbarHeight = document.getElementById("myNavbar").offsetHeight;

    // Set padding-top for the content area
    document.getElementById("content").style.paddingTop = navbarHeight + "px";
});