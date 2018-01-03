using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ContactApi.Dto;
using ContactApi.Models;
using ContactApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ContactApi.Controllers
{
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private readonly IContactsRepository ContactsRepo;
        private readonly IMapper _iMapper;

        public ContactsController(IContactsRepository _repo, IMapper iMapper)
        {
            ContactsRepo = _repo;
            _iMapper = iMapper;
        }

        [HttpGet("{skip}/{take}")]
        public async Task<IActionResult> GetContactsAsync(int skip, int take)
        {
            var result = await ContactsRepo.GetAllAsync(skip, take);

            var pagingres = PagingResult<ContactDto>.Create(_iMapper.Map<IEnumerable<ContactDto>>(result), await ContactsRepo.CountRecordsAsync());

            return Ok(pagingres);
        }

        [HttpGet("companies/{skip}/{take}")]
        public async Task<IActionResult> GetCompaniesAsync(int skip, int take)
        {
            var result = await ContactsRepo.GetCompaniesAsync(skip, take);

            var pagingres = new PagingResult
            {
                Data = result,
                Total = await ContactsRepo.CountRecordsAsync()
            };

            return Ok(pagingres);
        }

        [HttpGet("designations/{skip}/{take}")]
        public async Task<IActionResult> GetJTAsync(int skip, int take)
        {
            var result = await ContactsRepo.GetJTAsync(skip, take);

            var pagingres = new PagingResult
            {
                Data = _iMapper.Map<IEnumerable<ContactDto>>(result),
                Total = await ContactsRepo.CountRecordsAsync()
            };

            return Ok(pagingres);
        }

        [HttpGet("{id}", Name = "GetContacts")]
        public IActionResult GetById(int id)
        {
            var item = ContactsRepo.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Contacts item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            ContactsRepo.Add(item);
            return Ok("true");
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Contacts item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var contactObj = ContactsRepo.Find(id);
            if (contactObj == null)
            {
                return NotFound();
            }
            ContactsRepo.Update(item);
            return Ok(true);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ContactsRepo.Remove(id);

            return Ok("true");
        }
    }
}