using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Data;
using System.IO;

namespace Joshyba
{
    public class Archivos
    {
        public static Archivos documents;
        public string Mensaje_error = "";
        public bool resultado;
        public Archivos()
        {
            Archivos.documents = this;
        }
        //convertir binario a imágen
        public void Bytes_File(Byte[] Imagen,string ruta)
        {
            try
            {
                if (Imagen != null)
                {
                    File.WriteAllBytes(ruta, Imagen);
                    resultado= true;
                }
            }
            catch(Exception ex)
            {
                Mensaje_error = ex.Message;
            }
        }
        public Byte[] Imagen_Bytes(Image Imagen)
        {
            if(Imagen!=null)
            {
                MemoryStream Bin= new MemoryStream();
                Imagen.Save(Bin,System.Drawing.Imaging.ImageFormat.Jpeg);
                return Bin.GetBuffer();
            }
            else
            {
                return null;
            }
        }

        //***********************************************************************************************
        public byte[] Archivo(string filePath)
        {
            FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(stream);
            byte[] photo = reader.ReadBytes((int)stream.Length);
            reader.Close();
            stream.Close();
            return photo;
        }
 
    }
}
