using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UPSAssignment.Controller;
using Moq;

namespace Controller.Test
{
    [TestClass]
    public class UserControllerUnitTest
    {
        UsersController implementation;
        public UserControllerUnitTest()
        {
            var mockInterfaceDepen = new Mock<IUsersView>();
            implementation = new UsersController(mockInterfaceDepen.Object);  
        }

        //[TestMethod]
        //public void ShouldLoadAllProducts()
        //{
        //    _mockRepository.Setup(r => r.GetProducts()).Return(SomeProducts);

        //    var returnedProducts = _productController.GetProducts();

        //    Assert.Equals(returnedProducts, SomeProducts);
        //    _mockRepository.VerifyAll();
        //}
        [TestMethod]
        public void BindGridSuccessTestMethod()
        {
            implementation.LoadView(1); 
        }
    }
}
