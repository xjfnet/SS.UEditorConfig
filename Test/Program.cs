using HookingDotNet;
using System;

namespace Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var interceptor = new Interceptor(typeof(Target).GetMethod("Get"), typeof(Program).GetMethod("Get"));

            //var target = new Target();
            //target.Get();
            Target.Get();

            interceptor.Invoke(() => Target.Get());
        }

        public static void Get()
        {
            Console.WriteLine("111111111111111");
        }
    }

    public static class Target
    {
        public static void Get()
        {
            Console.WriteLine("22222222222222");
        }
    }
}