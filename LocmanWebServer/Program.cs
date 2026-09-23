using System;
using System.Net;
using System.Text;
using System.Threading;

namespace LocmanWebServer
{
    // Точка входа консольного сервера.
    // При запуске: LocmanWebServer.exe [порт]
    // Если порт не задан — запрашивается ввод.
    static class Program
    {
        static HttpListener listener;

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Title = "Лоцман — веб-сервер адресного справочника";

            string prefix = "http://localhost/";
            int port;

            if (args.Length > 0 && int.TryParse(args[0], out port))
            {
                prefix = GetPrefix(port);
            }
            else
            {
                Console.WriteLine("Сервер веб-интерфейса «Лоцман» (адресный справочник, MSSQL).");
                Console.Write("Введите порт (по умолчанию 8080): ");
                string s = Console.ReadLine();
                if (!int.TryParse((s ?? "").Trim(), out port) || port <= 0 || port > 65535)
                    port = 8080;
                prefix = GetPrefix(port);
            }

            listener = new HttpListener();
            try
            {
                listener.Prefixes.Add(prefix);
                listener.Start();
            }
            catch (HttpListenerException)
            {
                // Нет прав на привязку http://+:port/ — пробуем localhost
                listener = new HttpListener();
                listener.Prefixes.Add("http://localhost:" + port + "/");
                listener.Start();
                prefix = "http://localhost:" + port + "/";
                Console.WriteLine("ВНИМАНИЕ: нет прав на прослушивание всех интерфейсов (требуется netsh urlacl или запуск от администратора).");
                Console.WriteLine("Запущено только для localhost.");
            }

            Console.WriteLine("Сервер запущен: " + prefix);
            Console.WriteLine("Откройте в браузере:  http://IP-адрес-сервера:" + port + "/");
            Console.WriteLine("Для остановки — Ctrl+C.");

            Console.CancelKeyPress += delegate(object sender, ConsoleCancelEventArgs e)
            {
                e.Cancel = true;
                listener.Stop();
            };

            try
            {
                while (listener.IsListening)
                {
                    HttpListenerContext ctx = listener.GetContext();
                    HandleSafely(ctx);
                }
            }
            catch (HttpListenerException) { /* остановлен */ }

            Console.WriteLine("Сервер остановлен.");
        }

        static void HandleSafely(HttpListenerContext ctx)
        {
            try
            {
                WebServer.Handle(ctx);
            }
            catch (Exception ex)
            {
                try
                {
                    byte[] b = Encoding.UTF8.GetBytes("Ошибка сервера: " + ex.Message);
                    ctx.Response.StatusCode = 500;
                    ctx.Response.ContentType = "text/plain; charset=utf-8";
                    ctx.Response.OutputStream.Write(b, 0, b.Length);
                    ctx.Response.Close();
                }
                catch { }
            }
        }

        static string GetPrefix(int port)
        {
            // "+" слушает все интерфейсы; при отсутствии прав Program.Main
            // делает автоматический откат на localhost.
            return "http://+:" + port + "/";
        }
    }
}
