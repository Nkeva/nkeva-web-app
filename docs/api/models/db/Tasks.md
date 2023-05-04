# Tasks model

/[home](/README.md)/[api](/docs/api/README.md)/[models](/docs/api/README.md#models)/[db](/docs/api/README.md#database-models)/[Tasks](/docs/api/models/db/Tasks.md)

## Description

Tasks model

## Fields

| Name | Type | Required | Default | Description |
| ---- | ---- | -------- | ------- | ----------- |
| __Id__ | `int` | `true` | - | The identifier of the task |
| School | [School](School.md) | `true` | - | Task school |
| Course | [Course](Course.md) | `true` | - | Task course |
| Group | [Group](Group.md) | `true` | - | Task group |
| TaskType | [TaskType](TaskType.md) | `true` | - | Task type |
| Text | `string` | `true` | - | Task text |
| File | [`File`](File.md) | `false` | `null` | Task file |
| DueDate | `DateTime` | `false` | `null` | Task due date |
| Active | `bool` | `true` | `false` | Task status |
| TimetableRecord | [TimetableRecord](TimetableRecord.md) | `true` | - | Task timetable record |
| CreatedAt | `DateTime` | `false` | Current date | Task created at |
| UpdatedAt | `DateTime` | `false` | Current date | Task updated at |

## Relations

| Name | Type | Description |
| ---- | ---- | ----------- |
| Answers | [`Answer`](Answer.md)`[]` | Task answers |
