# Visit model

/[home](/README.md)/[api](/docs/api/README.md)/[models](/docs/api/README.md#models)/[db](/docs/api/README.md#database-models)/[Visit](/docs/api/models/db/Visit.md)

## Description

Visit model.

## Fields

| Name | Type | Required | Default | Description |
| ---- | ---- | -------- | ------- | ----------- |
| __Id__ | `int` | `true` | - | The identifier of the visit |
| Type | `Present (0) | Absent (10) | Late (20)` | `true` | - | Visit status |
| Points | `int` | `true` | - | Visit points |
| Mark | `int` | `false` | `null` | Visit mark |
| Comment | `string` | `false` | `null` | Visit comment |
| Student | [User](User.md) | `true` | - | Visit student |
| TimetableRecord | [TimetableRecord](TimetableRecord.md) | `true` | - | Visit timetable record |
| CreatedAt | `DateTime` | `false` | Current date | Visit created at |
| UpdatedAt | `DateTime` | `false` | Current date | Visit updated at |
