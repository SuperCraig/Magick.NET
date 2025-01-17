﻿// Copyright 2013-2019 Dirk Lemstra <https://github.com/dlemstra/Magick.NET/>
//
// Licensed under the ImageMagick License (the "License"); you may not use this file except in
// compliance with the License. You may obtain a copy of the License at
//
//   https://www.imagemagick.org/script/license.php
//
// Unless required by applicable law or agreed to in writing, software distributed under the
// License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
// either express or implied. See the License for the specific language governing permissions
// and limitations under the License.

using System;
using ImageMagick;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Magick.NET.Tests
{
    public partial class ExifValueTests
    {
        [TestClass]
        public class TheValueProperty
        {
            [TestMethod]
            public void ShouldThrowExceptionWhenValueIsInvalidDataType1()
            {
                var profile = new ExifProfile();
                profile.SetValue(ExifTag.Software, "Magick.NET");

                var value = profile.GetValue(ExifTag.Software);

                var exception = ExceptionAssert.Throws<InvalidOperationException>(() =>
                {
                    value.Value = 15;
                });

                Assert.AreEqual("The type of the value should be String.", exception.Message);
            }

            [TestMethod]
            public void ShouldThrowExceptionWhenValueIsInvalidDataType2()
            {
                var profile = new ExifProfile();
                profile.SetValue(ExifTag.ShutterSpeedValue, new SignedRational(75.55));

                var value = profile.GetValue(ExifTag.ShutterSpeedValue);

                var exception = ExceptionAssert.Throws<InvalidOperationException>(() =>
                {
                    value.Value = 75;
                });

                Assert.AreEqual("The type of the value should be SignedRational.", exception.Message);
            }

            [TestMethod]
            public void ShouldThrowExceptionWhenValueIsInvalidDataType3()
            {
                var profile = new ExifProfile();
                profile.SetValue(ExifTag.XResolution, new Rational(150.0));

                var value = profile.GetValue(ExifTag.XResolution);
                Assert.IsNotNull(value);
                Assert.AreEqual("150", value.ToString());

                var exception = ExceptionAssert.Throws<InvalidOperationException>(() =>
                {
                    value.Value = "Magick.NET";
                });

                Assert.AreEqual("The type of the value should be Rational.", exception.Message);
            }
        }
    }
}
