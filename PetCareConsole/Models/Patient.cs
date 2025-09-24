namespace PetCareConsole.Models;

class Patient
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public int Edad { get; private set; }
    public string Sintomas { get; private set; }

    public Patient(string name, int edad, string sintomas)
    {
        Id = Guid.NewGuid();
        this.Name = name;
        this.Edad = edad;
        this.Sintomas = sintomas;
    }

    public static void AskPatientInfo(List<Patient> patients)
    {
        Console.Clear();
        Console.WriteLine("Enter patient information (type 'cancel' anytime to abort):");
        Console.WriteLine("---------------------------------------------------------");

        string name = AskForName();


        int? edad = AskForAge();


        string sintomas = AskForSymptoms();
        if (name == null || edad == null || sintomas == null)
        {
            Console.WriteLine("Patient entry cancelled.");
            return;
        }
        else
        {
            Console.WriteLine("Patient added successfully!");
            patients.Add(new Patient(name, edad.Value, sintomas));
            Console.WriteLine($"Name: {name}, Age: {edad}, Symptoms: {sintomas}");

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

            if (int.TryParse(input, out int edad) && edad > 0)
                return edad;

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
