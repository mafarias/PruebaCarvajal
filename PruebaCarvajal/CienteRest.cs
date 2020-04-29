using Newtonsoft.Json;
using PruebaCarvajal.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PruebaCarvajal
{
    public class CienteRest
    {
        public void EjecutarApi(UsuarioModel entitie, string accion)
        {
            try
            {

                var url = "https://localhost:44368/api/usuario";//ConfigurationManager.AppSettings["UrlApiExcepcion"]; 
                string tipoR = string.Empty;
                if (accion == "consulta")
                {
                    tipoR = "GET";
                    //var json = JsonConvert.SerializeObject(entitie);
                    var res = GetApiHttpPost(url, string.Empty, tipoR);
                }
                else if (accion == "consultaxId")
                {
                    tipoR = "GET";
                    url = url + "/" + entitie.Id.ToString();
                    var json = JsonConvert.SerializeObject(entitie);
                    var res = GetApiHttpPost(url, json,tipoR);
                }
                else if (accion == "crear")
                {
                    tipoR = "POST";
                    
                    var json = JsonConvert.SerializeObject(entitie);
                    var res = GetApiHttpPost(url, json, tipoR);
                }
                else if (accion == "actualizar")
                {
                    tipoR = "PUT";
                    url = url + "/" + entitie.Id.ToString();
                    var json = JsonConvert.SerializeObject(entitie);
                    var res = GetApiHttpPost(url, json, tipoR);
                }
                else if (accion == "eliminar")
                {
                    tipoR = "DELETE";
                    url = url + "/" + entitie.Id.ToString();
                    var json = JsonConvert.SerializeObject(entitie);
                    var res = GetApiHttpPost(url, json, tipoR);
                }
                else if (accion == "TipoDoc")
                {
                    tipoR = "GET";
                    url = "https://localhost:44368/api/Docs";
                    var json = string.Empty;
                    var res = GetApiHttpPost(url, json, tipoR);
                }



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
                request.ContentLength = postBytes.Length;

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
