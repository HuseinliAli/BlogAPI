﻿using Application.RequestShapers;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories;
public interface IBlogPostRepository : IGenericRepository<BlogPost,int>
{
    Task<PagedList<BlogPost>> GetPostsAsync(RequestParameters request);
}
