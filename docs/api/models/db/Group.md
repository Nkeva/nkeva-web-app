# Group model

/[home](/README.md)/[api](/docs/api/README.md)/[models](/docs/api/README.md#models)/[db](/docs/api/README.md#database-models)/[Group](/docs/api/models/db/Group.md)

## Description

Group model.

## Fields

| Name | Type | Required | Default | Description |
| ---- | ---- | -------- | ------- | ----------- |
| __Code__ | `string` | `true` | - | Group code |
| School | [School](School.md) | `true` | - | Group school |
| IsSubGroup | `bool` | `false` | `false` | Group is subgroup |
| Active | `bool` | `false` | `false` | Group active |
| CreatedAt | `DateTime` | `false` | Current date | Group created at |
| UpdatedAt | `DateTime` | `false` | Current date | Group updated at |

## Relations

| Name | Type | Description |
| ---- | ---- | ----------- |
| TimetableRecords | [`TimetableRecord[]`](TimetableRecord.md) | Group timetable records |
| Courses | [`Course[]`](Course.md) | Group courses |
| Tasks | [`Tasks[]`](Tasks.md) | Group tasks |
| Users | [`User[]`](User.md) | Group users |
