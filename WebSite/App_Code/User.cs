using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Vartotojo klasė sauganti esminius duomenis apie vartotoją
/// </summary>
public class User
{
    public int UserID { get; set; }
    public string Username { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime BirthdayDate { get; set; }
    public string Email { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public char UserRole { get; set; }

    public User()
    {
        
    }

    public User(int user_id, string username, string name, string surname, DateTime birthday_date,
        string email, string city, string country, char userrole)
    {
        this.UserID = user_id;
        this.Username = username;
        this.Name = name;
        this.Surname = surname;
        this.BirthdayDate = birthday_date;
        this.Email = email;
        this.City = city;
        this.Country = country;
        this.UserRole = userrole;
    }

    public override string ToString()
    {
        return String.Format("ID: {0}, Username: {1}, Vardas: {2}, Pavardė: {3}, Gim. data: {5}, El. paštas: {6}, Miestas: {7}, Šalis: {8}",
            UserID, Username, Name, Surname, BirthdayDate, Email, City, Country);
    }
}