# TaskType model

/[home](/README.md)/[api](/docs/api/README.md)/[models](/docs/api/README.md#models)/[db](/docs/api/README.md#database-models)/[TaskType](/docs/api/models/db/TaskType.md)

## Description

Task type model.

## Fields

| Name | Type | Required | Default | Description |
| ---- | ---- | -------- | ------- | ----------- |
| __Id__ | `int` | `true` | - | The identifier of the task type |
| Name | `string` | `true` | - | Task type name |

## Relations

| Name | Type | Description |
| ---- | ---- | ----------- |
| Tasks | [`Tasks[]`](Tasks.md) | Tasks with this type |
