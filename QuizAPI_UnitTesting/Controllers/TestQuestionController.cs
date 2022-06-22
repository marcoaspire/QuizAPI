using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using QuizAPI.Controllers;
using QuizAPI.Models;
using QuizAPI_UnitTesting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizAPI_UnitTesting.Controllers
{
    class TestQuestionController
    {
        //Get
        [Test]
        public void Get_questions_ShouldReturnOK()
        {
            //Arrange
            var context = new TestQuizContext();
            Question[] mockQuestions = MockQuestions();
            foreach (Question question in mockQuestions)
            {
                context.Add(question);
            }

            CategoryResponse[] responseExpected = new CategoryResponse[mockQuestions.Length];

            for (int i = 0; i < mockQuestions.Length; i++)
            {
                responseExpected[i]= new CategoryResponse()
                {
                    QuestionID = mockQuestions[i].QuestionID,
                    Question = mockQuestions[i].Query,
                    CategoryID = mockQuestions[i].CategoryID,
                    Category = mockQuestions[i].Category.CategoryName,
                    Answers = mockQuestions[i].Answers
                };
            }
            var controller = new QuestionsController(null, context);
            //act
            var result = controller.Get() as OkObjectResult;
            //assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.StatusCode.Equals(200));
            dynamic values = result.Value;
            var categoriesResponse = values.GetType().GetProperty("questions").GetValue(values);
            Assert.AreEqual(responseExpected, categoriesResponse);
        }
        //Get_categoryByID
        [Test]
        public void Get_questionByID_ShouldReturnOK()
        {
            //arrange
            var context = new TestQuizContext();
            Question mockQuestion = MockQuestion();
            context.Add(mockQuestion);

            var responseExpected = new CategoryResponse
            {
                QuestionID=mockQuestion.QuestionID,
                Question = mockQuestion.Query,
                CategoryID=mockQuestion.CategoryID,
                Category = mockQuestion.Category.CategoryName,
                Answers = mockQuestion.Answers
            };

            var controller = new QuestionsController(null, context);
            var result = controller.Get(mockQuestion.QuestionID) as OkObjectResult;
            //assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.StatusCode.Equals(200));
            dynamic values = result.Value;
            var questionResponse = values.GetType().GetProperty("question").GetValue(values);
            Assert.AreEqual(responseExpected, questionResponse);
        }

        [Test]
        public void Get_questionByID_ShouldReturnNotFound()
        {
            //arrange
            var context = new TestQuizContext();
            var controller = new QuestionsController(null, context);
            //act
            var result = controller.Get(105) as NotFoundResult;
            //assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.StatusCode.Equals(404));
        }

        //delete
        [Test]
        public void Get_delete_ShouldReturnOK()
        {
            //arrange
            var context = new TestQuizContext();
            Question[] mockQuestions = MockQuestions();
            foreach (Question question in mockQuestions)
            {
                context.Add(question);
            }
            var controller = new QuestionsController(null, context);
            //act
            var result = controller.Delete(1) as OkObjectResult;
            //assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.StatusCode.Equals(200));
        }
        [Test]
        public void Get_delete_ShouldReturnNotFound()
        {
            var context = new TestQuizContext();

            var controller = new QuestionsController(null, context);
            var result = controller.Delete(1) as NotFoundObjectResult;
            Assert.IsNotNull(result);
            Assert.IsTrue(result.StatusCode.Equals(404));
        }

        [Test]
        public void Get_delete_ShouldReturn500Error()
        {
            //arrange
            var controller = new QuestionsController(null, null);
            //act
            var result = controller.Delete(1) as ObjectResult;
            //assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.StatusCode.Equals(500));
        }

        //update

        //post
        [Test]
        public void Post_question_returnOK()
        {
            //arrange
            var context = new TestQuizContext();
            Question mockQuestion = MockQuestion();
            var controller = new QuestionsController(null, context);
            //act
            var result = controller.Post(mockQuestion) as OkObjectResult;
            dynamic values = result.Value;
            var questionResponse = values.GetType().GetProperty("question").GetValue(values);
            //assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.StatusCode.Equals(200));
            Assert.AreEqual(mockQuestion, questionResponse);
        }
        [Test]

        public void Post_question_return500Error()
        {
            //arrange
            var context = new TestQuizContext();
            Question mockQuestion = MockQuestion();
            var controller = new QuestionsController(null, null);
            //act
            var result = controller.Post(mockQuestion) as ObjectResult;
            //assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.StatusCode.Equals(500));
        }

        [Test]

        public void Get_update_ShouldReturnOk()
        {
            //arrange
            var context = new TestQuizContext();
            Question[] mockQuestions = MockQuestions();
            foreach (Question question in mockQuestions)
            {
                context.Add(question);
            }
            Question mockQuestion = MockQuestion();
            var controller = new QuestionsController(null, context);
            //act
            var result = controller.Put(1, mockQuestion) as OkObjectResult;
            //assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.StatusCode.Equals(200));
        }

        [Test]
        public void Get_update_ShouldReturnNotFound()
        {
            //arrange
            var context = new TestQuizContext();
            Question[] mockQuestions = MockQuestions();
            foreach (Question question in mockQuestions)
            {
                context.Add(question);
            }
            Question mockQuestion = MockQuestion();
            var controller = new QuestionsController(null, context);
            //act
            var result = controller.Put(1000, mockQuestion) as NotFoundResult;
            //assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.StatusCode.Equals(404));
        }


        //Mocks
        public Question MockQuestion()
        {
            /*
            return new Question
            {
                QuestionID = 1,
                Query = "What is your name?",
                CategoryID = 1
            };
            */
            return new Question()
            {
                QuestionID = 1,
                Query = "Which is the capital of PERU?",
                CategoryID = 4,
                Category = new Category()
                {
                    CategoryID = 4,
                    CategoryName = "Geography",
                    Question = null
                },
                Answers = null
            };
        }
        
        //Mocks
        private Question[] MockQuestions()
        {
            var questions = new Question[]
            {
                new Question() {
                    QuestionID=1,
                    Query="Which is the capital of Peru?",
                    CategoryID=4,
                    Category=new Category()
                    {
                        CategoryID = 4,
                        CategoryName = "Geography",
                        Question = null
                    }
                },
                new Question() {
                    QuestionID=2,
                    Query="How are you?",
                    CategoryID=1,
                    Category=new Category()
                    {
                        CategoryID = 4,
                        CategoryName = "Geography",
                        Question = null
                    }

                }
            };
            return questions;
        }
    }
}
