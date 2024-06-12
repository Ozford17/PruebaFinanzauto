using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SqlServer.Server;
using PruebaFinanzauto.DTO;
using PruebaFinanzauto.Interfaces;
using PruebaFinanzauto.Model;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;

namespace PruebaFinanzauto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly IStudent _student; //->implementacion de la interfaz, la clase se llama StudentRepository

        public StudentController(IStudent student)
        {
            _student = student;
        }

        //Traer el listado de los estudiantes
        [HttpGet]
        public IActionResult getStudents()
        {
            try
            {
                return Ok(_student.ListStudent());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("Paginado")]
        public IActionResult getStudentsPaginado()
        {
            try
            {
                ArrayList pag= new ArrayList();
                var list=new List<Student>(); ;
                var aux = _student.ListStudent();
                var count = 0;
                for (int i=0;i< aux.LongCount(); i++)
                {
                    if (count <= 5)
                    {
                        
                        list.Add(aux[i]);
                        count ++;
                    }
                    else
                    {
                        pag.Add(list);
                        count = 0;
                        list = new List<Student>();
                    }

                    if(i== aux.LongCount()-1)
                    {
                        pag.Add(list);
                    }
                    
                    
                }
                return Ok(pag);
                


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //Traer por tipo de documento y numero de documento del estudiante
        [HttpGet]
        [Route("Find/{tipo}/{numero}")]
        public IActionResult getStudentsDocument(int tipo, string numero)
        {
            try
            {
                return Ok(_student.GetByStudent(tipo,numero));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Agregar nuevo estudiante
        [HttpPost]
        public IActionResult AddStudents(StudentDTO student) {
            try
            {
                Student obj = new Student();
                obj.Id = student.Id;
                obj.NameStudent = student.NameStudent;
                obj.Document = student.Document;
                obj.Number = student.Number;
                obj.LastName = student.LastName;
                obj.DateCreate = DateTime.Now;
                obj.State = true;
                return Ok(_student.AddStudent(obj));

            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }

        //Eliminar estudiante por el codigo que tiene en el sistema 
        [HttpDelete]
        public IActionResult DeleteStudents(StudentDTO student) {
            try
            {
             
                return Ok(_student.DeleteStudent(student.Id));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Actualizar el estudiante 
        [HttpPut]
        public IActionResult UpdateStudents(StudentDTO student)
        {
            try
            {
                Student obj = new Student();
                obj.Id = student.Id;
                obj.NameStudent = student.NameStudent;
                obj.Document = student.Document;
                obj.Number = student.Number;
                obj.LastName = student.LastName;
                obj.State= student.State;
                return Ok(_student.UpdateStudent(obj));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
