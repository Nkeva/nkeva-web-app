# Comment model

/[home](/README.md)/[api](/docs/api/README.md)/[models](/docs/api/README.md#models)/[db](/docs/api/README.md#database-models)/[Comment](/docs/api/models/db/Comment.md)

## Description

Comment model.

## Fields

| Name | Type | Required | Default | Description |
| ---- | ---- | -------- | ------- | ----------- |
| __Id__ | `int` | `true` | - | The identifier of the comment |
| Text | `string` | `true` | - | Comment text |
| File | [`File`](File.md) | `false` | `null` | Comment file |
| Answer | [Answer](Answer.md) | `true` | - | Comment answer |
| Writer | [User](User.md) | `true` | - | Comment writer |
| CreatedAt | `DateTime` | `false` | Current date | Comment created at |
| UpdatedAt | `DateTime` | `false` | Current date | Comment updated at |
