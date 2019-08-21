using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace BasicChat
{
    public static class Settings
    {
        private static readonly bool _isSecureStorageSupported;

        static Settings()
        {
            try
            {
                var rslt = Preferences.Get("sss", -1);
                if (rslt == -1)
                {
                    SecureStorage.SetAsync("supported", "true").RunSynchronously();
                    Preferences.Set("sss", 1);
                    _isSecureStorageSupported = true;
                }
                else if (rslt == 1)
                {
                    _isSecureStorageSupported = true;
                }
                else
                {
                    _isSecureStorageSupported = false;
                }


            }
            catch (Exception ex)
            {
                Preferences.Set("sss", 0);
                _isSecureStorageSupported = false;
            }
        }

        private static readonly string _username = "username";
        public static string Username {
            get => _isSecureStorageSupported ?
                SecureStorage.GetAsync(_username).Result :
                Preferences.Get(_username, string.Empty);
            set {
                if (_isSecureStorageSupported) SecureStorage.SetAsync(_username, value);
                else Preferences.Set(_username, value);
            }
        }

        private static readonly string _password = "password";
        public static string Password {
            get => _isSecureStorageSupported ?
                SecureStorage.GetAsync(_password).Result :
                Preferences.Get(_password, string.Empty);
            set {
                if (_isSecureStorageSupported) SecureStorage.SetAsync(_password, value);
                else Preferences.Set(_password, value);
            }
        }

        private static readonly string _isUserLoggedIn = "isuserloggedin";
        public static bool IsUserLoggedIn {
            get {
                if (_isSecureStorageSupported)
                {
                    var data = SecureStorage.GetAsync(_isUserLoggedIn).Result;
                    if (data is null || string.IsNullOrEmpty(data)) return false;
                    return bool.TryParse(data.ToString(), out bool setValue) && setValue;
                }
                else
                {
                    return Preferences.Get(_isUserLoggedIn, false);
                }
            }
            set {
                var sValue = value ? bool.TrueString : bool.FalseString;
                if (_isSecureStorageSupported) SecureStorage.SetAsync(_isUserLoggedIn, sValue);
                else Preferences.Set(_isUserLoggedIn, value);
            }
        }

        private static readonly string _userId = "userId";
        public static int UserId {
            get => _isSecureStorageSupported ?
                int.Parse(SecureStorage.GetAsync(_userId).Result) :
                Preferences.Get(_userId, 0);
            set {
                if (_isSecureStorageSupported) SecureStorage.SetAsync(_userId, value.ToString());
                else Preferences.Set(_userId, value);
            }
        }

    }
}
