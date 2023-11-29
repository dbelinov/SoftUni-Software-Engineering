namespace SmartDevice.Tests
{
    using NUnit.Framework;
    using System;
    using System.Text;

    public class Tests
    {
        private Device device;
        
        [SetUp]
        public void Setup()
        {
            device = new Device(128);
        }

        [Test]
        public void Does_ConstructorInitializeAllElements()
        {
            Assert.AreEqual(128, device.MemoryCapacity);
            Assert.AreEqual(128, device.AvailableMemory);
            Assert.AreEqual(0, device.Photos);
            Assert.IsNotNull(device.Applications);
        }

        [Test]
        public void Does_TakePhotoMethod_ReturnTrueWhenEnoughStorage()
        {
            Assert.IsTrue(device.TakePhoto(10));
        }
        
        [Test]
        public void Does_TakePhotoMethod_ReturnFalseWhenNotEnoughStorage()
        {
            Assert.IsFalse(device.TakePhoto(200));
        }
        
        [Test]
        public void Does_TakePhotoMethod_IncreasePhotoCount()
        {
            device.TakePhoto(10);
            Assert.AreEqual(1, device.Photos);
        }
        
        [Test]
        public void Does_TakePhotoMethod_ReduceAvailableMemory()
        {
            device.TakePhoto(100);
            Assert.AreEqual(28, device.AvailableMemory);
        }
        
        [Test]
        public void Does_InstallAppMethod_ReduceAvailableMemory()
        {
            device.InstallApp("Tinder", 100);
            Assert.AreEqual(28, device.AvailableMemory);
        }
        
        [Test]
        public void Does_InstallAppMethod_AddAppToApplicationsList()
        {
            device.InstallApp("Tinder", 100);
            Assert.Contains("Tinder", device.Applications);
        }
        
        [Test]
        public void Does_InstallAppMethod_ReturnCorrectStringWhenSuccessfulDownload()
        {
            string expected = $"Tinder is installed successfully. Run application?";
            Assert.AreEqual(expected, device.InstallApp("Tinder", 100));
        }
        
        [Test]
        public void Does_InstallAppMethod_Throw_WhenUnsuccessfulDownload()
        {
            device.InstallApp("Instagram", 128);
            Assert.Throws<InvalidOperationException>(() => device.InstallApp("Tinder", 10));
        }
        
        [Test]
        public void Does_FormatDeviceMethod_DeleteAllPhotos()
        {
            device.TakePhoto(10);
            device.TakePhoto(10);
            device.FormatDevice();
            Assert.AreEqual(0, device.Photos);
        }
        
        [Test]
        public void Does_FormatDeviceMethod_DeleteAllApps()
        {
            device.InstallApp("Tinder", 10);
            device.InstallApp("Instagram", 20);
            device.FormatDevice();
            Assert.AreEqual(0, device.Applications.Count);
        }
        
        [Test]
        public void Does_FormatDeviceMethod_ResetAvailableMemory()
        {
            device.InstallApp("Tinder", 10);
            device.InstallApp("Instagram", 20);
            device.FormatDevice();
            Assert.AreEqual(device.MemoryCapacity, device.AvailableMemory);
        }
        
        [Test]
        public void Does_GetDeviceStatusMethod_ReturnCorrectString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Memory Capacity: 128 MB, Available Memory: 128 MB");
            sb.AppendLine($"Photos Count: 0");
            sb.AppendLine($"Applications Installed: ");
            
            Assert.AreEqual(sb.ToString().Trim(), device.GetDeviceStatus());
        }
    }
}