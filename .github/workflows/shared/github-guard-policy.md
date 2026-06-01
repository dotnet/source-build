---
# Shared GitHub guard policy.
# Requires 'approved' min-integrity for GitHub MCP server tools,
# with 'community' as an approval label. This means community-authored
# issues must have the 'community' label (added by a maintainer) before
# the agent can process them, preventing prompt injection.
tools:
  github:
    min-integrity: approved
    approval-labels: [community]
---
