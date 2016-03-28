@script ExecuteInEditMode
var FireDot : Transform;
private var count : int = 0;
private var warning = false;
private var TString : String = "";
private var createRatio : int = 0;
private var looper : int = 1;

function Create()
{
	if (gameObject.GetComponent(MeshFilter))
		{
			if (!transform.Find("FirePoints"))
				{
					count = 0;
					var myMesh : Mesh = GetComponent(MeshFilter).sharedMesh;
					if (myMesh.vertexCount <= 2000 || warning)
						{
							if (int.TryParse(TString, createRatio))
								{
									var subC : GameObject = new GameObject("FirePoints");
									subC.transform.parent = transform;
									subC.transform.position = transform.position;
									for (var vert : Vector3 in myMesh.vertices)
										{
											if (looper == 1)
												{
													var dot : Transform = Instantiate(FireDot, transform.TransformPoint(vert), Quaternion.identity);
													dot.name = "FirePoint"+count;
													dot.parent = subC.transform;
													count++;
												}
											if (looper >= createRatio)
												looper = 0;
											looper++;
										}
									Debug.Log(count+" Fire Points created.");
									warning = false;
								}
							else
								Debug.LogError("createRatio is not of type int.");
						}
					else
						{
							Debug.LogWarning("Vertices of the mesh exceeds 2000 ("+myMesh.vertexCount+"). It is recommended that you set the Create Ratio greater than 5.");
							warning = true;
						}
				}
			else
				Debug.LogError("Fire Points already created.");
		}
	else
		Debug.LogError("No mesh present for the object.");
}

function DestroyP()
{
	if (transform.Find("FirePoints"))
		{
			DestroyImmediate(transform.Find("FirePoints").gameObject);
			Debug.Log("Fire Points destroyed.");
		}
}