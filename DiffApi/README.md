Functionalities of Diff Api:

Sample input/output
End-point	Request	Response
1	GET /v1/diff/1	404 Not Found
2	PUT /v1/diff/1/left
{
  "data": "AAAAAA=="
}
201 Created
3	GET /v1/diff/1	404 Not Found
4	PUT /v1/diff/1/right
{
  "data": "AAAAAA=="
}
201 Created
5	GET /v1/diff/1	200 OK
{
  "diffResultType": "Equals"
}
6	PUT /v1/diff/1/right
{
  "data": "AQABAQ=="
}
201 Created
7	GET /v1/diff/1	200 OK
{
  "diffResultType": "ContentDoNotMatch",
  "diffs": [
    {
      "offset": 0,
      "length": 1
    },
    {
      "offset": 2,
      "length": 2
    }
  ]
}
8	PUT /v1/diff/1/left
{
   "data": "AAA="
}
201 Created
9	GET /v1/diff/1	200 OK
{
  "diffResultType": "SizeDoNotMatch"
}
10	PUT /v1/diff/1/left
{
   "data": null
}
400 Bad Request

diffResultType:
- "0" = "Equals"
- "1" = "SizeDoNotMatch"
- "2" = "ContentDoNotMatch"