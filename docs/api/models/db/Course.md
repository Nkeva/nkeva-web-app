# CourseModel

/[home](/README.md)/[api](/docs/api/README.md)/[models](/docs/api/README.md#models)/[db](/docs/api/README.md#database-models)/[CourseModel](/docs/api/models/db/Course.md)

## Description

Course model.

## Fields

| Name | Type | Required | Default | Description |
| ---- | ---- | -------- | ------- | ----------- |
| __Id__ | `int` | `true` | - | The identifier of the course |
| School | [SchoolModel](School.md) | `true` | - | Course school |
| Name | `string` | `true` | - | Course name |
| Description | `string` | `true` | - | Course description |
| CreatedAt | `DateTime` | `false` | Current date | Course created at |
| UpdatedAt | `DateTime` | `false` | Current date | Course updated at |

## Relations

| Name | Type | Description |
| ---- | ---- | ----------- |
| Tasks | [`TaskModel[]`](Task.md) | Course tasks |
| Teachers | [`UserModel[]`](User.md) | Course teachers |
| Students | [`UserModel[]`](User.md) | Course students |
| Groups | [`GroupModel[]`](Group.md) | Course groups |
