using System;
using NUnit.Framework;
using PatternsTutorial;

namespace PatternsTutorialTests
{
    [TestFixture]
    public class SingletonTests
    {
        [Test]
        public void CreationTest()
        {
            var instance1 = Singleton.Instance();
            var instance2 = Singleton.Instance();
            Assert.That(instance1,Is.SameAs(instance2));
        }

        [Test]
        public void BasicLoadBalancerCreationTest()
        {
            for (var i = 0; i < 6; i++)
            {
                var server1=BasicLoadBalancer.GetLoadBalancer();
                Console.WriteLine(server1.Server);

            }
        }
    }
}
