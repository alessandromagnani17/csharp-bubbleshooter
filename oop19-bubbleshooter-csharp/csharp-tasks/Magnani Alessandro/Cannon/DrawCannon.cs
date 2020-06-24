using System;
using System.Drawing;

namespace csharp_tasks.Magnani_Alessandro.Cannon
{
    public class DrawCannon
    {
        
        private static readonly double CANNON_FIT_WIDTH = 10;
        private static readonly double CANNON_FIT_HEIGTH = 6;

        private readonly Rotate rotation = new Rotate();
        private readonly Cannon cannon;
        private readonly Controller controller;
        private readonly Point shootingBubblePosition;
        private readonly double shootingBubbleRadius; 
        
        /**
     * Constructor for a new DrawCannon.
     * <param name="pane">the panel where draw the {@link Cannon}.</param>
     * <param name="cannon">the {@link Cannon} to draw.</param>
     * <param name="controller">the {@link Controller} used to dialogue with {@link Model} and {@link view}.</param>
     * <param name="shootingBubblePosition">the position of {@link ShootingBubble}.</param>
     * <param name="shootingBubbleRadius">the radius of {@link ShootingBubble}.</param>
     */
    public DrawCannon(AnchorPane pane; readonly Cannon cannon, Controller controller,
        readonly Point shootingBubblePosition,  double shootingBubbleRadius) 
        {
        this.cannon = cannon;
        this.controller = controller;
        this.shootingBubblePosition = shootingBubblePosition;
        this.shootingBubbleRadius = shootingBubbleRadius;
        this.EditCannon();
        this.SetRotation();
        pane.GetChildren().Add(this.cannon.GetCannon());
    }

    /**
     * Method to get the angle of {@link Cannon} rotation.
     * @return the angle of {@link Cannon}.
     */
    public Rotate GetRotation() 
    {
        return this.rotation;
    }

    /**
     * Method to set the position of {@link Cannon}.
     */
    private void EditCannon() 
    {
        this.cannon.GetCannon().SetLayoutX((this.shootingBubblePosition.GetX() - this.cannon.GetCannon().GetImage().GetWidth() / 2)
                * (Settings.GetGuiWidth() / this.controller.GetWorldWidth()));
        this.cannon.GetCannon().SetLayoutY((this.shootingBubblePosition.GetY() - this.cannon.GetCannon().GetImage().GetHeight() 
                - this.shootingBubbleRadius) * (Settings.GetGuiHeight() / this.controller.GetWorldHeight()));

        this.cannon.GetCannon().SetFitWidth(Settings.GetGuiWidth() / CANNON_FIT_WIDTH);
        this.cannon.GetCannon().SetFitHeight(Settings.GetGuiHeight() / CANNON_FIT_HEIGTH);
    }

    /**
     * Method to set the angle of {@link Cannon} rotation.
     */
    private void SetRotation() 
    {
        this.rotation.SetPivotX(this.cannon.GetCannon().GetFitWidth() - (this.shootingBubbleRadius * 2 * (Settings.GetGuiWidth() / this.controller.GetWorldWidth())));
        this.rotation.SetPivotY(this.cannon.GetCannon().GetFitHeight());

        this.cannon.GetCannon().GetTransforms().Add(rotation);
    }

}

    }
}