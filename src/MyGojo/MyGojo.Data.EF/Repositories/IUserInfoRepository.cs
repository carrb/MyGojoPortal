using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MyGojo.Data.Model;

namespace MyGojo.Data.EF.Repositories
{
    public interface IUserInfoRepository
    {
        void InsertOrUpdate(UserInfo userInfo);
        void Delete(int id);
        void Save();
        UserInfo Find(int id);
        UserInfo Fetch(int id);
        UserInfo FetchWhere(Expression<Func<UserInfo, bool>> whereExpression);
        IQueryable<UserInfo> All { get; }
        IEnumerable<UserInfo> FetchAll();
        IQueryable<UserInfo> AllIncluding(params Expression<Func<UserInfo, object>>[] includeProperties);
    }
}