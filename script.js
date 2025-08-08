function mostrarDetalles(id) {
    const detalles = document.getElementById(id);
    const libros = document.querySelectorAll('.detalles');

    // Oculta todos los detalles
    libros.forEach(libro => {
        if (libro !== detalles) {
            libro.style.display = 'none';
        }
    });

    // Alterna la visibilidad del detalle seleccionado
    detalles.style.display = detalles.style.display === 'block' ? 'none' : 'block';
}