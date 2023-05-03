# VisitModel

/[home](/README.md)/[api](/docs/api/README.md)/[models](/docs/api/README.md#models)/[db](/docs/api/README.md#database-models)/[VisitModel](/docs/api/models/db/Visit.md)

## Description

Visit model.

## Fields

| Name | Type | Required | Default | Description |
| ---- | ---- | -------- | ------- | ----------- |
| __Id__ | `int` | `true` | - | The identifier of the visit |
| Status | `string` | `true` | - | Visit status |
| Points | `int` | `true` | - | Visit points |
| Mark | `int` | `false` | `null` | Visit mark |
| Comment | `string` | `false` | `null` | Visit comment |
| Student | [UserModel](User.md) | `true` | - | Visit student |
| TimetableRecord | [TimetableRecordModel](TimetableRecord.md) | `true` | - | Visit timetable record |
| CreatedAt | `DateTime` | `false` | Current date | Visit created at |
| UpdatedAt | `DateTime` | `false` | Current date | Visit updated at |
