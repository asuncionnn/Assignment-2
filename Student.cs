public class Student
{
    public int studentID { get; set; }
    public string name { get; set; }
    public string course { get; set; }
    public int grade { get; set; }

    public Student(int studentID, string name, string course, int grade)
    {
        this.studentID = studentID;
        this.name = name;
        this.course = course;
        this.grade = grade;
    }
}