using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using MyGojo.Data.Model;

namespace MyGojo.Data.EF.Repositories
{
    public class UserInfoRepository : IUserInfoRepository
    {
        private readonly MyGojoContext context;
        private readonly IDbSet<UserInfo> entities;


        public UserInfoRepository(MyGojoContext context)
		{
			this.context = context;
			entities = context.Set<UserInfo>();
		}


        public void InsertOrUpdate(UserInfo userInfo)
        {
            if (userInfo.Id == default(int))
            {
                // New entity
                entities.Add(userInfo);
            }
            else
            {
                // Existing entity
                context.Entry(userInfo).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var userInfo = context.Users.Find(id);
            entities.Remove(userInfo);
        }

        public void Save()
        {
            context.SaveChanges();
        }


        public UserInfo Find(int id)
        {
            return entities.Find(id);
        }

        public UserInfo Fetch(int id)
        {
            return All.Single(w => w.Id == id);
        }

        public UserInfo FetchWhere(Expression<Func<UserInfo, bool>> whereExpression)
        {
            return All.Where(whereExpression).FirstOrDefault();
        }

        public IQueryable<UserInfo> All
        {
            get { return entities; }
        }

        public IEnumerable<UserInfo> FetchAll()
        {
            return All.OrderBy(u => u.AdLogin);
        }

        public IQueryable<UserInfo> AllIncluding(params Expression<Func<UserInfo, object>>[] includeProperties)
        {
            return includeProperties.Aggregate<Expression<Func<UserInfo, object>>, IQueryable<UserInfo>>(context.Users, (current, includeProperty) => current.Include(includeProperty));

            /* Verbose method code...
             *
                IQueryable<UserInfo> query = context.UserInfos;
                foreach (var includeProperty in includeProperties) {
                    query = query.Include(includeProperty);
                }
                return query;
             */
        }
    }
}
