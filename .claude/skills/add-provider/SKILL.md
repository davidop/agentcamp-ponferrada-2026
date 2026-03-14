---
name: add-provider
description: Añade o revisa soporte para un proveedor LLM en este repositorio, manteniendo coherencia con el patrón actual de selección de proveedor, configuración y despliegue.
disable-model-invocation: true
allowed-tools: Read, Write, Edit, MultiEdit, Glob, Grep, Bash
---

# Add Provider

Usa esta skill cuando el usuario quiera añadir, revisar o corregir soporte para un proveedor LLM como `AzureOpenAI`, `GitHubModels`, `MicrosoftFoundry` o `GitHubCopilot`.

## Objetivo
Extender el repositorio con un proveedor nuevo o ajustar uno existente sin romper el patrón actual de configuración, selección y ejecución.

## Procedimiento

1. Identifica dónde se define actualmente la selección de proveedor.
2. Revisa:
   - `src/InterviewCoach.Agent`
   - `src/InterviewCoach.AppHost`
   - configuración asociada
   - variables de entorno y secretos
3. Determina:
   - enumeraciones o constantes de proveedor existentes
   - factorías o ramas de selección
   - configuración específica del proveedor
   - impacto en desarrollo local y despliegue
4. Propón el cambio mínimo necesario.
5. Si implementas:
   - añade el nuevo proveedor manteniendo el patrón existente
   - no hardcodees secretos
   - deja mensajes de error claros si falta configuración
6. Explica:
   - archivos tocados
   - variables/configuración nuevas
   - implicaciones para `azd` o entorno local
7. Sugiere validación mínima:
   - compilación
   - selección correcta del proveedor
   - smoke test de ejecución

## Reglas
- No rompas compatibilidad con proveedores existentes.
- No mezcles lógica de UI con detalles internos del proveedor.
- Aísla la configuración específica del proveedor.
- Si no encuentras un punto de extensión claro, dilo explícitamente antes de proponer refactor.

## Formato de salida
1. Estado actual
2. Diseño del cambio
3. Archivos a tocar
4. Implementación
5. Configuración requerida
6. Validación