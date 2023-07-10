using Grpc.Core;
using gRPC_Server.Data;
using gRPC_Server.Services;

new ServerDbContext().Database.EnsureCreated();

Server server = new()
{
    Ports = { new ServerPort("localhost", 1234, ServerCredentials.Insecure) },
    Services = { PeopleService.BindService(new PeopleServiceImpl()) }
};

try
{
    server.Start();
    Console.WriteLine("Server is running with port 1234");

    Console.WriteLine("Press enter to close the server");
    Console.ReadLine();
}
catch (Exception ex)
{
    Console.WriteLine("An error occurred: " + ex.ToString());
}
finally
{
    if (server is not null)
    {
        await server.ShutdownAsync();
    }
}