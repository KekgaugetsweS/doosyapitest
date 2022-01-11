﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Doosy.Framework.Domain
{
    public static class PagedDataExtension
    {
        public static PagedDataResponce<TModel> Paginate<TModel>(
            this IEnumerable<TModel> query,
            int page,
            int limit = 10
            )
            where TModel : class
        {

            var paged = new PagedDataResponce<TModel>();

            page = (page <= 0) ? 1 : page;

            paged.CurrentPage = page;
            paged.PageSize = limit;

            var totalItemsCountTask = query.Count();

            var startRow = (page - 1) * limit;
            paged.Items = query
                       .Skip(startRow)
                       .Take(limit)
                       .ToList();

            var exactNumberOfPages = totalItemsCountTask / limit;
            var numberOfPages = int.Parse(exactNumberOfPages.ToString());


            var UpperLimitDiplayOne = 0;
            var LimitDiplayOne = 0;

            if (page == 1)
            {
                LimitDiplayOne = 1;
                UpperLimitDiplayOne = limit;
            }
            else
            {
                UpperLimitDiplayOne = limit * page;
                LimitDiplayOne = UpperLimitDiplayOne - limit;
            }

            if (page == 1)
                paged.PreviousPage = 1;
            else
                paged.PreviousPage = page - 1;

            var currentItemCount = paged.Items.Count;

            if (totalItemsCountTask < UpperLimitDiplayOne)
            {
                paged.NextPage = page;
                UpperLimitDiplayOne = totalItemsCountTask;
            }
            else
            {
                paged.NextPage = page + 1;
            }



            paged.TotalItems = totalItemsCountTask;

            paged.DisplayingText = $"{LimitDiplayOne} - {UpperLimitDiplayOne} of {totalItemsCountTask}";

            paged.TotalPages = (int)Math.Ceiling(paged.TotalItems / (double)limit);

            return paged;
        }
    }
}
