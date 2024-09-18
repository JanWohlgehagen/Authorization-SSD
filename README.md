
# The setup

Each en-point in the articles API is authorized using a JWT Token, which can be fetched using the JWT service.
## Running the code

After cloning the repository, navigate to the Auth-SSD folder in you command line type.


```
docker compose up -d
```
This runs the JWT Service and the Article API in docker on localhost port 3001 and 3000 respectively.



## Testing the end-points

In the Auth-SSD folder you will find a file called postman_collection.json which can be imported into postman.

To test the article end-point you will need to set up a bearer token, which are the tokens fetched in the tokens end points collection in postman. You should hit the appropriate token end point which will respond with something like this.

```
{
    "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJ1c2VyX2lkXzEyMyIsImp0aSI6IjVkYTUyZjZmLTNmNjktNDFjOS04MzVhLWRjZDViNWFmMTFjOSIsInBlcm1pc3Npb25zIjpbIkRlbGV0ZUFydGljbGUiLCJFZGl0QXJ0aWNsZSIsIkVkaXRDb21tZW50IiwiRGVsZXRlQ29tbWVudCIsIkVkaXRBcnRpY2xlIiwiQ3JlYXRlQXJ0aWNsZSIsIkNyZWF0ZUNvbW1lbnQiLCJSZWFkQXJ0aWNsZSJdLCJleHAiOjE3MjY2NTY4MjIsImlzcyI6Imp3dC1pc3N1ZS5jb20iLCJhdWQiOiJzZWN1cmUtd2ViLWFwaS5jb20ifQ.hgTvFEa5sES0TpVPcMa_tg-WpyXA3yARSsYpwk4lcUw",
    "expiration": "2024-09-18T10:53:42.4068811Z"
}
```

The value of the token is what is required for the article end-points. To use the token when calling the article end points, go to a specific request and go to the "Authorization" menu item below the request URL. In the "Auth Type" drop-down choose "Bearer token" and insert the token.


