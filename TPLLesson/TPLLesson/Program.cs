using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using System.Threading;

namespace TPLLesson
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} выполняет работу");

            /*1 способ создания
            Task task = new Task(() => 
            {
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} выполняет работу");
            });
            task.wait(); главный поток (теккущий) дожидается выполнение таска
            task.Start();
            
            */
            /*2 способ
            Task.Factory.StartNew(() =>
            {
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} выполняет работу");
            });
            */

            /*3 способ*/
            var data = Task.Run(() =>
            {
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} выполняет работу");
                return 5;//какой-то любой результат
            }).Result;//для получения результата

            Console.WriteLine(data);

            /*CancellationTokenSource source = new CancellationTokenSource();

            var cancelationToken = source.Token;

            var task = new Task(() =>
            {
                Thread.Sleep(3000);
                Console.WriteLine("Таск завершен");
            }, cancelationToken);
            task.Start();
            source.Cancel();
            source.Dispose();
            Подход для завершения ваших задач походу скачивания на фоне*/

            Console.ReadLine();

        }

        // TODO доделать
        /*Когда вы ничего не возвращаете*/
        static Task/*<string>*/ GetDataAsync()
        {
            //CPU bound operation, как и Factory.StartNew() и task.Start()
            /*return Task.Run(() =>
            {
                return "";
            });*/

            try
            {
                //какие-то вычисления
                var data = "asd" + "asdawd";
                return Task.CompletedTask;/*FromResult(data);*/
            }
            catch(Exception exception)
            {
                return Task.FromException(exception);
            }
        }
    }
}

/* Еcть уже готовыt делегаты Acion, Func==возвращает результат, Predicate==Условность*/
