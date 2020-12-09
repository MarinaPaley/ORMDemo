namespace University.WebServices.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using University.Domain;
    using University.Services;
    using University.WebServices.ViewModels;

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
        public IEnumerable<TeacherViewModel> Filter([FromRoute] int groupId)
        {
            return this.service.GetTeachersByGroupId(groupId).Select(t => new TeacherViewModel(t.Name));
        }

        [HttpGet]
        public IEnumerable<Teacher> GetAll()
        {
            return this.service.GetAll().ToList();
        }

        /// <summary>
        /// Создание объекта типа <see cref="Teacher"/>.
        /// </summary>
        /// <remarks>
        /// POST is NOT idempotent (<see cref="https://restfulapi.net/rest-put-vs-post/"/>)
        /// </remarks>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create([FromBody] TeacherDTO dto)
        {
            if (dto is null)
            {
                return this.Ok(new { Error = $"{nameof(dto)} is null" });
            }

            var teacher = this.service.Create(dto.LastName, dto.FirstName, dto.MiddleName);

            if (teacher is null)
            {
                return this.Ok(new { Error = $"{nameof(teacher)} is null" });
            }

            return this.Ok(new { Id = teacher.Id });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            this.service.Delete(id);
            return this.Ok(new { Id = id });
        }
    }
}
