using System.ComponentModel.DataAnnotations;
using Conscea_Api.Models;
using Conscea_Api.Models.DTOs;
using Conscea_Api.Services;
using Conscea_Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Conscea_Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase {
    private readonly AccountService _accountService;
    public AccountController(AccountService accountService) {
        _accountService = accountService;
    }

    [HttpGet("Usernames/{id}")]
    public async Task<IActionResult> GetUsername(Guid id) {
        string? username = await _accountService.GetUsername(id);
        return username is null ? NotFound() : Ok(username);
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([Required] string username, [Required] [FromBody] string hexHash) {
        Tuple<AccountActionResult, Guid> outcome = await _accountService.Login(username, hexHash);

        if (0 > outcome.Item1) {
            return outcome.Item1 switch {
                AccountActionResult.USERNAME_DNE => NotFound("User with given username does not exist."),
                AccountActionResult.INVALID_DIGEST => BadRequest("Malformed SHA256 digest in request body."),
                AccountActionResult.WRONG_PASSWORD => BadRequest("Wrong password."),
                _ => BadRequest("Undefined state."),
            };
        }
        return Ok(outcome.Item2);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create([Required] string username, [Required] [FromBody] string hexHash,string email, string title, string phone, string grade, string firstName, string lastName, string role) {
        AccountActionResult outcome = await _accountService.Create(username, hexHash, email, title, phone, grade, firstName, lastName, role);
        if (0 > outcome) {
            return outcome switch  {
                AccountActionResult.INVALID_USERNAME_LEN => 
                    BadRequest("Invalid username. Username " + 
                        (username.Length==0 ? "too short." : "too long.")),
                AccountActionResult.INVALID_USERNAME => 
                    BadRequest("Invalid username. Username can only contain "
                        + "letters, numbers, and underscores."),
                AccountActionResult.USERNAME_ALREADY_EXISTS =>
                    BadRequest("Username already taken."),
                AccountActionResult.EMAIL_ALREADY_TAKEN =>
                    BadRequest("Email already taken."),
                AccountActionResult.NUMBER_ALREADY_TAKEN =>
                    BadRequest("Phone number already taken."),
                AccountActionResult.INVALID_DIGEST =>
                    BadRequest("Malformed SHA256 digest in request body."),
                _ => BadRequest("Undefined state."),

            };
        }

        return Ok();
    }
    [HttpPost("Logout")]
    public async Task<IActionResult> Logout([Required] Guid accountId) {
        bool outcome = await _accountService.Logout(accountId);
        return outcome ? Ok("Successfully logged out user.") : NotFound("No online users found with matching account ID.");
    }

    [HttpGet("GetAllAccounts")]
    public async Task<SortedSet<Account>> GetAllUsers() {
        var accounts = await _accountService.GetAllAsync();
        return new SortedSet<Account>(accounts);    
    }



}