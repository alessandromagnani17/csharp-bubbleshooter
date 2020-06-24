using System;
using System.Collections.Generic;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Magnani_Alessandro
{
    [TestClass]
    class TestSwitchingBubble
    {
        private static readonly double LIMITS = 3;

        private readonly Bubble switchBubble = new SwitchBubble(new Point(0, 0), BubbleColor.GREEN);
        private readonly Bubble testShootingBubble = new ShootingBubble(new Point(0, 0), BubbleColor.BLUE);
        private readonly List<Bubble> bubblesManager = new LinkedList<>();
        private readonly SwitcherController switcherController = new SwitcherController(bubblesManager);
        private readonly Level basicLevel = new BasicLevel();
        private readonly Level survivalLevel = new SurvivalLevel();

        
        /**
         * Method to test if the {@link ShootingBubble} at the switch takes on the color of the {@link SwitchBubble}.
         */
        [TestMethod]
        public void TestSwitch() {
            this.bubblesManager.Add(this.testShootingBubble);
            this.bubblesManager.Add(this.switchBubble);
            this.switcherController.SetBubbles(bubblesManager);
            this.switcherController.SwitchControl();

            Console.WriteLine(this.switchBubble.GetColor());

            Assert.IsTrue(this.switchBubble.GetColor().Equals(BubbleColor.BLUE));
            Assert.IsTrue(this.testShootingBubble.GetColor().Equals(BubbleColor.GREEN));
        }

        /**
         * Method to test if the {@link ShootingBubble} doesn't take on the 
         * {@link SwitchBubble}'s color when the Switch Limit is exceeded.
         */
        
        
        [TestMethod]
        public void TestLimitsExceeded() {
            this.bubblesManager.Add(this.testShootingBubble);
            this.bubblesManager.Add(this.switchBubble);
            this.switcherController.SetBubbles(bubblesManager);
            this.switcherController.SetNumSwitch(LIMITS);
            this.switcherController.SwitchControl();

            Assert.IsFalse(this.switchBubble.GetColor().Equals(BubbleColor.BLUE));
            Assert.IsFalse(this.testShootingBubble.GetColor().Equals(BubbleColor.GREEN));
        }

        /**
         * Method to test if the {@link ShootingBubble} takes on the color 
         * of the {@link SwitchBubble} after Shooting in {@link BasicMode}.
         */
        
        [TestMethod]
        public void TestBasicSwitchAfterShot() {
            this.bubblesManager.Add(testShootingBubble);
            this.bubblesManager.Add(switchBubble);
            this.basicLevel.GetBubblesManager().AddBubbles(bubblesManager);
            this.basicLevel.LoadShootingBubble();

            Assert.IsTrue(this.basicLevel.GetBubblesManager().GetShootingBubble().Get().GetColor().Equals(BubbleColor.GREEN));
        }

        /**
         * Method to test if the {@link ShootingBubble} takes on the color 
         * of the {@link SwitchBubble} after Shooting in {@link SurvivalMode}.
         */
        
        [TestMethod]
        public void TestSurvivalSwitchAfterShot() {
            this.bubblesManager.Add(testShootingBubble);
            this.bubblesManager.Add(switchBubble);
            this.survivalLevel.GetBubblesManager().AddBubbles(bubblesManager);
            this.survivalLevel.LoadShootingBubble();

            Assert.IsTrue(this.survivalLevel.GetBubblesManager().GetShootingBubble().Get().GetColor().Equals(BubbleColor.GREEN));
        }
    }
}