namespace EduSchedule
{
    public class Schedule
    {
        public int Id { get; set; }
        public int Day { get; set; }
        public int Period { get; set; }
        public string Group { get; set; }
        public string Discipline { get; set; }
        public string Teacher { get; set; }
        public string Room { get; set; }
    }

    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Discipline
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Room
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Type { get; set; }
    }
}