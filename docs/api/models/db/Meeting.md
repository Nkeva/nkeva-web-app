# Meeting model

/[home](/README.md)/[api](/docs/api/README.md)/[models](/docs/api/README.md#models)/[db](/docs/api/README.md#database-models)/[Meeting](/docs/api/models/db/Meeting.md)

## Description

Meeting model.

## Fields

| Name | Type | Required | Default | Description |
| ---- | ---- | -------- | ------- | ----------- |
| __Id__ | `int` | `true` | - | The identifier of the meeting |
| Creator | [User](User.md) | `true` | - | Meeting creator |
| Code | `string` | `true` | - | Meeting code |
| CreatedAt | `DateTime` | `false` | Current date | Meeting created at |

## Relations

| Name | Type | Description |
| ---- | ---- | ----------- |
| TimeTableRecord | [`TimetableRecord`](TimetableRecord.md)`[]` | Meeting timetable record |
