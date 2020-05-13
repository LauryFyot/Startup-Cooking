using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ProjetNotrePetiteCuisine.Data.Base
{
    public class XmlPrinter
    {

        public static void PrintLastWeekOrders(Database database)
        {
            try
            {
                List<OrderType> orders = database.GetAllOrdersOfLastWeek();

                // Configure save file dialog box
                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                dlg.FileName = "Orders-Of-Last-Week-Cooking"; // Default file name
                dlg.DefaultExt = ".xml"; // Default file extension
                dlg.Filter = "Xml documents (.xml)|*.xml"; // Filter files by extension

                // Show save file dialog box
                Nullable<bool> result = dlg.ShowDialog();

                // Process save file dialog box results
                if (result == true)
                {
                    // Document path
                    string filePath = dlg.FileName;

                    Type[] types = { typeof(OrderType) };
                    DataContractSerializer serializer = new DataContractSerializer(typeof(List<OrderType>), types);

                    using (var sw = new StringWriter())
                    {
                        using (var writer = new XmlTextWriter(sw))
                        {
                            writer.Formatting = Formatting.Indented; // Indent the Xml so it's human readable
                            serializer.WriteObject(writer, orders);
                            writer.Flush();
                            File.WriteAllText(filePath, sw.ToString());
                        }
                    }
                    Console.WriteLine("Orders serialied to {0}", filePath);
                }
                else
                {
                    Console.WriteLine("Serialization aborted !");
                }
            } catch(Exception e) // Here we catch Exception
            {
                App.ShowExceptionPopup(e);
            }
        }
    }
}
