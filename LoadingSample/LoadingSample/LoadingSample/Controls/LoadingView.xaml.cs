using System.Collections.ObjectModel;
using LoadingSample.Models;
using Xamarin.Forms;

namespace LoadingSample.Controls
{
    public partial class LoadingView : ContentView
    {
        public LoadingView()
        {
            InitializeComponent();
        }

        #region --Public properties--

        public static readonly BindableProperty SourceProperty = BindableProperty.Create(
            nameof(Source), typeof(ObservableCollection<LoadChainModel>), typeof(LoadingView), propertyChanged: OnSourceChanged);

        public ObservableCollection<LoadChainModel> Source
        {
            get { return (ObservableCollection<LoadChainModel>)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        public static readonly BindableProperty DescriptionProperty = BindableProperty.Create(
            nameof(Description), typeof(string), typeof(LoadingView), default(string));

        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }

        #endregion

        #region --Private helpers--

        private static void OnSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var source = newValue as ObservableCollection<LoadChainModel>;
            if (source != null)
            {
                ((LoadingView)bindable).Init();
            }
        }

        private void Init()
        {
            _source?.Children.Clear();
            foreach (var item in Source)
            {
                var image = CreateItem(item);
                _source.Children.Add(image);
            }
        }

        private Image CreateItem(LoadChainModel item)
        {
            var image = new Image()
            {
                BindingContext = item
            };

            return image;
        }

        #endregion
    }
}
