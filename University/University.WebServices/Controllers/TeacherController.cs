namespace University.WebServices.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.JsonPatch;
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

        private readonly IMapper mapper;

        public TeacherController(ITeacherService service, IMapper mapper)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("for-group/{groupId}")]
        public IActionResult Filter([FromRoute] int groupId)
        {
            var result = this.service.GetTeachersByGroupId(groupId)
                .AsEnumerable()
                .Select(this.mapper.Map<Teacher, TeacherViewModel>);

            return this.Ok(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = this.service.GetAll()
                .AsEnumerable()
                .Select(this.mapper.Map<Teacher, TeacherDto>);

            return this.Ok(result);
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
        public IActionResult Create([FromBody] TeacherDto dto)
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

        /// <summary>
        /// Удаление объекта типа <see cref="Teacher"/>.
        /// </summary>
        /// <param name="id"> Идентификатор удаляемого объекта. </param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            this.service.Delete(id);
            return this.Ok(new { Id = id });
        }

        [HttpPatch("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] JsonPatchDocument<TeacherDto> teacherPatch)
        {
            if (!this.service.TryGet(id, out var targetTeacher))
            {
                return this.NotFound(new { Id = id });
            }

            var teacherDto = new TeacherDto
            {
                LastName = targetTeacher.Name.LastName,
                FirstName = targetTeacher.Name.FirstName,
                MiddleName = targetTeacher.Name.MiddleName,
            };

            teacherPatch.ApplyTo(teacherDto);

            // save targetTeacher

            return this.Ok(new { Id = id });
        }
    }
}
