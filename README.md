# CMPS360 – Student Course API

## Project 1: Student Grade Calculator

You are going to input your name, major, and chosen class. After that, you choose three different assignments and input those grades. The system prints your average score and tells you whether you passed or failed based on a 70% passing score.

## Project 2: StudentCourseApi

A beginner-friendly ASP.NET Core Minimal API that stores course records in an in-memory list and serves a small HTML page.

### Requirements

- .NET 10 SDK
- PowerShell, Command Prompt, or VS Code terminal

### Create and run the project

```powershell
dotnet new web -n StudentCourseApi --framework net10.0
cd StudentCourseApi
dotnet restore
dotnet run
```

Open the localhost address displayed in your terminal to view the course list.

The webpage uses JavaScript `fetch()` to retrieve courses from `/api/courses`.

**Note:** Courses are stored in memory. Changes reset when the application restarts.

### Course fields

| Field | Type | Description |
|---|---|---|
| Id | Integer | Unique course ID |
| Code | String | Course code |
| Title | String | Course title |
| Credits | Integer | 1–6 credits |
| Instructor | String | Instructor name |

### API endpoints

| Method | Endpoint | Description |
|---|---|---|
| GET | `/api/courses` | Return all courses |
| GET | `/api/courses/{id}` | Return one course |
| POST | `/api/courses` | Add a course |
| PUT | `/api/courses/{id}` | Update a course |
| DELETE | `/api/courses/{id}` | Delete a course |

POST and PUT return HTTP 400 for invalid course information. Missing courses return HTTP 404.

### Test examples

Replace port 5000 with the port shown in your terminal.

Get all courses:

```powershell
curl.exe http://localhost:5000/api/courses
```

Get course 1:

```powershell
curl.exe http://localhost:5000/api/courses/1
```

Add a course:

```powershell
curl.exe -X POST http://localhost:5000/api/courses -H "Content-Type: application/json" -d '{ "code": "ART120", "title": "Introduction to Digital Art", "credits": 3, "instructor": "Prof. Riley Chen" }'
```

Update course 1:

```powershell
curl.exe -X PUT http://localhost:5000/api/courses/1 -H "Content-Type: application/json" -d '{ "code": "CS101", "title": "Programming Fundamentals", "credits": 4, "instructor": "Dr. Morgan Lee" }'
```

Delete course 1:

```powershell
curl.exe -X DELETE http://localhost:5000/api/courses/1
```

Test invalid credits (should return HTTP 400):

```powershell
curl.exe -X POST http://localhost:5000/api/courses -H "Content-Type: application/json" -d '{ "code": "BAD100", "title": "Invalid Credits Example", "credits": 8, "instructor": "Taylor Smith" }'
```

### Screenshots

Save your screenshots in the `screenshots` folder.

1. `course-list.png` – Browser displaying the courses.
2. `get-courses.png` – GET request showing all courses.
3. `post-course.png` – Successful POST request.

#### Course list page

![Course list page](screenshots/course-list.png)

#### GET courses response

![GET courses response](screenshots/get-courses.png)

#### POST course response

![POST course response](screenshots/post-course.png)
