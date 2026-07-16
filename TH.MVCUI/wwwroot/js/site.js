document.addEventListener("DOMContentLoaded", () => {

    const sidebar = document.querySelector(".th-sidebar");
    const sidebarToggle = document.getElementById("sidebarToggle");
    const overlay = document.querySelector(".sidebar-overlay");

    console.log("Sidebar:", sidebar);
    console.log("Toggle:", sidebarToggle);

    if (sidebarToggle && sidebar) {

        sidebarToggle.addEventListener("click", () => {

            // Desktop

            if (window.innerWidth > 992) {

                sidebar.classList.toggle("collapsed");

            }

            // Mobile

            else {

                sidebar.classList.toggle("show");
                if (overlay) {
                    overlay.classList.toggle("show");
                }

            }

        });

    }


    // Overlay'e basınca sidebar kapansın

    if (overlay) {

        overlay.addEventListener("click", () => {

            sidebar.classList.remove("show");
            overlay.classList.remove("show");

        });

    }


    // Responsive geçişlerinde sorun yaşamamak için

    window.addEventListener("resize", () => {

        if (window.innerWidth > 992) {

            sidebar.classList.remove("show");
            overlay.classList.remove("show");

        }

    });

});