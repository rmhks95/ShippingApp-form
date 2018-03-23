using System;
using System.Collections.Generic;
using System.Configuration;
using DotNetShipping.ShippingProviders;
using System.Data.OleDb;
using System.Data;
using ZipTastic;
using System.Windows.Forms;
using System.Linq;

namespace DotNetShipping.SampleApp
{
    internal class Program
    {

        //static Form1 myForm;

        static double weight;
        static int width;
        static int height;
        static int length;
        public static string zipcode;
        public static bool res;
        public static int quan;
        static List<string> pn_in = new List<string>();
        public static string[,] readParts = new string[10,2];
        static List<Package> packages = new List<Package>();


        public static void Main()
        {

            

            Application.Run(new Form1());

        }

        public static void Begin() {
            packages = new List<Package>();
            unknownWeight = 0;
            oversized = false;
            
            pn_in = new List<string>();

            for(int i = 0; i<readParts.Length/2; i++)
            {
                    for (int n = 0; n < Convert.ToInt32(readParts[i,1]); n++)
                        pn_in.Add(readParts[i,0]);
            }

            string[] parts = new string[pn_in.Count*5];

            int j = 0;
            for (int i = 0; i < pn_in.Count; i++)
            {
                string part = pn_in[i].ToUpper();
             
                    var conn = new OleDbConnection();
                    conn.ConnectionString =
                                "Provider=SQLOLEDB.1;" ;

                    OleDbCommand command = new OleDbCommand("SELECT [item_no],[comp_item_no] FROM [dbo].[imkitfil_sql ] where [item_no]= '" + part + "'", conn);

                    //Try catch to make sure it reaches the database
                    try
                    {
                        conn.Open();
                    }
                    catch (Exception ex)
                    {
                        Console.Write("Can not open database connection! ");
                    }


                    //Setting da to the database command
                    OleDbDataAdapter da = new OleDbDataAdapter(command);

                    //Initializing DataSet for info pulled from database
                    DataSet dset = new DataSet();

                    //Puts pulled information into dset
                    da.Fill(dset, "info");
                    DataTable dt = dset.Tables["info"];

                if (dt.Rows.Count != 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        parts[j] = dr["comp_item_no"].ToString();
                        Console.WriteLine(parts[j]);
                        j++;
                    }
                }
                else
                {
                    parts[j] = part;
                    j++;
                }
            }

            Console.WriteLine();
            
            for (int i = 0; i < parts.Length; i++)
            {
                if(parts[i] != "" && parts[i] != null)
                {
                    Part_Finder(parts[i]);
                }
                
            }

            //Adds package of the items that have a zero in lot_size(unboxed items)
            if (unknownWeight != 0) {
                if (oversized)
                {
                    packages.Add(new Package(50, 4, 4, unknownWeight, 50));
                }
                else
                {
                    packages.Add(new Package(0, 0, 0, unknownWeight, 50));
                }
            }

            Start();
            
        }

        public static decimal unknownWeight = 0;
        public static bool oversized = false;

        private static void Part_Finder(string pn)
        {
            var conn = new OleDbConnection();
            conn.ConnectionString =
                        "Provider=SQLOLEDB.1;";

            //Command to get info on part that matches the entered part# 
            OleDbCommand command = new OleDbCommand("SELECT [item_no],[item_desc_1],[item_desc_2],[item_weight],[cube_width],[cube_height],[cube_length],[lot_size] FROM [dbo].[imitmidx_sql ] where [item_no]= '" + pn +"'", conn);

            //Try catch to make sure it reaches the database
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open database connection! ");
            }

            
            //Setting da to the database command
            OleDbDataAdapter da = new OleDbDataAdapter(command);

            //Initializing DataSet for info pulled from database
            DataSet dset = new DataSet();

            //Puts pulled information into dset
            da.Fill(dset, "info");
            DataTable dt = dset.Tables["info"];

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Part: " + pn + " was not found, price is based off other parts.");
                return;
            }

            foreach (DataRow dr in dt.Rows)
            {
                if(Convert.ToInt32(dr["lot_size"]) == 0)
                {
                    if(Convert.ToInt32(dr["cube_length"]) > 44)
                    {
                        oversized = true;
                    }
                    unknownWeight += Convert.ToDecimal(dr["item_weight"]);
                    return;
                }
                    
                
                weight = Convert.ToDouble(dr["item_weight"]);
                width = Convert.ToInt32(dr["cube_width"]);
                height = Convert.ToInt32(dr["cube_height"]);
                length = Convert.ToInt32(dr["cube_length"]);
            }

            if (width != 0)
            {
                // Setup package size
                packages.Add(new Package(length, width, height, weight, 50));
            }
            

        } 




        private static void Start()
        {
            var appSettings = ConfigurationManager.AppSettings;

            // You will need a license #, userid and password to utilize the UPS provider.
            var upsLicenseNumber = "############";
            var upsUserId = "############";
            var upsPassword = ("############*");

            // You will need an account # and meter # to utilize the FedEx provider.
            var fedexKey = "############"; //Test Key: "ffMloFez7JlC6YaK";
            var fedexPassword = "############"; //Test Password: "m1jGUiezQhQJggNWXGtUKX5yw";
            var fedexAccountNumber = "############";
            var fedexMeterNumber = "############"; //Productin Meter#:"118918154";
            var fedexHubId = "5531"; // 5531 is the hubId to use in FedEx's test environment
            var fedexUseProduction = true;//Convert.ToBoolean(appSettings["FedExUseProduction"]);

            // You will need a userId to use the USPS provider. Your account will also need access to the production servers.
            var uspsUserId = "############";


            //Gets state zipcode for destination (required by UPS for negotiated rates)
            var myZips = new ZipTastic.getZipInfo();
            var myZipCodeData = new iZip();
            try { myZipCodeData = myZips.getZipData(zipcode, "US"); }catch(Exception e) { try { myZipCodeData = myZips.getZipData(zipcode, "CA"); } catch (Exception l) { MessageBox.Show("Please enter a valid zipcode."); return; } }
            


            // Sets package destination/ origin addresses
            //       origin: hard coded to Humboldt
            var origin = new Address("", "", "#####", "US", false);
            var destination = new Address("", myZipCodeData.state_short, zipcode, myZipCodeData.country, res); // US Address
            //var destination = new Address("", "", "00907", "PR"); // Puerto Rico Address
            //var destination = new Address("", "", "L4W 1S2", "CA"); // Canada Address
            //var destination = new Address("", "", "SW1E 5JL", "GB"); // UK Address

            // Create RateManager
            var rateManager = new RateManager();

            // Add desired DotNetShippingProviders
            rateManager.AddProvider(new UPSProvider(upsLicenseNumber, upsUserId, upsPassword) { UseProduction = true });
            //rateManager.AddProvider(new UPSProvider(upsLicenseNumber, upsUserId, upsPassword, "UPS Ground"));
            rateManager.AddProvider(new FedExProvider(fedexKey, fedexPassword, fedexAccountNumber, fedexMeterNumber, fedexUseProduction, res));
            rateManager.AddProvider(new FedExSmartPostProvider(fedexKey, fedexPassword, fedexAccountNumber, fedexMeterNumber, fedexHubId, fedexUseProduction));
            rateManager.AddProvider(new USPSProvider(uspsUserId, "Priority Commercial"));
            //rateManager.AddProvider(new USPSInternationalProvider(uspsUserId));

            // (Optional) Add RateAdjusters
            rateManager.AddRateAdjuster(new PercentageRateAdjuster(1.05M));

            // Call GetRates()
            var shipment = rateManager.GetRates(origin, destination, packages);
            if (shipment.Rates.Count == 0)
            {
                MessageBox.Show("Something went wrong, Check inputs");
            }

            decimal[] rates = new decimal[shipment.Rates.Count];

            string result = "";
            

            shipment.Rates.Sort((x,y)=> decimal.Compare(x.TotalCharges, y.TotalCharges));
            

            foreach (var rate in shipment.Rates)
            {
                    result += rate.Name + Environment.NewLine + "         $" + rate.TotalCharges.ToString("#,##0.00") + Environment.NewLine;
            }
            if (result != "") { MessageBox.Show(result); } 


                
            //string restart = Console.ReadLine();

            //if(restart.ToLower() == "y")
            //{
            //    Console.WriteLine();
            //    Main();
            //};
        }

    }
}