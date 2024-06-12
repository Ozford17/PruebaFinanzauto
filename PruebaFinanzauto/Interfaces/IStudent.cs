using PruebaFinanzauto.Model;
using System.Data.SqlTypes;

namespace PruebaFinanzauto.Interfaces
{
    public interface IStudent
    {
        bool AddStudent(Student student);
        List<Student> ListStudent();
        Student GetByStudent(int tipDoc, string Numero);
        bool DeleteStudent(int id);
        bool UpdateStudent(Student student);
    }
}
