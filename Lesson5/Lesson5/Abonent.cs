using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    internal class Abonent
    {
        class Singleton
        {
            private static Singleton instance;

            private Singleton()
            { }

            public static Singleton getInstance()
            {
                if (instance == null)
                    instance = new Singleton();
                return instance;
            }
        }

        private int id;
        private string name;
        private long number;
        private string country;

        private Id()
        {
            get {
                return id;
            }
            set { }
        }
        public Abonent(int id, string name, long number, string country)
        {
            this.id = id;
            this.name = name;
            this.number = number;
            this.country = country;
        }
    }
}
