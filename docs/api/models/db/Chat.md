# Chat model

/[home](/README.md)/[api](/docs/api/README.md)/[models](/docs/api/README.md#models)/[db](/docs/api/README.md#database-models)/[Chat](/docs/api/models/db/Chat.md)

## Description

Chat model.

## Fields

| Name | Type | Required | Default | Description |
| ---- | ---- | -------- | ------- | ----------- |
| __Id__ | `int` | `true` | - | The identifier of the chat |
| Name | `string` | `true` | - | Chat name |
| School | [School](School.md) | `true` | - | Chat school |
| Description | `string` | `false` | `null` | Chat description |
| Owner | [User](User.md) | `true` | - | Chat owner |
| CreatedAt | `DateTime` | `false` | Current date | Chat created at |
| UpdatedAt | `DateTime` | `false` | Current date | Chat updated at |
