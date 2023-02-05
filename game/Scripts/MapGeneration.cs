
using Godot;


public class MapGeneration : Node2D
{

    [Export]
    public int radiusSpawnLoops = 2500; // How many radius checks we loop over to spawn resources

    [Export]
    public int spawnItemPerRadius = 2;

    [Export]
    public float radiusIncrement = 400f;

    [Export]
    public float minResourceScale = 0.1f;

    [Export]
    public float maxResourceScale = 0.25f;

    [Export]
    public float previousRadiusOffset = 5f;



    // This is to prevent us spawning resources on top of the player when the scene starts
    [Export]
    public float initialRadiusToAvoidSpawn = 300f;


    PackedScene creatureResource;

    public override void _Ready()
    {
        var radius = initialRadiusToAvoidSpawn;
        creatureResource = ResourceLoader.Load<PackedScene>("res://Scenes/CreatureResource.tscn");
        for (int currentResourceCount = 0; currentResourceCount < radiusSpawnLoops; currentResourceCount++)
        {

            float newRadius = radius + radiusIncrement;
            DrawCircle(Vector2.Zero, newRadius, Colors.White);


            for (int i = 0; i < spawnItemPerRadius; i++)
            {
                float randomRadius = (float)GD.RandRange(radius + previousRadiusOffset, newRadius);
                float angleDeg = (float)GD.RandRange(0.0f, 360.0f);
                float xPos = randomRadius * Mathf.Cos(Mathf.Deg2Rad(angleDeg));
                float yPos = randomRadius * Mathf.Sin(Mathf.Deg2Rad(angleDeg));
                var positionToSpawn = new Vector2(xPos, yPos);
                SpawnResource(positionToSpawn);
            }

            // Update the radius
            radius = newRadius;
        }


    }


    public override void _Draw()
    {
        DrawCircle(Vector2.Zero, initialRadiusToAvoidSpawn, Colors.White);
    }



    public void SpawnResource(Vector2 position)
    {
        // Depending on the size of the resource, we should give it more value?? 
        float scale = (float)GD.RandRange(minResourceScale, maxResourceScale);
        var resourceInstance = creatureResource.Instance() as CreatureResource;
        resourceInstance.Translate(position);
        resourceInstance.Scale = new Vector2(scale, scale);
        resourceInstance.RotationDegrees = (float)GD.RandRange(0, 360);
        AddChild(resourceInstance);
    }

}
