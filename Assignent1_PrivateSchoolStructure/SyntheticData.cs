using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignent1_PrivateSchoolStructure
{
    public static class SyntheticData
    {
        public static List<string> FirstNames = new List<string>()
            {
                "Stergios","Giwrgos","Stefanos", "Nikos","Manolis","Themistoklis","Periklis", "Petros",
                "Stathis","Haris","Alexandros", "Mpampis", "Thanasis", "Vasilios", "Konstantinos", "Merkourios", "Andreas",
                "Dimitrios", "Thomas", "Lampros", "Filippos", "Marios", "Aggelos", "Eleptherios", "Evgenios", "Antonios",

            };

        public static List<string> LastNames = new List<string>()
            {
                "Dimas","Lykoudis","Pritsinas","Aidinopoulos","Drakakis","Tsikalakis","Stavrou","Manolopoulos",
                "Papadopoulos","Menidiatis","Fragkiadakis","Alexopoulos","Pantazis","Papadelis","Aksarlis","Zoidis",
                "Gyftonikolos", "Tsigaridas", "Mprokolakis", "Mpokolinis", "Koutzamapasis", "Tsironis", "Zaravelis",
                "Apostolopoulos", "Mavridis", "Kremydakis", "Georgiadis", "Mastorakis"
            };

        public static List<string> CourseTitles = new List<string>()
            {
                "OOP Fundamentals","Collections Fundamentals","Advanced Topics","Design Patterns",
                "Game Development","Introduction to AI and Machine Learning","Introduction to Web Development",
                "Introduction to Web Design","Web Development in Depth","Web Design in Depth", "Fast coding techniques",
                "Learn to build e-shops from scratch", "Become an entry level full stack developer", "Principles of Software Design",
                "Introduction to HTML and CSS", "From zero to hero(Front end development)"
            };

        public static List<string> AssignmentDescriptions = new List<string>()
            {
                "Design a drive through Kiosk","Design a private school structure","Design kino game","Design an RPG game",
                "Design a calculator","Design a national election system","Design an aircraft simulation system",
                "Design an AI robot", "Design an FPS game", "Design a weather info site"
            };

        public static List<string> TrainerSubjects = new List<string>()
            {
                "Data Science",
                "Databases",
                "AI",
                "Machine Learning",
                "Algorithms",
                "Project management"
            };
    }
}
