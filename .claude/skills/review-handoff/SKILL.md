---
name: review-handoff
description: Revisa la arquitectura de handoff entre agentes y propone mejoras concretas para los modos Single, LlmHandOff o CopilotHandOff en este repositorio.
disable-model-invocation: true
allowed-tools: Read, Edit, Glob, Grep, Bash
---

# Review Handoff

Usa esta skill cuando el usuario quiera revisar, diagnosticar o mejorar el comportamiento de handoff entre agentes en el repositorio.

## Objetivo
Evaluar si la arquitectura actual de handoff es coherente, mantenible y efectiva para el caso de uso de Interview Coach.

## Qué revisar

1. Identifica cómo están modelados los modos:
   - `Single`
   - `LlmHandOff`
   - `CopilotHandOff`

2. Revisa:
   - composición del agente principal
   - puntos de delegación o handoff
   - prompts/roles de los agentes involucrados
   - uso de tools antes y después del handoff
   - dependencias respecto al proveedor LLM

3. Evalúa:
   - claridad en responsabilidades
   - riesgo de bucles o delegaciones innecesarias
   - coste/latencia adicional
   - dificultad de depuración
   - acoplamiento a proveedor
   - impacto en experiencia de usuario

4. Propón mejoras incrementales:
   - mejor definición de roles
   - criterios más claros para delegar
   - reducción de handoffs innecesarios
   - telemetría o logging más útil
   - fallback cuando una vía falle

## Reglas
- No propongas una reescritura completa salvo que sea imprescindible.
- Prioriza cambios pequeños y verificables.
- Distingue entre problemas reales observados y oportunidades de mejora.
- Si el repositorio no deja claro el handoff, dilo explícitamente.

## Formato de salida
1. Resumen ejecutivo
2. Cómo está funcionando el handoff hoy
3. Hallazgos críticos
4. Hallazgos medios
5. Mejoras recomendadas
6. Validación sugerida