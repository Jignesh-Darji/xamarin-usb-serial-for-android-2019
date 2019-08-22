/* Copyright 2019 Jigneshdarji.com & Tyler Technologies Inc.
 *
 * This library is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 2.1 of the License, or (at your option) any later version.
 *
 * This library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public
 * License along with this library; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301,
 * USA.
 *
 * Project home page: https://github.com/Jignesh-Darji/xamarin-usb-serial-for-android-2019
 * This Project is a modified version of: https://github.com/anotherlab/xamarin-usb-serial-for-android
 * Portions of this library are based on usb-serial-for-android (https://github.com/mik3y/usb-serial-for-android).
 * Portions of this library are based on Xamarin USB Serial for Android (https://bitbucket.org/lusovu/xamarinusbserial).
 */

using Android.OS;
using Java.Interop;
using Hoho.Android.UsbSerial.Driver;

namespace Hoho.Android.UsbSerial.Extensions
{
    public sealed class UsbSerialPortInfo : Java.Lang.Object, IParcelable
    {
        static readonly IParcelableCreator creator = new ParcelableCreator();

        [ExportField("CREATOR")]
        public static IParcelableCreator GetCreator()
        {
            return creator;
        }

        public UsbSerialPortInfo()
        {
        }

        public UsbSerialPortInfo(UsbSerialPort port)
        {
            var device = port.Driver.Device;
            VendorId = device.VendorId;
            DeviceId = device.DeviceId;
            PortNumber = port.PortNumber;
        }

        private UsbSerialPortInfo(Parcel parcel)
        {
            VendorId = parcel.ReadInt();
            DeviceId = parcel.ReadInt();
            PortNumber = parcel.ReadInt();
        }

        public int VendorId { get; set; }

        public int DeviceId { get; set; }

        public int PortNumber { get; set; }

        #region IParcelable implementation

        public int DescribeContents()
        {
            return 0;
        }

        public void WriteToParcel(Parcel dest, ParcelableWriteFlags flags)
        {
            dest.WriteInt(VendorId);
            dest.WriteInt(DeviceId);
            dest.WriteInt(PortNumber);
        }

        #endregion

        #region ParcelableCreator implementation

        public sealed class ParcelableCreator : Java.Lang.Object, IParcelableCreator
        {
            #region IParcelableCreator implementation

            public Java.Lang.Object CreateFromParcel(Parcel parcel)
            {
                return new UsbSerialPortInfo(parcel);
            }

            public Java.Lang.Object[] NewArray(int size)
            {
                return new UsbSerialPortInfo[size];
            }

            #endregion
        }

        #endregion
    }
}