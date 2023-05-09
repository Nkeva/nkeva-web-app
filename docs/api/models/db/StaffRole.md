# StaffRole model

/[home](/README.md)/[api](/docs/api/README.md)/[models](/docs/api/README.md#models)/[db](/docs/api/README.md#database-models)/[StaffRole](/docs/api/models/db/StaffRole.md)

## Description

Staff role model.

## Implements [IRole](/nkeva-web-app/Models/Interfaces/IRole.cs)

## Fields

| Name | Type | Required | Default | Description |
| ---- | ---- | -------- | ------- | ----------- |
| __Id__ | `int` | `true` | - | The identifier of the staff role |
| Name | `string` | `true` | - | Staff role name |
| Description | `string` | `false` | - | Staff role description |

## Relations

| Name | Type | Description |
| ---- | ---- | ----------- |
| Staff | [`Staff[]`](Staff.md) | Staff with this role |
