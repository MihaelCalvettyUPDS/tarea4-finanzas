# modificacion de prueba
# NombreProyecto - Sistema Backend finanzas(.NET 10 + PostgreSQL)

API RESTful desarrollada en **.NET 10** con persistencia en **PostgreSQL**, orquestada mediante **Docker Compose** con separación entre entorno de construcción (`contructor.yml`) y despliegue limpio (`despliegue.yml`).

## Estructura del Proyecto

NombreProyecto/
├── contructor.yml          
├── despliegue.yml          
├── .gitignore              
├── .env.example            
├── README.md               
└── NombreProyecto/         
    ├── NombreProyecto.csproj
    ├── Program.cs
    ├── Dockerfile          
    ├── Controllers/        
    ├── Models/             
    └── Data/               

## Integrantes y Módulos Desarrollados

| **Integrante 1** | `Categoria` | `POST`, `GET` (lista), `GET` (ID), `PUT`, `DELETE` |
| **Integrante 2** | `Usuario`   | `POST`, `GET` (lista), `GET` (ID), `PUT`, `DELETE` |
| **Integrante 3** | `Moneda`    | `POST`, `GET` (lista), `GET` (ID), `PUT`, `DELETE` |

## Imagen Publicada en Docker Hub

* **Repositorio público:** https://hub.docker.com/repository/docker/mihaelcalvetty/finanzas-api
* **Etiqueta exacta:** `mihaelcalvetty/finanzas-api:1.0`

## Instrucciones de Ejecución

### 1. Configurar variables de entorno
Copia la plantilla de ejemplo y asigna tus credenciales locales antes de ejecutar cualquier entorno:

```bash
cp .env.example .env
```

### 2. Entorno de Despliegue (Producción desde Docker Hub)
Descarga la imagen precompilada desde Docker Hub y levanta los servicios sin compilar código:

```bash
docker compose --env-file .env -f despliegue.yml up -d
```

## Investigación y Verificación del Despliegue con IA

### ¿Qué se consultó a la IA?
Se consultó cómo estructurar un archivo `despliegue.yml` en Docker Compose para ejecutar una Web API en .NET 10 junto con PostgreSQL utilizando una imagen previamente publicada en Docker Hub, evitando la compilación desde el código fuente y manteniendo la base de datos aislada en una red interna sin exponer puertos al exterior.

### ¿Cómo se verificó la propuesta?
1. **Revisión de sintaxis y seguridad:** Se verificó que `despliegue.yml` utilizara la directiva `image:` apuntando a la etiqueta exacta publicada en Docker Hub, sin incluir directivas `build:`
2. **Descarga limpia:** Se ejecutó `docker compose --env-file .env -f despliegue.yml up -d`, confirmando que Docker descargó la imagen remota y levantó ambos contenedores
3. **Prueba de endpoints:** Se realizó una petición HTTP `GET` a los endpoints de la API en ejecución, verificando una respuesta exitosa