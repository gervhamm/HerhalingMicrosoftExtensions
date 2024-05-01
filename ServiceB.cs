class ServiceB
{
    private readonly ServiceA _service;
    public ServiceB(ServiceA service)
    {
        Console.WriteLine("Service B Created");
        _service = service;
    }
    public void Print(string message)
    {
        _service.Print(message);
    }
}