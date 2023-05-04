# Course model

/[home](/README.md)/[api](/docs/api/README.md)/[models](/docs/api/README.md#models)/[db](/docs/api/README.md#database-models)/[Course](/docs/api/models/db/Course.md)

## Description

Course model.

## Fields

| Name | Type | Required | Default | Description |
| ---- | ---- | -------- | ------- | ----------- |
| __Id__ | `int` | `true` | - | The identifier of the course |
| School | [School](School.md) | `true` | - | Course school |
| Name | `string` | `true` | - | Course name |
| Description | `string` | `true` | - | Course description |
| CreatedAt | `DateTime` | `false` | Current date | Course created at |
| UpdatedAt | `DateTime` | `false` | Current date | Course updated at |

## Relations

| Name | Type | Description |
| ---- | ---- | ----------- |
| Tasks | [`Tasks[]`](Tasks.md) | Course tasks |
| Groups | [`Group[]`](Group.md) | Course groups |
| TimetableRecords | [`TimetableRecord[]`](TimetableRecord.md) | Course timetable records |
