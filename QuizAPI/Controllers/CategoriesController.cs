using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizAPI.Interfaces;
using QuizAPI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuizAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        //private readonly Context _context;
        private IAnswerService _context;
        /*
        public CategoriesController(Context context)
        {
            _context = context;
        }
        */
        public CategoriesController(Context context, IAnswerService context2)
        {
            if (context != null)
                _context = context;
            else
                _context = context2;

        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(new
            {
                categories = _context.Categories

                /*
                .Select(q => new
                {

                    Question = q,
                    UserEmail= d.User.Email,
                    UserName = d.User.Name
                })
                */
                //.Include(d => d.Question)
                .ToList()
            });
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            //var category = _context.Categories
            //     .Include(c => c.Question)
            //     .ThenInclude(q => q.Answers)
            //     .SingleOrDefault(c =>c.CategoryID == id);
            //return Ok(new
            //{
            //    category

            //});

            var category = _context.Categories
                 .Include(c => c.Question)
                 .ThenInclude(q => q.Answers)
                 .SingleOrDefault(c => c.CategoryID == id);
            if (category != null)
                return Ok(new
                {
                    category
                });
            else
                return NotFound();

        }

        // POST api/<CategoriesController>
        [HttpPost]
        public ActionResult Post(Category category)
        {
            try
            {
                _context.Categories.Add(category);
                _context.SaveChanges();

                return Ok(new { category });
                

            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new { msg = "Unexpected error, check logs", details = ex.InnerException.Message });
            }
            catch (Exception e)
            {
                Trace.WriteLine(e);
                return StatusCode(500, new { msg = "Unexpected error, check logs"});
            }
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Category category)
        {
            try
            {
                if (id == category.CategoryID)
                {
                    //_context.Entry(category).State = EntityState.Modified;
                    _context.MarkAsModified(category);
                    _context.SaveChanges();
                    return Ok(new { category });
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
                var category = _context.Categories.Find(id);
                if (category == null)
                {
                    return NotFound(new { msg = "We could not find a category with that ID" });
                }

                _context.Categories.Remove(category);
                _context.SaveChanges();

                return Ok(new { msg = "Category deleted" });
            }
            catch (Exception)
            {
                return StatusCode(500, new {msg = "Unexpected error, check logs" });
            }
        }
    }
}
