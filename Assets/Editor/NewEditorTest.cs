using NUnit.Framework;

public class NewEditorTest
{
	/// <summary>
	/// 
	/// </summary>
	/// <remarks>
	/// According to the teamcity ##teamcity interaction documentation:
	/// https://confluence.jetbrains.com/display/TCD10/Build+Script+Interaction+with+TeamCity#BuildScriptInteractionwithTeamCity-Escapedvalues
	/// The following character must be escaped with | (pipe): ' \n \r (any unicode symbol) | [ ]
	/// when used in a message
	/// </remarks>
	/// <param name="parameter"></param>
	[Test]
	public void EditorTest([Values( "He|Ho", "Juppi[]", "Do\nDe\nDo\rLe\rFo", "'", "|", "ÜÊ5ØÔT©xÏ+,→¿" )] string parameter)
	{
		Assert.AreEqual( parameter, parameter );
	}
}
