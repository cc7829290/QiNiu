using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;

namespace QINIUYUN.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class SettingViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public SettingViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
            SaveSettingCommand = new RelayCommand(SaveSetting);
            ReloadSettingCommand = new RelayCommand(ReloadSetting);

        }
        public ICommand SaveSettingCommand { get; set; }
        public ICommand ReloadSettingCommand { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        private void SaveSetting()
        {
            //��������
            Properties.Settings.Default.Save();
        }
        /// <summary>
        /// ��ԭ��ʷ����
        /// </summary>
        private void ReloadSetting()
        {
            Properties.Settings.Default.Reset();
            Properties.Settings.Default.Save();
        }
    }
}