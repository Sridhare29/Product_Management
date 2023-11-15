using System;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProductManagement.Controllers;
using ProductManagement.Repositories;
using ProductManagement.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Products.UnitTest
{
    [TestClass]
	public class ProductControllerUnitTest
	{
        public readonly IProductRepositories _productRepositories;
        public readonly IMapper _mapper;
        public ProductController _productController;
        private static Mock<IProductRepositories> _productRepositoriesMock;
        private static Mock<IMapper> _productMapperMock;

        [TestInitialize]
        public void Setup()
        {
            _productController = new ProductController(_productRepositories, _mapper);
        }

        private void productMockData(IProductRepositories _productRepositories, IMapper _mapper)
        {
            _productController = new ProductController(_productRepositories, _mapper);
        }

        [TestMethod]
        public void GetAll_Success()
        {
            List<Product> products = new List<Product>();
            _productRepositoriesMock = new Mock<IProductRepositories>();
            _productMapperMock = new Mock<IMapper>();
            _productRepositoriesMock.Setup(x => x.GetAllAsync()).ReturnsAsync(products);
            productMockData(_productRepositoriesMock.Object,_productMapperMock.Object);
            var result = _productController.GetAll();

            //Assert.IsNotNull(result);
            var okResult = result.Result as OkObjectResult;
            Assert.AreEqual(200, okResult?.StatusCode);

        }

        [TestMethod]
        public void GetAll_Exception()
        {
            List<Product> products = new List<Product>();
            _productRepositoriesMock = new Mock<IProductRepositories>();
            _productMapperMock = new Mock<IMapper>();
            _productRepositoriesMock.Setup(x => x.GetAllAsync()).ReturnsAsync(products);
            //productMockData(_productRepositoriesMock.Object, _productMapperMock.Object);
            var result = _productController.GetAll();

            //Assert.IsNotNull(result);
            var okResult = result.Result as ObjectResult;
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));

        }


    }
}

