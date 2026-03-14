# CLAUDE.md

## Repository overview
This repository is an Interview Coach sample built with:
- Microsoft Agent Framework
- MCP servers
- .NET Aspire
- Blazor WebUI
- Azure deployment with azd

## Main solution shape
The repository is organized around:
- `src/InterviewCoach.Agent`
- `src/InterviewCoach.WebUI`
- `src/InterviewCoach.Mcp.InterviewData`
- `src/InterviewCoach.AppHost`
- `src/InterviewCoach.ServiceDefaults`

## Architecture intent
- `InterviewCoach.Agent` contains the main agent logic and orchestration
- `InterviewCoach.WebUI` exposes the user-facing Blazor application
- `InterviewCoach.Mcp.InterviewData` provides MCP-backed capabilities and interview-related tools/data
- `InterviewCoach.AppHost` composes the distributed application topology with Aspire
- `InterviewCoach.ServiceDefaults` centralizes cross-cutting service configuration patterns

## Working rules
- Preserve multi-provider LLM support
- Do not hardcode secrets
- Prefer incremental changes over broad rewrites
- Keep AppHost wiring explicit and easy to reason about
- Use MCP for external tool capabilities where it improves modularity
- Avoid coupling WebUI to provider-specific logic
- Keep the agent architecture explainable and testable
- Respect the current repo structure unless there is a strong reason to change it

## Configuration and secrets
- Use app configuration, user secrets, or environment variables
- Never commit secrets or fake production credentials
- Clearly document any newly required configuration values
- If a feature depends on a provider-specific setting, isolate that dependency

## Aspire and deployment
- Treat `src/InterviewCoach.AppHost` as the source of truth for distributed composition
- When changing service topology, review references, endpoints, waits, and dependencies
- Mention any impact on local execution and `azd` deployment
- Preserve a good local development experience

## Agent design guidance
When adding or changing agents:
- Define the role and boundaries clearly
- Explain whether the behavior belongs in a single-agent flow or in handoff mode
- Keep prompts narrow and operational
- Avoid hidden assumptions about provider capabilities
- Make tool usage explicit when relevant

## MCP guidance
When adding capabilities:
- Consider whether the capability belongs in an MCP server instead of direct in-process logic
- Prefer MCP for external, reusable, or independently evolvable capabilities
- Keep MCP contracts simple and observable
- Document ports, references, and environment needs from AppHost if changed

## Validation checklist
Before finishing a task:
- Identify impacted projects and files
- Check for provider-specific side effects
- Check AppHost wiring if topology changed
- Check configuration assumptions
- Mention deployment implications if Azure/AppHost files changed
- Suggest tests or validation steps when behavior changed

## Expected response style
For implementation tasks, prefer:
1. Objective
2. Proposed design
3. Files to change
4. Implementation notes
5. Risks/decisions
6. Validation steps

For review tasks, prefer:
1. Executive summary
2. Critical findings
3. Medium findings
4. Suggested improvements
5. Next steps