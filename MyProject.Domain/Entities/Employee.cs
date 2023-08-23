namespace MyProject.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DesignationId { get; set; }
        public virtual Designation? Designation { get; set; }
    }
}
