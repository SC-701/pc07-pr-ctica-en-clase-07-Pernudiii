[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/dvoi-q_B)
# Práctica en Clase 05: Integración con APIs Externas

## Información General
- **Curso:** Desarrollo de Aplicaciones Web
- **Práctica:** #5
- **Rubro:** Caso práctico 1
- **Valor:** 3%
- **Fecha:** Semana 05/06
- **Duración:** 1 hora

---

## 📋 Objetivo
Agregar a la API de Productos, en la consulta del detalle de producto:
- Campo Precio USD calculado automáticamente
- Colección de Postman

## Objetivos de Aprendizaje
Al finalizar esta práctica, el estudiante será capaz de:
- Consumir APIs externas con HttpClient
- Implementar servicios de integración
- Configurar HttpClient en .NET
- Manejar conversión de tipos de cambio
- Calcular valores dinámicos en respuestas

---

## Requisitos Previos
- Tener completada la Práctica en Clase 04

## 🌐 API del Banco Central de Costa Rica

**URL Base:** https://apim.bccr.fi.cr/SDDE/api/Bccr.GE.SDDE.Publico.Indicadores.API/cuadro/491/series

**Ejemplo de consulta:**
```
https://apim.bccr.fi.cr/SDDE/api/Bccr.GE.SDDE.Publico.Indicadores.API/cuadro/491/series?fechaInicio=2026/02/08&fechaFin=2026/02/08&idioma=ES
```

**Respuesta de ejemplo:**
```json
{
    "estado": true,
    "mensaje": "Consulta exitosa",
    "datos": [
        {
            "titulo": "Tipo de cambio de venta del dólar de los Estados Unidos de América",
            "periodicidad": "Diaria",
            "indicadores": [
                {
                    "codigoIndicador": "318",
                    "nombreIndicador": "Tipo cambio venta",
                    "series": [
                        {
                            "fecha": "2026-02-08",
                            "valorDatoPorPeriodo": 496.44000000
                        }
                    ]
                }
            ]
        }
    ]
}
```

**Autenticación:** Bearer Token

**Registro:**
Para obtener su token personal, regístrese en:
https://www.bccr.fi.cr/indicadores-economicos/suscripción-a-indicadores

---

## Instrucciones

### 🏗️ Arquitectura de Capas

La práctica debe implementar una arquitectura de capas similar a **Vehiculo.API**:

- **Servicios**: Capa responsable del consumo de APIs externas (Banco Central)
- **Reglas**: Capa que contiene la lógica de negocio (cálculo de precios, conversiones)
- **Flujo**: Orquestación de servicios y reglas
- **API**: Controllers que exponen los endpoints

### ✅ Recomendaciones

Antes de iniciar la implementación, siga estos pasos:

1. **Copiar el .gitignore** al nuevo proyecto
2. **Copiar el código de la Práctica en Clase 03/04** como base
3. **Crear una colección de Postman** y probar el consumo directo del API del Banco Central antes de iniciar la programación
4. **Analizar la respuesta del API** y crear un modelo (clases C#) que represente la estructura de datos retornada
5. **Analizar los cambios al endpoint de detalle de producto** - identificar qué campos nuevos se deben agregar
6. **Analizar las interfaces correspondientes** para Reglas (IProductoReglas) y Servicios (ITipoCambioServicio)

### 📋 Tareas

#### ✅ 1. Capa de Servicios - TipoCambioServicio
Implementar el servicio que consume el API del Banco Central.

**Ubicación:** `Servicios/TipoCambioServicio.cs`

**Responsabilidades:**
- Leer la configuración del URL y Bearer Token desde appsettings.json
- Construir la URL con las fechas dinámicas (fecha actual)
- Agregar el header de autorización Bearer Token
- Consumir el API del BCCR
- Deserializar la respuesta y extraer el valor del tipo de cambio

#### ✅ 2. Configuración

**En Program.cs:**
- Registrar el HttpClient para TipoCambioServicio
- Registrar TipoCambioServicio como Scoped

**En appsettings.json:**
- Agregar sección "BancoCentralCR" con UrlBase y BearerToken
- Reemplazar `TU_TOKEN_AQUI_DESDE_BCCR` con su token personal obtenido del registro

#### ✅ 3. Capa de Reglas - ProductoReglas
Implementar la lógica de negocio para calcular el precio en USD.

**Ubicación:** `Reglas/ProductoReglas.cs`

**Responsabilidades:**
- Inyectar ITipoCambioServicio
- Implementar método CalcularPrecioUSD que recibe el precio en colones
- Obtener el tipo de cambio del servicio
- Retornar el precio convertido a dólares

**Registrar en Program.cs:**
- Agregar ProductoReglas como Scoped

#### ✅ 4. Actualizar ProductoFlujo
- Inyectar IProductoReglas
- Llamar a CalcularPrecioUSD en el método ObtenerPorId
- Agregar la propiedad PrecioUSD al DTO de respuesta

#### ✅ 5. Colección de Postman
- Subir la colección actualizada al repositorio
