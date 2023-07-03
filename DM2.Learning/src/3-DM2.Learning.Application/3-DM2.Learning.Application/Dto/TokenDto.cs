namespace _3_DM2.Learning.Application.Dto
{
    public class TokenDto
    {
        public string Value { get; set; }

        public TokenDto() { }

        public TokenDto(string token)
        {
            Value = token;
        }
    }
}
