using SQLite;

namespace Homework11.Models
{
    public class JokeItem
        {
            [PrimaryKey, AutoIncrement]
            public int ID { get; set; }
            public string Name { get; set; }
            public string Joke { get; set; }
            public bool Done { get; set; }
        }
    }
