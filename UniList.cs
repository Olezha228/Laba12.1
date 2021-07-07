using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using labar10;

namespace laba12
{
    public class UniList<T>
        where T : Person
    {
        Point<T> beg = null;

        public int Lenght
        {
            get
            {
                if (beg == null) return 0;
                Point<T> p = beg;
                int len = 0;
                while (p != null)
                {
                    p = p.next;
                    len++;
                }
                return len;                    
            }
        }

        public UniList() { }

        public UniList(int size)
        {
            if (size == 0)
                return;
            beg = new Point<T>(true);
            Point<T> p = beg;
            for (int i = 1; i < size; i++)
            {
                Point<T> temp = new Point<T>(true);
                p.next = temp;
                p = temp;
            }
        }

        //public UniList(params T[]mas)
        //{
        //    beg = new Point<T>(mas[0]);
        //    Point<T> p = beg;
        //    beg.data = mas[0];
        //    for (int i = 1; i < mas.Length; i++)
        //    {
        //        Point<T> temp = new Point<T>(mas[i]);
        //        p.next = temp;
        //        p = temp;
        //    }
        //} 

        public void PrintList()
        {
            if (beg == null)
            {
                Console.WriteLine("The list is empty");
                return;
            }
            Point<T> p = beg;
            while (p != null)
            {
                Console.WriteLine(p);
                p = p.next; 
            }
        }
          
        public void AddPointToBeg(T d)
        {
            Point<T> temp = new Point<T>(true);
            if (beg == null)
            {
                beg = temp;
                return;
            }

            temp.next = beg;
            beg = temp;
        }

        public void AddPointToEnd(T d)
        {
            Point<T> added = new Point<T>(true);
            Point<T> temp = beg;
            if (beg == null)
            {
                beg = added;
                return;
            }
            for (int i = 0; i < Lenght - 1; i++)
            {
                temp = temp.next;
            }
            temp.next = added;
        }

        public void RemovePoint(int nom)
        {
            if (beg == null)
                return;
            if (nom == 1)
            {
                beg = beg.next;
                return;
            }
            Point<T> p = beg;
            for (int i = 1; i < nom; i++)
                p = p.next;
            p.next = p.next.next;
        }

        public void RemoveEven()
        {
            if (beg == null || Lenght == 1)
                return;
            Point<T> temp = beg;
            Point<T> help = null;
            
            if (Lenght % 2 == 0)
            {
                if (Lenght == 2)
                {
                    help = temp.next;
                    temp.next = temp.next.next;
                    help.next = null;
                    temp = temp.next;
                    return;
                }
                for (int i = 0; i < Lenght - 1; i++)
                {
                    if (i % 2 == 0)
                    {
                        help = temp.next;
                        temp.next = temp.next.next;
                        help.next = null;
                        temp = temp.next;
                    }
                }
                temp.next = null; 
            }
            else
            {
                if (Lenght == 3)
                {
                    help = temp.next;
                    temp.next = temp.next.next;
                    help.next = null;
                    temp = temp.next;
                    return;
                }
                for (int i = 0; i < Lenght; i++)
                {
                    if ((i % 2 == 0) && (i < Lenght - 2))
                    {
                        help = temp.next;
                        temp.next = temp.next.next;
                        help.next = null;
                        temp = temp.next;
                    }
                    if (i >= Lenght - 2)
                    {
                        help = temp.next;
                        temp.next = temp.next.next;
                        help.next = null;
                    }
                }
            }
        }

        public void DeleteUniList()
        {
            if (beg == null) Console.WriteLine("Список уже не существует!");
            else
            {
                Point<T> p = beg;
                Point<T> temp;

                while (p != null)
                {
                    temp = p;
                    temp.next = null;
                    p = p.next;
                }
                beg = null;
            }
        }
    }
}
