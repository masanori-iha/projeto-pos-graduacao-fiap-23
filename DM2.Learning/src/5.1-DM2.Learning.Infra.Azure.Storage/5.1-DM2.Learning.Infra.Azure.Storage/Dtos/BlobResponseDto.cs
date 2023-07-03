namespace _5._1_DM2.Learning.Infra.Azure.Storage.Dtos
{
    public class BlobResponseDto
    {
        public BlobResponseDto()
        {
            Blob = new BlobDto();
        }

        public string? Status { get; set; }
        public bool Error { get; set; }
        public BlobDto Blob { get; set; }
    }
}
