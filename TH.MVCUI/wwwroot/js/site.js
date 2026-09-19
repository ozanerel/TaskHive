document.addEventListener("DOMContentLoaded", function () {

    const sidebar = document.querySelector(".th-sidebar");
    const sidebarToggle = document.getElementById("sidebarToggle");
    const overlay = document.querySelector(".sidebar-overlay");

    if (!sidebar || !sidebarToggle)
        return;


    // Sidebar Toggle
    sidebarToggle.addEventListener("click", function () {

        // Desktop
        if (window.innerWidth > 992) {

            sidebar.classList.toggle("collapsed");

            return;
        }

        // Mobile
        sidebar.classList.toggle("show");

        if (overlay) {
            overlay.classList.toggle("show");
        }

    });


    // Overlay
    if (overlay) {

        overlay.addEventListener("click", function () {

            sidebar.classList.remove("show");
            overlay.classList.remove("show");

        });

    }


    // Responsive transition
    window.addEventListener("resize", function () {

        if (window.innerWidth > 992) {

            sidebar.classList.remove("show");

            if (overlay) {
                overlay.classList.remove("show");
            }

        }

    });

});