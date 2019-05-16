using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HMI_ProductData
{

    //回调函数
    public delegate string EventCallBackGetShowText();//读取显示值的回调
    public delegate void EventCallBackSetShowText(string inString);//设置显示值的回调

    /// <summary>
    /// KeyBoard.xaml 的交互逻辑
    /// </summary>
    public partial class KeyBoard : Window
    {

        public EventCallBackGetShowText GetShowTextCallBack;//读取显示值
        public EventCallBackSetShowText SetShowTextCallBack;//设置显示值

        public KeyBoard()
        {
            InitializeComponent();
        }

        //数字键
        private void Num1_Click(object sender, RoutedEventArgs e)
        {
            string showText;
            if(GetShowTextCallBack!=null)
            {
                showText = GetShowTextCallBack();
                if (sender == Num1)
                {
                    showText += "1";
                }
                else if (sender == Num2)
                {
                    showText += "2";
                }
                else if (sender == Num3)
                {
                    showText += "3";
                }
                else if (sender == Num4)
                {
                    showText += "4";
                }
                else if (sender == Num5)
                {
                    showText += "5";
                }
                else if (sender == Num6)
                {
                    showText += "6";
                }
                else if (sender == Num7)
                {
                    showText += "7";
                }
                else if (sender == Num8)
                {
                    showText += "8";
                }
                else if (sender == Num9)
                {
                    showText += "9";
                }
                else if (sender == Num0)
                {
                    showText += "0";
                }
                //加载到页面显示
                SetShowTextCallBack?.Invoke(showText);

            }

            
        }
        //退格键
        private void NumDel_Click(object sender, RoutedEventArgs e)
        {
            string showText;
            if (GetShowTextCallBack != null)
            {
                showText = GetShowTextCallBack();

                if (showText.Length > 0)
                {
                    showText = showText.Substring(0, showText.Length - 1);
                }
                //加载到页面显示
                SetShowTextCallBack?.Invoke(showText);

            }
        }
        //清空
        private void Btclr_Click(object sender, RoutedEventArgs e)
        {
            string showText;
            if (GetShowTextCallBack != null)
            {
                showText = GetShowTextCallBack();

                showText = "";
                //加载到页面显示
                SetShowTextCallBack?.Invoke(showText);

            }
        }

        //+-号
        private void BtPlus_Click(object sender, RoutedEventArgs e)
        {
            string showText;
            if (GetShowTextCallBack != null)
            {
                showText = GetShowTextCallBack();

                if(showText.Contains("-"))
                {
                    showText=showText.Remove(0, 1);
                }
                else
                {
                    showText = "-" + showText;
                }
                //加载到页面显示
                SetShowTextCallBack?.Invoke(showText);

            }
        }

        //关闭窗口
        private void BtEnter_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void NumDecimal_Click(object sender, RoutedEventArgs e)
        {
            string showText;
            if (GetShowTextCallBack != null)
            {
                showText = GetShowTextCallBack();

                if (!showText.Contains("."))
                {
                    showText+=".";
                }
                //加载到页面显示
                SetShowTextCallBack?.Invoke(showText);

            }
        }
    }
}
