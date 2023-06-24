namespace premier_projet
{
    class Program
    {
        static void Main(string[] args)
        {
            EducationSystemService educationSystemService = new EducationSystemService();
            UserInterface userInterface = new UserInterface(educationSystemService);
            userInterface.Run();
        }
    }
}



