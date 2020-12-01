using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace demo2.Persistance.Entities
{
	public class MyRole : IdentityRole<string>
	{
		// [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		// public override string Id { get; set; }

		public MyRole() { }

		public MyRole(string name)
		{
			this.Name = name;
			base.Id = name;
		} 
	}
}