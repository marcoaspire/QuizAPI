using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using QuizAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using QuizAPI.Interfaces;

namespace QuizAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswersController : ControllerBase
    {
        //private readonly Context _context;

        // modify the type of the db field
        private IAnswerService _context;
        //public AnswersController() { }
        /*
        public AnswersController(IAnswerService context)
        {
          _context = context;
        }
        */
        public AnswersController(Context context, IAnswerService context2)
        {
            if (context!=null)
                _context = context;
            else
                _context = context2;

        }


        [HttpGet("/prueba")]
        public virtual bool Prueba()
        {
            return true;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public virtual ActionResult Get()
        {
            Trace.WriteLine("entre get");
            List<Answer> questions=_context.Answers.Include(q => q.Question).ToList();
            //var questions=_context.Answers;
            //var questions= _context.Get();

            /*
            foreach (var item in questions)
            {
                Debug.WriteLine(item.PosibleAnswer);
            }
            */
            return Ok(new
            {
                questions
            });
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Trace.WriteLine("entre get by id");

            var h = _context.Answers
                    .Include(q => q.Question).SingleOrDefault(c => c.AnswerID == id);
            return Ok(new
            {
                Answer = h
            });
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public ActionResult Post(Answer[] answers)
        {
            try
            {
                foreach (Answer answer in answers)
                {
                    _context.Answers.Add(answer);

                }
                _context.SaveChanges();

                return Ok(new { answers });
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new { msg = "Unexpected error, check logs", details = ex.InnerException.Message });
            }
            catch (Exception e)
            {
                Trace.WriteLine(e);
                throw;
            }
        }
        
        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Answer answer)
        {
            try
            {
                if (id == answer.AnswerID)
                {
                    //_context.Entry(answer).State = EntityState.Modified;
                    _context.MarkAsModified(answer);
                    _context.SaveChanges();
                    return Ok(new { answer });
                }
                return NotFound();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }
        }
        
        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var answer = _context.Answers.Find(id);
                if (answer == null)
                {
                    return NotFound(new {  msg = "We could not find an answer with that ID" });
                }
                _context.Answers.Remove(answer);
                _context.SaveChanges();
                return Ok(new {msg = "Questions deleted" });
            }
            catch (Exception)
            {
                return StatusCode(500, new { msg = "Unexpected error, check logs" });
            }
        }
    }
}
