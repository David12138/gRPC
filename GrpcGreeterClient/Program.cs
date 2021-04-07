using Grpc.Net.Client;
using System;
using System.Threading.Tasks;

namespace GrpcGreeterClient
{
    class Program
    {
        /// <summary>
        /// 异步主方法
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        static async Task Main(string[] args)
        {
            ////创建通道
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            //创建客户端
            var client = new Greeter.GreeterClient(channel);
            //调用客户方法
            var reply = await client.SayHelloAsync(new HelloRequest { Name = "GreeterClient" });
            //打印
            Console.WriteLine("Greeting: " + reply.Message);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();

            //创建通道[user不可调用，依据官网和各路大神的方法，都不行，诶，凉凉]
            //using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            ////创建客户端
            //var client = new User.UserClient(channel);
            ////调用客户方法
            //var reply = await client.GetUser(new HelloRequest { Name = "123" });
            ////打印
            //Console.WriteLine("姓名: " + reply.Message);
            //Console.WriteLine("Press any key to exit...");
            //Console.ReadKey();
        }
    }
}