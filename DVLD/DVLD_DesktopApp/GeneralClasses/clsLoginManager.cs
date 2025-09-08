﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_DesktopApp.GeneralClasses
{
    public class clsLoginManager
    {
        private const string KeyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD";
        private const string SubKeyPath = @"SOFTWARE\DVLD"; // for opening/deleting
        private const string UserValueName = "LoggedInUser";
        private const string PasswordValueName = "Password";

        public static bool SaveCredentials(string username, string password)
        {
            try
            {
                // Save username
                Registry.SetValue(KeyPath, UserValueName, username, RegistryValueKind.String);

                // Save password
                Registry.SetValue(KeyPath, PasswordValueName, password, RegistryValueKind.String);
                return true;
            }
            catch (Exception)
            {
                return false;
                
            }
        }

        public static bool LoadCredentials(ref string username, ref string password)
        {
            try
            {
                using (RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Default))
                {
                    using (RegistryKey key = baseKey.OpenSubKey(SubKeyPath))
                    {
                        if (key != null)
                        {
                            string u = key.GetValue(UserValueName) as string;
                            string p = key.GetValue(PasswordValueName) as string;

                            if (!string.IsNullOrEmpty(u) && !string.IsNullOrEmpty(p))
                            {
                                username = u;
                                password = p;
                                return true; // credentials found
                            }
                        }
                    }
                }
            }
            catch
            {
                // Ignore errors here, return false
            }

            return false; // credentials not found
        }

        public static bool ClearCredentials()
        {
            try
            {
                using (RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Default))
                {
                    using (RegistryKey key = baseKey.OpenSubKey(SubKeyPath, writable: true))
                    {
                        if (key != null)
                        {
                            if (key.GetValue(UserValueName) != null)
                                key.DeleteValue(UserValueName);

                            if (key.GetValue(PasswordValueName) != null)
                                key.DeleteValue(PasswordValueName);

                            return true;
                        }
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {

            }
            catch (Exception)
            {
            }
            return false;
        }
    }
}
