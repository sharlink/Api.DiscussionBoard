# Api.DiscussionBoard

This API provides endpoints for managing comments and replies in your application.

## Table of Contents

- [Getting Started](#getting-started)
- [Authentication](#authentication)
- [Endpoints](#endpoints)
  - [Create Comment](#create-comment)
  - [Get Comment](#get-comment)
  - [Get Comments](#get-comments)
  - [Update Comment](#update-comment)
  - [Delete Comment](#delete-comment)
  - [Create Reply](#create-reply)  
- [Error Handling](#error-handling)
- [Contributing](#contributing)
- [License](#license)

## Getting Started

To get started with the Comments and Replies API, you'll need to install it in your application:

GET /comments/123 HTTP/1.1
Host: api.example.com
Authorization: API_KEY your-api-key

POST /comments HTTP/1.1
Host: api.example.com
Authorization: API_KEY your-api-key
Content-Type: application/json

{
  "text": "This is a comment."
}

GET /comments/123 HTTP/1.1
Host: api.example.com
Authorization: API_KEY your-api-key

PUT /comments/123 HTTP/1.1
Host: api.example.com
Authorization: API_KEY your-api-key
Content-Type: application/json

{
  "text": "Updated comment."
}

DELETE /comments/123 HTTP/1.1
Host: api.example.com
Authorization: API_KEY your-api-key

POST /comments/123/replies HTTP/1.1
Host: api.example.com
Authorization: API_KEY your-api-key
Content-Type: application/json

{
  "text": "This is a reply."
}

GET /replies/456 HTTP/1.1
Host: api.example.com
Authorization: API_KEY your-api-key

PUT /replies/456 HTTP/1.1
Host: api.example.com
Authorization: API_KEY your-api-key
Content-Type: application/json

{
  "text": "Updated reply."
}

DELETE /replies/456 HTTP/1.1
Host: api.example.com
Authorization: API_KEY your-api-key

## Swagger UI
![image](https://github.com/sharlink/Api.DiscussionBoard/assets/7361263/51bb0367-6eac-4c1f-9dab-9e71e3edb745)


