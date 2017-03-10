using System;
using AutoMapper;
using AutoMapperByExample;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoMapperTests
{
	public class Person2RosterConverter: ITypeConverter<Roster, Person2>
	{
		public Person2 Convert(Roster source, Person2 destination, ResolutionContext context)
		{
			return new Person2()
			{
			Email = source.Person.Email,
			Name = source.Person.Name
			};
		}
	}
}
