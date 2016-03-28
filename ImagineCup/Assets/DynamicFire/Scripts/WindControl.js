enum WindD {NoWind, North, West, East, South}
var windDirection : WindD = WindD.NoWind;
var windSpeed : float = .5;
static var windV : int = 0;
static var windS : float = .5;

function Start()
{
	switch(windDirection)
		{
			case WindD.NoWind : windV = 0; break;
			case WindD.North : windV = 1; break;
			case WindD.West : windV = 2; break;
			case WindD.East : windV = 3; break;
			case WindD.South : windV = 4; break;
		}
	windS = windSpeed;
}