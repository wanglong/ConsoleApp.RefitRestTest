using Refit;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp.RefitRestTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main Thread Id: {0}\r\n", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Hello World!");

            Test();   

            //Test1();

            Console.ReadLine();
        }

        static async Task Test1()
        {
            Console.WriteLine("Before calling GetUser, Thread Id: {0}\r\n", Thread.CurrentThread.ManagedThreadId);
            var userInfo = GetAsync();    //我们这里没有用 await,所以下面的代码可以继续执行
                                          // 但是如果上面是 await GetAsync()，下面的代码就不会立即执行，输出结果就不一样了。
            Console.WriteLine("End calling GetUser.\r\n");
            var octocat = await userInfo;
            Console.WriteLine("Get result from GetUser octocat: {0}", octocat.Id +"  "+ octocat.Name);            
        }

        static async Task<User> GetAsync()
        {   // 这里还是主线程
            Console.WriteLine("Before calling Task.Run, current thread Id is: {0}", Thread.CurrentThread.ManagedThreadId);
            var gitHubApi = RestService.For<IGitHubApi>("https://api.github.com");
            var octocat = await gitHubApi.GetUserAsync("octocat");
            Console.WriteLine("'GetUser' Thread Id: {0}", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Get result from GetUser octocat: {0}", octocat.Id + "  " + octocat.Name);
            return octocat;
        }


        static async Task Test()
        {
            Console.WriteLine("Before calling GetName, Thread Id: {0}\r\n", Thread.CurrentThread.ManagedThreadId);
            var name = GetName();   //我们这里没有用 await,所以下面的代码可以继续执行
                                    // 但是如果上面是 await GetName()，下面的代码就不会立即执行，输出结果就不一样了。
            Console.WriteLine("End calling GetName.\r\n");
            Console.WriteLine("Get result from GetName: {0}", await name);
        }

        static async Task<string> GetName()
        {
            // 这里还是主线程
            Console.WriteLine("Before calling Task.Run, current thread Id is: {0}", Thread.CurrentThread.ManagedThreadId);
            return await Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("'GetName' Thread Id: {0}", Thread.CurrentThread.ManagedThreadId);
                return "Jesse";
            });
        }
    }
}
