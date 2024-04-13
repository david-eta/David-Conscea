using Conscea_Api.Data;
using Conscea_Api.Models;
using Conscea_Api.Models.DTOs;

namespace Conscea_Api.Services.Interfaces;

public interface IAccountService {


    public Task<string?> GetUsername(Guid accId);
    public Task<AccountActionResult> Create(
        string username, 
        string digestHexString, 
        string email, 
        string title, 
        string phone, 
        string grade, 
        string firstName, 
        string lastName, 
        string role); // creates user
    // public Task<AccountActionResult> Create(string username, string digestHexString); // creates user
    public Task<Tuple<AccountActionResult, Guid>> Login(string username, string digestHexString);
    public Task<bool> Logout(Guid accId);
    public Task<IEnumerable<Account>> GetAllAsync(); // see all users in db
    public Task DeleteUser(Guid id); // Delete user
}

public enum AccountActionResult {
    INVALID_USERNAME_LEN=-6,
    INVALID_USERNAME,
    INVALID_DIGEST,
    USERNAME_DNE,
    USERNAME_ALREADY_EXISTS,
    WRONG_PASSWORD,
    OKAY,
    EMAIL_ALREADY_TAKEN,
    NUMBER_ALREADY_TAKEN
}