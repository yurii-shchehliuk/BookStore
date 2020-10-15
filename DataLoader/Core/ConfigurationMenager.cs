using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;
using Microsoft.Win32;
using OPT_Faktury.Core;
using OPT_Faktury.Data;

namespace OPT_Faktury.Core
{
    public class ConfigurationMenager
    {
        #region properties
        private static XmlSerializer SerializerKonfig { get { return new XmlSerializer(typeof(Data.Configuration)); } }
        private static string DirPath { get { return Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location); } }
        private static string ConfigurationPath { get { return Path.Combine(DirPath, "Configuration.xml"); } }

        #endregion

        public void SaveConfiguration(Configuration konfiguracja)
        {
            using (StreamWriter writer = new StreamWriter(ConfigurationPath))
            {
                SerializerKonfig.Serialize(writer, konfiguracja);
            }
            // zapis hasla i entropi do rejestru
            //try
            //{

            //    byte[] _entropy = new byte[20];

            //    RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Jerzy\BookStore\Configuration", true);
            //    if (key == null)
            //    {
            //        key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Jerzy\BookStore\Configuration");
            //    }

            //    byte[] _password = null;

            //    if (konfiguracja.Connection.Password == null)
            //        _password = SecureManager.Protect(Encoding.ASCII.GetBytes(string.Empty), _entropy);
            //    else
            //        _password = SecureManager.Protect(Encoding.ASCII.GetBytes(konfiguracja.Connection.Password), _entropy);

            //    key.SetValue("Entropy", _entropy);
            //    key.SetValue("Password", _password);
            //    key.Close();

            //}
            //catch (Exception ex)
            //{
            //    throw new Exception("Błąd podczas zapisu konfiguracji ");
            //}
        }
        public static Configuration ReadConfiguration()
        {
            if (!File.Exists(ConfigurationPath))
                throw new Exception("Can't find configuration file!");
            using (StreamReader reader = new StreamReader(ConfigurationPath))
            {
                var konfiguracja = SerializerKonfig.Deserialize(reader) as Configuration;
                //opening the subkey  
                //RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Jerzy\BookStore\Configuration");

                //if it does exist, retrieve the stored values
                //if (key != null)
                //{
                //    try
                //    {
                //        byte[] _entropy = (byte[])(key.GetValue("Entropy"));
                //        byte[] _password = (byte[])(key.GetValue("Password"));
                //        var x = SecureManager.Unprotect(_password, _entropy);
                //        konfiguracja.Connection.Password = Encoding.ASCII.GetString(SecureManager.Unprotect(_password, _entropy));
                //    }
                //    catch (Exception ex)
                //    {
                //        throw new Exception("Błąd odczytu konfiguracji");
                //    }
                //    key.Close();
                //}
                return konfiguracja;
            }
        }
    }
}
