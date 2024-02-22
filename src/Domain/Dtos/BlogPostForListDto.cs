using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public record BlogPostForListDto(int Id, string ImageUrl,string Subject,long ViewCount,int LikeCount,int DislikeCount,DateTime CreatedAt);
    public record BlogPostForDetailDto(int Id, string ImageUrl,string Subject, string Content,long ViewCount, int LikeCount, int DislikeCount, DateTime CreatedAt);
}
