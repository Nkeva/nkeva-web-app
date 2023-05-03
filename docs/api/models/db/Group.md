# GroupModel

/[home](/README.md)/[api](/docs/api/README.md)/[models](/docs/api/README.md#models)/[db](/docs/api/README.md#database-models)/[GroupModel](/docs/api/models/db/Group.md)

## Description

Group model.

## Fields

| Name | Type | Required | Default | Description |
| ---- | ---- | -------- | ------- | ----------- |
| __Code__ | `string` | `true` | - | Group code |
| School | [SchoolModel](School.md) | `true` | - | Group school |
| IsSubgroup | `bool` | `false` | `false` | Group is subgroup |
| Active | `bool` | `false` | `false` | Group active |
| Curator | [UserModel](User.md) | `true` | - | Group curator |
| CreatedAt | `DateTime` | `false` | Current date | Group created at |
| UpdatedAt | `DateTime` | `false` | Current date | Group updated at |

## Relations

| Name | Type | Description |
| ---- | ---- | ----------- |
| Students | [`UserModel`](User.md)`[]` | Group students |
| Courses | [`CourseModel`](Course.md)`[]` | Group courses |
| Timetable | [`TimetableModel`](Timetable.md)`[]` | Group timetable. Stores only current timetable for group. |
