namespace _3_DM2.Learning.Application.ViewModels;

public class UserViewModel
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
    public UserImageViewModel? UserImage { get; set; }
}

public class UserImageUpdateViewModel
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
    public UserImageViewModel? UserImage { get; set; }
}
