using Godot;
using System;
using System.Collections.Generic;



public struct Action
{
    public int cost;
    public string name;

    public Action(int cost, string name)
    {
        this.cost = cost;
        this.name = name;
    }
}

public class ui_handler : Node
{

    [Signal]
    public delegate void ActionClicked(string actionName);


    Node buttonContainer;


    List<Action> actions = new List<Action>{
        new Action(1, "Grow tentacle"),
        new Action(3, "Grow clot"),
        new Action(5, "Eye")
    };


    public override void _Ready()
    {
        buttonContainer = GetNode("ButtonContainer");
        RenderButtons();
    }

    void _ButtonClicked()
    {
        GD.Print("whatever");
    }


    public void RenderButtons()
    {


        var buttonSpacing = 100;
        var buttonYPosition = 50;

        for (var i = 0; i < actions.Count; i++)
        {
            var action = actions[i];
            var button = new Button();
            button.Text = action.name;
            button.RectMinSize = new Vector2(150, 30);

            button.Connect("pressed", this, "_ButtonClicked");
            // button.SetPosition(new Vector2(buttonSpacing * i, buttonYPosition));

            buttonContainer.AddChild(button);
        }




    }

}
