namespace Healthcare.Domain.Entities
{
    public class Patient : BaseEntity
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}