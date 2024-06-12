using Microsoft.EntityFrameworkCore;
using PruebaFinanzauto.Data;
using PruebaFinanzauto.Interfaces;
using PruebaFinanzauto.Model;

namespace PruebaFinanzauto.Repository
{
    public class StudentRepository : IStudent
    {
        //Se trae el contesto de la base de datos
        public readonly ApiDbContext _identity;
        //Se escoge el objeto el cual se va a utilizar 
        private DbSet<Student> _Items;
        public StudentRepository(ApiDbContext api)
        {
            this._identity = api;
            this._Items = this._identity.Set<Student>();

        }
        public bool AddStudent(Student student)
        {
            try
            {
                _Items.Add(student);
                _identity.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public bool DeleteStudent(int id)
        {
            //verificar que existe el estudiante
            var aux = _Items.Where(I => I.Id == id).SingleOrDefault();
            if(aux != null)
            {
                _Items.Remove(aux);
                _identity.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
            
            
        }

        public Student GetByStudent(int tipDoc, string Numero)
        {
            return _Items.Where(I => I.Document.Equals(tipDoc) && I.Number.Equals(Numero) ).SingleOrDefault();
        }

        
        public List<Student> ListStudent()
        { 
                return this._Items.ToList();  
        }

        public bool UpdateStudent(Student student)
        {
            //Verificacion que exista para hacer la actualizacion de los datos.
            var aux = _Items.Where(I => I.Id == student.Id).SingleOrDefault();
            if (aux != null)
            {
                aux.NameStudent = student.NameStudent;
                aux.LastName = student.LastName;
                aux.Document = student.Document;
                aux.Number = student.Number;
                aux.State = student.State;
                _identity.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
