# TaskModel

/[home](/README.md)/[api](/docs/api/README.md)/[models](/docs/api/README.md#models)/[db](/docs/api/README.md#database-models)/[TaskModel](/docs/api/models/db/Task.md)

## Description

Task model

## Fields

| Name | Type | Required | Default | Description |
| ---- | ---- | -------- | ------- | ----------- |
| __Id__ | `int` | `true` | - | The identifier of the task |
| School | [SchoolModel](School.md) | `true` | - | Task school |
| Course | [CourseModel](Course.md) | `true` | - | Task course |
| Group | [GroupModel](Group.md) | `true` | - | Task group |
| Text | `string` | `true` | - | Task text |
| File | [`FileModel`](File.md) | `false` | `null` | Task file |
| DueDate | `DateTime` | `false` | `null` | Task due date |
| Active | `bool` | `true` | `false` | Task status |
| TimetableRecord | [TimetableRecordModel](TimetableRecord.md) | `true` | - | Task timetable record |
| CreatedAt | `DateTime` | `false` | Current date | Task created at |
| UpdatedAt | `DateTime` | `false` | Current date | Task updated at |

## Relations

| Name | Type | Description |
| ---- | ---- | ----------- |
| Answers | [`AnswerModel`](Answer.md)`[]` | Task answers |
