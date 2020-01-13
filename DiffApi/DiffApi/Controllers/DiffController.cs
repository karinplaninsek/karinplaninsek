using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Net;
using DiffApi.Contracts;
using DiffApi.Models;

namespace DiffApi.Controllers
{
    [Route("v1/diff")]
    public class DiffController : ControllerBase
    {
        private readonly IDiffService _diffService;
        private readonly IStateService _stateService;

        public DiffController(IStateService stateService, IDiffService diffService)
        {
            _diffService = diffService;
            _stateService = stateService;
        }

        // gets result of the diff between v1/diff/left and v1/diff/right
        [HttpGet, Route("{id}")]
        public IActionResult GetResult([FromRoute] string id)
        {
            var left = _stateService.Get(id, Side.Left);

            if (left == null)
            {
                return NotFound();
            }

            var right = _stateService.Get(id, Side.Right);

            if (right == null)
            {
                return NotFound();
            }

            return Ok(_diffService.GetDiff(left, right));
        }

        // sets left or right side of diff arguments
        [HttpPut, Route("{id}/{side}")]
        public IActionResult Set([FromRoute] string id, [FromRoute] Side side, [FromBody] Diff diff)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _stateService.Set(id, side, diff.data);
            return StatusCode((int)HttpStatusCode.Created);
        }
    }
}
