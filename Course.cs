namespace StudentCourseApi;

public class Course
{
    public int Id { get; set; }
    public string Code { get; set; } = "";
    public string Title { get; set; } = "";
    public int Credits { get; set; }
    public string Instructor { get; set; } = "";
}

// Input model used for POST and PUT. The server assigns the Id.
public class CourseInput
{
    public string? Code { get; set; }
    public string? Title { get; set; }
    public int Credits { get; set; }
    public string? Instructor { get; set; }
}
