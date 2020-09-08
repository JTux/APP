using System;
using System.Collections.Generic;
using APollPoll.Services.Questions.Models;
using APollPoll.Services.Questions.Service;
using APollPoll.Web.App_Start;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace APollPoll.Tests.Questions
{
    [TestClass]
    public class QuestionServiceTests
    {
        private QuestionService _service;

        [TestInitialize]
        public void Arrange()
        {
            _service = new QuestionService(MapperConfig.GetMapper());
        }

        [TestMethod]
        public void Create()
        {
            var createModel = new QuestionCreate
            {
                Title = "Test Question",
                IsMultipleChoice = true
            };

            var result = _service.CreateAsync(createModel).Result;
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetAll()
        {
            var questions = _service.GetAllAsync().Result;
            Assert.IsInstanceOfType(questions, typeof(List<QuestionListItem>));
        }

        [TestMethod]
        public void GetById()
        {
            var question = _service.GetByIdAsync(1).Result;
            Assert.IsNotNull(question);
        }

        [TestMethod]
        public void Update()
        {
            var updateModel = new QuestionUpdate
            {
                Id = 1,
                IsMultipleChoice = false,
                Title = "Updated Title"
            };
            Assert.IsTrue(_service.UpdateAsync(updateModel).Result);
        }

        [TestMethod]
        public void Delete()
        {
            Assert.IsTrue(_service.DeleteAsync(1).Result);
        }
    }
}
