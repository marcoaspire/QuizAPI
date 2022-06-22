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

//Nunit

namespace QuizAPI_UnitTesting.Controllers
{
    public class TestAnswerController
    {
        //private readonly Context _context4 =  new Context();
        private Mock<Context> _context;
        private readonly Mock<DbSet<Answer>> mockSet = new Mock<DbSet<Answer>>();


        AnswersController controller;
        private AnswerFake _service;


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
        public void Post_answers_returnOK()
        {
            //arrange
            var controller = new AnswersController(null,new TestQuizContext() );
            Answer[] item = MockAnswers();
            //act
            var result = controller.Post(item) as OkObjectResult;
            dynamic values = result.Value;
            var answersResponse = values.GetType().GetProperty("answers").GetValue(values);
            //assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.StatusCode.Equals(200));
            Assert.AreEqual(item, answersResponse); 
        }

        [Test]
        public void Post_answers_return500error()
        {
            //arrange
            var context = new TestQuizContext();
            Answer[] answers = MockAnswers();
            var controller = new AnswersController(null, null);
            //act
            var result = controller.Post(answers) as ObjectResult;
            //assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.StatusCode.Equals(500));
        }

        [Test]
        public void Get_answers_ShouldReturnOK()
        {            
            var context = new TestQuizContext();
            Answer[] mockAnswers = MockAnswers();
            foreach (Answer Answer in mockAnswers)
            {
                context.Add(Answer);
            }
            var controller = new AnswersController(null, context);
            var result = controller.Get() as OkObjectResult;
            //assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.StatusCode.Equals(200));
            dynamic values = result.Value;
            var answersResponse = values.GetType().GetProperty("answers").GetValue(values);
            Assert.AreEqual(mockAnswers, answersResponse);
        }

        //Get_answersByID
        [Test]
        public void Get_answersByID_ShouldReturnOK()
        {
            //arrange
            var context = new TestQuizContext();
            Answer mockAnswer = MockAnswer();
            context.Add(mockAnswer);
            var controller = new AnswersController(null, context);
            var result = controller.Get(mockAnswer.AnswerID) as OkObjectResult;
            //assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.StatusCode.Equals(200));
            dynamic values = result.Value;
            var answersResponse = values.GetType().GetProperty("Answer").GetValue(values);
            Assert.AreEqual(mockAnswer, answersResponse);
        }

        [Test]
        public void Get_answersByID_ShouldReturnNotFound()
        {
            //arrange
            var context = new TestQuizContext();
            var controller = new AnswersController(null, context);
            //var result = controller.Get(105) as NotFoundObjectResult;
            var result = controller.Get(105) as Microsoft.AspNetCore.Mvc.NotFoundResult;
            //assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.StatusCode.Equals(404));

        }

        //Delete answer
        [Test]
        public void Get_delete_ShouldReturnOK()
        {
            var context = new TestQuizContext();
            Answer[] mockAnswers = MockAnswers();
            foreach (Answer Answer in mockAnswers)
            {
                context.Add(Answer);
            }
            var controller = new AnswersController(null, context);
            var result = controller.Delete(1) as OkObjectResult;
            Assert.IsNotNull(result);
            Assert.IsTrue(result.StatusCode.Equals(200));
        }

        [Test]
        public void Get_delete_ShouldReturnNotFound()
        {
            var context = new TestQuizContext();
            
            var controller = new AnswersController(null, context);
            var result = controller.Delete(1) as NotFoundObjectResult;
            Assert.IsNotNull(result);
            Assert.IsTrue(result.StatusCode.Equals(404));
        }

        [Test]
        public void Get_delete_ShouldReturn500Error()
        {
            //arrange
            var controller = new AnswersController(null, null);
            //act
            var result = controller.Delete(1) as ObjectResult;
            //assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.StatusCode.Equals(500));
        }

        //Update answer

        [Test]

        public void Get_update_ShouldReturnOk()
        {
            //arrange
            var context = new TestQuizContext();
            Answer[] mockAnswers = MockAnswers();
            foreach (Answer Answer in mockAnswers)
            {
                context.Add(Answer);
            }
            Answer mockAnswer = MockAnswer();
            var controller = new AnswersController(null, context);
            //act
            var result = controller.Put(1, mockAnswer) as OkObjectResult;
            //assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.StatusCode.Equals(200));
        }

        [Test]
        public void Get_update_ShouldReturnNotFound()
        {
            //arrange
            var context = new TestQuizContext();
            Answer[] mockAnswers = MockAnswers();
            foreach (Answer Answer in mockAnswers)
            {
                context.Add(Answer);
            }
            Answer mockAnswer = MockAnswer();
            var controller = new AnswersController(null, context);
            //act
            var result = controller.Put(1000, mockAnswer) as Microsoft.AspNetCore.Mvc.NotFoundResult;
            //assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.StatusCode.Equals(404));

        }

        //Mocks

        public Answer MockAnswer()
        {
            return new Answer()
            {
                AnswerID = 1,
                Correct = true,
                PosibleAnswer = "Something updated",
                QuestionID = 1
            };
        }

        public Answer[] MockAnswers()
        {
            var answers = new Answer[]
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
            return answers;
        }

        public Answer[] MockAnswers2()
        {
            var answers = new Answer[]
            {
                new Answer()
                {
                    AnswerID = 7,
                    Correct = true,
                    PosibleAnswer = "Something2",
                    QuestionID = 1
                },
                new Answer()
                {
                    AnswerID = 8,
                    Correct = false,
                    PosibleAnswer = "Something bad2",
                    QuestionID = 1
                }
            };
            return answers;
        }
    }

}