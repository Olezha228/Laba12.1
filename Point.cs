using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using labar10;

namespace laba12
{
    class Point<T>
        where T : Person
    {
        public Person data;//информационное поле
        public Point<T> next;//адресное поле

        public Point()//конструктор без параметров
        {
            data = null;
            next = null;
        }

        public Point(bool ok)//конструктор с параметрами
        {
            data = Rand();
            next = null;
        }

        static Person Rand()
        {
            Person p = new Person();
            Random rnd = new Random();
            int k = rnd.Next(1, 5);
            switch (k)
            {
                case 1:
                    p = (Person)new Student().Init();
                    break;
                case 2:
                    p = (Person)new Schooler().Init();
                    break;
                case 3:
                    p = (Person)new CorrespondenceStudent().Init();
                    break;
                case 4:
                    p = (Person)new Person().Init();
                    break;
            }
            return p;
        }

        public override string ToString()
        {
            return data + " ";
        }
    }
}
