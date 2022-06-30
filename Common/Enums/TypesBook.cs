using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Common.Enums
{
	public enum TypesBook
	{
		[Display(Name = "Роман")]
		Roman = 0,

		[Display(Name = "Повесть")]
		Povest = 1,
	}
}