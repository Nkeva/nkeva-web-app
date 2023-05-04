# TimetableRecord model

/[home](/README.md)/[api](/docs/api/README.md)/[models](/docs/api/README.md#models)/[db](/docs/api/README.md#database-models)/[TimetableRecord](/docs/api/models/db/TimetableRecord.md)

## Description

Timetable record model.

## Fields

| Name | Type | Required | Default | Description |
| ---- | ---- | -------- | ------- | ----------- |
| __Id__ | `int` | `true` | - | The identifier of the timetable record |
| School | [School](School.md) | `true` | - | The school associated with this timetable record |
| StartAt | `DateTime` | `true` | - | The date and time of the timetable record |
| Active | `bool` | `true` | `false` | The status of the timetable record |
| Course | [Course](Course.md) | `true` | - | The course associated with this timetable record |
| Group | [Group](Group.md) | `true` | - | The group assigned to this timetable record |
| Teacher | [User](User.md) | `true` | - | Teacher who conducts the lesson |
| Room | `string` | `true` | - | Some information about the room |
| Type | [`TimetableRecordType`](TimetableRecordType.md) | `true` | - | Timetable record type |
| MeetingId | `string` | `false` | `null` | Ref to meeting table |
| ExtraPoints | `int` | `false` | `5` | These points can be awarded to students for being active in class. Points are limited. |
| Description | `string` | `false` | `null` | Timetable record description |
| CreatedAt | `DateTime` | `false` | Current date | Timetable record created at |
| UpdatedAt | `DateTime` | `false` | Current date | Timetable record updated at |

## Relations

| Name | Type | Description |
| ---- | ---- | ----------- |
| Visits | [`Visit`](Visit.md)`[]` | Timetable record visits |
| Tasks | [`Tasks`](Tasks.md)`[]` | Timetable record tasks |
