using models;
using Rt.DbLayer;

namespace services;

public class StudentService{

    readonly DataContext _context;
    public StudentService(DataContext context)
    {
        _context = context;

    }

    public List<Student> GetStudents(){
      var students =   _context.Students.ToList();

        return students;
    }

    public void GenerateStudent(){
          Student student = new Student();

        student.FIO ="1";
        _context.Students.Add(student);
          Student student2 = new Student();

        student2.FIO ="2";
        _context.Students.Add(student2);

        Student student3 = new Student();

        student3.FIO ="3";
        _context.Students.Add(student3);
        _context.Students.Remove(student3);
        _context.SaveChanges();
    }
}