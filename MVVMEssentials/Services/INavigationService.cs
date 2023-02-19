namespace MVVMEssentials.Services
{
    public interface INavigationService<T> where T : new()
    {
        void Navigate(T parameter = default);
    }
}