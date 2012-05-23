using System;
using AutoMapper;

namespace MyGojo.Web.Infrastructure.AutoMapper.Profiles.Resolvers
{
	public class StringToGuidConverter : TypeConverter<string, Guid>
	{
		protected override Guid ConvertCore(string source)
		{
			Guid guid;
			return Guid.TryParse(source, out guid) == false ? Guid.Empty : guid;
		}
	}

	public class StringToNullableGuidConverter : TypeConverter<string, Guid?>
	{
		protected override Guid? ConvertCore(string source)
		{
			Guid guid;
			if (Guid.TryParse(source, out guid) == false)
				return null;
			return guid;
		}
	}
}