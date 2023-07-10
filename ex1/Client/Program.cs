using Grpc.Core;

Channel channel = new("localhost:1234", ChannelCredentials.Insecure);
try
{
    await channel.ConnectAsync();
    Console.WriteLine("Successfully connected to the server!");

    Console.WriteLine("First name?");
    var name = Console.ReadLine();

    Console.WriteLine("Last name? ");
    var lastName = Console.ReadLine();

    var request = new CreatePersonRequest
    {
        FirstName = name,
        LastName = lastName
    };

    var client = new PeopleService.PeopleServiceClient(channel);

    var response = await client.CreatePersonAsync(request);

    Console.WriteLine($"{response.FirstName} {response.LastName} has been created " +
        $"on the server! (id = {response.Id})");

    Console.WriteLine("Press enter to close the client");
    Console.ReadLine();
}
catch (Exception ex)
{
    Console.WriteLine("An error occurred: " + ex.ToString());
    Console.ReadLine();
}
finally
{
    if (channel is not null)
    {
        await channel.ShutdownAsync();
    }
}