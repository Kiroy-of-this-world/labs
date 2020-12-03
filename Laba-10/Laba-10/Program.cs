using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_10
{
    class Student
    {
        private string name;
        public string Name { get { return name; } set { name = value; } }
        public Student(string str)
        {
            Name = str;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ArrayList");
            ArrayList array = new ArrayList();
            Student person = new Student("Кирилл");
            Random rnd = new Random();
            for (int i = 0; i < 5; i++) array.Add(Convert.ToString(rnd.Next(0, 10)));
            array.Add("Эта строка была добавлена, и следующая тоже");
            array.Add(person.Name);
            foreach (object obj in array) Console.Write(obj + "; ");
            Console.WriteLine("\nТекущий размер коллекции: " + array.Count);
            Console.Write("Введите элемент, который надо удалить: ");
            array.Remove(Console.ReadLine());
            foreach (object i in array) Console.Write(i + "; ");
            Console.WriteLine("\nТекущий размер коллекции: " + array.Count);
            Console.Write("Введите элемент, который надо найти: ");
            if (array.Contains(Console.ReadLine())) Console.WriteLine("Этот элемент тут есть");
            else Console.WriteLine("Такого элемента тут нет");
            Console.WriteLine();


            Console.WriteLine("Stack<T>");
            Stack<double> stack = new Stack<double>();
            stack.Push(0.54);
            stack.Push(6.345);
            stack.Push(8.76543);
            stack.Push(3.87);
            stack.Push(9.18);
            stack.Push(5.55);
            stack.Push(2.532);
            stack.Push(1.69);
            stack.Push(7.478);
            stack.Push(4.2356);
            stack.Push(6.27);
            foreach (double d in stack) Console.Write(d + "; ");
            Console.Write("\nВведите количество элементов, которое надо удалить: ");
            int quantity = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < quantity; i++) stack.Pop();
            foreach (double d in stack) Console.Write(d + "; ");
            double pushObj;
            Console.Write("\nВведите элементы, которые надо добавить (0-выход): ");
            for (; ; )
            {
                pushObj = Convert.ToDouble(Console.ReadLine());
                if (pushObj == 0.0) break;
                stack.Push(pushObj);
            }
            foreach (double d in stack) Console.Write(d + "; ");
            Console.WriteLine();
            Console.WriteLine();


            Console.WriteLine("LinkedList<T>");
            LinkedList<double> spisok = new LinkedList<double>();
            spisok.AddFirst(2.53);
            spisok.AddLast(2.34);
            spisok.AddLast(5.89);
            spisok.AddLast(7.34);
            spisok.AddFirst(3.95);
            spisok.AddFirst(4.66);
            foreach (double d in spisok) Console.Write(d + "; ");
            Console.Write("\nВведите элемент, который надо найти: ");
            if (spisok.Contains(Convert.ToDouble(Console.ReadLine()))) Console.WriteLine("Этот элемент тут есть");
            else Console.WriteLine("Такого элемента тут нет");
            Console.WriteLine();


            Console.WriteLine("Stack<Student>");
            Stack<Student> sstack = new Stack<Student>();
            sstack.Push(new Student("Кирилл"));
            sstack.Push(new Student("Илья"));
            sstack.Push(new Student("Дима"));
            sstack.Push(new Student("Вадим"));
            foreach (Student d in sstack) Console.Write(d.Name + "; ");
            Console.Write("\nВведите количество элементов, которое надо удалить: ");
            int qquantity = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < qquantity; i++) sstack.Pop();
            foreach (Student d in sstack) Console.Write(d.Name + "; ");
            Console.Write("\nВведите элементы, которые надо добавить (0-выход): ");
            string str;
            for (; ; )
            {
                str = Convert.ToString(Console.ReadLine());
                if (str == "0") break;
                sstack.Push(new Student(str));
            }
            foreach (Student d in sstack) Console.Write(d.Name + "; ");
            Console.WriteLine();
            Console.WriteLine();


            Console.WriteLine("LinkedList<Student>");
            LinkedList<Student> sspisok = new LinkedList<Student>();
            LinkedListNode<Student> node = sspisok.AddFirst(new Student("Кирилл"));
            sspisok.AddLast(new Student("Илья"));
            sspisok.AddLast(new Student("Дима"));
            sspisok.AddFirst(new Student("Вадим"));
            foreach (Student d in sspisok) Console.Write(d.Name + "; ");
            Console.Write("\nВведите элемент, который надо найти: ");
            str = Convert.ToString(Console.ReadLine());
            Student pperson = new Student(str);
            int b = 0;
            for (int i = 0; i < sspisok.Count; i++)
            {
                if (pperson.Name == node.Next.Value.Name) b = 1;
            }
            if (b == 1) Console.WriteLine("Этот элемент тут есть");
            else Console.WriteLine("Такого элемента тут нет");
            Console.WriteLine();

            Student f = new Student("Кирилл");
            ObservableCollection<Student> observList = new ObservableCollection<Student>();

            observList.CollectionChanged += Changes;
            observList.Add(f);
            observList.RemoveAt(0);
        }
        private static void Changes(object sender, NotifyCollectionChangedEventArgs e)   
        {
            switch (e.Action)       //свойство Action позволяет узнать характер изменений
            {
                case NotifyCollectionChangedAction.Add: // если добавление
                    Student newFig = e.NewItems[0] as Student;  //Свойства NewItems и OldItems позволяют получить соответственно добавленные и удаленные объекты.
                    Console.WriteLine($"Добавлен новый объект: {newFig.Name}"); 
                    break;                                          
                case NotifyCollectionChangedAction.Remove: // если удаление
                    Student oldUser = e.OldItems[0] as Student;
                    Console.WriteLine($"Удален объект: {oldUser.Name}");
                    break;
                case NotifyCollectionChangedAction.Replace: // если замена
                    Student replacedUser = e.OldItems[0] as Student;
                    Student replacingUser = e.NewItems[0] as Student;
                    Console.WriteLine($"Объект {replacedUser.Name} заменен объектом {replacingUser.Name}");
                    break;
            }
        }
    }
}