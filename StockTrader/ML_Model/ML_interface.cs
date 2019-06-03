﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using IEXDataLibrary;
using Newtonsoft.Json;
using System.Net.Http;



namespace StockTrader.ML_Model
{
    class ML_interface
    {
        public static int GetPrediction(String ticker)
        {
            
            //get data from IEX interface
            var data = IEXDataLibrary.IEXDataAccess.GetGeneralData(ticker, "3m");




            //convert data into JSON and prepare for HTTP POST
            var json_data = JsonConvert.SerializeObject(data);
            var http = new HttpClient();
            //for now, the URL will be to localhost.  will determine at later date if Google Cloud Services will host the model API
            String url = "http://localhost:5000";
            var response = http.PostAsync(url, new StringContent(json_data, Encoding.UTF8, "application/json"));
            //we'll let the Python handle the json data.  parsing it would require creating a new object, so it seems the manipulations are easier done in python
            
    


            //parse response for prediction, and return that

            return 0;
        }
    }
}