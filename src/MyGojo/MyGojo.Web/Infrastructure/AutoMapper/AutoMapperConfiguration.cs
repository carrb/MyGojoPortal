using System;
using System.Web.Mvc;
using AutoMapper;
using MyGojo.Web.Infrastructure.AutoMapper.Profiles.Resolvers;

namespace MyGojo.Web.Infrastructure.AutoMapper
{
	public class AutoMapperConfiguration
	{
		public static void Configure()
		{
		    Mapper.CreateMap<string, MvcHtmlString>().ConvertUsing<MvcHtmlStringConverter>();
			Mapper.CreateMap<Guid, string>().ConvertUsing<GuidToStringConverter>();
			Mapper.CreateMap<DateTimeOffset, DateTime>().ConvertUsing<DateTimeTypeConverter>();
		}
	}
}