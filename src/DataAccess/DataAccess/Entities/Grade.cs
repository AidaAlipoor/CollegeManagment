namespace DataAccess.Entities
{
    public class Grade
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public virtual Student Students { get; set; }
        public virtual TeacherCourse TeacherCourse { get; set; }

        public const int ScoreLengthLimit = 20;
    }
}
