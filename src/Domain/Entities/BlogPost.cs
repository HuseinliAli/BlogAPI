using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class BlogPost:BaseEntity<int>
{
    public string ThumbnailImagePath { get; set; }
    public string Subject { get; set; }
    public string Content { get; set; }
    public long ViewCount{ get; set; }

    public Guid CreatedBy { get; set; }
    public Guid DeletedBy { get; set; }
}
