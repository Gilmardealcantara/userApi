using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using UsersAPI.Models;
using UsersAPI.Repository;

namespace UsersAPI.Controllers
{
  [Route("api/[Controller]")]

  public class UsersController : Controller
  {
    private readonly IUserRepository _userRepository;
    public UsersController(IUserRepository userRep)
    {
       Console.WriteLine("Init Users Controler");        
      _userRepository = userRep;
    }

    [HttpGet]
    public IEnumerable<User> GetAll()
    {
        return _userRepository.GetAll();
    }

    [HttpGet("{id}", Name="GetUser")]
    public IActionResult GetById(long id){
        var user  = _userRepository.Find(id);
        if(user == null) return NotFound();
        return new ObjectResult(user);
    }

    [HttpPost]
    public IActionResult Create([FromBody] User user)
    {
      if(user == null) return BadRequest();
      _userRepository.Add(user);
      return CreateAtRoute("GetUser", new User{UserId=user.UserId}, user);
    }

    private IActionResult CreateAtRoute(string v, User user1, User user2)
    {
      throw new NotImplementedException();
    }
  }
}