namespace DungeonsAndDragonsClub
{
	using System;
	using System.Collections.Generic;
	using System.Text;
	public interface Description
	{
		Int32 Id { get; set; }
		String Name { get; set; }
		String Race{ get; set;}
		String Class { get; set; }
		Int32 level { get; set; }
		String Concept { get; set; }
		String BackStory { get; set; }
		// dont know the file type and how to do files in C# and visual studio
		String CharacterSheetFile { get; set; }
	}
}
