# BaseResponse

/[home](/README.md)/[api](/docs/api/README.md)/[models](/docs/api/README.md#models)/[response](/docs/api/README.md#response-models)/[BaseResponse](/docs/api/models/response/BaseResponse.md)

## Description

Base response model. Contains only status code and message.

## Is abstract = true

## Fields

| Name | Type | Required | Default | Description |
| ---- | ---- | -------- | ------- | ----------- |
| status | `int` | `true` | `200` | HTTP status code |
| message | `string` | `false` | `"OK"` | Response message |
| data | `object` | `false` | `null` | Response data |

## Example

```json
{
    "status": 200,
    "message": "OK",
    "data": null
}
```
