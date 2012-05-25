using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using MyGojo.Data.Model;

namespace MyGojo.Data.EF.Repositories
{
    public class SiteInfoRepository
    {
        private readonly MyGojoContext context;
        private readonly IDbSet<SiteInfo> entities;


        public SiteInfoRepository(MyGojoContext context)
		{
			this.context = context;
			entities = context.Set<SiteInfo>();
		}


        public void InsertOrUpdate(SiteInfo siteInfo)
        {
            if (siteInfo.Id == default(int))
            {
                // New entity
                entities.Add(siteInfo);
            }
            else
            {
                // Existing entity
                context.Entry(siteInfo).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var siteInfo = context.Sites.Find(id);
            entities.Remove(siteInfo);
        }

        public void Save()
        {
            context.SaveChanges();
        }


        public SiteInfo Find(int id)
        {
            return entities.Find(id);
        }

        public SiteInfo Fetch(int id)
        {
            return All.Single(w => w.Id == id);
        }

        public SiteInfo FetchWhere(Expression<Func<SiteInfo, bool>> whereExpression)
        {
            return All.Where(whereExpression).FirstOrDefault();
        }

        public IQueryable<SiteInfo> All
        {
            get { return entities; }
        }

        public IEnumerable<SiteInfo> FetchAll()
        {
            return All.OrderBy(s => s.Priority);
        }

        public IQueryable<SiteInfo> AllIncluding(params Expression<Func<SiteInfo, object>>[] includeProperties)
        {
            return includeProperties.Aggregate<Expression<Func<SiteInfo, object>>, IQueryable<SiteInfo>>(context.Sites, (current, includeProperty) => current.Include(includeProperty));

            /* Verbose method code...
             *
                IQueryable<SiteInfo> query = context.SiteInfos;
                foreach (var includeProperty in includeProperties) {
                    query = query.Include(includeProperty);
                }
                return query;
             */
        }
    }
}
