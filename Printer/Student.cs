namespace Printer;

public class Student
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public int Grade { get; set; }

    public Student(string name, string lastName, int age, int grade)
    {
        Name = name;
        LastName = lastName;
        Age = age;
        Grade = grade;
    }

    public override string ToString()
    {
        return $"{Name} {LastName}, Age: {Age}, Grade: {Grade}";
    }
}