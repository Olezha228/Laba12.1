using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using labar10;

namespace laba12
{
    class DuoPoint<T>
        where T : Person
    {
        public Person data;
        public DuoPoint<T> next;
        public DuoPoint<T> prev;

        public DuoPoint()//конструктор без параметров
        {
            data = null;
            next = null;
            prev = null;
        }

        public DuoPoint(bool b)//конструктор с параметрами
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
            data = p;
            next = null;
            prev = null;
        }

        public override string ToString()
        {
            return data + " ";
        }
    }
}
