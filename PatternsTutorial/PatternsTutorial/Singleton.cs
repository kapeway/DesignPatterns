using System;
using System.Collections.Generic;

namespace PatternsTutorial
{
    public class Singleton
    {
        private static Singleton _instance;

        protected Singleton()
        {
        }

        public static Singleton Instance()
        {
            if(_instance==null)
                _instance=new Singleton();
            return _instance;
        }
    }

    public class BasicLoadBalancer
    {
        private static BasicLoadBalancer _instance;
        private List<string> _servers=new List<string>();
        private Random _random =new Random();

        private static object syncLock= new object();

        protected BasicLoadBalancer()
        {
            _servers.Add("server1");
            _servers.Add("server2");
            _servers.Add("server3");
            _servers.Add("server4");
        }

        public static BasicLoadBalancer GetLoadBalancer()
        {
            if (_instance == null)
            {
                lock (syncLock)
                {
                    _instance=new BasicLoadBalancer();
                }
            }

            return _instance;
        }

        public string Server
        {
            get
            {
                int r = _random.Next(_servers.Count);
                return _servers[r];
            }
        }
    }
}
