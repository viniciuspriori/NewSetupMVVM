# **Reference Sheet**

This project was forked from SingletonSean's _"wpf-tutorial"_ repository. Please check his videos and code if you want a full explanation about the resources of this navigation pattern.

SingletonSean navigation playlist: https://www.youtube.com/watch?v=N26C_Cq-gAY&list=PLA8ZIAm2I03ggP55JbLOrXl6puKw4rEb2

I incorpored a window navigation service and packed together the modal project. The objective was to make it easier to setup MVVM aplications in WPF.

Below we have some reference info for a quick-start:

# Navigating:
* The pattern of the all Navigation Services is very similar, just pass a Store and a Func that creates a ViewModel

### Stores
* NavigationStore: Stores the current user control in the MainViewModel
* ModalNavigationStore: Stores the current modal user control in the MainViewModel
* WindowNavigationStore: Stores the current Window displayed

### Services

* NavigationService: navigate between user controls

* ModalNavigationService and CloseModalNavigationService: Pop-up navigation

* CompositeNavigationService: Multiple navigations

### Interfaces
* INavigationService: General navigation interface, used in 99% of the cases

* ICompositeWindowNavigationService: navigate between multiple windows and user controls


### Commands
* NavigateCommand: Used for general navigation, if the destionation is a window, pass the window name as a parameter

* WindowNavigationCommand: Optional command for window navigation, for the sake of organization

* CompositeWindowNavigateCommand: used for navigating between multiple windows in the same time, very specific used case


# Code Examples

## Aplication Setup:

* The rule of thumb it to pass to the view models the NavigationService that contains the place you want to go. In the example below, I navigate from ViewModel1 to ViewModel2 and vice-versa. In the repository solution there is also code with dependency injection setup.

```c#
        private readonly NavigationStore _navigationService;

        public class App()
        {
            _navigationStore = new NavigationStore();
        }

        ///
        private ViewModel1 CreateViewModel1()
        {
            return new ViewModel1(CreateViewModel2NavigationService());
        }

        private INavigationService CreateViewModel1NavigationService()
        {
            return new NavigationService<ViewModel1>(_navigationStore, CreateViewModel1);
        }

        ///
        private ViewModel2 CreateViewModel2()
        {
            return new ViewModel2(CreateViewModel1NavigationService());
        }

        private INavigationService CreateViewModel2NavigationService()
        {
            return new NavigationService<ViewModel2>(_navigationStore, CreateViewModel2)
        }
```

 ## Command Binding:

 - View:
 ```xaml
         <Button Content="Open View Model 2" Command="{Binding GoToViewModel2Command}"/>
```
- ViewModel:
```c#
public class ViewModel1 : ViewModelBase
{
    public ICommand GoToViewModel2Command { get; }

    public ViewModel1(INavigationService goToViewModel2)
    {
        GoToViewModel2Command = new NavigateCommand(goToViewModel2);
    }
}
```
### __Attention!__ : All ViewModels must inherit from ViewModelBase.
&nbsp;

## MainWindow.xaml DataTemplate Setup:
```xaml
<Window...
    xmlns:viewmodels="clr-namespace:NewSetupMVVM.ViewModels"
    xmlns:views="clr-namespace:NewSetupMVVM.Views"
    xmlns:modalview="clr-namespace:NewSetupMVVM.Views.Modals"
    xmlns:modalviewmodel="clr-namespace:NewSetupMVVM.ViewModels.ModalViewModel">

    <Window.Resources>
        <DataTemplate DataType="{x:Type viewmodels:ViewModel1}">
            <views:View1/>
        </DataTemplate>
    </Window.Resources>

    <DataTemplate DataType="{x:Type modalviewmodel:MyModalViewModel}">
            <modalview:MyModal/>
        </DataTemplate>
    
    <Grid>
        <ContentControl Content="{Binding CurrentViewModel}"/>
    </Grid>
```

## MainViewModel Setup:
There is already a MainViewModel incorpored in the nuget package. If you wanna inherit from this and add your own code, you can do it.