namespace TechnoTest.Services.Factory.Abstraction
{
    public interface IServiceFactory<TService>
    {
        TService Service { get; }
    }
}