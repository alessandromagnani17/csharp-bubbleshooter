using System;
using System.Net.Mime;

namespace csharp_tasks.Magnani_Alessandro.Cannon
{
    public class Cannon : ImageView
    {
        private readonly ImageView imageCannon;
        private double angle;

        /**
         * Constructor for a new Cannon.
         * 
         * @param img , the image of Cannon.
         */
        public Cannon(Image img)
        {
            this.imageCannon = new ImageView(img);
        }

        /**
         * Method to get the {@link ImageView} of the {@link Cannon}.
         * @return the {@link ImageView} of the {@link Cannon}.
         */
        public ImageView GetCannon()
        {
            return imageCannon;
        }

        /**
         * Method to get the angle of {@link Cannon} rotation.
         * @return the angle of {@link Cannon}.
         */
        public double GetAngle()
        {
            return angle;
        }

        /**
         * Method to set the angle of {@link Cannon} rotation.
         * @param angle , the angle of {@link Cannon}.
         */
        public void SetAngle(double angle)
        {
            this.angle = angle;
        }

    }
}