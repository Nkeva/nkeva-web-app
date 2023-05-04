# ChatMember model

/[home](/README.md)/[api](/docs/api/README.md)/[models](/docs/api/README.md#models)/[db](/docs/api/README.md#database-models)/[ChatMember](/docs/api/models/db/ChatMember.md)

## Description

Chat member model.

## Fields

| Name | Type | Required | Default | Description |
| ---- | ---- | -------- | ------- | ----------- |
| Chat | [Chat](Chat.md) | `true` | - | Chat member chat |
| User | [User](User.md) | `true` | - | Chat member user |
| CreatedAt | `DateTime` | `false` | Current date | Chat member created at |
