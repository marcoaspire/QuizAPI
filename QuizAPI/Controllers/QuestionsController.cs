using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using QuizAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace QuizAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly Context _context;
        public QuestionsController(Context context)
        {
            _context = context;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(new
            {
                questions = _context.Questions
                            .Include(q => q.Answers)
                            .ToList(),
                ok = true
            });
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var h = _context.Questions
                    .Include(q => q.Answers).SingleOrDefault(c => c.QuestionID == id);
            return Ok(new
            {
                question = h,
                ok = "true"
            });
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public ActionResult Post(Question question)
        {
            try
            {
                _context.Questions.Add(question);
                _context.SaveChanges();

                return Ok(new { ok = true, question });
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new { ok = false, msg = "Unexpected error, check logs", details = ex.InnerException.Message });
            }
            catch (Exception e)
            {
                Trace.WriteLine(e);
                throw;
            }
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Question question)
        {
            try
            {
                if (id == question.QuestionID)
                {
                    _context.Entry(question).State = EntityState.Modified;
                    _context.SaveChanges();
                    return Ok(new { ok = true, question });
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
                var question = _context.Questions.Find(id);
                if (question == null)
                {
                    return NotFound(new { ok = false, msg = "We could not find a question with that ID" });
                }

                _context.Questions.Remove(question);
                _context.SaveChanges();

                return Ok(new { ok = true, msg = "Questions deleted" });
            }
            catch (Exception)
            {
                return StatusCode(500, new { ok = false, msg = "Unexpected error, check logs" });
            }
        }
    }
}
