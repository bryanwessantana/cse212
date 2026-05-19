/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represents locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean are represent valid directions
///
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.  
///
/// If there is a wall, then throw an InvalidOperationException with the message "Can't go that way!".  If there is no wall,
/// then the 'currX' and 'currY' values should be changed.
/// </summary>
public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    public void MoveLeft()
    {
        var currentCoordinates = (_currX, _currY);
        
        // Verify if the movement to the left (index 0) is valid
        if (_mazeMap.ContainsKey(currentCoordinates) && _mazeMap[currentCoordinates][0])
        {
            _currX -= 1; // Move left by decrementing X
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    public void MoveRight()
    {
        var currentCoordinates = (_currX, _currY);

        // Verify if the movement to the right (index 1) is valid
        if (_mazeMap.ContainsKey(currentCoordinates) && _mazeMap[currentCoordinates][1])
        {
            _currX += 1; // Move right by incrementing X
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    public void MoveUp()
    {
        var currentCoordinates = (_currX, _currY);

        // Verify if the movement to the up (index 2) is valid
        if (_mazeMap.ContainsKey(currentCoordinates) && _mazeMap[currentCoordinates][2])
        {
            _currY -= 1; // In many matrix/grid formats, "Up" decrements the Y coordinate.
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    public void MoveDown()
    {
        var currentCoordinates = (_currX, _currY);

        // Verify if the movement to the down (index 3) is valid
        if (_mazeMap.ContainsKey(currentCoordinates) && _mazeMap[currentCoordinates][3])
        {
            _currY += 1; // In many matrix/grid formats, "Down" increments the Y coordinate.
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}