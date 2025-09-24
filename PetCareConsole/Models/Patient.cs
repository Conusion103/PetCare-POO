namespace PetCareConsole.Models;

class Patient
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public int Age { get; private set; }
    public string Symptoms { get; private set; }

    public Patient(string name, int age, string symptoms)
    {
        Id = Guid.NewGuid();
        this.Name = name;
        this.Age = age;
        this.Symptoms = symptoms;
    }

    public static void AskPatientInfo(List<Patient> patients)
    {
        Console.Clear();
        Console.WriteLine("Enter patient information (type 'cancel' anytime to abort):");
        Console.WriteLine("---------------------------------------------------------");

        string name = AskForName();


        int? age = AskForAge();


        string symptoms = AskForSymptoms();
        if (name == null || age == null || symptoms == null)
        {
            Console.WriteLine("Patient entry cancelled.");
            return;
        }
        else
        {
            Console.WriteLine("Patient added successfully!");
            patients.Add(new Patient(name, age.Value, symptoms));
            Console.WriteLine($"Name: {name}, Age: {age}, Symptoms: {symptoms}");

        }


    }

    private static string AskForName()
    {
        while (true)
        {
            Console.Write("Enter patient name: ");
            string input = Console.ReadLine();

            if (string.Equals(input, "cancel", StringComparison.OrdinalIgnoreCase))
                return null;

            if (!string.IsNullOrWhiteSpace(input))
                return input;

            Console.WriteLine("Name cannot be empty. Please try again or type 'cancel' to abort.");
        }
    }

    private static int? AskForAge()
    {
        while (true)
        {
            Console.Write("Enter patient age: ");
            string input = Console.ReadLine();

            if (string.Equals(input, "cancel", StringComparison.OrdinalIgnoreCase))
                return null;

            if (int.TryParse(input, out int age) && age > 0)
                return age;

            Console.WriteLine("Invalid age. Please enter a positive number or type 'cancel' to abort.");
        }
    }

    private static string AskForSymptoms()
    {
        while (true)
        {
            Console.Write("Enter patient symptoms: ");
            string input = Console.ReadLine();

            if (string.Equals(input, "cancel", StringComparison.OrdinalIgnoreCase))
                return null;

            if (!string.IsNullOrWhiteSpace(input))
                return input;

            Console.WriteLine("Symptoms cannot be empty. Please try again or type 'cancel' to abort.");
        }
    }


}
