# FileModel

/[home](/README.md)/[api](/docs/api/README.md)/[models](/docs/api/README.md#models)/[db](/docs/api/README.md#database-models)/[FileModel](/docs/api/models/db/File.md)

## Description

File model

## Fields

| Name | Type | Required | Default | Description |
| ---- | ---- | -------- | ------- | ----------- |
| __Id__ | `int` | `true` | - | The identifier of the file |
| School | [SchoolModel](School.md) | `true` | - | File school |
| Name | `string` | `true` | - | File name |
| Extension | `string` | `true` | - | File extension |
| Size | `int` | `true` | - | File size |
| Owner | [UserModel](User.md) | `true` | - | File owner |
| CreatedAt | `DateTime` | `false` | Current date | File created at |
| UpdatedAt | `DateTime` | `false` | Current date | File updated at |
