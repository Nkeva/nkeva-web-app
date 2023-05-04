# User model

/[home](/README.md)/[api](/docs/api/README.md)/[models](/docs/api/README.md#models)/[db](/docs/api/README.md#database-models)/[User](/docs/api/models/db/User.md)

## Description

User model.

## Fields

| Name | Type | Required | Default | Description |
| ---- | ---- | -------- | ------- | ----------- |
| __Id__ | `int` | `true` | - | User id |
| School | [`School`](School.md) | `false` | - | User school |
| FirstName | `string` | `true` | - | User first name |
| LastName | `string` | `true` | - | User last name |
| Surname | `string` | `false` | - | User surname |
| Login | `string` | `true` | - | User login |
| Email | `string` | `false` | `null` | User email |
| Phone | `string` | `false` | `null` | User phone |
| Password | `string` | `true` | - | User password |
| Role | [`SchoolRole`](SchoolRole.md) | `true` | - | User role |
| IsOnline | `bool` | `true` | `false` | User online |
| IsBlocked | `bool` | `true` | `false` | User blocked |
| CreatedAt | `DateTime` | `false` | Current date | User created at |
| UpdatedAt | `DateTime` | `false` | Current date | User updated at |

## Relations

| Name | Type | Description |
| ---- | ---- | ----------- |
| Groups | [`Group[]`](Group.md) | User groups |
| Chats | [`Chat[]`](Chat.md) | User chats |
| ChatMembers | [`ChatMember[]`](ChatMember.md) | User chat members |
| Files | [`File[]`](File.md) | User files |
| Messages | [`Message[]`](Message.md) | User messages |
| TimetableRecords | [`TimetableRecord[]`](TimetableRecord.md) | User timetable records |
| Visits | [`Visit[]`](Visit.md) | User visits |
| Answers | [`Answer[]`](Answer.md) | User answers |
| Comments | [`Comment[]`](Comment.md) | User comments |
| Meetings | [`Meeting[]`](Meeting.md) | User meetings |
