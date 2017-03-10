using System;
using AutoMapper;
using AutoMapperByExample;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoMapperTests
{
	[TestClass]
	public class AutoMapperTests
	{
		IMapper _mapper;

		[TestInitialize]
		public void SetUp()
		{
			_mapper = getMapper();
		}
		IMapper getMapper()
		{
			var mapperConfig = new MapperConfiguration((config) =>
			{
				config.CreateMap<AllTheThings, SomeOfTheThings>();
				config.CreateMap<AllTheThings, SomePlusMore>();
				config.CreateMap<SomeOfTheThings, AllTheThings>();
				config.CreateMap<SomePlusMore, AllTheThings>();
				config.CreateMap<Person, Person2>().ReverseMap();
				config.CreateMap<Roster, Person>().ConstructUsing(source => source.Person);
				config.CreateMap<Roster, Person2>().ConvertUsing(new Person2RosterConverter());
			});

			return mapperConfig.CreateMapper();
		}

		[TestMethod]
		public void mapping_from_many_to_few()
		{
			var att = new AllTheThings() { Age = 100, City = "Dallas", Name = "Joe", State = "TX" };
			var sott = _mapper.Map<SomeOfTheThings>(att);

			Assert.IsNotNull(sott);
		}

		[TestMethod]
		public void mapping_from_many_more()
		{
			var att = new AllTheThings() { Age = 100, City = "Dallas", Name = "Joe", State = "TX" };
			var spm = _mapper.Map<SomePlusMore>(att);

			Assert.IsNotNull(spm);
		}


		[TestMethod]
		public void mapping_from_some_to_all()
		{
			var sott = new SomeOfTheThings() { Age = 100, Name = "Joe" };
			var att = _mapper.Map<AllTheThings>(sott);

			Assert.IsNotNull(att);
		}

		[TestMethod]
		public void mapping_from_somePlus_to_all()
		{
			var sott = new SomePlusMore() { Age = 100, Name = "Joe", ZipCode = "123" };
			var att = _mapper.Map<AllTheThings>(sott);

			Assert.IsNotNull(att);
		}

		[TestMethod]
		public void mapping_roster_to_person()
		{
			var roster = new Roster() { Person = new Person() { Name = "Tom", Email = "tom@acme.com" } };

			var person = _mapper.Map<Person2>(roster);

			Assert.IsNotNull(person);
		}
	}
}
