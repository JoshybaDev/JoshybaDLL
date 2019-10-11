using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Joshyba
{
    public class Criptografia
    {
        private string archivo="", llavedecocodi="";
        private int llave=0,Enc=0,p=0;
        long cipher=0;
        private string codificar = "";
        public static Criptografia Cripto;
        public int saltLengthLimit = 10;

        public Criptografia()
        {
            Criptografia.Cripto = this;
        }
        public string MD5Encryptar(string mensaje)
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();

            stream = md5.ComputeHash(encoding.GetBytes(mensaje));

            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);

            return sb.ToString();
        }
        public string Encriptar(string llaveu, string mensaje)
        {
            try
            {
                codificar = "";
                if (llaveu.Length > 0)
                {
                    llavedecocodi = llaveu.Substring(0, 4);
                }
                archivo = mensaje;
                llave = llavecodidecofuncion(llavedecocodi);
                Enc = checaprime(llave);
                do
                {
                    llave = llave - 1;
                    Enc = checaprime(llave); 
                } while (Enc == 0);
                for (int j = 0; j <= archivo.Length - 1; j++)
                {
                    cipher = Convert.ToInt64(archivo[j]) * llave;
                    codificar += Convert.ToChar(cipher);
                }
                return codificar;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "";
            }
        }
        public string Desencriptar(string llaveu="", string mensaje="")
        {
            string decodificar = "";
            try
            {
                codificar = "";
                if (llaveu.Length > 0)
                {
                    llavedecocodi = llaveu.Substring(0, 4);
                }
                archivo = mensaje;
                llave = llavecodidecofuncion(llavedecocodi);
                Enc = checaprime(llave);
                do
                {
                    llave = llave - 1;
                    Enc = checaprime(llave);
                } while (Enc == 0);
                for (int j = 0; j <= archivo.Length - 1; j++)
                {
                    cipher = Convert.ToInt64(archivo[j]) / llave;
                    decodificar += Convert.ToChar(cipher);
                }
                return decodificar;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "";
            }
        }
        private int llavecodidecofuncion(string llavedecocodi)
        {
            try
            {
                short c=0;
                Int16 j =0;
                foreach(char i in llavedecocodi)
                {
                   c+=Convert.ToInt16(i);
                   j+=1;
                }
                return c;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }
        private int checaprime(int llave3)
        {
            try
            {
                p=2;
                while(p<llave3)
                {
                    if(llave3%p==0)
                    {
                        Enc=1;
                        break;
                    }
                    else
                    {
                        Enc=0;
                    }
                    p += 1;
                }
                return Enc;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        //===================================================================================

        /*#region --> Generate SALT Key


        private static byte[] Get_SALT( )
        {
            return Get_SALT(10);
        }

        private static byte[] Get_SALT(int maximumSaltLength)
        {
            var salt = new byte[maximumSaltLength];

            //Require NameSpace: using System.Security.Cryptography;
            using (var random = new RNGCryptoServiceProvider())
            {
                random.GetNonZeroBytes(salt);
            }

            return salt;
        }

        #endregion*/



        public static string Get_HASH_SHA512(string password, string username, byte[] salt)
        {
            try
            {
                //required NameSpace: using System.Text;
                //Plain Text in Byte
                byte[] plainTextBytes = Encoding.UTF8.GetBytes(password + username);

                //Plain Text + SALT Key in Byte
                byte[] plainTextWithSaltBytes = new byte[plainTextBytes.Length + salt.Length];

                for (int i = 0; i < plainTextBytes.Length; i++)
                {
                    plainTextWithSaltBytes[i] = plainTextBytes[i];
                }

                for (int i = 0; i < salt.Length; i++)
                {
                    plainTextWithSaltBytes[plainTextBytes.Length + i] = salt[i];
                }

                HashAlgorithm hash = new SHA512Managed();
                byte[] hashBytes = hash.ComputeHash(plainTextWithSaltBytes);
                byte[] hashWithSaltBytes = new byte[hashBytes.Length + salt.Length];

                for (int i = 0; i < hashBytes.Length; i++)
                {
                    hashWithSaltBytes[i] = hashBytes[i];
                }

                for (int i = 0; i < salt.Length; i++)
                {
                    hashWithSaltBytes[hashBytes.Length + i] = salt[i];
                }

                return Convert.ToBase64String(hashWithSaltBytes);
            }
            catch
            {
                return string.Empty;
            }
        }

    }
}
