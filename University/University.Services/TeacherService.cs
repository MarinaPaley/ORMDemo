﻿namespace University.Services
{
    using System;
    using System.Linq;
    using University.Domain;
    using University.NH.Repositories;

    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository repository;

        private readonly IGroupService groupService;

        public TeacherService(ITeacherRepository repository, IGroupService groupService)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.groupService = groupService ?? throw new ArgumentNullException(nameof(groupService));
        }

        public IQueryable<Teacher> GetAll()
        {
            return this.repository.GetAll();
        }

        public IQueryable<Teacher> GetTeachersByGroupId(int groupId)
        {
            if (!this.groupService.TryGet(groupId, out var targetGroup))
            {
                return Enumerable.Empty<Teacher>().AsQueryable();
            }

            return repository.Filter(t => t.Groups.Contains(targetGroup));
        }
    }
}