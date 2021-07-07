using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using labar10;

namespace laba12
{
    public class DuoList<T>
        where T : Person
    {
        DuoPoint<T> head = null;
        DuoPoint<T> tail = null;

        public DuoList() { }

        public DuoList(int size)
        {
            if (size == 0)
                return;
            head = new DuoPoint<T>(true);
            DuoPoint<T> p = head;
            for (int i = 1; i < size; i++)
            {
                DuoPoint<T> temp = new DuoPoint<T>(true);
                p.next = temp;
                temp.prev = p;
                p = temp;
            }
            tail = p;
        }

        public int Lenght
        {
            get
            {
                if (head == null) return 0;
                DuoPoint<T> h = head;
                int len = 0;
                while (h != null)
                {
                    h = h.next;
                    len++;
                }
                return len;
            }
        }


        public void AddLast(T data)
        {
            DuoPoint<T> node = new DuoPoint<T>(true);

            if (head == null)
                head = node;
            else
            {
                tail.next = node;
                node.prev = tail;
            }
            tail = node;
        }

        public void AddFirst(T data)
        {
            DuoPoint<T> node = new DuoPoint<T>(true);
            DuoPoint<T> temp = head;
            node.next = temp;
            head = node;
            if (Lenght == 0)
                tail = head;
            else
                temp.prev = node;
        }

        public void PrintList()
        {
            if (head == null)
            {
                Console.WriteLine("The list is empty");
                return;
            }
            DuoPoint<T> p = head;
            while (p != null)
            {
                Console.WriteLine(p);
                p = p.next;
            }
        }

        public void PrintListBack()
        {
            if (tail == null)
            {
                Console.WriteLine("The list is empty");
                return;
            }
            DuoPoint<T> p = tail;
            while (p != null)
            {
                Console.WriteLine(p);
                p = p.prev;
            }
        }

        public void RemovePoint(int nom)
        {
            if (head == null)
                return;
            if (nom == 1)
            {
                head = head.next;
                return;
            }
            DuoPoint<T> p = head;
            for (int i = 1; i < nom; i++)
                p = p.next;
            p.next = p.next.next;
        }

        public void AddAfterElement()
        {
            int num = Program.ParseInt("Введите число, после которого вставить новый элемент: ");
            while (!((num >= 0) && (num <= Lenght)))
            {
                Console.WriteLine("Число не попадает в диапазон!");
                num = Program.ParseInt("Введите число, после которого вставить новый элемент: ");
            }
            DuoPoint<T> node = new DuoPoint<T>(true);
            DuoPoint<T> p = head;
            DuoPoint<T> help;

            if (Lenght == 0)
            {
                head = node;
                return;
            }
            if (num == 0)
            {
                p.prev = node;
                node.next = p;
                head = node;
                return;
            }
            if (num == Lenght)
            {
                for (int i = 1; i < Lenght; i++)
                    p = p.next;
                p.next = node;
                node.prev = p;
                return;
            }
            for (int i = 1; i < num; i++)
                p = p.next;

            help = p.next;

            p.next = node;
            node.prev = p;

            node.next = help;
            help.prev = node;
        }

        public void DeleteUniList()
        {
            if (head == null) Console.WriteLine("Список уже не существует!");
            else
            {
                DuoPoint<T> p = head;
                DuoPoint<T> temp;

                while (p != null)
                {
                    temp = p;
                    temp.next = null;
                    temp.prev = null;
                    p = p.next;
                }
                head = null;
            }
        }
    }
}
