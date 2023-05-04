# Message model

/[home](/README.md)/[api](/docs/api/README.md)/[models](/docs/api/README.md#models)/[db](/docs/api/README.md#database-models)/[Message](/docs/api/models/db/Message.md)

## Description

Message model.

## Fields

| Name | Type | Required | Default | Description |
| ---- | ---- | -------- | ------- | ----------- |
| __Id__ | `int` | `true` | - | The identifier of the message |
| Chat | [Chat](Chat.md) | `true` | - | Message chat |
| Text | `string` | `true` | - | Message text |
| File | [`File`](File.md) | `false` | `null` | Message file |
| Sender | [User](User.md) | `true` | - | Message sender |
| IsChanged | `bool` | `false` | `false` | Message is edited |
| IsRead | `bool` | `false` | `false` | Message is read |
| ReplyTo | [Message](Message.md) | `false` | `null` | Message reply to |
| CreatedAt | `DateTime` | `false` | Current date | Message created at |
| UpdatedAt | `DateTime` | `false` | Current date | Message updated at |

## Relations

| Name | Type | Description |
| ---- | ---- | ----------- |
| Replies | [`Message[]`](Message.md) | Message replies |
