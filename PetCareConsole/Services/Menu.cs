public class Menu
{
    public static int ShowMenu()
    {
        Console.WriteLine(@"Welcome to the Pet Care System!
1. Add Patient
2. View Patients
3. Search Patient
4. Exit");
        int.TryParse(Console.ReadLine(), out int option);
        return option;
    }
}