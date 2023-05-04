# SchoolRole model

/[home](/README.md)/[api](/docs/api/README.md)/[models](/docs/api/README.md#models)/[db](/docs/api/README.md#database-models)/[SchoolRole](/docs/api/models/db/SchoolRole.md)

## Description

SchoolRole model.

## Fields

| Name | Type | Required | Default | Description |
| ---- | ---- | -------- | ------- | ----------- |
| __Id__ | `int` | `true` | - | Role id |
| Name | `string` | `true` | - | Role name |
| Description | `string` | `false` | - | Role description |

## Relations

| Name | Type | Description |
| ---- | ---- | ----------- |
| Users | [`User[]`](User.md) | Users with this role |
