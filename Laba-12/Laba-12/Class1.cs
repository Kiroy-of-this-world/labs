using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Lists
{
    List<int> someList = new List<int>(); //выделение памяти списка
    public Lists() //конструктор списка
    {
        List<int> someList = new List<int>();
    }
    public void Add(int element) //метод добавления элемента в список
    {
        someList.Add(element);
    }
    public void Output() //метод вывода списка
    {
        foreach (int i in someList)
        {
            Console.WriteLine(i);
        }
    }
    public void Delete(int element) //метод удаления элемента из списка
    {
        someList.RemoveAt(element);
    }
    public int Count() //метод возвращает количество элементов списка
    {
        return someList.Count();

    }
    public int Element(int i) //метод возвращает элемент списка
    {
        if (someList[i] <= someList.Count()) return someList[i];
        else return someList[i];
    }
    public void Revers() //метод инверсии списка
    {
        someList.Reverse();
    }
    public void RandomFill() //рандомизация
    {
        Random rnd = new Random();
        someList.Add(rnd.Next(1,20));
    }
    public static Lists operator +(Lists l1, Lists l2) //перегрузка оператора
    {
        var UnitedList = new Lists();
        for (int i = 0; i < l1.Count(); i++)
        {
            int element = l1.Element(i);
            UnitedList.Add(element);
        }
        for (int i = 0; i < l2.Count(); i++)
        {
            int element = l2.Element(i);
            UnitedList.Add(element);
        }
        return UnitedList;
    }
    public static Lists operator <(Lists l1, Lists l2) //перегрузка оператора
    {
        for (int i = 0; i < l2.Count(); i++)
        {
            int element = l2.Element(i);
            l1.Add(element);
        }
        return l1;
    }
    public static Lists operator >(Lists l1, Lists l2) //перегрузка оператора
    {
        for (int i = 0; i < l1.Count(); i++)
        {
            int element = l1.Element(i);
            l2.Add(element);
        }
        return l2;
    }
    public static Lists operator !(Lists l1) //перегрузка оператора
    {
        l1.Revers();
        return l1;
    }
    public static bool operator ==(Lists l1, Lists l2) //перегрузка оператора
    {
        int count = 0;
        if (l1.Count() != l2.Count()) return false;
        else
        {
            for (int i = 0; i < l1.Count(); i++)
            {
                if (l1.Element(i) == l2.Element(i)) count += 1;
            }
            if (count == l1.Count()) return true;
            else return false;
        }
    }
    public static bool operator !=(Lists l1, Lists l2) //перегрузка оператора
    {
        int count = 0;
        if (l1.Count() != l2.Count()) return true;
        else
        {
            for (int i = 0; i < l1.Count(); i++)
            {
                if (l1.Element(i) == l2.Element(i)) count += 1;
            }
            if (count == l1.Count()) return false;
            else return true;
        }
    }
}
