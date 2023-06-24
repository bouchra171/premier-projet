using System;
using premier_projet.Models;

namespace premier_projet
{
    public class UserInterface
    {
        private EducationSystemService _educationSystemService;

        public UserInterface(EducationSystemService educationSystemService)
        {
            _educationSystemService = educationSystemService;
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("1. Ajouter un élève");
                Console.WriteLine("2. Ajouter une note à un élève");
                Console.WriteLine("3. Quitter");
                Console.Write("Choisissez une option : ");

                string option = Console.ReadLine() ?? "";

                if (option == "1")
                {
                    Console.Write("Entrez le prénom de l'élève : ");
                    string firstName = Console.ReadLine() ?? "";
                    Console.Write("Entrez le nom de l'élève : ");
                    string lastName = Console.ReadLine() ?? "";
                    Student newStudent = new Student() { FirstName = firstName, LastName = lastName };
                    _educationSystemService.AddStudent(newStudent);
                    Console.WriteLine("Élève ajouté avec succès.");
                }
                else if (option == "2")
                {
                    Console.Write("Entrez l'ID de l'élève : ");
                    string studentIdString = Console.ReadLine() ?? "";
                    if (!int.TryParse(studentIdString, out int studentId))
                    {
                        Console.WriteLine("ID de l'élève invalide.");
                        continue;
                    }

                    Console.Write("Entrez l'ID du cours : ");
                    string courseIdString = Console.ReadLine() ?? "";
                    if (!int.TryParse(courseIdString, out int courseId))
                    {
                        Console.WriteLine("ID du cours invalide.");
                        continue;
                    }

                    Console.Write("Entrez la note : ");
                    string scoreString = Console.ReadLine() ?? "";
                    if (!decimal.TryParse(scoreString, out decimal score))
                    {
                        Console.WriteLine("Note invalide.");
                        continue;
                    }

                    Grade newGrade = new Grade() { CourseId = courseId, Score = score };
                    Student student = _educationSystemService.GetStudent(studentId);
                    if (student != null)
                    {
                        try
                        {
                            _educationSystemService.AddGradeToStudent(studentId, newGrade);
                            Console.WriteLine("Note ajoutée avec succès.");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Élève non trouvé.");
                    }
                }
                else if (option == "3")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Option non reconnue.");
                }
            }
        }
    }
}
