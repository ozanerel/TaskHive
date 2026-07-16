//document.addEventListener("DOMContentLoaded", () => {

//    const sidebar = document.querySelector(".th-sidebar");
//    const sidebarToggle = document.getElementById("sidebarToggle");
//    const overlay = document.querySelector(".sidebar-overlay");

//    console.log("Sidebar:", sidebar);
//    console.log("Toggle:", sidebarToggle);

//    if (sidebarToggle && sidebar) {

//        sidebarToggle.addEventListener("click", () => {

//            // Desktop

//            if (window.innerWidth > 992) {

//                sidebar.classList.toggle("collapsed");

//            }

//            // Mobile

//            else {

//                sidebar.classList.toggle("show");
//                if (overlay) {
//                    overlay.classList.toggle("show");
//                }

//            }

//        });

//    }


//    // Overlay'e basınca sidebar kapansın

//    if (overlay) {

//        overlay.addEventListener("click", () => {

//            sidebar.classList.remove("show");
//            overlay.classList.remove("show");

//        });

//    }


//    // Responsive geçişlerinde sorun yaşamamak için

//    window.addEventListener("resize", () => {

//        if (window.innerWidth > 992) {

//            sidebar.classList.remove("show");
//            overlay.classList.remove("show");

//        }

//    });

//});

document.addEventListener("DOMContentLoaded", function () {

    const sidebar = document.querySelector(".th-sidebar");
    const sidebarToggle = document.getElementById("sidebarToggle");
    const overlay = document.querySelector(".sidebar-overlay");

    if (!sidebar || !sidebarToggle)
        return;

    // Desktop
    sidebarToggle.addEventListener("click", function () {

        if (window.innerWidth > 992) {

            sidebar.classList.toggle("collapsed");

            return;
        }

        // Mobile
        sidebar.classList.toggle("show");
        overlay.classList.toggle("show");
    });


    // Overlay
    if (overlay) {

        overlay.addEventListener("click", function () {

            sidebar.classList.remove("show");
            overlay.classList.remove("show");

        });

    }


    // Resize
    window.addEventListener("resize", function () {

        if (window.innerWidth > 992) {

            sidebar.classList.remove("show");

            if (overlay)
                overlay.classList.remove("show");

        }

    });

});

