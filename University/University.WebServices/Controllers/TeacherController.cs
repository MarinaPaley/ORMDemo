namespace University.WebServices.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using University.Domain;
    using University.Services;

    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService service;

        public TeacherController(ITeacherService service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet("for-group/{groupId}")]
        public IEnumerable<Teacher> Filter([FromRoute] int groupId)
        {
            return this.service.GetTeachersByGroupId(groupId);
        }

        [HttpGet]
        public IEnumerable<Teacher> GetAll()
        {
            return this.service.GetAll().ToList();
        }
    }
}
