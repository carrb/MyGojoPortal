using System;
using AutoMapper;

namespace MyGojo.Web.Infrastructure.AutoMapper.Profiles.Resolvers
{
    public class GuidToStringConverter : TypeConverter<Guid, string>
    {
        protected override string ConvertCore(Guid source)
        {
            return source.ToString("N");
        }
    }
}
