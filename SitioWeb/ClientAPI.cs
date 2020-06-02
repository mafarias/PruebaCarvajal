using Newtonsoft.Json;
using SitioWeb.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace SitioWeb
{
    public class ClientAPI
    {

        public string EjecutarApi(UsuarioModel entitie, string accion)
        {
            try
            {

                var url = "https://localhost:44368/api/usuario"; 
                string tipoR = string.Empty;
                string res = string.Empty;
                if (accion == "consulta")
                {
                    var request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = "GET";
                    request.ContentType = "application/json";
                    request.Accept = "application/json";
                    tipoR = "GET";
                    //var json = JsonConvert.SerializeObject(entitie);
                    //var res = GetApiHttpPost(url, string.Empty, tipoR);
                    using (WebResponse response = request.GetResponse())
                    {
                        using (Stream strReader = response.GetResponseStream())
                        {
                            if (strReader == null) 
                            using (StreamReader objReader = new StreamReader(strReader))
                            {
                                 res = objReader.ReadToEnd();
                                // Do something with responseBody
                                
                            }
                        }
                    }
                    return res;
                }
                else if (accion == "consultaxId")
                {
                    tipoR = "GET";
                    url = url + "/" + entitie.Id.ToString();
                    var request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = "GET";
                    request.ContentType = "application/json";
                    request.Accept = "application/json";
                    var json = JsonConvert.SerializeObject(entitie);
                    using (WebResponse response = request.GetResponse())
                    {
                        using (Stream strReader = response.GetResponseStream())
                        {
                            if (strReader == null) 
                            using (StreamReader objReader = new StreamReader(strReader))
                            {
                                 res = objReader.ReadToEnd();
                                // Do something with responseBody
                                
                            }
                        }
                    }
                    //res = GetApiHttpPost(url, json, tipoR);
                    return res;
                }
                else if (accion == "crear")
                {
                    tipoR = "POST";

                    var json = JsonConvert.SerializeObject(entitie);
                     res = GetApiHttpPost(url, json, tipoR);
                    return res;
                }
                else if (accion == "actualizar")
                {
                    tipoR = "PUT";
                    url = url + "/" + entitie.Id.ToString();
                    var json = JsonConvert.SerializeObject(entitie);
                     res = GetApiHttpPost(url, json, tipoR);
                    return res;
                }
                else if (accion == "eliminar")
                {
                    tipoR = "DELETE";
                    url = url + "/" + entitie.Id.ToString();
                    var json = JsonConvert.SerializeObject(entitie);
                     res = GetApiHttpPost(url, json, tipoR);
                    return res;
                }
                else if (accion == "TipoDoc")
                {
                    tipoR = "GET";
                    url = "https://localhost:44368/api/Docs";
                    var json = string.Empty;
                     res = GetApiHttpPost(url, json, tipoR);
                    return res;
                }

                return "";

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string GetApiHttpPost(string path, string valor, string tipo)
        {
            try
            {
                string url = path;
                string postdata = valor;
                byte[] data = Encoding.UTF8.GetBytes(postdata);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                request.KeepAlive = false;
                request.ProtocolVersion = HttpVersion.Version10;

                request.Method = tipo;
                //request.Method = "POST";
                request.Timeout = 30000;
                // turn our request string into a byte stream
                byte[] postBytes = Encoding.UTF8.GetBytes(postdata);

                // this is important - make sure you specify type this way
                request.ContentType = "application/json; charset=UTF-8";
                request.Accept = "application/json";
                if (valor.Length >1)
                {
                    request.ContentLength = postBytes.Length;
                }
                

                Stream requestStream = request.GetRequestStream();

                // now send it
                requestStream.Write(postBytes, 0, postBytes.Length);
                requestStream.Close();

                // grab te response and print it out to the console along with the status code
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string result;
                using (StreamReader rdr = new StreamReader(response.GetResponseStream()))
                {
                    result = rdr.ReadToEnd();
                }
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
