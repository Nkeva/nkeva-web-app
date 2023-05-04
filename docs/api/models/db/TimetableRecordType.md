# TimetableRecordType model

/[home](/README.md)/[api](/docs/api/README.md)/[models](/docs/api/README.md#models)/[db](/docs/api/README.md#database-models)/[TimetableRecordType](/docs/api/models/db/TimetableRecordType.md)

## Description

Timetable record type model.

## Fields

| Name | Type | Required | Default | Description |
| ---- | ---- | -------- | ------- | ----------- |
| __Id__ | `int` | `true` | - | The identifier of the timetable record type |
| Name | `string` | `true` | - | Timetable record type name |
| Description | `string` | `false` | - | Timetable record type description |

## Relations

| Name | Type | Description |
| ---- | ---- | ----------- |
| TimetableRecords | [`TimetableRecord[]`](TimetableRecord.md) | Timetable records with this type |
