namespace PetCareConsole.Models;

class Patient
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public int Age { get; private set; }
    public string Symptoms { get; private set; }

    //Constructor
    public Patient(string name, int age, string symptoms)
    {
        this.Id = Guid.NewGuid();
        this.Name = name;
        this.Age = age;
        this.Symptoms = symptoms;
    }



    // Method to display patient info
    public string ShowPatient()
    {
        return $"Patient ID: {Id}\nName: {Name}\nAge: {Age}\nSymptoms: {Symptoms}\n";
    }

    public static Patient? SearchPatientById(Dictionary<int, Patient> patients, int id)
    {
        if (patients.TryGetValue(id, out Patient patient))
        {
            return patient;
        }
        return null;
    }


    // Method to show the last added patient
    public static string ShowLastPatient(List<Patient> patients)
    {
        if (patients == null || patients.Count == 0)
            return "No patients available.";
        return patients.Last().ShowPatient();
    }

    // Method to show all patients
    public static void ShowAllPatients(List<Patient> patients)
    {
        if (patients == null || patients.Count == 0)
        {
            Console.WriteLine("No patients available.");
            return;
        }

        Console.WriteLine("All Patients:");
        Console.WriteLine("-------------");
        foreach (var patient in patients)
        {
            Console.WriteLine(patient.ShowPatient());
        }
    }


    //Methods
    // Method to ask for patient info
    public static void AskPatientInfo(List<Patient> patients)
    {
        Console.Clear();
        Console.WriteLine("Enter patient information (type 'cancel' anytime to abort):");
        Console.WriteLine("---------------------------------------------------------");

        int id = AskForId(patients);
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

        }


    }

    // Helper methods to ask for each field with validation
    // Ask for Name
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

    // Ask for Age
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

    // Ask for Symptoms
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

    private static int AskForId(Dictionary<int, Patient> patients)
    {
        int amountOfPatient = patients.Count > 0 ? patients.Count : 0;
        if (amountOfPatient == 0)
        {
            Console.WriteLine("No patients available.");
            return -1;
        }
        else
        {

            int idMax = patients.Keys.Max();
            return idMax + 1;
        }

    }


}
