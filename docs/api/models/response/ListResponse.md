# ListResponse

/[home](/README.md)/[api](/docs/api/README.md)/[models](/docs/api/README.md#models)/[response](/docs/api/README.md#response-models)/[ListResponse](/docs/api/models/response/ListResponse.md)

## Description

List response model. Contains only status code, message and list of items.

## Extends [BaseResponse](/docs/api/models/response/BaseResponse.md)

## Fields

| Name | Type | Required | Default | Description |
| ---- | ---- | -------- | ------- | ----------- |
| success | `bool` | `false` | `true` | Is request successful |
| message | `string` | `false` | `null` | Response message |
| data | `T[]` | `false` | `[]` | Response data |

## Example

```json
{
    "status": 200,
    "message": "OK",
    "data": []
}
```
