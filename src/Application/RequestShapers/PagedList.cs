﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RequestShapers;
public class PagedList<T>:List<T>
{
    public MetaData MetaData { get; set; }
    public PagedList(List<T>items,int count,int pageNumber,int pageSize)
    {
        MetaData=new()
        {
            TotalCount=count,
            PageSize=pageSize,
            CurrentPage=pageNumber,
            TotalPages=(int)Math.Ceiling(count/(double)pageSize)
        };
        AddRange(items);
    }

    public static PagedList<T> ToPagedList(IEnumerable<T>source,int pageNumber,int pageSize)
    {
        var count = source.Count();
        var items = source.Skip((pageNumber-1)*pageSize).Take(pageSize).ToList();
        return new(items, count, pageNumber, pageSize);
    }
}
