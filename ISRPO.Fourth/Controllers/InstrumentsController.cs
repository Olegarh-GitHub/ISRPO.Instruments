using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISRPO.Fourth.Domain.Models;
using ISRPO.Fourth.Domain.Repositories.Base;
using ISRPO.Fourth.DTO;
using ISRPO.Fourth.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ISRPO.Fourth.Controllers
{
    [Route("[controller]")]
    public class InstrumentsController : Controller
    {
        private readonly InstrumentService _instrumentService;

        public InstrumentsController(InstrumentService instrumentService)
        {
            _instrumentService = instrumentService;
        }
        
        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create(InstrumentDTO instrument)
        {
            var result = await _instrumentService.Create(instrument);

            return Json(result);
        }

        [Route("read")]
        [HttpGet]
        public IActionResult Read()
        {
            var result = _instrumentService.Read();

            return Json(result);
        }

        [Route("update")]
        [HttpPut]
        public async Task<IActionResult> Update(InstrumentDTO instrument)
        {
            var result = await _instrumentService.Update(instrument);

            return Json(result);
        }

        [Route("delete/")]
        [HttpDelete]
        public async Task<IActionResult> Delete(InstrumentDTO instrument)
        {
            var deleted = await _instrumentService.Delete(instrument);

            return Json(new {result = deleted});
        }

        [Route("image/{id:int}")]
        [HttpGet]
        public async Task<IActionResult> GetImage(int id)
        {
            var instrument = (await _instrumentService.Read().ToListAsync()).FirstOrDefault(x => x.Id == id);;

            return Json(new {image = instrument?.Image});
        }
    }
}