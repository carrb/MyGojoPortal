using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MyGojo.Data.Model;

namespace MyGojo.Data.EF.Repositories
{
    public interface ISiteInfoRepository
    {
        void InsertOrUpdate(SiteInfo siteInfo);
        void Delete(int id);
        void Save();
        SiteInfo Find(int id);
        SiteInfo Fetch(int id);
        SiteInfo FetchWhere(Expression<Func<SiteInfo, bool>> whereExpression);
        IQueryable<SiteInfo> All { get; }
        IEnumerable<SiteInfo> FetchAll();
        IQueryable<SiteInfo> AllIncluding(params Expression<Func<SiteInfo, object>>[] includeProperties);
    }
}