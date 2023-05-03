# StaffModel

/[home](/README.md)/[api](/docs/api/README.md)/[models](/docs/api/README.md#models)/[db](/docs/api/README.md#database-models)/[StaffModel](/docs/api/models/db/Staff.md)

## Description

Staff model.

## Fields

| Name | Type | Required | Default | Description |
| ---- | ---- | -------- | ------- | ----------- |
| __Id__ | `int` | `true` | - | The identifier of the staff |
| Email | `string` | `true` | - | Staff email |
| Password | `string` | `true` | - | Staff password |
| FirstName | `string` | `true` | - | Staff first name |
| LastName | `string` | `true` | - | Staff last name |
| MiddleName | `string` | `false` | `null` | Staff middle name |
| StaffRole | [StaffRoleModel](StaffRole.md) | `true` | - | Staff role |
| IsActivated | `bool` | `true` | `false` | Staff activated |
| IsOnline | `bool` | `true` | `false` | Staff online |
| CreatedAt | `DateTime` | `false` | Current date | Staff created at |
| UpdatedAt | `DateTime` | `false` | Current date | Staff updated at |
