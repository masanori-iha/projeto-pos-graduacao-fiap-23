namespace _4_DM2.Learning.Domain.Entities;

public class UserImage
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; }
}
