using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepositoryPlusUnitOfWorkPattern.Domain.Models;
using RepositoryPlusUnitOfWorkPattern.Domain.RepositoryInterface;
using RepositoryPlusUnitOfWorkPattern.EFData;

namespace DbIntegrationTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetPerson()
        {
            IUnitOfWork unitOfWork = CreateUnitOfWork();
            var person = unitOfWork.People.Get(1);
            person.LastName.Should().Be("Nielson");


        }
        [TestMethod]
        public void GetAllPeople()
        {
            IUnitOfWork unitOfWork = CreateUnitOfWork();
            var sheeple = unitOfWork.People.GetAll();
            sheeple.Should().NotBeNullOrEmpty();
            sheeple.FirstOrDefault().Address.Should().NotBeNull();
            sheeple.FirstOrDefault().Phones.FirstOrDefault().Should().NotBeNull();
        }

        [TestMethod]
        public void GetPersonsByName()
        {
            IUnitOfWork unitOfWork = CreateUnitOfWork();
            var personToUpdate = unitOfWork.People.Find(x => x.LastName.Equals("Christ"));
            personToUpdate.Should().NotBeNull();
            Assert.IsTrue(personToUpdate.Any());

        }

        [TestMethod]
        public void GetSinglePersonByName()
        {
            IUnitOfWork unitOfWork = CreateUnitOfWork();
            var personToUpdate = unitOfWork.People.SingleOrDefault(x => x.LastName.Equals("Nielson"));
            personToUpdate.Should().NotBeNull();
            
            Assert.IsTrue(personToUpdate.LastName.Equals("Nielson"));

        }

     

       

        [TestMethod]
        public void InsertFullPerson()
        {
            Person newguy = new Person
            {
                FirstName = "Dan",
                LastName = "Christ",
                EmailAddress = "Dan@Christ.com",
                MiddleName = "Dexter"
            };
            newguy.Address = new Address
            {
                Street1 = "111 first Street",
                City = "New York",
                State = "CO",
                PostalCode = "22222"
            };
            newguy.Phones = new List<Phone>
            {
                new Phone {PhoneNumber = "5554443333", PhoneTypeId = (int)PhoneTypeEnum.Home}
            };

            IUnitOfWork unitOfWork = CreateUnitOfWork();
            unitOfWork.People.Add(newguy);
            unitOfWork.Complete();

            var sheeple = unitOfWork.People.GetAll();

            sheeple.Should().NotBeNullOrEmpty();



        }

        [TestMethod]
        public void UpdatePerson()
        {
            IUnitOfWork unitOfWork = CreateUnitOfWork();
            var ourguy = unitOfWork.People.Get(17);

            ourguy.LastName = "Yash";
            unitOfWork.Complete();

            var mrYash = unitOfWork.People.Find(x => x.LastName.Equals("Yash"));
            mrYash.Should().NotBeNullOrEmpty();


        }

        [TestMethod]
        public void UpdatePersonsAddress()
        {
            IUnitOfWork unitOfWork = CreateUnitOfWork();
            var ourguy = unitOfWork.People.Get(22);

            ourguy.Address.City = "Yonkers";
            unitOfWork.Complete();

           


        }

        [TestMethod]
        public void DeleteSomething()
        {
            IUnitOfWork unitOfWork = CreateUnitOfWork();
            var asdf = unitOfWork.People.Get(23);
            if (asdf.Phones.Any())
                unitOfWork.Phones.RemoveRange(asdf.Phones);
            unitOfWork.People.Remove(asdf);
            unitOfWork.Complete();


        }




        private IUnitOfWork CreateUnitOfWork()
        {
            return new UnitOfWork();
        }
    }
}
