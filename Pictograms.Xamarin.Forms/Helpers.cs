using System;

namespace Xamarin.Forms.Helpers
{
    internal class Common
    {
        internal static double GetNamedSize(NamedSize namedSize, Type targetElementType = null)
        {
            if (targetElementType == null)
                targetElementType = typeof(Label);

            if (Device.RuntimePlatform == Device.iOS)
                return Device.GetNamedSize(namedSize, targetElementType) * 0.85;
            else
                return Device.GetNamedSize(namedSize, targetElementType);
        }

        public static double GetNamedSize(NamedSize namedSize, Element targetElement)
        {
            if (targetElement == null)
                targetElement = new Label();
            return GetNamedSize(namedSize, targetElement.GetType());
        }
    }
}