using StudentCourseApi;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// In-memory seed data. Changes are kept only while the application is running.
var courses = new List<Course>
{
    new() { Id = 1, Code = "CMPS480", Title = "Senior Project", Credits = 3, Instructor = "Prof. Voortman" },
    new() { Id = 2, Code = "CMPS360", Title = "Servey of Programming Languages", Credits = 3, Instructor = "Prof. Seaman" },
    new() { Id = 3, Code = "CMPS361", Title = "Web Application Development", Credits = 3, Instructor = "Prof. Seaman" },
    new() { Id = 4, Code = "CMPS160", Title = "Databases", Credits = 3, Instructor = "Prof. Voortman" },
    new() { Id = 5, Code = "CMPS260", Title = "Data Structures", Credits = 3, Instructor = "Prof. Seaman" }
};

var nextId = courses.Max(course => course.Id) + 1;

app.MapGet("/api/courses", () => Results.Ok(courses));

app.MapGet("/api/courses/{id:int}", (int id) =>
{
    var course = courses.FirstOrDefault(course => course.Id == id);
    return course is null ? Results.NotFound() : Results.Ok(course);
});

app.MapPost("/api/courses", (CourseInput input) =>
{
    if (!IsValid(input))
        return Results.BadRequest(new { message = "Code, title, and instructor are required. Credits must be from 1 to 6." });

    var course = new Course
    {
        Id = nextId++,
        Code = input.Code!.Trim(),
        Title = input.Title!.Trim(),
        Credits = input.Credits,
        Instructor = input.Instructor!.Trim()
    };

    courses.Add(course);
    return Results.Created($"/api/courses/{course.Id}", course);
});

app.MapPut("/api/courses/{id:int}", (int id, CourseInput input) =>
{
    var course = courses.FirstOrDefault(course => course.Id == id);
    if (course is null)
        return Results.NotFound();

    if (!IsValid(input))
        return Results.BadRequest(new { message = "Code, title, and instructor are required. Credits must be from 1 to 6." });

    course.Code = input.Code!.Trim();
    course.Title = input.Title!.Trim();
    course.Credits = input.Credits;
    course.Instructor = input.Instructor!.Trim();

    return Results.Ok(course);
});

app.MapDelete("/api/courses/{id:int}", (int id) =>
{
    var course = courses.FirstOrDefault(course => course.Id == id);
    if (course is null)
        return Results.NotFound();

    courses.Remove(course);
    return Results.NoContent();
});

app.Run();

static bool IsValid(CourseInput input)
{
    return !string.IsNullOrWhiteSpace(input.Code)
        && !string.IsNullOrWhiteSpace(input.Title)
        && !string.IsNullOrWhiteSpace(input.Instructor)
        && input.Credits >= 1
        && input.Credits <= 6;
}
