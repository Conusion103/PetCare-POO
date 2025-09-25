using PetCareConsole.Models;


Dictionary<Int, Patient> patients = new Dictionary<Int, Patient>();



while (true)
{
    int option = Menu.ShowMenu();
    switch (option)
    {
        case 1:
            Console.Clear();
            Patient.AskPatientInfo(patients);
            break;
        case 2:
            Console.Clear();
            Patient.ShowAllPatients(patients);
            break;
        case 3:
            Console.Clear();
            Guid.TryParse(Console.ReadLine(), out Guid id);
            Patient.SearchPatientById(patients, id);
            break;
        case 4:
            Console.WriteLine("Exiting the application. Goodbye!");
            return;
        default:
            Console.WriteLine("Invalid option. Please try again.");
            continue;

    }
    
}




       