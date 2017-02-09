using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MyUIGenerator
{
    public class UIHelper
    {
        public static BitmapImage GetImageFromByte(string path)
        {
            //  path = "asd";
            path = "/MyUIGenerator;component" + "/" + path;
            //MemoryStream ms = new MemoryStream(bytes);
            //ms.Write(bytes, 0, bytes.Length);
            //ms.Position = 0; // THIS !!!!!
            //return BitmapImage..FromStream(ms); 
            path = path.Replace("//", "/");
            BitmapImage image = new BitmapImage();
            //////MemoryStream stream = new MemoryStream(bytes);
            //////image.BeginInit();
            //////image.StreamSource = stream;
            //////image.EndInit();
            image.BeginInit();
            image.UriSource = new Uri(path, UriKind.Relative);
            image.EndInit();

            return image;
        }
        public static Color getColorFromHexString(string color)
        {
            if (color.StartsWith("#"))
                color = color.Remove(0, 1);
            byte a = System.Convert.ToByte(color.Substring(0, 2), 16);
            byte r = System.Convert.ToByte(color.Substring(2, 2), 16);
            byte g = System.Convert.ToByte(color.Substring(4, 2), 16);
            byte b = System.Convert.ToByte(color.Substring(6, 2), 16);
            return Color.FromArgb(a, r, g, b);
        }

        public static T Clone<T>(T obj)
        {
            DataContractSerializer dcSer = new DataContractSerializer(obj.GetType());
            MemoryStream memoryStream = new MemoryStream();

            dcSer.WriteObject(memoryStream, obj);
            memoryStream.Position = 0;

            T newObject = (T)dcSer.ReadObject(memoryStream);
            return newObject;
        }
        //internal static byte[] GetBytesFromFilePath(string path)
        //{
        //  return  System.IO.File.ReadAllBytes(path);
        //}



        internal static Button GenerateCommand(MyUILibrary.I_Command command)
        {
            var btnCommand = new Button();
            btnCommand.MinWidth = 100;
            btnCommand.Tag = command;
            StackPanel content = new StackPanel();
            content.Orientation = Orientation.Horizontal;
            if (!string.IsNullOrEmpty(command.ImagePath))
            {
                Image image = new Image();
                //image.Width = 20;
                //image.Height = 15;
                image.Source = UIHelper.GetImageFromByte(command.ImagePath);
                // btnCommand.ImageAlign = ContentAlignment.MiddleLeft;
                content.Children.Add(image);
                // btnCommand.BackgroundImageLayout = ImageLayout.Stretch;
            }
            TextBlock header = new TextBlock();
            header.Text = command.Title;
            header.Margin = new System.Windows.Thickness(5, 0, 2, 0);
            content.Children.Add(header);
            btnCommand.Content = content;
            btnCommand.Margin = new System.Windows.Thickness(2);
            btnCommand.Height = 22;
            return btnCommand;
        }
    }
}
