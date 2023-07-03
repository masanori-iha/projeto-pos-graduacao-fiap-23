using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5._1_DM2.Learning.Infra.Azure.Storage.Dtos
{
    public class BlobDto
    {
        public string? Uri { get; set; }
        public string Name { get; set; }
        public string? ContentType { get; set; }
        public Stream? Content { get; set; }
    }
}
