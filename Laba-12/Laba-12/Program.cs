using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;


namespace _12lab
{
    class FILE
    {
        public static void ReadFile(Type type, string method)
        {
            StreamReader sr = new StreamReader(@"C:\Кирилл\message.txt");
            object obj = Activator.CreateInstance(type, true);  
            string stringF = sr.ReadToEnd();
            MethodInfo methodInfo = type.GetMethod(method);
            var result = methodInfo.Invoke(obj, new object[] { });
            Console.WriteLine("Вызов метода: ");
            (obj as Lists).Output();
        }

        public static void WriteToFile(StreamWriter file, string str)
        {
            file.WriteLine(str);
            Console.WriteLine(str);
        }

        public static void ToFile(Type t)
        {
            StreamWriter info = new StreamWriter(@"C:\Кирилл\text.txt", false, System.Text.Encoding.Default);
            bool IS = t.IsSealed, II = t.IsInterface, IC = t.IsClass, IArr = t.IsArray, IA = t.IsAbstract, IE = t.IsEnum;
            WriteToFile(info, $"Main Info: ");
            WriteToFile(info, $"FullName:    [{t.FullName}]");
            WriteToFile(info, $"Name:        [{t.Name}]");
            WriteToFile(info, $"BaseType:    [{t.BaseType}]");
            WriteToFile(info, $"IsSealed:    [{IS}]");
            WriteToFile(info, $"IsInterface: [{II}]");
            WriteToFile(info, $"IsClass:     [{IC}]");
            WriteToFile(info, $"IsAbstract:  [{IA}]");
            WriteToFile(info, $"IsEnum:      [{IE}]");
            WriteToFile(info, $"IsArray:     [{IArr}]");
            MethodInfo[] methodinfo = t.GetMethods();
            PropertyInfo[] propertyinfo = t.GetProperties();
            ConstructorInfo[] constructorinfo = t.GetConstructors();
            FieldInfo[] fileinfo = t.GetFields();
            Type[] i = t.GetInterfaces();
            WriteToFile(info, "Methods:");
            foreach (var s in methodinfo)
                WriteToFile(info, $"    [{s.ToString()}]");
            WriteToFile(info, "Properties:");
            foreach (var b in propertyinfo)
                WriteToFile(info, $"   [{b.ToString()}]");
            WriteToFile(info, "Constructors:");
            foreach (var s in constructorinfo)
                WriteToFile(info, $"   [{s.ToString()}]");
            WriteToFile(info, "Fields:");
            foreach (var s in fileinfo)
                WriteToFile(info, $"   [{s.ToString()}]");
            WriteToFile(info, "Interfaces:");
            foreach (var s in i)
                WriteToFile(info, $"   [{s.ToString()}]");
            WriteToFile(info, "Имена методов, содержащие типы Int32:");
            foreach (var s in methodinfo)
            {
                var MethodParams = s.GetParameters();
                foreach (var k in MethodParams)
                    if (k.ParameterType == typeof(Int32))
                        WriteToFile(info, $"   [{s.Name}]");
            }
            info.Close();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            FILE.ToFile(typeof(Lists));
            FILE.ReadFile(typeof(Lists), "RandomFill");
        }
    }
}