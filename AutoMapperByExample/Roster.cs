using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperByExample
{
	public class Roster
	{
		public Person Person { get; set; }	
	}
	public class Person
	{
	public string Name { get; set; }
	public string Email { get; set; }
	}

	public class Person2
	{
		public string Name { get; set; }
		public string Email { get; set; }
	}

	public class AllTheThings
	{
		public string Name { get; set; }
		public int Age { get; set; }
		public string State { get; set; }
		public string City { get; set; }
	}

	public class SomeOfTheThings
	{
		public string Name { get; set; }
		public int Age { get; set; }
	}

	public class SomePlusMore
	{
		public string Name { get; set; }
		public int Age { get; set; }
		public string ZipCode { get; set; }
	}


}
