# TimetableRecordModel

/[home](/README.md)/[api](/docs/api/README.md)/[models](/docs/api/README.md#models)/[db](/docs/api/README.md#database-models)/[TimetableRecordModel](/docs/api/models/db/TimetableRecord.md)

## Description

Timetable record model.

## Fields

| Name | Type | Required | Default | Description |
| ---- | ---- | -------- | ------- | ----------- |
| __Id__ | `int` | `true` | - | The identifier of the timetable record |
| School | [SchoolModel](School.md) | `true` | - | The school associated with this timetable record |
| Date | `DateTime` | `true` | - | The date of the timetable record |
| Time | `DateTime` | `true` | - | The time of the timetable record |
| Active | `bool` | `true` | `false` | The status of the timetable record |
| Course | [CourseModel](Course.md) | `true` | - | The course associated with this timetable record |
| Group | [GroupModel](Group.md) | `true` | - | The group assigned to this timetable record |
| Teacher | [UserModel](User.md) | `true` | - | Teacher who conducts the lesson |
| Room | `string` | `true` | - | Some information about the room |
| Type | `string` | `true` | - | Record type |
| MeetingId | `string` | `false` | `null` | Ref to meeting table |
| ExtraPoints | `int` | `false` | `5` | These points can be awarded to students for being active in class. Points are limited. |
| CreatedAt | `DateTime` | `false` | Current date | Timetable record created at |
| UpdatedAt | `DateTime` | `false` | Current date | Timetable record updated at |

## Relations

| Name | Type | Description |
| ---- | ---- | ----------- |
| Visits | [`VisitModel`](Visit.md)`[]` | Timetable record visits |
| Tasks | [`TaskModel`](Task.md)`[]` | Timetable record tasks |
| Answers | [`AnswerModel`](Answer.md)`[]` | Timetable record answers |
