# AnswerModel

/[home](/README.md)/[api](/docs/api/README.md)/[models](/docs/api/README.md#models)/[db](/docs/api/README.md#database-models)/[AnswerModel](/docs/api/models/db/Answer.md)

## Description

Answer model

## Fields

| Name | Type | Required | Default | Description |
| ---- | ---- | -------- | ------- | ----------- |
| __Id__ | `int` | `true` | - | The identifier of the answer |
| Text | `string` | `true` | - | Answer text |
| File | [`FileModel`](File.md) | `false` | `null` | Answer file |
| Mark | `int` | `false` | `null` | Answer mark |
| Task | [TaskModel](Task.md) | `true` | - | Answer task |
| Student | [UserModel](User.md) | `true` | - | Answer student |
| CreatedAt | `DateTime` | `false` | Current date | Answer created at |
| UpdatedAt | `DateTime` | `false` | Current date | Answer updated at |
