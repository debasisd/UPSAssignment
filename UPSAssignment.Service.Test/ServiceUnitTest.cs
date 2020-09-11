using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UPSAssignment.Model;

namespace UPSAssignment.Service.Test
{
    [TestClass]
    public class ServiceUnitTest
    {
        IService implementation;

        public ServiceUnitTest()
        {
            implementation = new Service();
            implementation.SetConfiguration("https://gorest.co.in/public-api", "d53ded72dc1886bb0d0ddfec5bb4dc6f1b1958b78153098504a1d3171b1e12a1");

        }
        [TestMethod]
        public void GetTestMethod()
        {
            int userId = 2005;
            Model.UserInfoResponse response = new Model.UserInfoResponse();
            Task.Run(async () =>
            {
                response = await implementation.GetUser(userId);
            }).GetAwaiter().GetResult();

            Assert.AreEqual(response.IsSuccess, true);
        }

        [TestMethod]
        public void InsertSuccessTestMethod()
        {
            User info = new User("John Doe", 0, "JohnDoe@test.com", User.SexOfPerson.Male, User.UserStatus.Active);
            Model.OperationResponse response = new Model.OperationResponse();
            Task.Run(async () =>
            {
                response = await implementation.SaveUser(info);
            }).GetAwaiter().GetResult();

            Assert.AreEqual(response.IsSuccess, true);
        }

        [TestMethod]
        public void InsertFailTestMethod()
        {
            User info = new User("John Doe", 0, "JohnDoe@test.com", User.SexOfPerson.Male, User.UserStatus.Active);
            Model.OperationResponse response = new Model.OperationResponse();
            Task.Run(async () =>
            {
                response = await implementation.SaveUser(info);
            }).GetAwaiter().GetResult();

            Assert.AreEqual(response.IsSuccess, false);
        }

        [TestMethod]
        public void UpdateSuccessTestMethod()
        {
            User info = new User("John Doe", 2020, "JohnDoe@test.com", User.SexOfPerson.Male, User.UserStatus.Active);
            Model.OperationResponse response = new Model.OperationResponse();
            Task.Run(async () =>
            {
                response = await implementation.SaveUser(info);
            }).GetAwaiter().GetResult();

            Assert.AreEqual(response.IsSuccess, true);
        }

        [TestMethod]
        public void EmailIdExistTestMethod()
        {
            User info = new User("John Doe", 2020, "test@test.com", User.SexOfPerson.Male, User.UserStatus.Active);
            Model.OperationResponse response = new Model.OperationResponse();
            Task.Run(async () =>
            {
                response = await implementation.SaveUser(info);
            }).GetAwaiter().GetResult();

            Assert.AreEqual(response.IsSuccess, false);
        }

        [TestMethod]
        public void ParameterValueMissingTestMethod()
        {
            User info = new User("", 0, "test@test.com", User.SexOfPerson.NA, User.UserStatus.NA);
            Model.OperationResponse response = new Model.OperationResponse();
            Task.Run(async () =>
            {
                response = await implementation.SaveUser(info);
            }).GetAwaiter().GetResult();

            Assert.AreEqual(response.IsSuccess, false);
        }



        [TestMethod]
        public void DeleteSuccessTestMethod()
        {
            int userIdToDelete = 2020;
            Model.OperationResponse response = new Model.OperationResponse();
            Task.Run(async () =>
            {
                response = await implementation.DeleteUser(userIdToDelete);
            }).GetAwaiter().GetResult();

            Assert.AreEqual(response.IsSuccess, true);
        }

        [TestMethod]
        public void SearchSuccessTestMethod()
        {
            User search = new User("", 0, "JohnDoe@test.com", User.SexOfPerson.NA, User.UserStatus.NA);
            Model.UserListResponse response = new Model.UserListResponse();
            Task.Run(async () =>
            {
                response = await implementation.SearchUser(search);
            }).GetAwaiter().GetResult();

            Assert.AreEqual(response.IsSuccess && response.UserInfoList.Count > 0, true);
        }

        [TestMethod]
        public void ListSuccessTestMethod()
        {
            Model.UserListResponse response = new Model.UserListResponse();
            Task.Run(async () =>
            {
                response = await implementation.GetUserList(1);
            }).GetAwaiter().GetResult();

            Assert.AreEqual(response.IsSuccess && response.UserInfoList.Count > 0, true);
        }
    }
}
