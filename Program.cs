using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using labar10;

namespace laba12
{
    public class Program
    {
        static void menu()
        {
            Console.WriteLine(" --------------Меню---------------");
            Console.WriteLine(" |1. Однонаправленный список.    |");
            Console.WriteLine(" |2. Двунаправленный список.     |");
            Console.WriteLine(" |3. Бинарное дерево.            |");
            Console.WriteLine(" |4. Выход.                      |");
            Console.WriteLine(" ---------------------------------");
        }

        //task 1
        static void UniDirect()
        {
            Console.WriteLine("===========================Задание 1============================");
            Console.WriteLine("1. Сформируем и распечатаем односвязный список.");
            int size = ParseInt("Введите количество элементов: ");
            var uniList = new UniList<CorrespondenceStudent>(size);
            uniList.PrintList();
            Console.WriteLine();

            Console.WriteLine("2. Обработаем список - удалим из списка все элементы с четными номерами.");
            uniList.RemoveEven();
            uniList.PrintList();
            Console.WriteLine();

            Console.WriteLine("3. Удалим список из памяти и попытаемся вывести его.");
            uniList.DeleteUniList();
            uniList.PrintList();
            Console.WriteLine("================================================================");
        }

        //task2
        static void DuoDirect()
        {
            Console.WriteLine("===========================Задание 2============================");
            Console.WriteLine("1. Сформируем и распечатаем двусвязный список.");
            int size = ParseInt("Введите количество элементов: ");
            var duoList = new DuoList<Person>(size);
            duoList.PrintList();
            Console.WriteLine();

            Console.WriteLine("2. Обработаем список - добавим в список элемент после номера предыдущего элемента.");
            duoList.AddAfterElement();
            duoList.PrintList();
            Console.WriteLine();

            Console.WriteLine("3. Удалим список из памяти и попытаемся вывести его.");
            duoList.DeleteUniList();
            duoList.PrintList();
            Console.WriteLine("================================================================");
        }

        //task3
        static void BinaryTree()
        {
            Console.WriteLine("===========================Задание 3============================");
            Console.WriteLine("1. Сформируем идеально сбалансированное дерево и распечаем его.");
            int size = ParseInt("Введите количество элементов: ");
            var tree = new Tree<Person>(size);
            tree.PrintTree1(tree.top, 10);

            Console.WriteLine("2. Обработаем список - найдем количество листьев.");
            Console.WriteLine("Кол-во листьев: " + tree.FindLeaves(tree.top));

            Console.WriteLine("3. Преобразуем наше идеально сбалансированное дерево в дерево поиска и распечатаем его.");
            tree = TurnToSearch(tree.top);
            tree.PrintTree1(tree.top, 3);

            Console.WriteLine("4. Удалим дерево из памяти и попробуем его вывести.");
            tree.Delete();
            tree.PrintTree1(tree.top, 10);
            Console.WriteLine("================================================================");
        }

        static Tree<Person> TurnToSearch(Node<Person> node)
        {
            List<Person> list = Tree<Person>.listNode(node);
            Tree<Person> newTree = new Tree<Person>();
            foreach (var el in list)
                newTree.Insert(el);
            return newTree;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("------------------Лабораторная работа 12----------------");
            bool endProgram = false;
            int i;
            while(!endProgram)
            {
                menu();
                i = ParseInt("Введите выбранный пункт:");
                switch(i)
                {
                    case 1:
                        UniDirect();
                        break;
                    case 2:
                        DuoDirect();
                        break;
                    case 3:
                        BinaryTree();
                        break;
                    case 4:
                        endProgram = true;
                        break;
                    default:
                        Console.WriteLine("Такого пункта нет в меню!");
                        break;
                }
            }
        }

        public static int ParseInt(string input)
        {
            int n;
            bool ok;
            Console.Write(input);
            do
            {
                string str = Console.ReadLine();
                ok = int.TryParse(str, out n);
                if (!((ok) && (n >= 0)))
                {
                    ok = false;
                    Console.WriteLine("Число должно быть целым и неотрицательным!");
                }
            }
            while (!ok);
            return n;
        }

        public static double ParseDouble(string input)
        {
            double n;
            bool ok;
            Console.WriteLine(input);
            do
            {
                string str = Console.ReadLine();
                ok = double.TryParse(str, out n);
                if (!ok)
                    Console.WriteLine("Число должно быть целым!");
            }
            while (!ok);
            return n;
        }
    }
}
