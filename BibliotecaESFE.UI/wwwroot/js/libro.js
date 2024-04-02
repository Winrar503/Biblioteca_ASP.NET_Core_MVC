// Función para resaltar filas al pasar el cursor sobre ellas
document.addEventListener("DOMContentLoaded", function () {
    const rows = document.querySelectorAll("tbody tr");
    rows.forEach(row => {
        row.addEventListener("mouseover", function () {
            this.style.backgroundColor = "#f2f2f2"; // Cambia el color de fondo al pasar el cursor
        });
        row.addEventListener("mouseout", function () {
            this.style.backgroundColor = ""; // Restaura el color de fondo al quitar el cursor
        });
    });
});

// Función para animación de desplazamiento suave al hacer clic en enlaces internos
document.addEventListener("DOMContentLoaded", function () {
    const links = document.querySelectorAll('a[href^="#"]');
    links.forEach(link => {
        link.addEventListener("click", function (e) {
            e.preventDefault();
            const targetId = this.getAttribute("href");
            document.querySelector(targetId).scrollIntoView({
                behavior: "smooth"
            });
        });
    });
});
