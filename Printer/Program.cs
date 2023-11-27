using System.Collections;
using System.Reflection;
using System.Text;
using Printer;

public  class Program
{
    public static void Main(string[] args)
    {
        IObjectRepresentationBuilder builder = new SimpleObjectPrinter();
        var school = new School("Komarovi School", new Address("Robakidze Street 10", "Tbilisi", "Tbilisi", "4122"),
            new List<Student>()
            {
                new Student("Giorgi", "Pachulia", 22, 10),
                new Student("Luka", "Gabaidze", 21, 10)
            });

        var representation = builder.GetRepresentation(school);
        Console.WriteLine(representation);
    }
}

public interface IObjectRepresentationBuilder
{
    public string GetRepresentation<TObject>(TObject @object);
}

public class SimpleObjectPrinter : IObjectRepresentationBuilder
{
    public string GetRepresentation<TObject>(TObject @object)
    {
        var sb = new StringBuilder();
        BuildObjectRepresentation(@object, sb);
        return sb.ToString();
    }

    private void BuildObjectRepresentation<TObject>(TObject obj, StringBuilder representationBuilder, string indentation = "")
    {
        if (obj == null)
        {
            representationBuilder.AppendLine("null");
            return;
        }

        var objectType = obj.GetType();
        var objectProperties = objectType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

        representationBuilder.AppendLine($"{indentation}Object of Class \"{objectType.Name}\"");
        representationBuilder.AppendLine($"{indentation}{new string('-', 40)}");

        foreach (var property in objectProperties)
        {
            var propertyValue = property.GetValue(obj);

            if (property.PropertyType.IsSimple())
            {
                representationBuilder.AppendLine($"{indentation}{property.Name} = {propertyValue?.ToString()}");
            }
            else if (propertyValue is IEnumerable enumerable && !(propertyValue is string))
            {
                foreach (var item in enumerable)
                {
                    BuildObjectRepresentation(item, representationBuilder, $"{indentation}\t");
                }
            }
            else
            {
                BuildObjectRepresentation(propertyValue, representationBuilder, $"{indentation}\t");
            }
        }
    }
}

