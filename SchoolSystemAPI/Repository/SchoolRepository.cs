﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using SchoolSystemAPI.Data;
using SchoolSystemAPI.DTO;
using SchoolSystemAPI.Interfaces;
using SchoolSystemAPI.Models;

namespace SchoolSystemAPI.Repository
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly ApplicationDbContext _context;

        public SchoolRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get All Schools //
        public IEnumerable<School> GetAllSchools()
        {
            return _context.Schools.OrderBy(id => id).ToList();
        }

        // Get School by Id //
        public School? GetSchoolById(int Id)
        {
       
            var school = _context.Schools.Where(s => s.SchoolId == Id).FirstOrDefault();
            return school; 
        }

        // Update School //
        public School UpdateSchool(School school, School newSchool)
        {
      
            school.SchoolName = newSchool.SchoolName;
            school.Address = newSchool.Address;
            school.City= newSchool.City;
            school.State= newSchool.State;
            school.PostalCode= newSchool.PostalCode;

            _context.Schools.Attach(school);
            _context.SaveChanges();
            return school; 
        }

        // Create New School //
        public School CreateSchool(School school)
        {
           
            _context.Schools.Add(school);
            _context.SaveChanges();

            return school;
        }

        // Delete School by Id //
        public void DeleteSchool(School school)
        {
            _context.Remove(school);
            _context.SaveChanges();
        }

        // Does School Exist //
        public bool SchoolExists(int Id)
        {
            return _context.Schools.Any(s => s.SchoolId == Id);
        }

    }
}
