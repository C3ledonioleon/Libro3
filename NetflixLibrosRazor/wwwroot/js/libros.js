function mostrarDetalles(id) {
    const item = document.getElementById(id);

    if (item.style.display === "block") {
        item.style.display = "none";
    } else {
        item.style.display = "block";
    }
}
