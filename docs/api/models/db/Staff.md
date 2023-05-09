# Staff model

/[home](/README.md)/[api](/docs/api/README.md)/[models](/docs/api/README.md#models)/[db](/docs/api/README.md#database-models)/[Staff](/docs/api/models/db/Staff.md)

## Description

Staff model.

## Implements [IUser](/nkeva-web-app/Models/Interfaces/IUser.cs) interface

## Fields

| Name | Type | Required | Default | Description |
| ---- | ---- | -------- | ------- | ----------- |
| __Id__ | `int` | `true` | - | The identifier of the staff |
| Email | `string` | `true` | - | Staff email |
| PhoneNumber | `string` | `true` | - | Staff phone number |
| Password | `string` | `true` | - | Staff password |
| FirstName | `string` | `true` | - | Staff first name |
| LastName | `string` | `true` | - | Staff last name |
| MiddleName | `string` | `false` | `null` | Staff middle name |
| Role | [StaffRole](StaffRole.md) | `true` | - | Staff role |
| IsBlocked | `bool` | `false` | `false` | Staff blocked |
| IsOnline | `bool` | `false` | `false` | Staff online |
| CreatedAt | `DateTime` | `false` | Current date | Staff created at |
| UpdatedAt | `DateTime` | `false` | Current date | Staff updated at |
