using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolAPI.Globals;
using SchoolAPI.Helpers;
using SchoolAPI.Models;
using System;

namespace SchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Students : Controller
    {
        [HttpGet]
        [Route("GetStudents")]
        [AllowAnonymous]
        public ActionResult GetStudents()
        {
            try
            {
                return Ok(AppGlobals.Students);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error -> GetStudents: "+ex.Message);
                return new StatusCodeResult(500);
            }
        }

        [HttpGet]
        [Route("GetStudent/{id}")]
        [AllowAnonymous]
        public ActionResult GetStudent(int id)
        {
            try
            {
                int position = AppGlobals.Students.FindIndex(a => a.Id == id);
                if (position >= 0)
                    return Ok(AppGlobals.Students[position]);
                else
                    return new StatusCodeResult(404);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error -> GetStudent: " + ex.Message);
                return new StatusCodeResult(500);
            }
        }

        [HttpPost]
        [Route("InsertStudent")]
        [Authorize]
        public ActionResult InsertStudent(Student student)
        {
            try
            {
                bool allGood = Utils.AddStudent(student);
                if(allGood)
                    return Ok(student);
                else
                    return new StatusCodeResult(500);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error -> InsertStudent: " + ex.Message);
                return new StatusCodeResult(500);
            }
        }

        [HttpPut]
        [Route("UpdateStudent/{id}")]
        [Authorize]
        public ActionResult UpdateStudent(int id, Student student)
        {
            try
            {
                if (id >= 0)
                {
                    bool allGood = Utils.UpdateStudent(student, id);
                    if (allGood)
                        return Ok(student);
                    else
                        return new StatusCodeResult(500);
                }
                else
                    return new StatusCodeResult(404);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error -> UpdateStudent: " + ex.Message);
                return new StatusCodeResult(500);
            }
        }

        [HttpDelete]
        [Route("DeleteStudent/{id}")]
        [Authorize]
        public ActionResult DeleteStudent(int id)
        {
            try
            {
                if (id >= 0)
                {
                    bool allGood = Utils.DeleteStudent(id);
                    if (allGood)
                        return Ok(new ServerAnswers()
                        {
                            Message="Student deleted!"
                        });
                    else
                        return new StatusCodeResult(500);
                }
                else
                    return new StatusCodeResult(404);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error -> DeleteStudent: " + ex.Message);
                return new StatusCodeResult(500);
            }
        }

    }
}
