
<h1 align="center" style="font-weight: bold;">Simply Books 💻</h1>

<p align="center">
<a href="#tech">Technologies</a>
<a href="#started">Getting Started</a>
<a href="#routes">API Endpoints</a>
<a href="#colab">Collaborators</a>
<a href="#contribute">Contribute</a> 
</p>


<p align="center">Simply Books i a app that allows users to save  books and authors. It is run by an API database.</p>


<p align="center">
<a href="https://github.com/GraceRenewed/SimplyBooksBEnd.git">📱 Visit this Project</a>
</p>

<h2 id="technologies">💻 Technologies</h2>

- C#
- .NET
- PgAdmin
- Postman
- Swagger
- Visual Studio

<h2 id="started">🚀 Getting started</h2>

- Click the "Visit This Project" Link above
- In the green "Code" box, click the down arrow
- Select "HTTPS" 
- Copy the link to your clipboard
- In your terminal type:
- git clone "https address" without quotes, press enter
- type: cd SimplyBooksBEnd, press enter
- type: code .     , press enter
- You should be able to view the project
- In your project directory run: 
- dotnet ef database update, press enter
- To Install Entity Framework Tools:
- dotnet tool install --global dotnet-ef, press enter


<h3>Prerequisites</h3>

Here you list all prerequisites necessary for running your project.

- [.NET SDK](https://dotnet.microsoft.com/en-us/download)
- [Visual Studio](https://visualstudio.microsoft.com/)
- or [Visual Studio Code](https://code.visualstudio.com/)
- [PostgreSQL](https://www.postgresql.org/download/)

<h3>Cloning</h3>

How to clone your project

```bash
git clone https://github.com/GraceRenewed/SimplyBooksBEnd.git
```

<h3>Config .env variables</h2>

Use the `.env.example` as reference to create your configuration file `.env` with your Credentials

```yaml
NEXT_PUBLIC_FIREBASE_API_KEY=""
NEXT_PUBLIC_FIREBASE_AUTH_DOMAIN=""
NEXT_PUBLIC_FIREBASE_DATABASE_URL=""
NEXT_PUBLIC_FIREBASE_PROJECT_ID=""
NEXT_PUBLIC_FIREBASE_STORAGE_BUCKET=""
NEXT_PUBLIC_FIREBASE_APP_ID=""
```

<h3>Starting</h3>

How to start your project

```bash
cd SimplyBooksBEnd
dotnet watch run
```

<h2 id="routes">📍 API Endpoints</h2>

Here are some of the API endpoints, to view all of them please refer to the postman documentation.
[Postman](https://documenter.getpostman.com/view/36650801/2sB2cVdLzX)
​
| route               | description                                          
|----------------------|-----------------------------------------------------
| <kbd>GET /books</kbd>     | retrieves all books [response details](#get-auth-detail)
| <kbd>POST /books</kbd>     | allows you to add a book [request details](#post-auth-detail)
| <kbd>GET /author/{firebaseKey}</kbd>     | retrieves a single author [response details](#get-auth-detail)
| <kbd>POST /authors</kbd>     | allows you to create an author [request details](#post-auth-detail)


<h3 id="get-auth-detail">GET /books</h3>

**RESPONSE**
```json
  {
    "firebaseKey": "book1",
    "userUid": "user1",
    "user": null,
    "authorFirebaseKey": "author1",
    "author": {
      "firebaseKey": "author1",
      "userUid": "user1",
      "user": null,
      "first_name": "Max",
      "last_name": "Lucado",
      "email": "maxlucado@example.com",
      "favorite": true,
      "books": [
        null
      ]
    },
    "title": "Grace for the Moment",
    "description": "A devotional book filled with insights and reflections for daily living.",
    "image": "image_url1",
    "price": 12.99,
    "sale": true
  },
```

<h3 id="post-auth-detail">POST /books</h3>

**REQUEST**
```json
{
  "firebaseKey": "book15",
  "UserUid": "user2",
  "AuthorFirebaseKey": "author3",
  "title": "Test1",
  "description": "fiction",
  "image": "http://121345",
  "price": 20.00,
  "sale": false
}
```

**RESPONSE**
```json
{
  "firebaseKey": "book15",
  "userUid": "user2",
  "user": null,
  "authorFirebaseKey": "author3",
  "author": null,
  "title": "Test1",
  "description": "fiction",
  "image": "http://121345",
  "price": 20,
  "sale": false
}
```

<h3 id="get-auth-detail">GET //authors/{firebaseKey}</h3>

**RESPONSE**
```json
 {
    "firebaseKey": "author1",
    "userUid": "user1",
    "user": null,
    "first_name": "Max",
    "last_name": "Lucado",
    "email": "maxlucado@example.com",
    "favorite": true,
    "books": [
      {
        "firebaseKey": "book1",
        "userUid": "user1",
        "user": null,
        "authorFirebaseKey": "author1",
        "author": null,
        "title": "Grace for the Moment",
        "description": "A devotional book filled with insights and reflections for daily living.",
        "image": "image_url1",
        "price": 12.99,
        "sale": true
      }
    ]
  }
```

<h3 id="post-auth-detail">POST /authors</h3>

**REQUEST**
```json
{
  "firebaseKey": "author8",
  "userUid": "user1",
  "first_name": "Test1",
  "last_name": "Test2",
  "email": "test@email.com",
  "favorite": false
}
```

**RESPONSE**
```json
{
  "firebaseKey": "author8",
  "userUid": "user1",
  "user": null,
  "first_name": "Test1",
  "last_name": "Test2",
  "email": "test@email.com",
  "favorite": false,
  "books": []
}
```

<h2 id="colab">🤝 Collaborators</h2>

<p>Special thank you for my classmates in Cohort 28 for all your support!</p>
<table>
<tr>

<td align="center">
<a href="https://github.com/GraceRenewed">
<img src="https://avatars.githubusercontent.com/u/171828567?v=4" width="100px;" alt="Christina Vieau Profile Picture"/><br>
<sub>
<b>Christina Vieau</b>
</sub>
</a>
</td>

</tr>
</table>

<h2 id="contribute">📫 Contribute</h2>

If you would like to contribute to this project. Make sure you have all the required Prerequisites and follow the Getting Started directions, both are above.

1. `git clone https://github.com/GraceRenewed/SimplyBooksBEnd.git`
2. `git checkout -b feature/NAME`
3. Follow commit patterns
4. Open a Pull Request explaining the problem solved or feature made, if exists, append screenshot of visual modifications and wait for the review!

<h3>Documentations that might help</h3>

[📝 How to create a Pull Request](https://www.atlassian.com/br/git/tutorials/making-a-pull-request)

[💾 Commit pattern](https://gist.github.com/joshbuchea/6f47e86d2510bce28f8e7f42ae84c716)
