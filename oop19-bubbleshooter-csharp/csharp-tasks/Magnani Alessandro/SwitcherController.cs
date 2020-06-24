using System;
using System.Collections.Generic;

namespace csharp_tasks.Magnani_Alessandro
{
    class SwitcherController
    {
        private static readonly double LIMITS_SWITCH = 3;
        private double numSwitch;
        private BubbleSwitcher bubbleSwitcher;
        private List<Bubble> bubbles;

        /**
         * Constructor for a new SwitcherController.
         * 
         * @param bubbles , the list of all {@link Bubble}s.
         */
        public SwitcherController(List<Bubble> bubbles)
        {
            this.bubbles = bubbles;
            this.bubbleSwitcher = new BubbleSwitcher(this.bubbles);
            this.SetInitialNumSwitch();
        }

        /**
         * Method to recall the switch of the {@link Bubble}s if the switch limit has not been exceeded.
         */
        public readonly void SwitchControl()
        {
            if (!IsSwitchEnd()) {
                this.IncreasesNumSwitch();
                this.bubbleSwitcher.SwitchBall();
            }
        }

        /**
         * Method to set the number of switches already made.
         * @param numSwitch , the number of switches already made.
         */
        public void SetNumSwitch(double numSwitch)
        {
            this.numSwitch = numSwitch;
        }

        /**
         * Method to set the initial value of the number of switches already made.
         */
        public void SetInitialNumSwitch()
        {
            this.numSwitch = 0;
        }

        /**
         * Method to increase the number of switches already made.
         */
        public void IncreasesNumSwitch()
        {
            this.numSwitch++;
        }

        /**
         * Method that checks whether the number of switches already made is greater than the possible switches.
         * @return the number of switches already made is greater than the possible switches.
         */
        public bool IsSwitchEnd()
        {
            return this.numSwitch >= LIMITS_SWITCH;
        }

        /**
         * Method to set the list of all {@link Bubble}s.
         * @param bubbles , the list of all {@link Bubble}s.
         */
        public void SetBubbles(List<Bubble> bubbles)
        {
            this.bubbles = bubbles;
            this.bubbleSwitcher = new BubbleSwitcher(this.bubbles);
        }

        /**
         * Method to get the number of switches already made.
         * @return the number of switches already made.
         */
        public double GetNumSwitch()
        {
           return this.numSwitch;
        }
    }
}