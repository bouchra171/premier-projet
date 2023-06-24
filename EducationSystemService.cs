using System;
using premier_projet.Models;
using premier_projet.Services;

namespace premier_projet
{
    public class EducationSystemService
    {
        private List<Student> _students;
        private readonly DataStorage _dataStorage;
        private const string FileName = "students.json";

        public EducationSystemService()
        {
            _dataStorage = new DataStorage();
            _students = _dataStorage.LoadData<Student>(FileName) ?? new List<Student>();
        }

        public void AddStudent(Student newStudent)
        {
            newStudent.Id = (_students.Count > 0 ? _students.Max(s => s.Id) : 0) + 1;
            _students.Add(newStudent);
            SaveData();
        }

        public void AddGradeToStudent(int studentId, Grade newGrade)
        {
            Student student = GetStudent(studentId);
            if (student != null)
            {
                student.Grades.Add(newGrade);
                SaveData();
            }
            else
            {
                throw new Exception("Élève non trouvé.");
            }
        }

        public Student? GetStudent(int studentId)
        {
            var student = _students.Find(s => s.Id == studentId);
            if (student == null)
            {
                throw new Exception("Élève non trouvé.");
            }
            return student;
        }


        private void SaveData()
        {
            _dataStorage.SaveData(FileName, _students);
        }
    }
}

private void AutoSaveData()
{
    _dataStorage.SaveData(FileName, _students);
}
