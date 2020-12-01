using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace demo2.Persistance.Entities
{
	public class MyUserAccount : IdentityUser<string>
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public override string Id { get; set; }

		public ICollection<MyRole> Roles { get; set; }

		public string Address { get; set; }
		
		public string Nickname { get; set; }
	}
}