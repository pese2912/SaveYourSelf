@CustomEditor (CreateFirePoints)
class FPEditor extends Editor
{
	function OnInspectorGUI()
		{
			GUILayout.Label("Dynamic Fire (C) 2012");
			GUILayout.Label("Gabriel Farrugia");
			if (GUILayout.Button("Build Points"))
				target.Create();
			GUILayout.Label("This button will generate Fire Points for your\nmesh.");
			if (GUILayout.Button("Destroy Points"))
				target.DestroyP();
			GUILayout.Label("This button will destory Fire Points for your\nmesh.");
			target.TString = GUILayout.TextField(target.TString);
			GUILayout.Label("This field controls the ratio of how many \nFirePoints per vertex are created. \n(For example 5 means 1 FirePoint\nper 5 vertices.)");
		}
}