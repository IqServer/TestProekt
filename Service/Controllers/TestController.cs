using Microsoft.AspNetCore.Mvc;
using models;
using services;

namespace controllers;

class TestController : ControllerBase
{
    StudentService _studentService;
    public TestController(StudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpGet]
    public void GenerateStudent()
    {
      
        _studentService.GenerateStudent();
    }
}