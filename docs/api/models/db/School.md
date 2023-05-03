# SchoolModel

/[home](/README.md)/[api](/docs/api/README.md)/[models](/docs/api/README.md#models)/[db](/docs/api/README.md#database-models)/[SchoolModel](/docs/api/models/db/School.md)

## Description

School model

## Fields

| Name | Type | Required | Default | Description |
| ---- | ---- | -------- | ------- | ----------- |
| __Id__ | `int` | `true` | - | The identifier of the school |
| Name | `string` | `true` | - | School name |
| Address | `string` | `true` | - | School address |
| City | `string` | `true` | - | School city |
| Country | `string` | `true` | - | School country |
| ZipCode | `string` | `true` | - | School zip code |
| Phone | `string` | `true` | - | School phone |
| Email | `string` | `true` | - | School email |
| Active | `bool` | `false` | `true` | School active |
| CreatedAt | `DateTime` | `false` | Current date | School created at |
| UpdatedAt | `DateTime` | `false` | Current date | School updated at |

## Relations

| Name | Type | Description |
| ---- | ---- | ----------- |
| Users | [`UserModel[]`](User.md) | School users |
| Courses | [`CourseModel[]`](Course.md) | School courses |
| Groups | [`GroupModel[]`](Group.md) | School groups |
| Tasks | [`TaskModel[]`](Task.md) | School tasks |
| Files | [`FileModel[]`](File.md) | School files |
| Chats | [`ChatModel[]`](Chat.md) | School chats |
| TimetableRecords | [`TimetableRecordModel[]`](TimetableRecord.md) | School timetable records |
