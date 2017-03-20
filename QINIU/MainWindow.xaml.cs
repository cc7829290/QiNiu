using Qiniu.Storage;
using Qiniu.Storage.Model;
using Qiniu.Util;
using QINIUYUN.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QINIUYUN
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            //Test();
        }

        private void GotoSetting(object sender, RoutedEventArgs e)
        {
            Test();
            SettingWindow win = new SettingWindow();
            win.Owner = this;
            win.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            win.ShowDialog();
        }
        private void Test()
        {
            try
            {


                Mac mac = new Mac(QINIUYUN.Properties.Settings.Default.AK, QINIUYUN.Properties.Settings.Default.SK);
                BucketManager bm = new BucketManager(mac);
                string bucket = "data"; // 目标空间
                string marker = ""; // 首次请求时marker必须为空
                string prefix = null; // 按文件名前缀保留搜索结果
                string delimiter = null; // 目录分割字符(比如"/")
                int limit = 100; // 最大值1000
                                 // 返回结果存储在items中

                List<FileDesc> items = new List<FileDesc>();
                do
                {
                    var result = bm.listFiles(bucket, prefix, marker, limit, delimiter);
                    marker = result.Marker;
                    if (result.Items != null)
                    {
                        items.AddRange(result.Items);
                    }
                } while (!string.IsNullOrEmpty(marker));

                foreach (var item in items)
                {
                    System.Console.WriteLine(item.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
    }
}
