---
# Shared GitHub guard policy.
# Allows issues with the 'community' label to be processed by
# agentic workflows, providing a human-in-the-loop gate for
# community-authored issues to prevent prompt injection.
tools:
  github:
    approval-labels: [community]
---
