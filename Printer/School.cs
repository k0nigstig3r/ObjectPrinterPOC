namespace Printer;


public class School
{
    public string Name { get; set; }
    public Address SchoolAddress { get; set; }
    public List<Student> Students { get; set; }

    public School(string name, Address schoolAddress, List<Student> students)
    {
        Name = name;
        SchoolAddress = schoolAddress;
        Students = students;
    }
}