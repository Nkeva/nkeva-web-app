# MessageModel

/[home](/README.md)/[api](/docs/api/README.md)/[models](/docs/api/README.md#models)/[db](/docs/api/README.md#database-models)/[MessageModel](/docs/api/models/db/Message.md)

## Description

Message model.

## Fields

| Name | Type | Required | Default | Description |
| ---- | ---- | -------- | ------- | ----------- |
| __Id__ | `int` | `true` | - | The identifier of the message |
| Chat | [ChatModel](Chat.md) | `true` | - | Message chat |
| Text | `string` | `true` | - | Message text |
| File | [`FileModel`](File.md) | `false` | `null` | Message file |
| Writer | [UserModel](User.md) | `true` | - | Message writer |
| IsСhanged | `bool` | `false` | `false` | Message is edited |
| IsRead | `bool` | `false` | `false` | Message is read |
| ReplyTo | [MessageModel](Message.md) | `false` | `null` | Message reply to |
| CreatedAt | `DateTime` | `false` | Current date | Message created at |
| UpdatedAt | `DateTime` | `false` | Current date | Message updated at |

## Relations

| Name | Type | Description |
| ---- | ---- | ----------- |
| Replies | [`MessageModel[]`](Message.md) | Message replies |
