using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using QINIUYUN.View;
using System.Windows.Input;
using Qiniu.Util;
using Qiniu.Storage;
using Qiniu.Storage.Model;
using System.Collections.Generic;
using System;

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
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            Test();
            //return;
            //Mac mac = new Mac(QINIU.Properties.Settings.Default.AK, QINIU.Properties.Settings.Default.SK);
            //BucketManager bm = new BucketManager(mac);
            //string bucket = "data"; // 目标空间
            //string marker = ""; // 首次请求时marker必须为空
            //string prefix = null; // 按文件名前缀保留搜索结果
            //string delimiter = null; // 目录分割字符(比如"/")
            //int limit = 100; // 最大值1000
            //                 // 返回结果存储在items中

            //List<FileDesc> items = new List<FileDesc>();
            //do
            //{
            //    var result = bm.listFiles(bucket, prefix, marker, limit, delimiter);
            //    marker = result.Marker;
            //    if (result.Items != null)
            //    {
            //        items.AddRange(result.Items);
            //    }
            //} while (!string.IsNullOrEmpty(marker));

            //foreach (var item in items)
            //{
            //    System.Console.WriteLine(item.ToString());
            //}
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
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
                    System.Console.WriteLine(item.Key);
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