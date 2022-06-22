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
    class TestCategoryController
    {
        //GetCategory
        [Test]
        public void Get_categories_ShouldReturnOK()
        {
            var context = new TestQuizContext();
            Category [] mockCategories = MockCategories();
            foreach (Category category in mockCategories)
            {
                context.Add(category);
            }
            var controller = new CategoriesController(null, context);
            var result = controller.Get() as OkObjectResult;
            //assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.StatusCode.Equals(200));
            dynamic values = result.Value;
            var categoriesResponse = values.GetType().GetProperty("categories").GetValue(values);
            Assert.AreEqual(mockCategories, categoriesResponse);
        }
        //Get_categoryByID
        [Test]
        public void Get_categoryByID_ShouldReturnOK()
        {
            //arrange
            var context = new TestQuizContext();
            Category mockCategory = MockCategory();
            context.Add(mockCategory);
            var controller = new CategoriesController(null, context);
            //act
            var result = controller.Get(mockCategory.CategoryID) as OkObjectResult;
            //assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.StatusCode.Equals(200));
            dynamic values = result.Value;
            var categoryResponse = values.GetType().GetProperty("category").GetValue(values);
            Assert.AreEqual(mockCategory, categoryResponse);
        }

        [Test]
        public void Get_categoryByID_ShouldReturnNotFound()
        {
            //arrange
            var context = new TestQuizContext();
            var controller = new CategoriesController(null, context);
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
            Category[] mockCategories = MockCategories();
            foreach (Category category in mockCategories)
            {
                context.Add(category);
            }
            var controller = new CategoriesController(null, context);
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

            var controller = new CategoriesController(null, context);
            var result = controller.Delete(1) as NotFoundObjectResult;
            Assert.IsNotNull(result);
            Assert.IsTrue(result.StatusCode.Equals(404));
        }

        [Test]
        public void Get_delete_ShouldReturn500Error()
        {
            //arrange
            var controller = new CategoriesController(null, null);
            //act
            var result = controller.Delete(1) as ObjectResult;
            //assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.StatusCode.Equals(500));
        }

        //update

        //post
        [Test]
        public void Post_category_returnOK()
        {
            //arrange
            var context = new TestQuizContext();
            Category mockCategory = MockCategory();
            var controller = new CategoriesController(null, context);
            //act
            var result = controller.Post(mockCategory) as OkObjectResult;
            dynamic values = result.Value;
            var categoryResponse = values.GetType().GetProperty("category").GetValue(values);
            //assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.StatusCode.Equals(200));
            Assert.AreEqual(mockCategory, categoryResponse);
        }
        [Test]

        public void Post_category_return500Error()
        {
            //arrange
            var context = new TestQuizContext();
            Category mockCategory = MockCategory();
            var controller = new CategoriesController(null, null);
            //act
            var result = controller.Post(mockCategory) as ObjectResult;
            //assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.StatusCode.Equals(500));
        }

        [Test]

        public void Get_update_ShouldReturnOk()
        {
            //arrange
            var context = new TestQuizContext();
            Category[] mockCategories = MockCategories();
            foreach (Category category in mockCategories)
            {
                context.Add(category);
            }
            Category mockcategory = MockCategory();
            var controller = new CategoriesController(null, context);
            //act
            var result = controller.Put(1, mockcategory) as OkObjectResult;
            //assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.StatusCode.Equals(200));
        }

        [Test]
        public void Get_update_ShouldReturnNotFound()
        {
            //arrange
            var context = new TestQuizContext();
            Category[] mockCategories = MockCategories();
            foreach (Category category in mockCategories)
            {
                context.Add(category);
            }
            Category mockcategory = MockCategory();
            var controller = new CategoriesController(null, context);
            //act
            var result = controller.Put(1000, mockcategory) as NotFoundResult;
            //assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.StatusCode.Equals(404));
        }


        //Mocks
        public Category MockCategory()
        {
            return new Category
            {
                CategoryID = 1,
                CategoryName = "Sports U",
                Question = null
            };
        }
        public Category[] MockCategories()
        {
            var categories = new Category[]
            {
                new Category() {
                    CategoryID = 1,
                    CategoryName = "Sports",
                    Question = null
                },
                new Category() {
                    CategoryID = 2,
                    CategoryName = "Geography",
                    Question = null
                },
            };
            return categories;
        }
    }
}
