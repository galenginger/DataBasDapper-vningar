using System.Data;
using MySql.Data.MySqlClient;
using Dapper;
using System.Data.Common;
class Program
{
    static void Main()
    {
        //skapa en connetionstring mot min databas
        string constring = File.ReadLines("Connectionstring.txt").First();


        //using IDbConnection connection = new MySqlConnection(


        //skapa ett IDbconnetion-objekt (dbcon) av MySQL-typ:
        using IDbConnection dbcon = new MySqlConnection(constring);

        //lägg in lärare:
        dbcon.Execute("INSERT INTO Teacher(Name, Email) VALUES ('Janne Långben', 'janne@suvnet.se');");

        //skapa en lista med teachers, fykk på den med data från ett result set
        //genom att anropa dapper-metoden Query()
        IEnumerable<Teacher> teachers = dbcon.Query<Teacher>("select Name, Email from Teacher;");

        //loopa igenom teachers-ienumerable (typ lista) och skriv ut :
        foreach (Teacher t in teachers)
        {
            Console.WriteLine($"Hello from {t.Name}, you can reach me at {t.Email};");
        }

    }
}