using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using PatternsTutorial.Creational;

namespace PatternsTutorialTests.Creational
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
        public void BasicLoadBalancerCreationSingleThreadTest()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            for (var i = 0; i < 3; i++)
            {
                var server1 = BasicLoadBalancer.GetLoadBalancer();
                Console.WriteLine($"{server1.Server} :: Thread Id :: {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(1000);
            }
            stopWatch.Stop();
            Console.WriteLine($"Total execution :: {stopWatch.Elapsed}");
        }
        [Test]
        public void BasicLoadBalancerCreationMultiThreadTest()
        {
            var taskList = new List<Task>();
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            for (var i = 0; i < 3; i++)
            {
                var lastTask = new Task(WriteServerCalledByLoadBalancer);
                lastTask.Start();
                taskList.Add(lastTask);
            }
            Task.WaitAll(taskList.ToArray());
            stopWatch.Stop();
            Console.WriteLine($"Total execution :: {stopWatch.Elapsed}");
        }

        private void WriteServerCalledByLoadBalancer()
        {
            var server1 = BasicLoadBalancer.GetLoadBalancer();
            Console.WriteLine($"{server1.Server} :: Thread Id :: {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(1000);
        }
    }
}
