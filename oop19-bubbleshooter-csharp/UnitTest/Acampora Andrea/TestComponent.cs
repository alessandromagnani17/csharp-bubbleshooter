using csharp_tasks.Acampora_Andrea;
using csharp_tasks.Accursi_Giacomo;
using NUnit.Framework;

namespace UnitTest.Acampora_Andrea
{
    [TestFixture]
    public class Tests
    {
    
        IBubble ShootingBubble = new ShootingBubble(new Point2D(0,0));
        IComponent CollisionComponent = new CollisionComponent(new ShootingBubble(new Point2D(0,0)));
        IComponent ShootingComponent = new ShootingComponent(new ShootingBubble(new Point2D(0,0)));

        [Test]
        public void TestComponent()
        {
            Assert.True(ShootingBubble.Components.Count != 0);
        }

        [Test]
        public void TestCollisionType()
        {
            Assert.Equals(CollisionComponent.Type,ComponentType.CollisionComponent);
        }

        [Test]
        public void TestShootingType()
        {
            Assert.Equals(ShootingComponent.Type,ComponentType.ShootingComponent);
        }

        [Test]
        public void TestContainer()
        {
            IBubble shootingBubble = new ShootingBubble(new Point2D(0,0));
            IComponent shootingComponent = new ShootingComponent(shootingBubble);
            Assert.Equals(shootingComponent.Container, shootingBubble);
        }
    }
}