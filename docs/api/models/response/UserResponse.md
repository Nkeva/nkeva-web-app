# UserResponse

/[home](/README.md)/[api](/docs/api/README.md)/[models](/docs/api/README.md#models)/[response](/docs/api/README.md#response-models)/[UserResponse](/docs/api/models/response/UserResponse.md)

## Description

User response model.

## Extends [BaseResponse](/docs/api/models/response/BaseResponse.md)

## Fields

| Name | Type | Required | Default | Description |
| ---- | ---- | -------- | ------- | ----------- |
| success | `bool` | `false` | `true` | Is request successful |
| message | `string` | `false` | `null` | Response message |
| data | [User](/docs/api/models/BaseResponse.md#user) | `false` | `null` | Response data |

## User

| Name | Type | Required | Default | Description |
| ---- | ---- | -------- | ------- | ----------- |
| id | `int` | `true` | - | User id |
| login | `string` | `true` | - | User login |
| role | `string` | `true` | - | User role |
| schoolId | `int` | `true` | - | User school id |
| firstName | `string` | `true` | - | User first name |
| lastName | `string` | `true` | - | User last name |
| surname | `string` | `false` | `null` | User surname |
| email | `string` | `false` | `null` | User email |
| phone | `string` | `false` | `null` | User phone |
| isOnline | `bool` | `false` | `false` | Is user online |
| isBlocked | `bool` | `false` | `false` | Is user blocked |
| createdAt | `string` | `false` | `Current date` | User created at |
| updatedAt | `string` | `false` | `Current date` | User updated at |
