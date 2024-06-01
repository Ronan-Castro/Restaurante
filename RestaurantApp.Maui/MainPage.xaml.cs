using Microsoft.Maui.Controls.PlatformConfiguration;

namespace RestaurantApp.Maui
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            
            InitializeComponent();
            // Verificar e solicitar permissões
            //CheckAndRequestPermissions();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
           // CheckAndRequestPermissions();
        }

        async void CheckAndRequestPermissions()
        {
            var statusStorage = await Permissions.CheckStatusAsync<Permissions.StorageWrite>();

            if (statusStorage != PermissionStatus.Granted)
            {
                var result = await Permissions.RequestAsync<Permissions.StorageWrite>();

                if (result != PermissionStatus.Granted)
                {
                    // Lidar com a recusa do usuário
                    // Pode exibir uma mensagem ou tomar outras medidas apropriadas
                }
            }
        }
    }
}
