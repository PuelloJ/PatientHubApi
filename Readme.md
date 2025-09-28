# PatientHub API

Una API REST moderna desarrollada con .NET 8 para la gestión integral de pacientes en entornos médicos.

## Arquitectura

El proyecto sigue los principios de **Clean Architecture** con las siguientes capas:

```
PatientHubApi/
├── API/                    # Capa de presentación
│   ├── Controllers/        # Controladores REST
│   └── Middleware/         # Middleware personalizado
├── Application/            # Capa de aplicación
│   ├── DTOs/              # Objetos de transferencia de datos
│   ├── Interfaces/        # Contratos de servicios
│   ├── Models/            # Modelos de aplicación
│   └── Services/          # Lógica de negocio
├── Core/                  # Capa de dominio
│   ├── Entities/          # Entidades del dominio
│   └── Interfaces/        # Contratos del dominio
└── Infrastructure/        # Capa de infraestructura
    ├── Data/              # Contexto de base de datos
    └── Repositories/      # Implementación de repositorios
```

## Instalación y Configuración

### 1. Clonar el repositorio

```bash
git clone https://github.com/tu-usuario/PatientHubApi.git
cd PatientHubApi
```

### 2. Restaurar paquetes NuGet

```bash
dotnet restore
```

### 3. Configurar la base de datos

Actualiza la cadena de conexión en `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=PatientHubDb;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
```

### 4. Ejecutar migraciones

```bash
# Instalar herramientas de EF Core (si no están instaladas)
dotnet tool install --global dotnet-ef

# Crear y aplicar migraciones
dotnet ef migrations add InitialCreate --project . --output-dir Infrastructure/Data/Migrations
dotnet ef database update
```

### 5. Ejecutar el procedimiento almacenado

Ejecuta el archivo `Procedimiento.sql` en tu base de datos para crear el procedimiento almacenado `GetPatientsCreatedAfter`:

```bash
# Usando SQL Server Management Studio (SSMS)
# 1. Conectarse a la instancia de SQL Server
# 2. Abrir el archivo Procedimiento.sql
# 3. Ejecutar el script

# O usando sqlcmd desde la línea de comandos:
sqlcmd -S localhost\SQLEXPRESS -d DBPatientHub -i Procedimiento.sql
```

El procedimiento permite obtener pacientes creados después de una fecha específica:
```sql
EXEC GetPatientsCreatedAfter @DateCreated = '2024-01-01'
```

### 6. Ejecutar la aplicación

```bash
dotnet run --project PatientHubApi
```

La API estará disponible en:
- **HTTP**: `http://localhost:5000`
- **Acceso directo**: Navegar a `http://localhost:5000/` redirige automáticamente a Swagger

## Endpoints de la API

### Pacientes

| Método | Endpoint | Descripción |
|--------|----------|-------------|
| `GET` | `/api/patient` | Obtener lista paginada de pacientes |
| `GET` | `/api/patient/{id}` | Obtener paciente por ID |
| `POST` | `/api/patient` | Crear nuevo paciente |
| `PUT` | `/api/patient/{id}` | Actualizar paciente existente |
| `DELETE` | `/api/patient/{id}` | Eliminar paciente |

### Datos de Prueba (Seeding)

| Método | Endpoint | Descripción |
|--------|----------|-------------|
| `POST` | `/api/seed/patients` | Insertar 40+ pacientes colombianos de prueba |
| `DELETE` | `/api/seed/patients/clear` | Eliminar todos los pacientes |
| `GET` | `/api/seed/stats` | Obtener estadísticas de la base de datos |

### Parámetros de consulta para listado

- `pageNumber` (int): Número de página (default: 1)
- `pageSize` (int): Tamaño de página (default: 10)
- `searchTerm` (string): Término de búsqueda
- `sortBy` (string): Campo para ordenar
- `sortDirection` (string): Dirección de ordenamiento (asc/desc)

### Ejemplo de respuesta

```json
{
  "data": [
    {
      "patientId": 1,
      "documentType": "DNI",
      "documentNumber": "12345678",
      "firstName": "Juan",
      "lastName": "Pérez",
      "birthDate": "1990-05-15T00:00:00",
      "phoneNumber": "+54 11 1234-5678",
      "email": "juan.perez@email.com",
      "createdAt": "2024-01-15T10:30:00Z"
    }
  ],
  "totalCount": 1,
  "pageNumber": 1,
  "pageSize": 10,
  "totalPages": 1,
  "hasPreviousPage": false,
  "hasNextPage": false
}
```



## 📝 Estructura de la Base de Datos

### Tabla: Patients

| Campo | Tipo | Descripción |
|-------|------|-------------|
| `PatientId` | int (PK) | Identificador único |
| `DocumentType` | nvarchar(50) | Tipo de documento |
| `DocumentNumber` | nvarchar(50) | Número de documento |
| `FirstName` | nvarchar(100) | Nombre |
| `LastName` | nvarchar(100) | Apellido |
| `BirthDate` | datetime2 | Fecha de nacimiento |
| `PhoneNumber` | nvarchar(20) | Número de teléfono (opcional) |
| `Email` | nvarchar(100) | Correo electrónico (opcional) |
| `CreatedAt` | datetime2 | Fecha de creación |

## 🤝 Contribución

1. Fork el proyecto
2. Crea una rama feature (`git checkout -b feature/AmazingFeature`)
3. Commit tus cambios (`git commit -m 'Add some AmazingFeature'`)
4. Push a la rama (`git push origin feature/AmazingFeature`)
5. Abre un Pull Request


## Licencia

Este proyecto está bajo la Licencia MIT. Ver el archivo [LICENSE](LICENSE) para más detalles.

---

Desarrollado con ❤️ por [PuelloJ](https://github.com/PuelloJ) 