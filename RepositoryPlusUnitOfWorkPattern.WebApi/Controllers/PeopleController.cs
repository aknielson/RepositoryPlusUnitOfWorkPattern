using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RepositoryPlusUnitOfWorkPattern.Domain.Models;
using RepositoryPlusUnitOfWorkPattern.Domain.RepositoryInterface;
using RepositoryPlusUnitOfWorkPattern.EFData;

namespace RepositoryPlusUnitOfWorkPattern.WebApi.Controllers
{
    public class PeopleController : ApiController
    {
        private IUnitOfWork _unitOfWork;
        public PeopleController():this(new UnitOfWork())
        {
            
        }

        public PeopleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: api/People
        public IEnumerable<Person> Get()
        {
            return _unitOfWork.People.GetAll();
        }

        // GET: api/People/5
        public Person Get(int id)
        {
            var person = _unitOfWork.People.Get(id);
            return person;
        }

        // POST: api/People
        public void Post([FromBody]string value)
        {
        }

        ///PUT: api/People/5
        public void Put(int id, [FromBody]string value)
        {
        }




        // DELETE: api/People/5
        public void Delete(int id)
        {
            var person = _unitOfWork.People.Get(id);
            _unitOfWork.People.Remove(person);
            _unitOfWork.Complete();
        }
    }
}
