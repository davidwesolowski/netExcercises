using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace demo2.Persistance.Entities
{
	public class MyRole : IdentityRole<string>
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public string Id { get; set; }

		public string Name { get; set; }
		
		public MyRole() { }

		public MyRole(string id, string name)
		{
			this.Id = id;
			this.Name = name;
		} 
	}
}