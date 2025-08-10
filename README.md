# ProyectoEvaluacion

Aplicación web ASP.NET Core 8 con arquitectura en capas, autenticación por grupos, funcionalidad maestro-detalle y despliegue en IIS.

o Base de datos

El script de creación se encuentra en /Database/ProyectoEvaluacionDb.sql.

o Para restaurar:
1. Abrir SSMS
2. Ejecutar el script
3. Verificar tablas y datos

o Estructura del proyecto

- WebApp: capa de presentación
- DtaAccess.BsnLogic: capa de datos y lógica de negocio
- Database: scripts SQL y respaldo

o Buenas prácticas aplicadas

- Índices en campos clave
- PascalCase

o Próximos pasos

- Implementar lógica de negocio
- Crear vistas dinámicas
- Integrar seguridad por grupo