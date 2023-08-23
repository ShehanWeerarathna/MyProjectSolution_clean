namespace MyProject.Domain.Entities
{
    public class Designation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
