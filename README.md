# 📚 Libro3 – Aplicación Razor Pages estilo “Netflix de Libros”

Proyecto grupal desarrollado en **ASP.NET Core Razor Pages**, cuyo objetivo es implementar una plataforma de visualización, administración y exploración de libros inspirada en la experiencia de Netflix.

---

## 🚀 Características principales

- 🗂️ **Listado y filtrado de libros**  
- 🔍 **Búsqueda por título, autor y categoría**
- 👁️ **Páginas Razor con patrón MVVM**
- 🗃️ **Modelos y DTOs organizados**
- 💾 **Repositorio y servicios con separación de responsabilidades**
- ✔️ **Validaciones mediante clases en `/Validador`**
- 🎨 **UI moderna con archivos estáticos en `wwwroot`**

---

## 🏗️ Estructura del proyecto

Libro3/
│
├── NetflixLibrosRazor/
│ ├── Models/ # Entidades de dominio
│ ├── DTOs/ # Objetos de transferencia de datos
│ ├── Repository/ # Capa de acceso a datos
│ ├── Service/ # Lógica de negocio
│ ├── Validador/ # Validadores personalizados
│ ├── Pages/ # Razor Pages (UI)
│ ├── wwwroot/ # CSS, JS, imágenes
│ ├── Program.cs # Configuración principal
│ └── appsettings.json # Configuración de entorno
│
└── script.js # Scripts generales

yaml
Copiar código

---

## ⚙️ Requisitos

- .NET 6 o superior  
- Visual Studio 2022 o VS Code  
- SDK de ASP.NET Core  

---

## ▶️ Cómo ejecutar el proyecto

1. Clonar o descargar el repositorio.
2. Abrir la solución `Libro3.sln`.
3. Restaurar dependencias:

```bash
dotnet restore
Ejecutar la aplicación:

bash
Copiar código
dotnet run --project NetflixLibrosRazor
Abrir en el navegador:

arduino
Copiar código
https://localhost:5001
👥 Trabajo en equipo
Este proyecto se desarrolló de manera grupal aplicando buenas prácticas de programación, diseño y organización.

📄 Licencia
Proyecto académico — uso educativo.

markdown
Copiar código

Si querés, puedo **generarlo como archivo README.md listo para descargar**. ¿Querés que lo cree?