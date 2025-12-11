## ✨ Integrantes

* Leon Flores, Celedonio
* Diego, Algañaras 
* Ramirez, Luján

---

## 📝 Descripción General del Proyecto

El proyecto **Libro3** es una aplicación desarrollada con **ASP.NET Core Razor Pages**, inspirada en la experiencia de plataformas como Netflix, pero orientada a la visualización y gestión de libros.

El sistema permite:

* Visualizar libros con información detallada.
* Filtrar y buscar por género, autor o título.
* Administrar libros desde capas separadas.
* Utilizar DTOs, repositorios y servicios para una arquitectura limpia.
* Validar datos mediante clases dedicadas.
* Renderizar páginas dinámicas con Razor Pages.

---

## 🧱 Arquitectura del Proyecto

El proyecto está organizado siguiendo una estructura clara y mantenible:

### 1. **Models**

* Entidades principales del sistema.
* Representación de los libros y otros objetos de dominio.

### 2. **DTOs**

* Objetos para transferencia de datos entre capas.
* Separación entre entidad y datos expuestos a la UI.

### 3. **Repository**

* Acceso a datos.
* Métodos CRUD encapsulados.
* Comunicación con la fuente de datos (JSON/DB según implementación).

### 4. **Service**

* Lógica de negocio.
* Procesamiento de datos antes de llegar a la UI.

### 5. **Validador**

* Validaciones de datos.
* Reglas personalizadas por entidad.

### 6. **Pages (Razor Pages)**

* Vista principal del sistema.
* Renderizado de listas de libros.
* Navegación y búsqueda.

### 7. **wwwroot**

* Archivos estáticos: imágenes, CSS, JS.

---

## 🔄 Flujo General del Sistema

1. El usuario accede a la página principal.
2. Razor Page solicita datos al **Service**.
3. El Service procesa la petición y consulta al **Repository**.
4. Repository devuelve los datos solicitados.
5. El Service aplica reglas, validaciones o filtros.
6. Los datos son enviados a la Razor Page como modelos o DTOs.
7. La interfaz muestra los libros al usuario.

---

## 📚 Módulos del Sistema

### ✔ Listado de libros  
### ✔ Visualización de detalles  
### ✔ Filtros por título, género y autor  
### ✔ Gestión desde servicios y repositorios  
### ✔ Validación de datos  
### ✔ Recursos estáticos (imágenes, estilos, scripts)  

---

## 🛠 Tecnologías Utilizadas

* .NET 9  
* ASP.NET Core Razor Pages  
* C#  
* AutoMapper (opcional según implementación)  
* Bootstrap / CSS para estilos  
* JSON o base de datos (dependiendo del repositorio usado)

---

## 🚧 Estado Actual del Proyecto

✔ Razor Pages implementadas  
✔ Modelos y DTOs definidos  
✔ Servicios funcionales  
✔ Repositorios creados  
✔ Interfaz estilo catálogo  

---

## 📌 Estructura del Proyecto

```txt
Libro3/
├── NetflixLibrosRazor
│   ├── Models
│   ├── DTOs
│   ├── Repository
│   ├── Service
│   ├── Validador
│   ├── Pages
│   ├── wwwroot
│   ├── Program.cs
│   └── appsettings.json
└── script.js
