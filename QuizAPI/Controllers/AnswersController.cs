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
    public class AnswersController : ControllerBase
    {
        private readonly Context _context;
        public AnswersController(Context context)
        {
            _context = context;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(new
            {
                questions = _context.Answers
                            .Include(q => q.Question)
                            .ToList(),
                ok = true
            });
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var h = _context.Answers
                    .Include(q => q.Question).SingleOrDefault(c => c.AnswerID == id);
            return Ok(new
            {
                Answer = h,
                ok = "true"
            });
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public ActionResult Post(Answer answer)
        {
            try
            {
                _context.Answers.Add(answer);
                _context.SaveChanges();

                return Ok(new { ok = true, answer });
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
        public ActionResult Put(int id, Answer answer)
        {
            try
            {
                if (id == answer.AnswerID)
                {
                    _context.Entry(answer).State = EntityState.Modified;
                    _context.SaveChanges();
                    return Ok(new { ok = true, answer });
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
                    return NotFound(new { ok = false, msg = "We could not find an answer with that ID" });
                }

                _context.Answers.Remove(answer);
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
