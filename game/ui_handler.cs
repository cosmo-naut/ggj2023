using Godot;
using System;
using System.Collections.Generic;



public struct Action
{
    public int cost;
    public string name;

    //properties of the each action button
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

    PackedScene actionButtonTemp;//the button's base to be instanced
    Node buttonContainer;//container of the buttons.

    //List of action buttons to be generated and its parameters
    List<Action> actions = new List<Action>{
        new Action(1, "Grow tentacle"),
        new Action(3, "Grow clot"),
        new Action(5, "Eye")
    };
    List <ActionButton>buttonList=new List<ActionButton>();



    public override void _Ready()
    {
        //ready for the custom button "template"
        actionButtonTemp = (PackedScene)GD.Load("res://ActionButton.tscn");
        buttonContainer = GetNode("ButtonContainer");
        RenderButtons();
    }

    void _ButtonClicked(ActionButton targetButton)
    {
        
        GD.Print(targetButton.buttonName+" "+targetButton.cost);
        if(targetButton.buttonName=="Grow tentacle")
            GD.Print("It Grows!!!!!");
        
    }


    public void RenderButtons()
    {


        var buttonSpacing = 100;
        var buttonYPosition = 50;

        for (var i = 0; i < actions.Count; i++)
        {                        
            var action = actions[i];
            //create a new instance of action button
            ActionButton button= (ActionButton)actionButtonTemp.Instance();
            button.RectMinSize = new Vector2(150, 30);
            button.Text = action.name;
            button.buttonName = action.name;
            button.cost = action.cost;
            GD.Print(button.buttonName);

            buttonList.Add(button);
            button.Connect("pressed", this, "_ButtonClicked", new Godot.Collections.Array(){button});
            //button.SetPosition(new Vector2(buttonSpacing * i, buttonYPosition));

            buttonContainer.AddChild(button);
        }




    }

}
