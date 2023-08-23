namespace MyProject.Application.DTOs
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DesignationId { get; set; }
        public virtual DesignationDto? Designation { get; set; }
        public List<DropDownDto>? DesignationList { get; set; }
    }
}
