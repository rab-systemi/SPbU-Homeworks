using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace WeatherWindowsForms
{
    internal class Request<T>
    {
        public List<T> GetTemperature(string url)
        {
            string json;

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            using (StreamReader sr = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                json = sr.ReadToEnd();
            }

            List<T> mainClass = (List<T>)JsonConvert.DeserializeObject(json, typeof(List<T>));

            return mainClass;
        }

        public T GetTemperatureWeatherApi(string url)
        {
            string json;

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            using (StreamReader sr = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                json = sr.ReadToEnd();
            }

            T mainClass = (T)JsonConvert.DeserializeObject(json, typeof(T));

            return mainClass;
        }
    }
}