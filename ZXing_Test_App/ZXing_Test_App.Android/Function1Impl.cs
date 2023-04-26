using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Kotlin.Jvm.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZXing_Test_App.Droid
{
    /**
    * Snippet from: 
    * https://stackoverflow.com/questions/64013415/pass-lambda-function-to-c-sharp-generated-code-of-kotlin-in-xamarin-android-bind
    */
    class Function1Impl<T> : Java.Lang.Object, IFunction1 where T : Java.Lang.Object
    {
        private readonly Action<T> OnInvoked;

        public Function1Impl(Action<T> onInvoked)
        {
            this.OnInvoked = onInvoked;
        }

        public Java.Lang.Object Invoke(Java.Lang.Object objParameter)
        {
            try
            {
                T parameter = (T)objParameter;
                OnInvoked?.Invoke(parameter);
                return null;
            }
            catch (Exception ex)
            {
                // Exception handling, if needed
            }

            return null;
        }
    }
}