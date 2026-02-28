# GitHub Copilot setup

For local development with GitHub Copilot.

## When to use GitHub Copilot

Good for leveraging GitHub Copilot CLI capability into your agentic application.

Use it with extreme care for production, sensitive data, or anything that needs reliable availability. Consider using [Foundry](MICROSOFT-FOUNDRY.md) or [Azure OpenAI](AZURE-OPENAI.md).

[Compare providers](README.md)

## What is GitHub Copilot?

[GitHub Copilot](https://docs.github.com/copilot/get-started/what-is-github-copilot) is an AI coding assistant that helps you write code faster and with less effort. Then, you can focus more energy on problem solving and collaboration.

## Prerequisites

- GitHub account ([Sign up free](https://github.com/signup))

## Step 1: Get a GitHub Personal Access Token

You need a PAT with the "Copilot Request ➡️ ReadOnly" permission.

### Create PAT

1. Follow this document, [Creating a fine-grained personal access token](https://docs.github.com/authentication/keeping-your-account-and-data-secure/managing-your-personal-access-tokens#creating-a-fine-grained-personal-access-token)

## Step 2: Store token

```bash
# Store GitHub token
dotnet user-secrets --file ./apphost.cs set GitHubCopilot:Token "{{GITHUB_PAT}}"
```

## Step 3: Run the app

```bash
# Using file-based Aspire (recommended)
aspire run --file ./apphost.cs -- --provider GitHubCopilot --mode CopilotHandOff

# Using project-based Aspire
aspire run --project ./src/InterviewCoach.AppHost -- --provider GitHubCopilot --mode CopilotHandOff
```

## Rate limits

GitHub Copilot has usage limits. See [GitHub Copilot plans](https://docs.github.com/copilot/concepts/billing/individual-plans) for details.

## Next steps

- [Learning objectives](../LEARNING-OBJECTIVES.md)
- [Architecture overview](../ARCHITECTURE.md)
- [Tutorials](../TUTORIALS.md)
- [FAQ](../FAQ.md)

## Resources

- [GitHub Copilot Documentation](https://docs.github.com/copilot)
- [Personal Access Tokens Guide](https://docs.github.com/authentication/keeping-your-account-and-data-secure/managing-your-personal-access-tokens)
- [GitHub Copilot Terms of Service](https://docs.github.com/site-policy/github-terms/github-terms-for-additional-products-and-features#github-copilot)
