# Answer model

/[home](/README.md)/[api](/docs/api/README.md)/[models](/docs/api/README.md#models)/[db](/docs/api/README.md#database-models)/[Answer](/docs/api/models/db/Answer.md)

## Description

Answer model

## Fields

| Name | Type | Required | Default | Description |
| ---- | ---- | -------- | ------- | ----------- |
| __Id__ | `int` | `true` | - | The identifier of the answer |
| School | [School](School.md) | `true` | - | Answer school |
| Text | `string` | `true` | - | Answer text |
| File | [`File`](File.md) | `false` | `null` | Answer file |
| Mark | `int` | `false` | `null` | Answer mark |
| Task | [Tasks](Tasks.md) | `true` | - | Answer task |
| Student | [User](User.md) | `true` | - | Answer student |
| CheckDate | `DateTime` | `false` | `null` | Answer check date |
| CreatedAt | `DateTime` | `false` | Current date | Answer created at |
| UpdatedAt | `DateTime` | `false` | Current date | Answer updated at |

## Relations

| Name | Type | Description |
| ---- | ---- | ----------- |
| Comments | [`Comment[]`](Comment.md) | Answer comments |
