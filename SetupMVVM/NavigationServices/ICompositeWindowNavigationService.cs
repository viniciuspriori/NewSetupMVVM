namespace SetupMVVM.Services
{
    public interface ICompositeWindowNavigationService
    {
        public void Navigate(params string[] windowNames);

    }
}