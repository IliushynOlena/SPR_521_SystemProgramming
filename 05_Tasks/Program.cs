namespace _05_Tasks
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            //---------------Example 1----------
            //Task task = new Task(Display);
            //Task task = new Task(delegate ()
            //{
            //    Console.WriteLine("Start task method ");
            //    Console.WriteLine("End task method ");
            //});
            /*
            Task task = new Task(() =>
            {
                Console.WriteLine("Start task method ");
                Console.WriteLine("End task method ");
            });
            task.Start();
            task.Wait();//freeze



            ////start automaticly
            Task task2 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine($"Task 2 in Thread : " +
                $"{Thread.CurrentThread.ManagedThreadId}");
            });

            //start automaticly
            Task task3 = Task.Run(() => Console.WriteLine($"Task 3 in Thread :" +
                $" {Thread.CurrentThread.ManagedThreadId}"));


            //Console.ReadKey();
            //---------------Example 2----------
            Task[] tasks = new Task[3]
            {
                new Task( ()=> { Console.WriteLine("First Task"); }),
                new Task( ()=> { Console.WriteLine("Second Task"); }),
                new Task( ()=> { Console.WriteLine("Third Task"); })
            };
            foreach (var item in tasks)
            {
                item.Start();
            }
            Task.WaitAll(tasks);
            Console.WriteLine("All task have done work");
            Random random = new Random();

            Task[] tasks2 = new Task[3];
          
            int j = 1;
            for (int i = 0; i < tasks2.Length; i++)
            {
                tasks2[i] = Task.Run(() =>
                {
                    Thread.Sleep(random.Next(3000));
                    Console.WriteLine($"Task {j++}");
                });
            }
            
            Task.WaitAny(tasks2);
            Console.WriteLine("Any task have done work ");
            Console.ReadKey();

            */
            //---------------Example 3----------
            //Task task = new Task(() =>
            //{
            //    Console.WriteLine($"Task id : {Task.CurrentId}");
            //    Thread.Sleep(1000);
            //});

            //Task task2 = task.ContinueWith(Display)
            //    .ContinueWith(Display)
            //    .ContinueWith(Display);

            //task.Start();
            //task2.Wait();
            //Console.WriteLine("Main is working...");
            //Console.ReadKey();

            Task<int> task4 = new Task<int>(() => Factorial(5));
            Task<int> task5 = task4.ContinueWith(Summa);
            task4.Start();
            
          
            //task4.Wait();

            Console.WriteLine(task4.Result);
            Console.WriteLine(task5.Result);

        }
        static int Factorial(int x)
        {
            int result = 1;
            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }
            return result;
        }
        static int Summa(Task<int> prev)
        {
            int summa = prev.Result + prev.Result;
            return summa;

        }
        static void Display(Task prev)
        {
            Console.WriteLine($"Task id curent thread: {Task.CurrentId}");
            Console.WriteLine($"Task id prev thread: {prev.Id}");
            Console.WriteLine("Start task method ");
            Console.WriteLine("End task method ");
        }
    }
}
