---
description: >
  When an issue is opened, analyze it and post a structured
  triage comment using the triage skill.

on:
  issues:
    types: [opened]
  skip-bots: [github-actions, copilot]

permissions:
  contents: read
  issues: read

safe-outputs:
  add-comment:

imports:
  - shared/pat_pool.md

engine:
  id: copilot
  env:
    COPILOT_GITHUB_TOKEN: |
      ${{ case(
        needs.pat_pool.outputs.pat_number == '0', secrets.COPILOT_PAT_0,
        needs.pat_pool.outputs.pat_number == '1', secrets.COPILOT_PAT_1,
        needs.pat_pool.outputs.pat_number == '2', secrets.COPILOT_PAT_2,
        needs.pat_pool.outputs.pat_number == '3', secrets.COPILOT_PAT_3,
        needs.pat_pool.outputs.pat_number == '4', secrets.COPILOT_PAT_4,
        needs.pat_pool.outputs.pat_number == '5', secrets.COPILOT_PAT_5,
        needs.pat_pool.outputs.pat_number == '6', secrets.COPILOT_PAT_6,
        needs.pat_pool.outputs.pat_number == '7', secrets.COPILOT_PAT_7,
        needs.pat_pool.outputs.pat_number == '8', secrets.COPILOT_PAT_8,
        needs.pat_pool.outputs.pat_number == '9', secrets.COPILOT_PAT_9,
        secrets.COPILOT_GITHUB_TOKEN)
      }}
---

You are an automated triage agent for this repository.

## Your Task

When this workflow is triggered by a new issue, triage it using the `triage` skill.

## Important Overrides for Automated Mode

Since you are running as an automated workflow (not interactively with a human):

- **Always post the triage comment.** Do not ask for confirmation — this is an
  automated workflow and there is no human to confirm. Use the `add-comment`
  safe output to post the comment.
- **Never apply labels or milestones.** Only post the triage comment. A human
  will decide whether to apply the recommended labels and milestone.
- **Never close, lock, or assign the issue.**
