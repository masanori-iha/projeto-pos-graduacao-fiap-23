namespace _4_DM2.Learning.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; } 
    public UserImage? UserImage { get; set; } 
}
