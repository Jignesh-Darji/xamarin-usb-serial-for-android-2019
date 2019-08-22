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
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.Hardware.Usb;

using Hoho.Android.UsbSerial.Driver;

namespace Hoho.Android.UsbSerial.Extensions
{
    public static partial class AsyncExtensions
    {
        public static Task<IList<IUsbSerialDriver>> FindAllDriversAsync(this UsbSerialProber prober, UsbManager manager)
        {
            var tcs = new TaskCompletionSource<IList<IUsbSerialDriver>>();

            Task.Run(() =>
            {
                tcs.TrySetResult(prober.FindAllDrivers(manager));
            });
            return tcs.Task;
        }
    }
}