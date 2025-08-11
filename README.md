ProyectoEvaluacion:

Aplicación web ASP.NET Core 8 con arquitectura en capas, autenticación por grupos, funcionalidad maestro-detalle y despliegue en IIS.

o Descripción:
  La rama master contine el proyecto completo, para fines de clonación y uso de la solución
  Se encuentra proceso de construcción desde cero y pasos de despliegue en WebApp/Documentacion/
  
o Base de datos

El script de creación se encuentra en WebApp/Database/ProyectoEvaluacionDb.sql.

o Para restaurar:

Abrir SSMS
Ejecutar el script
Verificar tablas y datos

o Estructura del proyecto:

WebApp: capa de presentación
DtaAccess.BsnLogic: capa de datos y lógica de negocio
Database: scripts SQL y respaldo

o Buenas prácticas aplicadas:

Índices en campos clave
PascalCase

o Se integro funcionalidad de:

Seguridad por grupo y login sencillo
Vista dinámica para agregar materiales a la formula de un producto
