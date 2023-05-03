# UserModel

/[home](/README.md)/[api](/docs/api/README.md)/[models](/docs/api/README.md#models)/[db](/docs/api/README.md#database-models)/[UserModel](/docs/api/models/db/User.md)

## Description

User model.

## Fields

| Name | Type | Required | Default | Description |
| ---- | ---- | -------- | ------- | ----------- |
| __Id__ | `int` | `true` | - | User id |
| FirstName | `string` | `true` | - | User first name |
| LastName | `string` | `true` | - | User last name |
| Surname | `string` | `true` | - | User surname |
| Login | `string` | `true` | - | User login |
| Email | `string` | `true` | `null` | User email |
| Password | `string` | `true` | - | User password |
| Role | `string` | `true` | - | User role |
| Active | `bool` | `true` | `false` | User active |
| CreatedAt | `DateTime` | `false` | Current date | User created at |
| UpdatedAt | `DateTime` | `false` | Current date | User updated at |

## Relations

| Name | Type | Description |
| ---- | ---- | ----------- |
| Answers | [`AnswerModel`](Answer.md)`[]` | User answers |
| Visits | [`VisitModel`](Visit.md)`[]` | User visits |
| Courses | [`CourseModel`](Course.md)`[]` | User courses |
| Groups | [`GroupModel`](Group.md)`[]` | User groups |
