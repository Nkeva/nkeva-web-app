# File model

/[home](/README.md)/[api](/docs/api/README.md)/[models](/docs/api/README.md#models)/[db](/docs/api/README.md#database-models)/[File](/docs/api/models/db/File.md)

## Description

File model

## Fields

| Name | Type | Required | Default | Description |
| ---- | ---- | -------- | ------- | ----------- |
| __Id__ | `int` | `true` | - | The identifier of the file |
| School | [School](School.md) | `true` | - | File school |
| Name | `string` | `true` | - | File name |
| Size | `long` | `true` | - | File size |
| Owner | [User](User.md) | `true` | - | File owner |
| CreatedAt | `DateTime` | `false` | Current date | File created at |
| UpdatedAt | `DateTime` | `false` | Current date | File updated at |

## Relations

| Name | Type | Description |
| ---- | ---- | ----------- |
| Answers | [`Answer`](Answer.md)[] | File answer |
| Tasks | [`Tasks`](Tasks.md)[] | File task |
| Messages | [`Message`](Message.md)[] | File message |
| Comments | [`Comment`](Comment.md)[] | File comment |
