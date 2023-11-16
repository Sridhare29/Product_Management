using System;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProductManagement.Controllers;
using ProductManagement.Repositories;
using ProductManagement.Entities;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Models.DTO;

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
            _productRepositoriesMock = new Mock<IProductRepositories>();
            _productMapperMock = new Mock<IMapper>();
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
            productMockData(_productRepositoriesMock.Object, _productMapperMock.Object);
            var result = _productController.GetAll();

            var okResult = result.Result as OkObjectResult;
            Assert.AreEqual(200, okResult?.StatusCode);

        }

        [TestMethod]
        public void GetById_Success()
        {
            Guid Id = Guid.Parse("106ca5a2-4cf1-48cc-06d5-08dbe3a83d27");
            Product product = new Product()
            {
                Id = Guid.Parse("106ca5a2-4cf1-48cc-06d5-08dbe3a83d27"),
                Name = "Mac",
                Description = "Hello Mac!",
                Price = 2000,
                ProductImageUrl = "mac.jpg",
                CategoryId = Guid.Parse("3dda4c07-27bf-45d9-95ea-1350c4ddd971")
            };
            _productRepositoriesMock = new Mock<IProductRepositories>();
            _productMapperMock = new Mock<IMapper>();
            _productRepositoriesMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(product);
            productMockData(_productRepositoriesMock.Object, _productMapperMock.Object);

            var result = _productController.GetById(Id);

            var okResult = result.Result as OkObjectResult;
            Assert.AreEqual(200, okResult?.StatusCode);
        }

        [TestMethod]
        public void GetById_Null()
        {
            Guid productId = Guid.NewGuid();
            _productRepositoriesMock = new Mock<IProductRepositories>();
            _productMapperMock = new Mock<IMapper>();

            _productRepositoriesMock.Setup(repo => repo.GetByIdAsync(productId)).ReturnsAsync((Product?)null);

            var result = _productController.GetById(productId);

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));

        }

        [TestMethod]
        public void Post_success()
        {
            AddProductRequestDto addProductRequestDto = new AddProductRequestDto()
            {
                Name = "Mac",
                Description = "Hello Mac!",
                Price = 2000,
                ProductImageUrl = "mac.jpg",
                CategoryId = Guid.Parse("3dda4c07-27bf-45d9-95ea-1350c4ddd971")
            };
            Product product = new Product()
            {
                Name = "Mac",
                Description = "Hello Mac!",
                Price = 2000,
                ProductImageUrl = "mac.jpg",
                CategoryId = Guid.Parse("3dda4c07-27bf-45d9-95ea-1350c4ddd971")

            };
            _productRepositoriesMock = new Mock<IProductRepositories>();
            _productMapperMock = new Mock<IMapper>();
            _productRepositoriesMock.Setup(x => x.CreateAsync(It.IsAny<Product>())).ReturnsAsync(product);
            productMockData(_productRepositoriesMock.Object, _productMapperMock.Object);

            var result = _productController.Create(addProductRequestDto);

            var okResult = result.Result as OkObjectResult;
            Assert.AreEqual(200, okResult?.StatusCode);

        }

        [TestMethod]
        public void Post_Invalid()
        {
            AddProductRequestDto addProductRequestDto = new AddProductRequestDto()
            {
                Name = null,
                Description = "Hello Mac!",
                Price = -123,
                ProductImageUrl = "mac.jpg",
                CategoryId = Guid.Parse("3dda4c07-27bf-45d9-95ea-1350c4ddd971")
            };
            Product product = new Product()
            {
                Name = "Mac",
                Description = "Hello Mac!",
                Price = 123,
                ProductImageUrl = "mac.jpg",
                CategoryId = Guid.Parse("3dda4c07-27bf-45d9-95ea-1350c4ddd971")

            };
            _productRepositoriesMock = new Mock<IProductRepositories>();
            _productMapperMock = new Mock<IMapper>();
            _productRepositoriesMock.Setup(x => x.CreateAsync(It.IsAny<Product>())).ReturnsAsync(product);
            productMockData(_productRepositoriesMock.Object, _productMapperMock.Object);

            var result = _productController.Create(addProductRequestDto);

            var okResult = result.Result as ObjectResult;
            Assert.AreEqual(200, okResult?.StatusCode);

        }

        [TestMethod]
        public async Task update_success()
        {
            var productId = Guid.NewGuid();
            var updateProductRequestDto = new UpdateProductRequestDto
            {
            };

            var existingProduct = new Product
            {
                Id = productId,
            };
            _productRepositoriesMock = new Mock<IProductRepositories>();
            _productMapperMock = new Mock<IMapper>();
            productMockData(_productRepositoriesMock.Object, _productMapperMock.Object);
            _productRepositoriesMock.Setup(x => x.UpdateAsync(productId, It.IsAny<Product>())).ReturnsAsync(existingProduct);


            var result = await _productController.update(productId, updateProductRequestDto);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(200, okResult.StatusCode);

        }

        [TestMethod]
        public async Task update_NotFound()
        {
            Guid productId = Guid.NewGuid();
            var updateProductRequestDto = new UpdateProductRequestDto
            {
            };
            _productRepositoriesMock = new Mock<IProductRepositories>();
            _productMapperMock = new Mock<IMapper>();
            productMockData(_productRepositoriesMock.Object, _productMapperMock.Object);

            _productRepositoriesMock.Setup(x => x.UpdateAsync(productId, It.IsAny<Product>())).ReturnsAsync((Product?)null);

            var result = await _productController.update(productId, updateProductRequestDto);

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
            var notFoundResult = (NotFoundResult)result;
            Assert.AreEqual(404, notFoundResult.StatusCode);
        }


        [TestMethod]
        public async Task Delete_Success()
        {
            var productId = Guid.NewGuid();

            var existingProduct = new Product
            {
                Id = productId,
            };
            _productRepositoriesMock = new Mock<IProductRepositories>();
            _productMapperMock = new Mock<IMapper>();
            productMockData(_productRepositoriesMock.Object, _productMapperMock.Object);

            _productRepositoriesMock.Setup(x => x.DeleteAsync(productId)).ReturnsAsync(existingProduct);

            var result = await _productController.Delete(productId);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [TestMethod]
        public async Task Delete_NotFound()
        {
            var productId = Guid.NewGuid();
            _productRepositoriesMock = new Mock<IProductRepositories>();
            _productMapperMock = new Mock<IMapper>();
            productMockData(_productRepositoriesMock.Object, _productMapperMock.Object);

            _productRepositoriesMock.Setup(x => x.DeleteAsync(productId)).ReturnsAsync((Product)null);

            var result = await _productController.Delete(productId);

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
            var notFoundResult = (NotFoundResult)result;
            Assert.AreEqual(404, notFoundResult.StatusCode);
        }
    }
}

