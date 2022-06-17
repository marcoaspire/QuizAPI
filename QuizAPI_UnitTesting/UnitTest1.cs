using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using QuizAPI.Controllers;
using QuizAPI.Interfaces;
using QuizAPI.Models;
using QuizAPI_UnitTesting.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Web.Http;
using System.Web.Http.Results;

//MS->ocupar este
//X

namespace QuizAPI_UnitTesting
{
    public class Tests
    {
        //Checar
        //private readonly Context _context4 =  new Context();
        private Mock<Context> _context;
        private readonly Mock<DbSet<Answer>> mockSet = new Mock<DbSet<Answer>>();


        AnswersController controller;
        private AnswerFake _service;



        public Answer mockAnswer = new()
        {
            AnswerID = 1,
            Correct = true,
            PosibleAnswer = "Something",
            QuestionID = 1
        };


        [SetUp]
        public void SetUp()
        {
            //_context = new Mock<Context>();
            //controller = new AnswersController(_context.Object);



            //_service = new AnswerFake();
            //controller = new AnswersController(_service);

            //controller = new AnswersController(_context);


        }


        [Test]
        public void Test1()
        {
            TestContext.WriteLine("test context");
            Console.WriteLine("test console");

            _service = new AnswerFake();

            //var mockSet = new Mock<DbSet<Answer>>();
            _context = new Mock<Context>();
            /*
            _context.Setup(repo => repo.Answers).Returns(
                _service.Answers2
            );*/

            controller = new AnswersController(null,_service);



            //var mockSet = new Mock<DbSet<Answer>>();
            var mockSet = new Mock<Answer>();



            //mockSet.Setup(a => a.Add(mockAnswer));

            //PAso!!!!
            //Mock<Context> _context = new Mock<Context>();
            //controller = new AnswersController(_context.Object);

            /*
            _context = new Mock<Context>();

            
             _context4.Set<Answer>().AddRange(
               _service.Answers2

            );
            */

            /*
            _context.Setup(repo => repo.Answers).Returns(
                _service.Set<Answer>()
            );
            
            */


            //controller = new AnswersController(_context.Object);
            //var answers = controller.Get();


            /*
            var mockSet = new Mock<DbSet<Answer>>();
            var mockContext = new Mock<Context>();
            mockContext.Setup(m => m.Answers).Returns(mockSet.Object);
            */
            //fake instance
            //var _context = new Mock<Context>();

            //arrange 
            //act
            var result2 = controller.Get();
            var result = controller.Prueba();
            //Assert
            Assert.IsTrue(result);
        }
        [Test]
        public void Test2()
        {
            ////arrange a
            var testAnswers = AnswersFake();

            //var fakeAnswers = A.CollectionOfDummy<Answer>(5).AsEnumerable();
            //var dataStore = A.Fake<Answer>();
            ////A.CallTo( ()=> dataStore.)

            //foreach (var fake in fakeAnswers)
            //{
            //    Console.WriteLine(fake.AnswerID);
            //    Console.WriteLine(fake.Correct);
            //    Console.WriteLine(fake.PosibleAnswer);
            //    Console.WriteLine(fake.QuestionID);
            //    Console.WriteLine();
            //}
            //Console.WriteLine("Fin");

            //Console.WriteLine(dataStore.AnswerID);
            //Console.WriteLine(dataStore.Correct);
            //Console.WriteLine(dataStore.PosibleAnswer);

            //Console.WriteLine(fakeAnswers);

            //_context = new Mock<Context>();
           // AnswersController controller = new AnswersController(_context);




            // Setup mocking behavior  
            var result = controller.Get(10);
            var okObjectResult = (OkObjectResult)result;

            //Assert
            okObjectResult.StatusCode.Equals(200);

            //act
            //ActionResult actionResult = s.Get();

            Console.WriteLine(okObjectResult);
            //Assert
            //var contentResult = response as OkObjectResult;

            //Console.WriteLine(response);

            //Assert.IsInstanceOf<Microsoft.AspNetCore.Mvc.OkResult>(okObjectResult);

            // Assert the result  
            //Assert.IsNotNull(contentResult);
            //Assert.IsNotNull(contentResult.Content);
            //Assert.AreEqual(1, contentResult.Content.AnswerID);
            //Assert.IsFalse(result);



        }
        [Test]

        public void Test3()
        {
            var controller = new AnswersController(null,new TestQuizContext() );

            var item = MockAnswers();


            /*
            var result =
                controller.Get() as OkObjectResult;
            */
            var result =
                controller.Post(item) as OkObjectResult;

            Assert.IsNotNull(result);
            /*
            foreach (Answer i in result.Value)
            {
                Console.WriteLine(i.PosibleAnswer);
            }
            */
            Assert.AreEqual(result.Value, item); //Buscar como comparar
            result.StatusCode.Equals(200);

            //Assert.AreEqual(result.RouteName, "DefaultApi");
            //Assert.AreEqual(result.RouteValues["id"], result.Content.Id);
            //Assert.AreEqual(result.Content.Name, item.Name);
        }

        
        

        public List<Answer> AnswersFake()
        {
            return new List<Answer>()
            {
                new Answer() { 
                    AnswerID=1,
                    Correct=true,
                    PosibleAnswer="Something",
                    QuestionID=1
                },
                new Answer() {
                    AnswerID=2,
                    Correct=false,
                    PosibleAnswer="Something bad",
                    QuestionID=1
                },

            };
        }

        public Answer[] MockAnswers()
        {
            var questions = new Answer[]
            {
                new Answer() {
                    AnswerID=1,
                    Correct=true,
                    PosibleAnswer="Something",
                    QuestionID=1
                },
                new Answer() {
                    AnswerID=2,
                    Correct=false,
                    PosibleAnswer="Something bad",
                    QuestionID=1
                },

            };
            return questions;
        }

        /*
        public DbSet<Answer> MockSetAnswers()
        {

                new Answer()
                {
                    AnswerID = 1,
                    Correct = true,
                    PosibleAnswer = "Something",
                    QuestionID = 1
                }
            );
        }
        */

    }
}