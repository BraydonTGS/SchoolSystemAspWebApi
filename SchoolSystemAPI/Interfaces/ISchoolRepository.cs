﻿using SchoolSystemAPI.Models;

namespace SchoolSystemAPI.Interfaces
{
    public interface ISchoolRepository
    {
        public IEnumerable<School> GetAllSchools();
        public School? GetSchoolById(int Id);
        public bool SchoolExists(int Id); 
    }
}
