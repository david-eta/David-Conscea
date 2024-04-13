using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;

namespace Conscea_Api.Models;


public class Account : IComparable<Account>
{
    [Required, Key]
    public Guid Id { get; set; }

    [Required, StringLength(32)]
    public string Username { get; set; }

    /* Password stored as SHA-256 hash code. */
    /* Password. 32 chars long seems like a prudent limit. */
    [Required, Column(TypeName = "varbinary(32)")]
    public byte[] ShaDigest { get; set; }

    [Required]
    public bool IsOnline { get; set; }

    [Required, EmailAddress]
    public string Email { get; set; }
    public string Title { get; set; }
    public List<string> Notes { get; set; }

    // public bool IsAdmin { get; set; }
    [StringLength(10)]
    public string? Mobile { get; set; }

    [StringLength(1)]
    public string? Grade { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Role { get; set; }

    // public ICollection<CertArchive> CertArchives { get; }

    public Account(string username, byte[] shaDigest, bool isOnline, string email, string title, string phone, string grade, string firstName, string lastName, string role) {
        this.Id = Guid.NewGuid();
        this.Username = username;
        this.ShaDigest = shaDigest;
        this.IsOnline = isOnline;
        this.Email = email;
        this.Title = title;
        if (phone == null) { this.Mobile = "XXX-XXX-XXXX"; }
        else { this.Mobile = phone; }

        if (grade == null) {  }
        else { this.Grade = grade; }

        if (firstName == null) {  }
        else { this.FirstName = firstName; }

        if (lastName == null) {  }
        else { this.LastName = lastName; }

        if (role == null) {  }
        else { this.Role = role; }


    }
    public Account(string username, byte[] shaDigest) {
        this.Id = Guid.NewGuid();
        this.Username = username;
        this.ShaDigest = shaDigest;
    }
    public Account() {}

    // comparison method to allow Item to be included in SortedSet
    public int CompareTo(Account? other)
    {
        // checks if other item is null or not
        if (other != null)
            return this.Id.CompareTo(other.Id); // compares by id
        
        // if null or otherwise, return 
        return 1;
    }
}
