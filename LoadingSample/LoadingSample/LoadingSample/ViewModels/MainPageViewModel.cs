using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using LoadingSample.Enums;
using LoadingSample.Models;
using Prism.Commands;
using Prism.Navigation;

namespace LoadingSample.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
        }

        #region --Public properties--

        private ObservableCollection<LoadChainModel> _loadingTasks;
        public ObservableCollection<LoadChainModel> LoadingTasks
        {
            get { return _loadingTasks; }
            set { SetProperty(ref _loadingTasks, value); }
        }

        private string _descriptionTask;
        public string DescriptionTask
        {
            get { return _descriptionTask; }
            set { SetProperty(ref _descriptionTask, value); }
        }

        private ICommand _signUpCommand;
        public ICommand SignUpCommand
        {
            get { return _signUpCommand ?? (_signUpCommand = new DelegateCommand(async () => await OnSignUpCommandAsync())); }
        }

        #endregion

        #region --Overrides--

        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);
            Init();
        }

        #endregion

        #region --Private helpers--

        private void Init()
        {
            LoadingTasks = new ObservableCollection<LoadChainModel>()
            {
                new LoadChainModel { Id = 0, Description = "CheckingConnection" },
                new LoadChainModel { Id = 1,  Description = "CheckingServerAvailability" },
                new LoadChainModel { Id = 2,  Description = "RegisteringClient" },
                new LoadChainModel { Id = 3,  Description = "RegisteringNotifications" }
            };
        }

        private async Task OnSignUpCommandAsync()
        {
            var result = true;

            foreach (var item in LoadingTasks)
            {
                item.State = ELoadState.Run;
                DescriptionTask = item.Description;

                result = await RunLoading(item.Id);
                if (!result)
                {
                    Init();
                    break;
                }
                item.State = ELoadState.Done;
            }

            if (result)
            {
                //await NavigationService.NavigateAsync(nameof(RootView));
            }
        }

        private async Task<bool> RunLoading(int i)
        {
            bool result;
            switch (i)
            {
                case 0:
                    result = await TaskAsync();
                    break;
                case 1:
                    result = await TaskAsync();
                    break;
                case 2:
                    result = await TaskAsync();
                    break;
                case 3:
                    result = await TaskAsync();
                    break;
                default:
                    result = false;
                    break;
            }

            return result;
        }

        private async Task<bool> TaskAsync()
        {
            await Task.Delay(3000);
            return true;
        }

        #endregion
    }
}
